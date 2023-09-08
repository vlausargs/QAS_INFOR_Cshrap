using CSI.Data.CRUD;
using CSI.MG;
using System.Collections.Generic;

namespace CSI.Admin.SiteOnBoarding
{
    public class SchemaLevelCRUD : ISchemaLevelCRUD
    {
        private readonly IApplicationDB appDB;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        public SchemaLevelCRUD(IApplicationDB appDB, ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.appDB = appDB;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
        }
        public ICollectionLoadResponse GetTargetSchemaLevel()
        {
            //throw new NotImplementedException();
            var targetSchemaLevelLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SchemaLevel","SchemaLevel"},
                },
                tableName: "ProductSchemaInfo",
                loadForChange: false,
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(targetSchemaLevelLoadRequest);
        }
    }
}
