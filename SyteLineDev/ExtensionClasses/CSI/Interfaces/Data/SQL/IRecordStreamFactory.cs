using CSI.Data.Cache;
using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.SQL
{
    public interface IRecordStreamFactory
    {
        IRecordStream Create(IApplicationDB appDB,
            IQueryLanguage queryLanguage,
            ICache mgSessionVariableBasedCache,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadRequest templateLoadRequest,
            ISortOrder sortOrder,
            SQLPagedRecordStreamBookmarkID bookmarkID,
            int pageSize,
            LoadType loadType = LoadType.First,
            bool persistBookmark = true);
    }
}
