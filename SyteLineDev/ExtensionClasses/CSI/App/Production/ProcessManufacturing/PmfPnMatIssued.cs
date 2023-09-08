//PROJECT NAME: Production
//CLASS NAME: PmfPnMatIssued.cs

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
    public class PmfPnMatIssued : IPmfPnMatIssued
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IPmfPnMatIssuedCRUD iPmfPnMatIssuedCRUD;

        public PmfPnMatIssued(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IPmfPnMatIssuedCRUD iPmfPnMatIssuedCRUD)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iPmfPnMatIssuedCRUD = iPmfPnMatIssuedCRUD;
        }

        public (
            int? ReturnCode,
            string warning)
        PmfPnMatIssuedSp(
            Guid? job_RowPointer,
            int? op_complete,
            string warning)
        {

            int? Severity = 0;

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            decimal? matl_qty_issued = null;
            string InfoBar = null;
            if (this.iPmfPnMatIssuedCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iPmfPnMatIssuedCRUD.Optional_Module1Select();
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("PmfPnMatIssuedSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iPmfPnMatIssuedCRUD.Optional_Module1Insert(optional_module1LoadResponse);

                while (this.iPmfPnMatIssuedCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iPmfPnMatIssuedCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iPmfPnMatIssuedCRUD.AltExtGen_PmfPnMatIssuedSp(ALTGEN_SpName,
                        job_RowPointer,
                        op_complete,
                        warning);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, warning);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iPmfPnMatIssuedCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iPmfPnMatIssuedCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_PmfPnMatIssuedSp") != null)
            {
                var EXTGEN = this.iPmfPnMatIssuedCRUD.AltExtGen_PmfPnMatIssuedSp("dbo.EXTGEN_PmfPnMatIssuedSp",
                    job_RowPointer,
                    op_complete,
                    warning);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.warning);
                }
            }

            var jobLoadResponse = this.iPmfPnMatIssuedCRUD.JobSelect(job_RowPointer);
            if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLEqual(op_complete, 1), sQLUtil.SQLNot((sQLUtil.SQLGreaterThan(matl_qty_issued, 0))))))
            {

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: InfoBar,
                    BaseMsg: "E=PmfZeroCostOutput");
                InfoBar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

            }
            warning = stringUtil.IsNull(
                InfoBar,
                "");
            return (Severity, warning);

        }

    }
}
