using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;
using System;

namespace CSI.Data.SQL
{
    public class SQLPagedRecordBunch : IRecordBunch
    {
        readonly IApplicationDB applicationDB;
        readonly IQueryLanguage queryLanguage;
        readonly IGetVariable getVariable;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly ICache mgSessionVariableBasedCache;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadRequest templateLoadRequest;
        readonly ISortOrder sortOrder;
        readonly IBookmarkFactory bookmarkFactory;
        readonly SQLPagedRecordBunchBookmarkID bookmarkID;
        readonly LoadType loadType;
        readonly BunchType bunchType;
        readonly int pageSize;
        readonly bool persistBookmark;

        //internal state
        IBookmark currentBookmark;

        public SQLPagedRecordBunch(IApplicationDB appDB,
            IQueryLanguage queryLanguage,
            IGetVariable getVariable,
            IDefineProcessVariable defineProcessVariable,
            ICache mgSessionVariableBasedCache,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadRequest templateLoadRequest,
            ISortOrder sortOrder,
            IBookmarkFactory bookmarkFactory,
            SQLPagedRecordBunchBookmarkID bookmarkID,
            BunchType bunchType = BunchType.Load,
            LoadType loadType = LoadType.First,
            int pageSize = 200,
            bool persistBookmark = true)
        {
            this.applicationDB = appDB;
            this.queryLanguage = queryLanguage;
            this.getVariable = getVariable;
            this.defineProcessVariable = defineProcessVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.templateLoadRequest = templateLoadRequest;
            this.sortOrder = sortOrder;
            this.bookmarkFactory = bookmarkFactory;
            this.bookmarkID = bookmarkID;
            this.pageSize = pageSize;
            this.bunchType = bunchType;
            this.persistBookmark = persistBookmark;
            this.loadType = loadType;
            if (this.pageSize == 0)
                this.pageSize = int.MaxValue - 1;

            if (this.pageSize == -1)
                this.pageSize = 200;
        }

        public ICollectionLoadResponse CurrentPage { get; private set; }

        public bool EOF { get; private set; }

        public bool ReadPage()
        {
            if (EOF)
                return true;

            // CurrentPage is null, it indicates a new request from client.
            if (CurrentPage == null)
            {
                if (loadType == LoadType.Next)
                    RestoreBookmark();
                else
                    ClearBookmark();
            }

            performLoad();

            // Empty page.
            if (CurrentPage == null || CurrentPage.Items.Count == 0)
            {
                //we didn't get any more records - Done
                ClearBookmark();
                EOF = true;
                return false;
            }

            // No more request from client then.
            if (bunchType == BunchType.Load && CurrentPage.Items.Count <= pageSize)
            {
                ClearBookmark();
                return true;
            }

            int bookmarkRowIndex;
            // For MG result load and we did have one more row.
            if (bunchType == BunchType.Load)
                bookmarkRowIndex = CurrentPage.Items.Count - 2;
            else
                bookmarkRowIndex = CurrentPage.Items.Count - 1;

            IRecord bookmarkRecord = CurrentPage.Items[bookmarkRowIndex];
            currentBookmark = bookmarkFactory.Create(bookmarkRecord, sortOrder);

            return true;
        }

        string cacheKey(SQLPagedRecordBunchBookmarkID id) => Enum.GetName(typeof(SQLPagedRecordBunchBookmarkID), id);

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
                loadForChange: this.templateLoadRequest.LoadForChange,
                lockingType: this.templateLoadRequest.LockingType,
                fromClause: this.templateLoadRequest.FromClause,
                whereClause: newWhereClause,
                orderByClause: orderByClause,
                maximumRows: bunchType == BunchType.Load? pageSize + 1 : pageSize);

            CurrentPage = applicationDB.Load(collectionLoadRequest);
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
                mgSessionVariableBasedCache.Insert(cacheKey(bookmarkID), (ICachable)currentBookmark);
        }

        void ClearBookmark()
        {
            if (persistBookmark)
                mgSessionVariableBasedCache.Remove(cacheKey(bookmarkID)); //cleanup
        }

        void SyncToMGBookmark()
        {
            string mgBookmarkKey = Enum.GetName(typeof(MGBookmark), MGBookmark.Bookmark);
            var variable = getVariable.GetVariableSp(cacheKey(bookmarkID), "", 0, "", "");
            
            if (!string.IsNullOrEmpty(variable.VariableValue))
                defineProcessVariable.DefineProcessVariableSp(mgBookmarkKey, variable.VariableValue, variable.Infobar);
        }

        public void Dispose()
        {
            if (!EOF && persistBookmark && currentBookmark != null)
            {
                SaveBookmark();
                SyncToMGBookmark();
            }
        }
    }
}
