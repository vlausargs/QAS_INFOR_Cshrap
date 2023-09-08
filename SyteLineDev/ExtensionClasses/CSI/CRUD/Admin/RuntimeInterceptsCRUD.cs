using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Admin
{
    public interface IRuntimeInterceptsCRUD
    {
        ICollectionLoadResponse LoadAll();
    }
    public class RuntimeInterceptsCRUD : IRuntimeInterceptsCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IApplicationDB appDB;
        public RuntimeInterceptsCRUD(IApplicationDB appDB,
                   ICollectionLoadRequestFactory collectionLoadRequestFactory)
        {
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.appDB = appDB;
        }
        public ICollectionLoadResponse LoadAll()
        {
            var loadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                    {"RuntimeIntercept","rti.runtime_intercept_name"},
                    {"AssemblyName","rti.custom_assembly_name"},
                    {"AssemblyFullName","oca.FullName"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "runtime_intercept",
                    fromClause: collectionLoadRequestFactory.Clause(" rti inner join objcustomassembly oca on rti.custom_assembly_name = rti.AssemblyName "),
                    whereClause: collectionLoadRequestFactory.Clause("active = 1"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(loadRequest);
        }
    }
}
