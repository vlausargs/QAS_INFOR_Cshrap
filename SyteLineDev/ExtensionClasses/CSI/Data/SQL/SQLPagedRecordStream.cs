using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using System;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class SQLPagedRecordStream : IRecordStream
    {
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadRequest templateLoadRequest;
        readonly ISortOrder sortOrder;
        readonly int pageSize;
        readonly SQLPagedRecordStreamBookmarkID bookmarkID;
        readonly LoadType loadType;
        readonly bool persistBookmark;
        readonly IBookmarkFactory bookmarkFactory;

        //internal state
        IBookmark currentBookmark;
        int currentIndex;
        ICollectionLoadResponse currentLoad;
        IApplicationDB appDB;
        public SQLPagedRecordStream(
            IApplicationDB appDB,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadRequest templateLoadRequest,
            ISortOrder sortOrder,
            IBookmarkFactory bookmarkFactory,
            SQLPagedRecordStreamBookmarkID bookmarkID,
            int pageSize,
            LoadType loadType = LoadType.First,
            bool persistBookmark = true)
        {
            this.appDB = appDB;
            this.queryLanguage = queryLanguage;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.templateLoadRequest = templateLoadRequest;
            this.sortOrder = sortOrder;
            this.pageSize = pageSize;
            this.bookmarkID = bookmarkID;
            this.persistBookmark = persistBookmark;
            this.loadType = loadType;
            this.bookmarkFactory = bookmarkFactory;
        }

        string cacheKey(SQLPagedRecordStreamBookmarkID id) => Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), id);

        public bool EOF { get; private set; } = false;
        public IRecordReadOnly Current { get; private set; }
        public bool Read()
        {
            if (EOF)
                //this is not the first call, and we've already hit the end of the record during prior calls
                return false;

            //make sure there's at least one record
            if (currentLoad == null || currentIndex == currentLoad.Items.Count - 1)
            {
                if (currentLoad == null) //this is the very first load
                    if (loadType == LoadType.First)
                        ClearBookmark();
                    else
                        //check to see if there's a bookmark out there already
                        RestoreBookmark();
                else
                    //we had some records but we've processed them all, so we need to update the bookmark and get another page worth
                    this.currentBookmark = bookmarkFactory.Create(Current, sortOrder);

                //perform the load
                performLoad();
                if (currentLoad.Items.Count == 0)
                {
                    //we didn't get any more records - Done
                    EOF = true;
                    Current = null;
                    return false;
                }
                currentIndex = -1;
            }

            //we know there's at least one record, return it
            Current = currentLoad.Items[++currentIndex];
            return true;
        }

        void performLoad()
        {
            var newWhereClause = this.templateLoadRequest.WhereClause;

            if (currentBookmark != null)
                //if a bookmark is in play, make sure we use it
                newWhereClause = queryLanguage.AppendBookmark(newWhereClause, currentBookmark);

            IParameterizedCommand orderByClause = queryLanguage.OrderByClause(this.sortOrder);

            var collectionLoadRequest = collectionLoadRequestFactory.SQLLoad(
                columnExpressionByColumnName: this.templateLoadRequest.ColumnExpressionByColumnName,
                tableName: this.templateLoadRequest.TableName,                
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: this.templateLoadRequest.FromClause,
                whereClause: newWhereClause,
                orderByClause: orderByClause,
                maximumRows: this.pageSize);

            currentLoad = appDB.Load(collectionLoadRequest);
        }

        //bookmark persistance
        void RestoreBookmark()
        {
            if (persistBookmark)
                mgSessionVariableBasedCache.TryGet<IBookmark>(cacheKey(bookmarkID), out currentBookmark); //bookmark will be null if there's a miss
        }

        void SaveBookmark()
        {
            if (persistBookmark)
            {
                mgSessionVariableBasedCache.Insert(cacheKey(bookmarkID), (ICachable)currentBookmark);
            }
        }

        void ClearBookmark()
        {
            if (persistBookmark)
                mgSessionVariableBasedCache.Remove(cacheKey(bookmarkID)); //cleanup
        }

        public void Dispose()
        {
            if (!persistBookmark)
                return;

            if (EOF || Current == null)
            {
                ClearBookmark();
                return;
            }

            //we had some records but we've processed them all, so we need to update the bookmark and get another page worth
            this.currentBookmark = bookmarkFactory.Create(Current, sortOrder);
            SaveBookmark();
        }
    }    
}
