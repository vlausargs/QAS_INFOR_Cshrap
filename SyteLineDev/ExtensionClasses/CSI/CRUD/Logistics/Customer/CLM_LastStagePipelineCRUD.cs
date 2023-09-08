//PROJECT NAME: Logistics
//CLASS NAME: CLM_LastStagePipelineCRUD.cs

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
    public class CLM_LastStagePipelineCRUD : ICLM_LastStagePipelineCRUD
    {
        readonly IApplicationDB appDB;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly IExistsChecker existsChecker;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;

        public CLM_LastStagePipelineCRUD(IApplicationDB appDB,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            IExistsChecker existsChecker,
            IVariableUtil variableUtil,
            IStringUtil stringUtil)
        {
            this.appDB = appDB;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.existsChecker = existsChecker;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
        }

        public bool Optional_ModuleForExists()
        {
            return existsChecker.Exists(tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_LastStagePipelineSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"));
        }

        public ICollectionLoadResponse Optional_Module1Select()
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
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('CLM_LastStagePipelineSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(optional_module1LoadRequest);
        }

        public void Optional_Module1Insert(ICollectionLoadResponse optional_module1LoadResponse)
        {
            var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                items: optional_module1LoadResponse.Items);

            this.appDB.Insert(optional_module1InsertRequest);
        }

        public bool Tv_ALTGENForExists()
        {
            return existsChecker.Exists(tableName: "#tv_ALTGEN",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""));
        }

        public (string, int? rowCount) Tv_ALTGEN1Load(string ALTGEN_SpName)
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

        public ICollectionLoadResponse Tv_ALTGEN2Select(string ALTGEN_SpName)
        {
            var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                {
                    {"[SpName]","[SpName]"},
                },
                tableName: "#tv_ALTGEN", 
                loadForChange: true, 
                lockingType: LockingType.None,
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            return this.appDB.Load(tv_ALTGEN2LoadRequest);
        }

        public void Tv_ALTGEN2Delete(ICollectionLoadResponse tv_ALTGEN2LoadResponse)
        {
            var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                items: tv_ALTGEN2LoadResponse.Items);
            this.appDB.Delete(tv_ALTGEN2DeleteRequest);
        }

        public (int?, int? rowCount) Opportunity_StageasosLoad(int? MaxChanceToClose)
        {
            ByteType _MaxChanceToClose = DBNull.Value;

            var opportunity_stageASosLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_MaxChanceToClose,"MAX(ISNULL(os.chance_to_close, 0))"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "opportunity_stage AS os",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var opportunity_stageASosLoadResponse = this.appDB.Load(opportunity_stageASosLoadRequest);
            if (opportunity_stageASosLoadResponse.Items.Count > 0)
            {
                MaxChanceToClose = _MaxChanceToClose;
            }

            int rowCount = opportunity_stageASosLoadResponse.Items.Count;
            return (MaxChanceToClose, rowCount);
        }

        public (string, int? rowCount) Opportunity_Stageasos1Load(int? MaxChanceToClose, string LastOppStage)
        {
            StringType _LastOppStage = DBNull.Value;

            var opportunity_stageASos1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LastOppStage,"ISNULL(os.opp_stage, NULL)"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "opportunity_stage AS os",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("os.chance_to_close = {0}", MaxChanceToClose),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var opportunity_stageASos1LoadResponse = this.appDB.Load(opportunity_stageASos1LoadRequest);
            if (opportunity_stageASos1LoadResponse.Items.Count > 0)
            {
                LastOppStage = _LastOppStage;
            }

            int rowCount = opportunity_stageASos1LoadResponse.Items.Count;
            return (LastOppStage, rowCount);
        }

        public (decimal?, int? rowCount) OpportunityasoppLoad(string LastOppStage, int? MaxChanceToClose, decimal? LastStagePipeline)
        {
            DecimalType _LastStagePipeline = DBNull.Value;

            var opportunityASoppLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LastStagePipeline,$"CONVERT (DECIMAL (22, 2), SUM(ISNULL(opp.est_value, 0) * {variableUtil.GetQuotedValue<int?>(MaxChanceToClose)})) / 100.00"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "opportunity AS opp",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("opp.opp_stage = {0}", LastOppStage),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var opportunityASoppLoadResponse = this.appDB.Load(opportunityASoppLoadRequest);
            if (opportunityASoppLoadResponse.Items.Count > 0)
            {
                LastStagePipeline = _LastStagePipeline;
            }

            int rowCount = opportunityASoppLoadResponse.Items.Count;
            return (LastStagePipeline, rowCount);
        }

        public ICollectionLoadResponse NontableSelect(decimal? LastStagePipeline)
        {
            var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
            {
                    { "DerLastStagePipeline", stringUtil.IsNull(
                        LastStagePipeline,
                        0.00M)},
            });

            return this.appDB.Load(nonTableLoadRequest);
        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_CLM_LastStagePipelineSp(
            string AltExtGenSp)
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

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
