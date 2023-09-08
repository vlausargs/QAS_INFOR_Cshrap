//PROJECT NAME: Logistics
//CLASS NAME: CLM_LastStagePipeline.cs

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
    public class CLM_LastStagePipeline : ICLM_LastStagePipeline
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_LastStagePipelineCRUD iCLM_LastStagePipelineCRUD;

        public CLM_LastStagePipeline(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_LastStagePipelineCRUD iCLM_LastStagePipelineCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_LastStagePipelineCRUD = iCLM_LastStagePipelineCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_LastStagePipelineSp()
        {

            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            DecimalType _LastStagePipeline = DBNull.Value;
            decimal? LastStagePipeline = null;
            int? MaxChanceToClose = null;
            string LastOppStage = null;
            if (this.iCLM_LastStagePipelineCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_LastStagePipelineCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_LastStagePipelineSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_LastStagePipelineCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iCLM_LastStagePipelineCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_LastStagePipelineCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_LastStagePipelineCRUD.AltExtGen_CLM_LastStagePipelineSp(ALTGEN_SpName);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_LastStagePipelineCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iCLM_LastStagePipelineCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_LastStagePipelineSp") != null)
            {
                var EXTGEN = this.iCLM_LastStagePipelineCRUD.AltExtGen_CLM_LastStagePipelineSp("dbo.EXTGEN_CLM_LastStagePipelineSp");
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            (MaxChanceToClose, rowCount) = this.iCLM_LastStagePipelineCRUD.Opportunity_StageasosLoad(MaxChanceToClose);
            MaxChanceToClose = convertToUtil.ToInt32(convertToUtil.ToDecimal(stringUtil.IsNull(
                MaxChanceToClose,
                0)));
            (LastOppStage, rowCount) = this.iCLM_LastStagePipelineCRUD.Opportunity_Stageasos1Load(MaxChanceToClose, LastOppStage);
            (LastStagePipeline, rowCount) = this.iCLM_LastStagePipelineCRUD.OpportunityasoppLoad(LastOppStage, MaxChanceToClose, LastStagePipeline);
            var nonTableLoadResponse = this.iCLM_LastStagePipelineCRUD.NontableSelect(LastStagePipeline);
            Data = nonTableLoadResponse;
            return (Data, Severity);

        }

    }
}
