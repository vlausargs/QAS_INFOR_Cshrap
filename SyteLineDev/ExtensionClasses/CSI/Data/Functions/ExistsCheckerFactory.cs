using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Functions
{
    public class ExistsCheckerFactory
    {
        public IExistsChecker Create(IApplicationDB appDB, IQueryLanguage queryLanguage)
        {
            ICollectionLoadRequestFactory collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var iExistsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
            return iExistsChecker;
        }
    }
}
