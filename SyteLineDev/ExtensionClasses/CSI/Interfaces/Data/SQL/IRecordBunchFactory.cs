using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.SQL
{
    public interface IRecordBunchFactory
    {
        IRecordBunch Create(IApplicationDB appDB,
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
            bool persistBookmark = true);
    }
}
