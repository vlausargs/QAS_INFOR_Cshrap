using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Admin
{
    public interface IObjCustomAssemblySourceCRUD
    {
        bool Exists(string assemblyName, string fileName);
        void Insert(string assemblyName, string fileName, string sourceCode);
        void Update(string assemblyName, string fileName, string sourceCode);
    }
    public class ObjCustomAssemblySourceCRUD : IObjCustomAssemblySourceCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IApplicationDB appDB;
        public ObjCustomAssemblySourceCRUD(IApplicationDB appDB,
                   ICollectionLoadRequestFactory collectionLoadRequestFactory,
                   ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
                   ICollectionInsertRequestFactory collectionInsertRequestFactory,
                   ICollectionUpdateRequestFactory collectionUpdateRequestFactory)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
        }
        public bool Exists(string assemblyName, string fileName)
        {
            var assemblySourceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"AssemblyName","AssemblyName"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "ObjCustomAssemblySource",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("assemblyName = {0} and fileName = {1} AND DevelopmentFlag = 0", assemblyName, fileName),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var assemblySourceLoadResponse = this.appDB.Load(assemblySourceLoadRequest);
            return (assemblySourceLoadResponse != null && assemblySourceLoadResponse.Items.Count == 1);
        }
        public void Insert(string assemblyName, string fileName, string sourceCode)
        {
            var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                { "AssemblyName", assemblyName},
                { "FileName", fileName},
                { "SourceCode", sourceCode},
                { "DevelopmentFlag", 0},
            });

            var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);

            var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "ObjCustomAssemblySource",
                items: nonTable1LoadResponse.Items);

            this.appDB.Insert(nonTable1InsertRequest);
        }

        public void Update(string assemblyName, string fileName, string sourceCode)
        {
            var assemblyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                { "AssemblyName", "AssemblyName"},
                { "FileName", "FileName"},
                { "SourceCode", "SourceCode"},
            },
               tableName: "ObjCustomAssemblySource",
               loadForChange: true,
               lockingType: LockingType.UPDLock,
               fromClause: collectionLoadRequestFactory.Clause(""),
               whereClause: collectionLoadRequestFactory.Clause("assemblyName = {0} and fileName = {1} AND DevelopmentFlag = 0", assemblyName, fileName),
               orderByClause: collectionLoadRequestFactory.Clause(""));
            var assemblyLoadResponse = this.appDB.Load(assemblyLoadRequest);
            foreach (var item in assemblyLoadResponse.Items)
            {
                item.SetValue<string>("SourceCode", sourceCode);
            };

            var arinvdRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "ObjCustomAssemblySource",
                items: assemblyLoadResponse.Items);

            this.appDB.Update(arinvdRequestUpdate);
        }
    }
}
