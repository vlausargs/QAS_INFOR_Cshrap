//PROJECT NAME: Production
//CLASS NAME: PmfRptSelectSessFm.cs

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

namespace CSI.Production.ProcessManufacturing
{
    public class PmfRptSelectSessFm : IPmfRptSelectSessFm
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IPmfRptSelectSessFmCRUD iPmfRptSelectSessFmCRUD;

        public PmfRptSelectSessFm(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            IPmfRptSelectSessFmCRUD iPmfRptSelectSessFmCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iPmfRptSelectSessFmCRUD = iPmfRptSelectSessFmCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        PmfRptSelectSessFmSp(
            Guid? SessionID,
            int? Seq,
            int? ClearSession = 0)
        {

            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iPmfRptSelectSessFmCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iPmfRptSelectSessFmCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iPmfRptSelectSessFmCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iPmfRptSelectSessFmCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iPmfRptSelectSessFmCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iPmfRptSelectSessFmCRUD.AltExtGen_PmfRptSelectSessFmSp(ALTGEN_SpName,
                        SessionID,
                        Seq,
                        ClearSession);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iPmfRptSelectSessFmCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iPmfRptSelectSessFmCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PmfRptSelectSessFmSp") != null)
            {
                var EXTGEN = this.iPmfRptSelectSessFmCRUD.AltExtGen_PmfRptSelectSessFmSp("dbo.EXTGEN_PmfRptSelectSessFmSp",
                    SessionID,
                    Seq,
                    ClearSession);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            var pmf_formulaLoadResponse = this.iPmfRptSelectSessFmCRUD.Pmf_FormulaSelect(SessionID, Seq);
            Data = pmf_formulaLoadResponse;

            if ((sQLUtil.SQLEqual(ClearSession, 1) == true))
            {
                /*Needs to load at least one column from the table: pmf_tmp_rpt_formula for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                var pmf_tmp_rpt_formulaLoadResponse = this.iPmfRptSelectSessFmCRUD.Pmf_Tmp_Rpt_FormulaSelect(SessionID, Seq);
                this.iPmfRptSelectSessFmCRUD.Pmf_Tmp_Rpt_FormulaDelete(pmf_tmp_rpt_formulaLoadResponse);

            }

            return (Data, Severity);
        }

    }
}
