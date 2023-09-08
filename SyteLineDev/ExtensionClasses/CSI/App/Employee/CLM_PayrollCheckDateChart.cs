//PROJECT NAME: Employee
//CLASS NAME: CLM_PayrollCheckDateChart.cs

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

namespace CSI.Employee
{
    public class CLM_PayrollCheckDateChart : ICLM_PayrollCheckDateChart
    {

        readonly ICLM_PayrollCheckDateListing iCLM_PayrollCheckDateListing;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_PayrollCheckDateChartCRUD iCLM_PayrollCheckDateChartCRUD;

        public CLM_PayrollCheckDateChart(ICLM_PayrollCheckDateListing iCLM_PayrollCheckDateListing,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_PayrollCheckDateChartCRUD iCLM_PayrollCheckDateChartCRUD)
        {
            this.iCLM_PayrollCheckDateListing = iCLM_PayrollCheckDateListing;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_PayrollCheckDateChartCRUD = iCLM_PayrollCheckDateChartCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_PayrollCheckDateChartSp(
            string EmpNum)
        {

            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iCLM_PayrollCheckDateChartCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_PayrollCheckDateChartCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("CLM_PayrollCheckDateChartSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_PayrollCheckDateChartCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iCLM_PayrollCheckDateChartCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_PayrollCheckDateChartCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_PayrollCheckDateChartCRUD.AltExtGen_CLM_PayrollCheckDateChartSp(ALTGEN_SpName,
                        EmpNum);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_PayrollCheckDateChartCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iCLM_PayrollCheckDateChartCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_PayrollCheckDateChartSp") != null)
            {
                var EXTGEN = this.iCLM_PayrollCheckDateChartCRUD.AltExtGen_CLM_PayrollCheckDateChartSp("dbo.EXTGEN_CLM_PayrollCheckDateChartSp",
                    EmpNum);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            if (sQLUtil.SQLEqual(stringUtil.IsNull(
                    EmpNum,
                    ""), "") == true)
            {
                return (Data, Severity);

            }
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @results_tbl TABLE (
				    CheckDate  DATE            ,
				    CheckNum   INT             ,
				    RowPointer UNIQUEIDENTIFIER,
				    PerStart   DATE            ,
				    PerEnd     DATE            ,
				    GrossPay   DECIMAL (8, 2)  ,
				    NetPay     DECIMAL (8, 2)  ,
				    TotalTaxes DECIMAL (8, 2)  ,
				    TotalDed   DECIMAL (8, 2)  ,
				    DirectDep  DECIMAL (8, 2)  );
				SELECT * into #tv_results_tbl from @results_tbl");
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_results_tbl ADD tempTableId INT IDENTITY");
            /*Needs to load at least one column from the table: #tv_results_tbl for delete, Loads the record based on its where and from clause, then deletes it by record.*/
            var tv_results_tblLoadResponse = this.iCLM_PayrollCheckDateChartCRUD.Tv_Results_TblSelect();
            this.iCLM_PayrollCheckDateChartCRUD.Tv_Results_TblDelete(tv_results_tblLoadResponse);
            this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_results_tbl DROP COLUMN tempTableId");
            //Please Generate the bounce for this stored procedure:CLM_PayrollCheckDateListingSp
            var tv_results_tbl1ExecResult = this.iCLM_PayrollCheckDateListing.CLM_PayrollCheckDateListingSp(EmpNum: EmpNum);
            this.iCLM_PayrollCheckDateChartCRUD.Tv_Results_Tbl1Insert(tv_results_tbl1ExecResult.Data);
            var tv_results_tbl2LoadResponse = this.iCLM_PayrollCheckDateChartCRUD.Tv_Results_Tbl2Select();
            Data = tv_results_tbl2LoadResponse;

            return (Data, Severity = 0);

        }

    }
}
