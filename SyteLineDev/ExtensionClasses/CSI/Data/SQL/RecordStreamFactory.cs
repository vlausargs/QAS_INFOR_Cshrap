using CSI.Data;
using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class RecordStreamFactory : IRecordStreamFactory
    {
        public IRecordStream Create(IApplicationDB appDB,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadRequest templateLoadRequest,
            ISortOrder sortOrder,
            SQLPagedRecordStreamBookmarkID bookmarkID,
            int pageSize,
            LoadType loadType = LoadType.First,
            bool persistBookmark = true)
        {
            return new SQLPagedRecordStream(appDB, queryLanguage, mgSessionVariableBasedCache,
                collectionLoadRequestFactory, templateLoadRequest, sortOrder, new BookmarkFactory(), bookmarkID, pageSize, loadType, persistBookmark);
        }
    }
}
