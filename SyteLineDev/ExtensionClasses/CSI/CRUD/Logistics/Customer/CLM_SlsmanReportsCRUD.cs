//PROJECT NAME: Logistics
//CLASS NAME: CLM_SlsmanReportsCRUD.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class CLM_SlsmanReportsCRUD : ICLM_SlsmanReportsCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IDerSlsmanName iDerSlsmanName;
        readonly IExistsChecker existsChecker;
        readonly IStringUtil stringUtil;

        public CLM_SlsmanReportsCRUD(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IDerSlsmanName iDerSlsmanName,
            IExistsChecker existsChecker,
            IStringUtil stringUtil)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.iDerSlsmanName = iDerSlsmanName;
            this.existsChecker = existsChecker;
            this.stringUtil = stringUtil;
        }

        public bool CheckOptional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_SlsmanReportsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public ICollectionLoadResponse SelectOptional_Module()
        {
            var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"SpName","CAST (NULL AS NVARCHAR)"},
                    {"u0","[om].[ModuleName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_SlsmanReportsSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);

            foreach (var optional_module1Item in optional_module1LoadResponse.Items)
            {
                optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_SlsmanReportsSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
            };

            return optional_module1LoadResponse;
        }

        public void InsertOptional_Module(ICollectionLoadResponse optional_module1LoadResponse)
        {
            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool CheckTv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string ALTGEN_SpName, int? rowCount) LoadTv_ALTGEN(string ALTGEN_SpName)
        {
            StringType _ALTGEN_SpName = DBNull.Value;

            var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ALTGEN_SpName,"[SpName]"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tv_ALTGEN1LoadResponse = this.appDB.Load(tv_ALTGEN1LoadRequest);
            if (tv_ALTGEN1LoadResponse.Items.Count > 0)
            {
                ALTGEN_SpName = _ALTGEN_SpName;
            }

            int rowCount = tv_ALTGEN1LoadResponse.Items.Count;
            return (ALTGEN_SpName, rowCount);
        }

        public ICollectionLoadResponse SelectTv_ALTGEN(string ALTGEN_SpName)
        {
            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                loadForChange: true,
                lockingType: LockingType.None,
                tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_ALTGEN2LoadRequest);
        }

        public void DeleteTv_ALTGEN(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
        {
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
        }

        public ICollectionLoadResponse SelectSlsman(string UserName)
        {
            var slsmanLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"slsmangr","slsman.slsmangr"},
                    {"slsman","slsman.slsman"},
                    {"DerSlsmanName","CAST (NULL AS NVARCHAR)"},
                    {"username","slsman.username"},
                    {"level","CAST (NULL AS INT)"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "slsman",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("slsman.username = {0}", UserName),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var slsmanLoadResponse = this.appDB.Load(slsmanLoadRequest);

            foreach (var slsmanItem in slsmanLoadResponse.Items)
            {
                slsmanItem.SetValue<string>("slsmangr", slsmanItem.GetValue<string>("slsmangr"));
                slsmanItem.SetValue<string>("slsman", slsmanItem.GetValue<string>("slsman"));
                slsmanItem.SetValue<string>("DerSlsmanName", this.iDerSlsmanName.DerSlsmanNameFn(slsmanItem.GetValue<string>("slsman")));
                slsmanItem.SetValue<string>("username", slsmanItem.GetValue<string>("username"));
                slsmanItem.SetValue<int?>("level", 0);
            };

            return slsmanLoadResponse;
        }

        public void InsertSlsman(ICollectionLoadResponse slsmanLoadResponse)
        {
            var slsmanInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_DirectReports",
                items: slsmanLoadResponse.Items);

            this.appDB.Insert(slsmanInsertRequest);
        }

        public ICollectionLoadResponse SelectSlsman(int? Level)
        {
            var slsman1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"slsmangr","slsman.slsmangr"},
                    {"slsman","slsman.slsman"},
                    {"DerSlsmanName","CAST (NULL AS NVARCHAR)"},
                    {"username","slsman.username"},
                    {"level","CAST (NULL AS INT)"},
                    {"u0","d.level"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "slsman",
                fromClause: collectionLoadRequestFactory.Clause(@" inner join #tv_directreports as d on d.slsman = slsman.slsmangr
					and d.level = {0}", Level),
                whereClause: collectionLoadRequestFactory.Clause("slsman.slsman <> slsman.slsmangr"),
                orderByClause: collectionLoadRequestFactory.Clause(""));

            var slsman1LoadResponse = this.appDB.Load(slsman1LoadRequest);

            foreach (var slsman1Item in slsman1LoadResponse.Items)
            {
                slsman1Item.SetValue<string>("slsmangr", slsman1Item.GetValue<string>("slsmangr"));
                slsman1Item.SetValue<string>("slsman", slsman1Item.GetValue<string>("slsman"));
                slsman1Item.SetValue<string>("DerSlsmanName", this.iDerSlsmanName.DerSlsmanNameFn(slsman1Item.GetValue<string>("slsman")));
                slsman1Item.SetValue<string>("username", slsman1Item.GetValue<string>("username"));
                slsman1Item.SetValue<int?>("level", slsman1Item.GetValue<int?>("u0") + 1);
            };

            return slsman1LoadResponse;
        }

        public ICollectionLoadResponse SelectTv_Directreports(int? DisplayLevel)
        {
            var tv_DirectReportsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"slsman","slsman"},
                    {"DerSlsmanName","DerSlsmanName"},
                    {"username","username"},
                },
                loadForChange: false,
                lockingType: LockingType.None,
                tableName: "#tv_DirectReports",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("level <= {0}", DisplayLevel),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_DirectReportsLoadRequest);
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_SlsmanReportsSp(
            string AltExtGenSp,
            string UserName,
            int? DisplayLevel = 0)
        {
            UsernameType _UserName = UserName;
            IntType _DisplayLevel = DisplayLevel;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayLevel", _DisplayLevel, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                return (resultSet, returnCode);
            }
        }

    }
}
