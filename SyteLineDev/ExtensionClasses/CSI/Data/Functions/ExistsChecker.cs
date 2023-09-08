using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.SQL.UDDT;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.Data.Functions
{
    public class ExistsChecker : IExistsChecker
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;

        public ExistsChecker(IApplicationDB appDB, ICollectionLoadRequestFactory collectionLoadRequestFactory, ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
        }

        public bool Exists(string tableName,
                           IParameterizedCommand fromClause,
                           IParameterizedCommand whereClause)
        {
            var existsLoadRequest = collectionLoadRequestFactory.SQLLoad(columns: new List<string> { "1" },
                                                                         loadForChange: false, 
                                                                         lockingType: LockingType.None,
                                                                         maximumRows: 1, //Exists Statements must always have a maximumRows of 1 for optimization: 
                                                                         tableName: tableName,
                                                                         fromClause: fromClause,
                                                                         whereClause: whereClause,
                                                                         orderByClause: collectionLoadRequestFactory.Clause(""));
            var existsLoadResponse = this.appDB.Load(existsLoadRequest);

            return (existsLoadResponse.Items != null && existsLoadResponse.Items.Count == 1);
        }

        public bool Exists(IParameterizedCommand selectStatement)
        {
            if (collectionLoadStatementRequestFactory != null)
            {
                var existsLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(new List<string> { "1" }, selectStatement);
                var existsLoadResponse = this.appDB.Load(existsLoadRequest);
                return (existsLoadResponse.Items != null && existsLoadResponse.Items.Count > 0);
            }
            return false;
        }
    }
}
