using CSI.Data.CRUD;
using CSI.MG;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.CRUD.Admin
{
    public interface IObjCustomAssemblyCRUD
    {
        bool Exists(string assemblyName, int developmentFlag);
        void Insert(string assemblyName, string language, string references, string fileName, string accessAs, int assemblyType);
        void Update(string assemblyName, string language, string references, int assemblyType);
        string GetFullName(string assemblyName);
    }
    public class ObjCustomAssemblyCRUD : IObjCustomAssemblyCRUD
    {
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly IApplicationDB appDB;
        public ObjCustomAssemblyCRUD(IApplicationDB appDB,
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
        public bool Exists(string assemblyName, int developmentFlag)
        {
            var assemblySourceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"AssemblyName","AssemblyName"},
            },
            loadForChange: false, 
            lockingType: LockingType.None,
            tableName: "ObjCustomAssembly",
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("AssemblyName = {0} AND DevelopmentFlag = {1}", assemblyName, developmentFlag),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var assemblySourceLoadResponse = this.appDB.Load(assemblySourceLoadRequest);
            return (assemblySourceLoadResponse != null && assemblySourceLoadResponse.Items.Count == 1);
        }
        public void Update(string assemblyName, string language, string references, int assemblyType)
        {
            var assemblyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"AssemblyName","AssemblyName"},
                {"Language","[Language]"},
                {"References","[References]"},
                {"AssemblyType","AssemblyType"},
            },
            tableName: "ObjCustomAssembly", 
            loadForChange: true,
            lockingType: LockingType.UPDLock,
            fromClause: collectionLoadRequestFactory.Clause(""),
            whereClause: collectionLoadRequestFactory.Clause("assemblyName = {0} AND DevelopmentFlag = 0", assemblyName),
            orderByClause: collectionLoadRequestFactory.Clause(""));
            var assemblyLoadResponse = this.appDB.Load(assemblyLoadRequest);
            foreach (var item in assemblyLoadResponse.Items)
            {
                item.SetValue<string>("Language", language);
                item.SetValue<string>("References", references);
                item.SetValue<string>("AssemblyType", assemblyType);
            };

            var arinvdRequestUpdate = collectionUpdateRequestFactory.SQLUpdate(tableName: "ObjCustomAssembly",
                items: assemblyLoadResponse.Items);

            this.appDB.Update(arinvdRequestUpdate);
        }

        public void Insert(string assemblyName, string language, string references, string fileName, string accessAs, int assemblyType)
        {
            var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                { "AssemblyName", assemblyName},
                { "FileName", fileName},
                { "Language", language},
                { "References", references},
                { "AccessAs", accessAs},
                { "DevelopmentFlag", 0},
                { "AssemblyType", assemblyType},
                { "FullName", $"{assemblyName}, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null" },
                { "AssemblyImage", (byte)0},
            });

            var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);

            var nonTable1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "ObjCustomAssembly",
                items: nonTable1LoadResponse.Items);

            this.appDB.Insert(nonTable1InsertRequest);
        }

        public string GetFullName(string assemblyName)
        {
            var assemblySourceLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
            {
                {"FullName","FullName"},
            },
               loadForChange: false, 
               lockingType: LockingType.None,
               tableName: "ObjCustomAssembly",
               fromClause: collectionLoadRequestFactory.Clause(""),
               whereClause: collectionLoadRequestFactory.Clause("AssemblyName = {0} AND DevelopmentFlag = 0", assemblyName),
               orderByClause: collectionLoadRequestFactory.Clause(""));
            var assemblySourceLoadResponse = this.appDB.Load(assemblySourceLoadRequest);
            if (assemblySourceLoadResponse.Items.Count > 0)
                return assemblySourceLoadResponse.Items[0].GetValue<string>(0);
            return "";
        }
    }
}
