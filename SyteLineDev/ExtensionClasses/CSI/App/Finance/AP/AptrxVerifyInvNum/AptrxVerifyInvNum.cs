//PROJECT NAME: Logistics
//CLASS NAME: AptrxVerifyInvNum.cs

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

namespace CSI.Logistics.Vendor
{
    public class AptrxVerifyInvNum : IAptrxVerifyInvNum
    {

        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IAptrxVerifyInvNumCRUD iAptrxVerifyInvNumCRUD;
        readonly IInsertSiteGroupLoader iInsertSiteGroupLoader;

        public AptrxVerifyInvNum(ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IAptrxVerifyInvNumCRUD iAptrxVerifyInvNumCRUD,
            IInsertSiteGroupLoader iInsertSiteGroupLoader)
        {
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iAptrxVerifyInvNumCRUD = iAptrxVerifyInvNumCRUD;
            this.iInsertSiteGroupLoader = iInsertSiteGroupLoader;
        }

        public (
            int? ReturnCode,
            string Infobar)
        AptrxVerifyInvNumSp(
            string PVendNum,
            string PInvNum,
            string Infobar)
        {

            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? rowCount = null;
            int? Severity = null;
            string SiteRef = null;
            int? Voucher = null;
            if (this.iAptrxVerifyInvNumCRUD.Optional_ModuleForExists())
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
					    [SpName] SYSNAME);
					SELECT * into #tv_ALTGEN from @ALTGEN");
                var optional_module1LoadResponse = this.iAptrxVerifyInvNumCRUD.Optional_Module1Select();
                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                this.iAptrxVerifyInvNumCRUD.Optional_Module1Insert(optional_module1LoadResponse);
                while (this.iAptrxVerifyInvNumCRUD.Tv_ALTGENForExists())
                {
                    (ALTGEN_SpName, rowCount) = this.iAptrxVerifyInvNumCRUD.Tv_ALTGEN1Load(ALTGEN_SpName);
                    var ALTGEN = this.iAptrxVerifyInvNumCRUD.AltExtGen_AptrxVerifyInvNumSp(ALTGEN_SpName,
                        PVendNum,
                        PInvNum,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, Infobar);

                    }
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    var tv_ALTGEN2LoadResponse = this.iAptrxVerifyInvNumCRUD.Tv_ALTGEN2Select(ALTGEN_SpName);
                    this.iAptrxVerifyInvNumCRUD.Tv_ALTGEN2Delete(tv_ALTGEN2LoadResponse);
                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");

                }

            }
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_AptrxVerifyInvNumSp") != null)
            {
                var EXTGEN = this.iAptrxVerifyInvNumCRUD.AltExtGen_AptrxVerifyInvNumSp("dbo.EXTGEN_AptrxVerifyInvNumSp",
                    PVendNum,
                    PInvNum,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.Infobar);
                }
            }


            //     var tt_siteLoadResponse = this.iAptrxVerifyInvNumCRUD.SitesSelect(tsite);


            //this temp table is a table variable in old stored procedure version.
            IList<string> siteGroupVar = new List<string>();
            Severity = 0;
            var SitesLoadResponse = this.iAptrxVerifyInvNumCRUD.SitesSelect();
            // this.iAptrxVerifyInvNumCRUD.SitesInsert(SitesLoadResponse);

            siteGroupVar = iInsertSiteGroupLoader.InsertSiteGroup(SitesLoadResponse);

            SiteRef = null;
            (SiteRef, Voucher, rowCount) = this.iAptrxVerifyInvNumCRUD.Aptrxp_AllLoad(PVendNum, PInvNum, SiteRef, Voucher, siteGroupVar);
            if (sQLUtil.SQLGreaterThan(this.iAptrxVerifyInvNumCRUD.Aptrxp_AllLoad(PVendNum, PInvNum, SiteRef, Voucher, siteGroupVar).rowCount, 0) == true)
            {

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=Exist4",
                    Parm1: "@aptrxp",
                    Parm2: "@aptrxp.inv_num",
                    Parm3: PInvNum,
                    Parm4: "@vendor.vend_num",
                    Parm5: PVendNum,
                    Parm6: "@aptrxp.voucher",
                    Parm7: convertToUtil.ToString(Voucher),
                    Parm8: "@site.site",
                    Parm9: SiteRef);
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, Infobar);
            }
            SiteRef = null;
            (SiteRef, Voucher, rowCount) = this.iAptrxVerifyInvNumCRUD.Aptrx_AllLoad(PVendNum, PInvNum, SiteRef, Voucher, siteGroupVar);
            if (sQLUtil.SQLGreaterThan(this.iAptrxVerifyInvNumCRUD.Aptrx_AllLoad(PVendNum, PInvNum, SiteRef, Voucher, siteGroupVar).rowCount, 0) == true)
            {

                #region CRUD ExecuteMethodCall

                var MsgApp1 = this.iMsgApp.MsgAppSp(
                    Infobar: Infobar,
                    BaseMsg: "E=Exist4",
                    Parm1: "@aptrx",
                    Parm2: "@aptrx.inv_num",
                    Parm3: PInvNum,
                    Parm4: "@vendor.vend_num",
                    Parm5: PVendNum,
                    Parm6: "@aptrx.voucher",
                    Parm7: convertToUtil.ToString(Voucher),
                    Parm8: "@site.site",
                    Parm9: SiteRef);
                Severity = MsgApp1.ReturnCode;
                Infobar = MsgApp1.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, Infobar);
            }
            return (Severity, Infobar);

        }


    }
}
