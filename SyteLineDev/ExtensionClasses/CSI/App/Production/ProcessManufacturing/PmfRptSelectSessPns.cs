//PROJECT NAME: Production
//CLASS NAME: PmfRptSelectSessPns.cs

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
    public class PmfRptSelectSessPns : IPmfRptSelectSessPns
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IPmfRptSelectSessPnsCRUD iPmfRptSelectSessPnsCRUD;

        public PmfRptSelectSessPns(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            ISQLValueComparerUtil sQLUtil,
            IPmfRptSelectSessPnsCRUD iPmfRptSelectSessPnsCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.sQLUtil = sQLUtil;
            this.iPmfRptSelectSessPnsCRUD = iPmfRptSelectSessPnsCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        PmfRptSelectSessPnsSp(
            Guid? SessionId,
            int? Seq,
            int? ClearSess = 0)
        {

            ICollectionLoadResponse Data = null;

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            if (this.iPmfRptSelectSessPnsCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iPmfRptSelectSessPnsCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iPmfRptSelectSessPnsCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iPmfRptSelectSessPnsCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iPmfRptSelectSessPnsCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iPmfRptSelectSessPnsCRUD.AltExtGen_PmfRptSelectSessPnsSp(ALTGEN_SpName,
                        SessionId,
                        Seq,
                        ClearSess);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN.Data, ALTGEN_Severity);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iPmfRptSelectSessPnsCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iPmfRptSelectSessPnsCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PmfRptSelectSessPnsSp") != null)
            {
                var EXTGEN = this.iPmfRptSelectSessPnsCRUD.AltExtGen_PmfRptSelectSessPnsSp("dbo.EXTGEN_PmfRptSelectSessPnsSp",
                    SessionId,
                    Seq,
                    ClearSess);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN.Data, EXTGEN_Severity);
                }
            }

            var vPmfRptPn1LoadResponse = this.iPmfRptSelectSessPnsCRUD.Vpmfrptpn1Select(SessionId, Seq);
            Data = vPmfRptPn1LoadResponse;
            if ((sQLUtil.SQLEqual(ClearSess, 1) == true))
            {
                /*Needs to load at least one column from the table: pmf_tmp_rpt_pn for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                var pmf_tmp_rpt_pnLoadResponse = this.iPmfRptSelectSessPnsCRUD.Pmf_Tmp_Rpt_PnSelect(SessionId, Seq);
                this.iPmfRptSelectSessPnsCRUD.Pmf_Tmp_Rpt_PnDelete(pmf_tmp_rpt_pnLoadResponse);

            }

            return (Data, Severity);
        }

    }
}
