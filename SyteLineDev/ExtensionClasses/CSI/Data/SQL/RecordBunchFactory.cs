using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.MG;
using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.SQL
{
    public class RecordBunchFactory : IRecordBunchFactory
    {
        public IRecordBunch Create(IApplicationDB appDB,
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
            return new SQLPagedRecordBunch(appDB, queryLanguage, getVariable, defineProcessVariable, 
                mgSessionVariableBasedCache, collectionLoadRequestFactory, templateLoadRequest,
                sortOrder, bookmarkFactory, bookmarkID, bunchType, loadType, pageSize, persistBookmark);
        }
    }
}
