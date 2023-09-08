//PROJECT NAME: Logistics
//CLASS NAME: CLM_SlsmanReports.cs

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
    public class CLM_SlsmanReports : ICLM_SlsmanReports
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ICLM_SlsmanReportsCRUD iCLM_SlsmanReportsCRUD;

        public CLM_SlsmanReports(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            ICLM_SlsmanReportsCRUD iCLM_SlsmanReportsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iCLM_SlsmanReportsCRUD = iCLM_SlsmanReportsCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        CLM_SlsmanReportsSp(
            string UserName,
            int? DisplayLevel = 0)
        {

            ICollectionLoadResponse Data = null;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            int? Level = null;
            if (this.iCLM_SlsmanReportsCRUD.CheckOptional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iCLM_SlsmanReportsCRUD.SelectOptional_Module();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iCLM_SlsmanReportsCRUD.InsertOptional_Module(optional_module1LoadResponse);
                while (this.iCLM_SlsmanReportsCRUD.CheckTv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iCLM_SlsmanReportsCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
                    var ALTGEN = this.iCLM_SlsmanReportsCRUD.AltExtGen_CLM_SlsmanReportsSp(ALTGEN_SpName,
                        UserName,
                        DisplayLevel);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iCLM_SlsmanReportsCRUD.SelectTv_ALTGEN(ALTGEN_SpName);
                    this.iCLM_SlsmanReportsCRUD.DeleteTv_ALTGEN(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_CLM_SlsmanReportsSp") != null)
            {
                var EXTGEN = this.iCLM_SlsmanReportsCRUD.AltExtGen_CLM_SlsmanReportsSp("dbo.EXTGEN_CLM_SlsmanReportsSp",
                    UserName,
                    DisplayLevel);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            Severity = 0;
            Level = 0;
            DisplayLevel = (int?)(stringUtil.IsNull(DisplayLevel, 0));
            //this temp table is a table variable in old stored procedure version.
            this.sQLExpressionExecutor.Execute(@"DECLARE @DirectReports TABLE (
				    slsmangr      SlsmanType  ,
				    slsman        SlsmanType  ,
				    DerSlsmanName NameType    ,
				    username      UsernameType,
				    level         INT         );
				SELECT * into #tv_DirectReports from @DirectReports");
            var slsmanLoadResponse = this.iCLM_SlsmanReportsCRUD.SelectSlsman(UserName);
            var slsmanRequiredColumns = new List<string>() { "slsmangr", "slsman", "DerSlsmanName", "username", "level" };

            slsmanLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(slsmanLoadResponse, slsmanRequiredColumns);

            this.iCLM_SlsmanReportsCRUD.InsertSlsman(slsmanLoadResponse);
            while (sQLUtil.SQLEqual(Severity, 0) == true)
            {
                var slsman1LoadResponse = this.iCLM_SlsmanReportsCRUD.SelectSlsman(Level);
                var slsman1RequiredColumns = new List<string>() { "slsmangr", "slsman", "DerSlsmanName", "username", "level" };

                slsman1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(slsman1LoadResponse, slsman1RequiredColumns);

                this.iCLM_SlsmanReportsCRUD.InsertSlsman(slsman1LoadResponse);
                if (sQLUtil.SQLEqual(slsman1LoadResponse.Items.Count, 0) == true)
                {
                    goto RETURN_DATA;

                }
                Level = (int?)(Level + 1);

            }
        RETURN_DATA:;
            var tv_DirectReportsLoadResponse = this.iCLM_SlsmanReportsCRUD.SelectTv_Directreports(DisplayLevel);
            Data = tv_DirectReportsLoadResponse;

            return (Data, Severity);

        }

    }
}
