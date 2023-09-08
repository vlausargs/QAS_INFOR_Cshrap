//PROJECT NAME: Logistics
//CLASS NAME: AppmtdValidateVoucher.cs

using System;
using System.Data;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
    public class AppmtdValidateVoucher : IAppmtdValidateVoucher
    {
        readonly IApplicationDB appDB;

        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IMidnightOf iMidnightOf;
        readonly IStringUtil stringUtil;
        readonly ICurrCnvt iCurrCnvt;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IMsgAsk iMsgAsk;
        readonly IMinAmt iMinAmt;
        readonly IMaxAmt iMaxAmt;
        readonly IMinQty iMinQty;

        public AppmtdValidateVoucher(IApplicationDB appDB,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IMidnightOf iMidnightOf,
            IStringUtil stringUtil,
            ICurrCnvt iCurrCnvt,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IMsgAsk iMsgAsk,
            IMinAmt iMinAmt,
            IMaxAmt iMaxAmt,
            IMinQty iMinQty)
        {
            this.appDB = appDB;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iMidnightOf = iMidnightOf;
            this.stringUtil = stringUtil;
            this.iCurrCnvt = iCurrCnvt;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.iMsgAsk = iMsgAsk;
            this.iMinAmt = iMinAmt;
            this.iMaxAmt = iMaxAmt;
            this.iMinQty = iMinQty;
        }

        public (
            int? ReturnCode,
            string PApplyVend,
            string PName,
            DateTime? PDueDate,
            string PGrnNum,
            decimal? ForAmtDisc,
            decimal? ForAmtPaid,
            decimal? DomAmtDisc,
            decimal? DomAmtPaid,
            decimal? ExchRate,
            string AptrxpCurrCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        AppmtdValidateVoucherSp(
            string PType,
            int? PVoucher,
            string PSite,
            string PBankCode,
            string PVendNum,
            int? PCheckSeq,
            string PApplyVend,
            string PName,
            DateTime? PDueDate,
            string PGrnNum,
            decimal? ForAmtDisc,
            decimal? ForAmtPaid,
            decimal? DomAmtDisc,
            decimal? DomAmtPaid,
            decimal? ExchRate,
            string AptrxpCurrCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {

            NameType _PName = PName;
            DateType _PDueDate = PDueDate;
            GrnNumType _PGrnNum = PGrnNum;
            ExchRateType _ExchRate = ExchRate;
            CurrCodeType _AptrxpCurrCode = AptrxpCurrCode;

            StringType _ALTGEN_SpName = DBNull.Value;
            string ALTGEN_SpName = null;
            int? ALTGEN_Severity = null;
            int? Severity = null;
            RowPointerType _AppmtRowPointer = DBNull.Value;
            Guid? AppmtRowPointer = null;
            DateType _AppmtDueDate = DBNull.Value;
            DateTime? AppmtDueDate = null;
            AppmtPayTypeType _AppmtPayType = DBNull.Value;
            string AppmtPayType = null;
            DateType _AppmtCheckDate = DBNull.Value;
            DateTime? AppmtCheckDate = null;
            ExchRateType _AppmtExchRate = DBNull.Value;
            decimal? AppmtExchRate = null;
            AmountType _AppmtDomCheckAmt = DBNull.Value;
            decimal? AppmtDomCheckAmt = null;
            AmountType _AppmtForCheckAmt = DBNull.Value;
            decimal? AppmtForCheckAmt = null;
            RowPointerType _AppmtdRowPointer = DBNull.Value;
            Guid? AppmtdRowPointer = null;
            BankCodeType _AppmtdBankCode = DBNull.Value;
            string AppmtdBankCode = null;
            VendNumType _AppmtdVendNum = DBNull.Value;
            string AppmtdVendNum = null;
            VoucherType _AppmtdVoucher = DBNull.Value;
            int? AppmtdVoucher = null;
            ApCheckSeqType _AppmtdCheckSeq = DBNull.Value;
            int? AppmtdCheckSeq = null;
            RowPointerType _AptrxpRowPointer = DBNull.Value;
            Guid? AptrxpRowPointer = null;
            DateType _AptrxpDueDate = DBNull.Value;
            DateTime? AptrxpDueDate = null;
            GrnNumType _AptrxpGrnNum = DBNull.Value;
            string AptrxpGrnNum = null;
            DateType _AptrxpDiscDate = DBNull.Value;
            DateTime? AptrxpDiscDate = null;
            AmountType _AptrxpDiscAmt = DBNull.Value;
            decimal? AptrxpDiscAmt = null;
            AmountType _AptrxpInvAmt = DBNull.Value;
            decimal? AptrxpInvAmt = null;
            ExchRateType _AptrxpExchRate = DBNull.Value;
            decimal? AptrxpExchRate = null;
            ListYesNoType _AptrxpFixedRate = DBNull.Value;
            int? AptrxpFixedRate = null;
            string BankHdrBankCode = null;
            SiteType _ParmsSite = DBNull.Value;
            string ParmsSite = null;
            RowPointerType _VchHdrRowPointer = DBNull.Value;
            Guid? VchHdrRowPointer = null;
            VendNumType _VchHdrVendNum = DBNull.Value;
            string VchHdrVendNum = null;
            RowPointerType _VendaddrRowPointer = DBNull.Value;
            Guid? VendaddrRowPointer = null;
            VendNumType _VendaddrVendNum = DBNull.Value;
            string VendaddrVendNum = null;
            NameType _VendaddrName = DBNull.Value;
            string VendaddrName = null;
            AmountType _TotPayments = DBNull.Value;
            decimal? TotPayments = null;
            AmountType _TotAmtDisc = DBNull.Value;
            decimal? TotAmtDisc = null;
            AmountType _TotAdj = DBNull.Value;
            decimal? TotAdj = null;
            AmountType _TotAdjDisc = DBNull.Value;
            decimal? TotAdjDisc = null;
            TaxModeType _TaxSystem1TaxMode = DBNull.Value;
            string TaxSystem1TaxMode = null;
            ListYesNoType _TaxSystem1TaxDiscAllow = DBNull.Value;
            int? TaxSystem1TaxDiscAllow = null;
            TaxModeType _TaxSystem2TaxMode = DBNull.Value;
            string TaxSystem2TaxMode = null;
            ListYesNoType _TaxSystem2TaxDiscAllow = DBNull.Value;
            int? TaxSystem2TaxDiscAllow = null;
            CurrCodeType _DomCurrCode = DBNull.Value;
            string DomCurrCode = null;
            CurrCodeType _BanCurrCode = DBNull.Value;
            string BanCurrCode = null;
            DateTime? OldPDueDate = null;
            ListYesNoType _VoucherHoldFlag = DBNull.Value;
            int? VoucherHoldFlag = null;
            ICollectionLoadRequest AppmtdValidateVoucherSp3CrsLoadRequestForCursor = null;
            ICollectionLoadResponse AppmtdValidateVoucherSp3CrsLoadResponseForCursor = null;
            int AppmtdValidateVoucherSp3Crs_CursorFetch_Status = -1;
            int AppmtdValidateVoucherSp3Crs_CursorCounter = -1;
            AmountType _AptrxpSalesTax = DBNull.Value;
            decimal? AptrxpSalesTax = null;
            AmountType _AptrxpDiscPct = DBNull.Value;
            decimal? AptrxpDiscPct = null;

            if (existsChecker.Exists(
                tableName: "optional_module",
                fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AppmtdValidateVoucherSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
            {
                //this temp table is a table variable in old stored procedure version.
                this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
                        [SpName] SYSNAME);
                    SELECT * into #tv_ALTGEN from @ALTGEN ");

                #region CRUD LoadToRecord
                var optional_module1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"SpName","CAST (NULL AS NVARCHAR)"},
                        {"u0","[om].[ModuleName]"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AppmtdValidateVoucherSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                #endregion  LoadToRecord

                #region CRUD InsertByRecords
                foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                {
                    optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("AppmtdValidateVoucherSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                };

                var optional_module1RequiredColumns = new List<string>() { "SpName" };

                optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                    items: optional_module1LoadResponse.Items);

                this.appDB.Insert(optional_module1InsertRequest);
                #endregion InsertByRecords

                while (existsChecker.Exists(
                    tableName: "#tv_ALTGEN",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("")))
                {
                    #region CRUD LoadToVariable
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
                    #endregion  LoadToVariable

                    var ALTGEN = AltExtGen_AppmtdValidateVoucherSp(_ALTGEN_SpName,
                        PType,
                        PVoucher,
                        PSite,
                        PBankCode,
                        PVendNum,
                        PCheckSeq,
                        PApplyVend,
                        PName,
                        PDueDate,
                        PGrnNum,
                        ForAmtDisc,
                        ForAmtPaid,
                        DomAmtDisc,
                        DomAmtPaid,
                        ExchRate,
                        AptrxpCurrCode,
                        PromptMsg,
                        PromptButtons,
                        Infobar);
                    ALTGEN_Severity = ALTGEN.ReturnCode;

                    if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                    {
                        return (ALTGEN_Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);
                    }

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                    /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                    #region CRUD LoadToRecord
                    var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"col0","1"},
                        },
                        tableName: "#tv_ALTGEN", 
                        loadForChange: true, 
                        lockingType: LockingType.None,
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("[SpName] = {0}", ALTGEN_SpName),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var tv_ALTGEN2LoadResponse = this.appDB.Load(tv_ALTGEN2LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD DeleteByRecord
                    var tv_ALTGEN2DeleteRequest = collectionDeleteRequestFactory.SQLDelete(tableName: "#tv_ALTGEN",
                        items: tv_ALTGEN2LoadResponse.Items);
                    this.appDB.Delete(tv_ALTGEN2DeleteRequest);
                    #endregion DeleteByRecord

                    this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN DROP COLUMN tempTableId");
                }
            }

            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_AppmtdValidateVoucherSp") != null)
            {
                var EXTGEN = AltExtGen_AppmtdValidateVoucherSp("dbo.EXTGEN_AppmtdValidateVoucherSp",
                    PType,
                    PVoucher,
                    PSite,
                    PBankCode,
                    PVendNum,
                    PCheckSeq,
                    PApplyVend,
                    PName,
                    PDueDate,
                    PGrnNum,
                    ForAmtDisc,
                    ForAmtPaid,
                    DomAmtDisc,
                    DomAmtPaid,
                    ExchRate,
                    AptrxpCurrCode,
                    PromptMsg,
                    PromptButtons,
                    Infobar);
                int? EXTGEN_Severity = EXTGEN.ReturnCode;

                if (EXTGEN_Severity != 1)
                {
                    return (EXTGEN_Severity, EXTGEN.PApplyVend, EXTGEN.PName, EXTGEN.PDueDate, EXTGEN.PGrnNum, EXTGEN.ForAmtDisc, EXTGEN.ForAmtPaid, EXTGEN.DomAmtDisc, EXTGEN.DomAmtPaid, EXTGEN.ExchRate, EXTGEN.AptrxpCurrCode, EXTGEN.PromptMsg, EXTGEN.PromptButtons, EXTGEN.Infobar);
                }
            }

            Severity = 0;
            PApplyVend = null;
            PGrnNum = null;
            PromptMsg = null;

            #region CRUD LoadToVariable
            var tax_systemLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_TaxSystem1TaxMode,"tax_mode"},
                    {_TaxSystem1TaxDiscAllow,"tax_disc_allow"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause($"tax_system = 1"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tax_systemLoadResponse = this.appDB.Load(tax_systemLoadRequest);
            if (tax_systemLoadResponse.Items.Count > 0)
            {
                TaxSystem1TaxMode = _TaxSystem1TaxMode;
                TaxSystem1TaxDiscAllow = _TaxSystem1TaxDiscAllow;
            }
            #endregion  LoadToVariable

            #region CRUD LoadToVariable
            var tax_system1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_TaxSystem2TaxMode,"tax_mode"},
                    {_TaxSystem2TaxDiscAllow,"tax_disc_allow"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "tax_system",
                fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                whereClause: collectionLoadRequestFactory.Clause("tax_system = 2"),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var tax_system1LoadResponse = this.appDB.Load(tax_system1LoadRequest);
            if (tax_system1LoadResponse.Items.Count > 0)
            {
                TaxSystem2TaxMode = _TaxSystem2TaxMode;
                TaxSystem2TaxDiscAllow = _TaxSystem2TaxDiscAllow;
            }
            #endregion  LoadToVariable

            AppmtRowPointer = null;
            AppmtDueDate = null;
            AppmtPayType = null;
            AppmtExchRate = 0;

            #region CRUD LoadToVariable
            var appmtLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_AppmtRowPointer,"appmt.RowPointer"},
                    {_AppmtDueDate,"appmt.due_date"},
                    {_AppmtPayType,"appmt.pay_type"},
                    {_AppmtCheckDate,"appmt.check_date"},
                    {_AppmtExchRate,"appmt.exch_rate"},
                    {_AppmtDomCheckAmt,"appmt.dom_check_amt"},
                    {_AppmtForCheckAmt,"appmt.for_check_amt"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "appmt",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("appmt.bank_code = {0} AND appmt.vend_num = {2} AND appmt.check_seq = {1}", PBankCode, PCheckSeq, PVendNum),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var appmtLoadResponse = this.appDB.Load(appmtLoadRequest);
            if (appmtLoadResponse.Items.Count > 0)
            {
                AppmtRowPointer = _AppmtRowPointer;
                AppmtDueDate = _AppmtDueDate;
                AppmtPayType = _AppmtPayType;
                AppmtCheckDate = _AppmtCheckDate;
                AppmtExchRate = _AppmtExchRate;
                AppmtDomCheckAmt = _AppmtDomCheckAmt;
                AppmtForCheckAmt = _AppmtForCheckAmt;
            }
            #endregion  LoadToVariable

            if (AppmtRowPointer == null)
            {
                Infobar = null;

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(Infobar: Infobar
                    , BaseMsg: "E=Remove0"
                    , Parm1: "@appmt");
                Severity = MsgApp.ReturnCode;
                Infobar = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);//END
            }
            if (sQLUtil.SQLEqual(PVoucher, 0) == true || PVoucher == null)
            {
                Infobar = null;

                #region CRUD ExecuteMethodCall

                var MsgApp1 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                    , BaseMsg: "E=MustCompare>"
                    , Parm1: "@appmtd.voucher"
                    , Parm2: "@!Zero");
                Severity = MsgApp1.ReturnCode;
                Infobar = MsgApp1.Infobar;

                #endregion ExecuteMethodCall

                return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);//END
            }

            if (sQLUtil.SQLEqual(ExchRate, 0) == true)
            {
                ExchRate = AppmtExchRate;
                if (sQLUtil.SQLEqual(ExchRate, 0) == true)
                {
                    ExchRate = 1.0M;
                }
            }
            if (sQLUtil.SQLBool(sQLUtil.SQLEqual(PType, "V")))
            {
                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_ParmsSite,"parms.site"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
                if (parmsLoadResponse.Items.Count > 0)
                {
                    ParmsSite = _ParmsSite;
                }
                #endregion  LoadToVariable

                AptrxpRowPointer = null;
                AptrxpDueDate = null;
                AptrxpGrnNum = null;
                if (sQLUtil.SQLEqual(PSite, ParmsSite) == true)
                {
                    #region CRUD LoadToVariable
                    var aptrxpLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_AptrxpRowPointer,"aptrxp.RowPointer"},
                            {_AptrxpDueDate,"aptrxp.due_date"},
                            {_AptrxpGrnNum,"aptrxp.grn_num"},
                            {_AptrxpDiscDate,"aptrxp.disc_date"},
                            {_AptrxpDiscAmt,"aptrxp.disc_amt"},
                            {_AptrxpInvAmt,"aptrxp.inv_amt"},
                            {_AptrxpExchRate,"aptrxp.exch_rate"},
                            {_AptrxpFixedRate,"aptrxp.fixed_rate"},
                            {_AptrxpCurrCode,"aptrxp.curr_code"},
                            {_VoucherHoldFlag,"hold_flag"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("aptrxp.vend_num = {0} AND aptrxp.voucher = {1} AND aptrxp.type = 'V' AND aptrxp.active = 1", PVendNum, PVoucher),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxpLoadResponse = this.appDB.Load(aptrxpLoadRequest);

                    if (aptrxpLoadResponse.Items.Count > 0)
                    {
                        AptrxpRowPointer = _AptrxpRowPointer;
                        AptrxpDueDate = _AptrxpDueDate;
                        AptrxpGrnNum = _AptrxpGrnNum;
                        AptrxpDiscDate = _AptrxpDiscDate;
                        AptrxpDiscAmt = _AptrxpDiscAmt;
                        AptrxpInvAmt = _AptrxpInvAmt;
                        AptrxpExchRate = _AptrxpExchRate;
                        AptrxpFixedRate = _AptrxpFixedRate;
                        AptrxpCurrCode = _AptrxpCurrCode;
                        VoucherHoldFlag = _VoucherHoldFlag;
                    }
                    #endregion  LoadToVariable
                }
                else
                {
                    #region CRUD LoadToVariable
                    var aptrxp_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_AptrxpRowPointer,"aptrxp_all.RowPointer"},
                            {_AptrxpDueDate,"aptrxp_all.due_date"},
                            {_AptrxpGrnNum,"aptrxp_all.grn_num"},
                            {_AptrxpDiscDate,"aptrxp_all.disc_date"},
                            {_AptrxpDiscAmt,"aptrxp_all.disc_amt"},
                            {_AptrxpInvAmt,"aptrxp_all.inv_amt"},
                            {_AptrxpExchRate,"aptrxp_all.exch_rate"},
                            {_AptrxpFixedRate,"aptrxp_all.fixed_rate"},
                            {_AptrxpCurrCode,"aptrxp_all.curr_code"},
                            {_VoucherHoldFlag,"hold_flag"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp_all",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("aptrxp_all.vend_num = {0} AND aptrxp_all.voucher = {1} AND aptrxp_all.type = 'V' AND aptrxp_all.active = 1 AND aptrxp_all.site_ref = {2}", PVendNum, PVoucher, PSite),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxp_allLoadResponse = this.appDB.Load(aptrxp_allLoadRequest);
                    if (aptrxp_allLoadResponse.Items.Count > 0)
                    {
                        AptrxpRowPointer = _AptrxpRowPointer;
                        AptrxpDueDate = _AptrxpDueDate;
                        AptrxpGrnNum = _AptrxpGrnNum;
                        AptrxpDiscDate = _AptrxpDiscDate;
                        AptrxpDiscAmt = _AptrxpDiscAmt;
                        AptrxpInvAmt = _AptrxpInvAmt;
                        AptrxpExchRate = _AptrxpExchRate;
                        AptrxpFixedRate = _AptrxpFixedRate;
                        AptrxpCurrCode = _AptrxpCurrCode;
                        VoucherHoldFlag = _VoucherHoldFlag;
                    }
                    #endregion  LoadToVariable
                }
                if (AptrxpRowPointer == null)
                {
                    Infobar = null;

                    #region CRUD ExecuteMethodCall

                    var MsgApp2 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                        , BaseMsg: "E=NoExistFor2"
                        , Parm1: "@aptrxp"
                        , Parm2: "@aptrxp.vend_num"
                        , Parm3: "@aptrxp.voucher"
                        , Parm4: convertToUtil.ToString(PVoucher)
                        , Parm5: "@aptrxp.active"
                        , Parm6: "@:ListYesNo:1");
                    Severity = MsgApp2.ReturnCode;
                    Infobar = MsgApp2.Infobar;

                    #endregion ExecuteMethodCall

                    return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);//END
                }

                if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(
                    tableName: "vendor_currency",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("curr_code = {0} AND vend_num = {1}", AptrxpCurrCode, PVendNum)))))
                {
                    #region CRUD ExecuteMethodCall

                    var MsgApp3 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                        , BaseMsg: "E=NotValid"
                        , Parm1: "@aptrxp.voucher"
                        , Parm2: convertToUtil.ToString(PVoucher)
                        , Parm3: "@aptrxp.voucher"
                        , Parm4: convertToUtil.ToString(PVoucher)
                        , Parm5: "@currency"
                        , Parm6: AptrxpCurrCode
                        , Parm7: "@vendor"
                        , Parm8: PVendNum);
                    Severity = MsgApp3.ReturnCode;
                    Infobar = MsgApp3.Infobar;

                    #endregion ExecuteMethodCall

                    return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);//END
                }

                OldPDueDate = convertToUtil.ToDateTime(PDueDate);
                PDueDate = convertToUtil.ToDateTime(AptrxpDueDate);
                PGrnNum = AptrxpGrnNum;
                if (sQLUtil.SQLNotEqual(ParmsSite, PSite) == true)
                {
                    VchHdrRowPointer = null;
                    VchHdrVendNum = null;

                    #region CRUD LoadToVariable
                    var vch_hdr_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_VchHdrRowPointer,"vch_hdr_all.RowPointer"},
                            {_VchHdrVendNum,"vch_hdr_all.vend_num"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "vch_hdr_all",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("vch_hdr_all.site_ref = {1} AND vch_hdr_all.voucher = {0}", PVoucher, PSite),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var vch_hdr_allLoadResponse = this.appDB.Load(vch_hdr_allLoadRequest);

                    if (vch_hdr_allLoadResponse.Items.Count > 0)
                    {
                        VchHdrRowPointer = _VchHdrRowPointer;
                        VchHdrVendNum = _VchHdrVendNum;
                    }
                    #endregion  LoadToVariable

                    if (VchHdrRowPointer != null)
                    {
                        VendaddrRowPointer = null;
                        VendaddrVendNum = null;
                        VendaddrName = null;

                        #region CRUD LoadToVariable
                        var vendaddrLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_VendaddrRowPointer,"vendaddr.RowPointer"},
                                {_VendaddrVendNum,"vendaddr.vend_num"},
                                {_VendaddrName,"vendaddr.name"},
                            },
                            loadForChange: false, 
                            lockingType: LockingType.None,
                            tableName: "vendaddr",
                            fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED) INNER JOIN vendor WITH (READUNCOMMITTED) ON vendor.vend_num = vendaddr.vend_num"),
                            whereClause: collectionLoadRequestFactory.Clause("vendaddr.vend_num = {0}", VchHdrVendNum),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var vendaddrLoadResponse = this.appDB.Load(vendaddrLoadRequest);
                        if (vendaddrLoadResponse.Items.Count > 0)
                        {
                            VendaddrRowPointer = _VendaddrRowPointer;
                            VendaddrVendNum = _VendaddrVendNum;
                            VendaddrName = _VendaddrName;
                        }
                        #endregion  LoadToVariable
                    }
                    if (VendaddrRowPointer != null)
                    {
                        PApplyVend = VendaddrVendNum;
                        PName = VendaddrName;
                    }

                    #region CRUD LoadToVariable
                    var aptrxp_all1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_TotPayments,"isnull(sum(amt_paid), 0)"},
                            {_TotAmtDisc,"isnull(sum(amt_disc), 0)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp_all",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("aptrxp_all.type = 'P' AND aptrxp_all.vend_num = {0} AND aptrxp_all.voucher = {1} AND aptrxp_all.site_ref = {2}", PApplyVend, PVoucher, PSite),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxp_all1LoadResponse = this.appDB.Load(aptrxp_all1LoadRequest);
                    if (aptrxp_all1LoadResponse.Items.Count > 0)
                    {
                        TotPayments = _TotPayments;
                        TotAmtDisc = _TotAmtDisc;
                    }
                    #endregion  LoadToVariable

                    #region CRUD LoadToVariable
                    var aptrxp_all2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_TotAdj,"isnull(sum(inv_amt), 0)"},
                            {_TotAdjDisc,"isnull(sum(disc_amt), 0)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp_all",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("aptrxp_all.type = 'A' AND aptrxp_all.vend_num = {0} AND aptrxp_all.voucher = {1} AND aptrxp_all.site_ref = {2}", PApplyVend, PVoucher, PSite),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxp_all2LoadResponse = this.appDB.Load(aptrxp_all2LoadRequest);
                    if (aptrxp_all2LoadResponse.Items.Count > 0)
                    {
                        TotAdj = _TotAdj;
                        TotAdjDisc = _TotAdjDisc;
                    }
                    #endregion  LoadToVariable
                }

                if (sQLUtil.SQLEqual(ParmsSite, PSite) == true)
                {
                    AppmtDueDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(AppmtDueDate));
                    PDueDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(PDueDate));
                    if (sQLUtil.SQLNotEqual(AppmtDueDate, PDueDate) == true && sQLUtil.SQLGreaterThan(stringUtil.CharIndex(AppmtPayType, "TN"), 0) == true)
                    {
                        Infobar = null;

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: MsgAskSp
                        var MsgAsk = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                            , Buttons: PromptButtons
                            , BaseMsg: "I=NotEqual"
                            , Parm1: "@aptrxp.due_date"
                            , Parm2: convertToUtil.ToString(PDueDate)
                            , Parm3: "@appmt.due_date"
                            , Parm4: convertToUtil.ToString(AppmtDueDate));
                        PromptMsg = MsgAsk.Infobar;
                        PromptButtons = MsgAsk.Buttons;

                        #endregion ExecuteMethodCall
                    }
                    PDueDate = convertToUtil.ToDateTime(OldPDueDate);
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    AppmtdValidateVoucherSp3CrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"bank_hdr.bank_code","bank_hdr.bank_code"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "bank_hdr",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                    AppmtdValidateVoucherSp3CrsLoadResponseForCursor = this.appDB.Load(AppmtdValidateVoucherSp3CrsLoadRequestForCursor);
                    AppmtdValidateVoucherSp3Crs_CursorFetch_Status = AppmtdValidateVoucherSp3CrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    AppmtdValidateVoucherSp3Crs_CursorCounter = -1;

                    while (sQLUtil.SQLEqual(Severity, 0) == true)
                    {
                        //BEGIN
                        AppmtdValidateVoucherSp3Crs_CursorCounter++;
                        if (AppmtdValidateVoucherSp3CrsLoadResponseForCursor.Items.Count > AppmtdValidateVoucherSp3Crs_CursorCounter)
                        {
                            BankHdrBankCode = AppmtdValidateVoucherSp3CrsLoadResponseForCursor.Items[AppmtdValidateVoucherSp3Crs_CursorCounter].GetValue<string>(0);
                        }
                        AppmtdValidateVoucherSp3Crs_CursorFetch_Status = (AppmtdValidateVoucherSp3Crs_CursorCounter == AppmtdValidateVoucherSp3CrsLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLEqual(AppmtdValidateVoucherSp3Crs_CursorFetch_Status, -1) == true)
                        {
                            break;
                        }
                        if (existsChecker.Exists(
                            tableName: "appmtd",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("{1} = {0} AND {3} = {6} AND {4} = {7} AND {2} <> {5}", BankHdrBankCode, AppmtdBankCode, AppmtdCheckSeq, AppmtdVendNum, AppmtdVoucher, PCheckSeq, PVendNum, PVoucher)))
                        {
                            #region CRUD ExecuteMethodCall

                            //Please Generate the bounce for this stored procedure: MsgAskSp
                            var MsgAsk1 = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                                , Buttons: PromptButtons
                                , BaseMsg: "I=Exist4"
                                , Parm1: "@appmtd"
                                , Parm2: "@appmtd.bank_code"
                                , Parm3: BankHdrBankCode
                                , Parm4: "@appmtd.vend_num"
                                , Parm5: PVendNum
                                , Parm6: "@appmtd.check_seq"
                                , Parm7: convertToUtil.ToString(PCheckSeq)
                                , Parm8: "@appmtd.voucher"
                                , Parm9: convertToUtil.ToString(PVoucher));
                            PromptMsg = MsgAsk1.Infobar;
                            PromptButtons = MsgAsk1.Buttons;

                            #endregion ExecuteMethodCall
                        }
                    }
                    //Deallocate Cursor AppmtdValidateVoucherSp3Crs
                    if (PromptMsg != null)
                    {
                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: MsgAskSp
                        var MsgAsk2 = this.iMsgAsk.MsgAskSp(Infobar: PromptMsg
                            , Buttons: PromptButtons
                            , BaseMsg: "Q=CmdContinueNoYes"
                            , Parm1: "@%update");
                        PromptMsg = MsgAsk2.Infobar;
                        PromptButtons = MsgAsk2.Buttons;

                        #endregion ExecuteMethodCall
                    }

                    #region CRUD LoadToVariable
                    var aptrxp1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_TotPayments,"isnull(sum(amt_paid), 0)"},
                            {_TotAmtDisc,"isnull(sum(amt_disc), 0)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("aptrxp.type = 'P' AND aptrxp.vend_num = {0} AND aptrxp.voucher = {1}", PVendNum, PVoucher),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxp1LoadResponse = this.appDB.Load(aptrxp1LoadRequest);
                    if (aptrxp1LoadResponse.Items.Count > 0)
                    {
                        TotPayments = _TotPayments;
                        TotAmtDisc = _TotAmtDisc;
                    }
                    #endregion  LoadToVariable

                    #region CRUD LoadToVariable
                    var aptrxp2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_TotAdj,"isnull(sum(inv_amt), 0)"},
                            {_TotAdjDisc,"isnull(sum(disc_amt), 0)"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp",
                        fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                        whereClause: collectionLoadRequestFactory.Clause("aptrxp.type = 'A' AND aptrxp.vend_num = {0} AND aptrxp.voucher = {1}", PVendNum, PVoucher),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxp2LoadResponse = this.appDB.Load(aptrxp2LoadRequest);
                    if (aptrxp2LoadResponse.Items.Count > 0)
                    {
                        TotAdj = _TotAdj;
                        TotAdjDisc = _TotAdjDisc;
                    }
                    #endregion  LoadToVariable
                }

                #region CRUD LoadToVariable
                var appmtd1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_TotPayments,convertToUtil.ToString($"{variableUtil.GetValue<decimal?>(_TotPayments)} + isnull(sum(for_amt_paid), 0)")},
                        {_TotAmtDisc,convertToUtil.ToString($"{variableUtil.GetValue<decimal?>(_TotAmtDisc)} + isnull(sum(for_amt_disc), 0)")},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "appmtd",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("appmtd.voucher = {2} AND appmtd.site = {4} AND appmtd.bank_code = {0} AND appmtd.vend_num = {3} AND appmtd.check_seq <> {1}", PBankCode, PCheckSeq, PVoucher, PVendNum, PSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var appmtd1LoadResponse = this.appDB.Load(appmtd1LoadRequest);
                if (appmtd1LoadResponse.Items.Count > 0)
                {
                    TotPayments = _TotPayments;
                    TotAmtDisc = _TotAmtDisc;
                }
                #endregion  LoadToVariable

                if (sQLUtil.SQLGreaterThan(AppmtCheckDate, AptrxpDiscDate) == true)
                {
                    AptrxpDiscAmt = 0.0M;
                    TotAdjDisc = 0.0M;
                }
                ForAmtDisc = 0.0M;
                if (sQLUtil.SQLGreaterThanOrEqual((AptrxpInvAmt + TotAdj), 0) == true)
                {
                    ForAmtDisc = (decimal?)(this.iMaxAmt.MaxAmtFn(this.iMinAmt.MinAmtFn((AptrxpDiscAmt + TotAdjDisc - TotAmtDisc), (AptrxpInvAmt + TotAdj - TotPayments - TotAmtDisc)), 0.0M));
                }
                else
                {
                    ForAmtDisc = (decimal?)(this.iMinAmt.MinAmtFn(this.iMaxAmt.MaxAmtFn((AptrxpDiscAmt + TotAdjDisc - TotAmtDisc), (AptrxpInvAmt + TotAdj - TotPayments - TotAmtDisc)), 0.0M));
                }
                ForAmtPaid = (decimal?)(AptrxpInvAmt + TotAdj - (TotPayments + TotAmtDisc) - ForAmtDisc);

                #region CRUD LoadToVariable
                var currparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_DomCurrCode,"curr_code"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "currparms_all",
                    fromClause: collectionLoadRequestFactory.Clause(" WITH (READUNCOMMITTED)"),
                    whereClause: collectionLoadRequestFactory.Clause("site_ref = {0}", PSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var currparms_allLoadResponse = this.appDB.Load(currparms_allLoadRequest);
                if (currparms_allLoadResponse.Items.Count > 0)
                {
                    DomCurrCode = _DomCurrCode;
                }
                #endregion  LoadToVariable

                #region CRUD LoadToVariable
                var bank_hdr1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_BanCurrCode,"curr_code"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "bank_hdr",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("bank_code = {0}", PBankCode),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var bank_hdr1LoadResponse = this.appDB.Load(bank_hdr1LoadRequest);
                if (bank_hdr1LoadResponse.Items.Count > 0)
                {
                    BanCurrCode = _BanCurrCode;
                }
                #endregion  LoadToVariable

                ExchRate = convertToUtil.ToDecimal((sQLUtil.SQLEqual(AptrxpFixedRate, 1) == true ? AptrxpExchRate :
                sQLUtil.SQLEqual(AptrxpCurrCode, BanCurrCode) == true && sQLUtil.SQLNotEqual(BanCurrCode, DomCurrCode) == true ? AppmtExchRate : null));
                if ((sQLUtil.SQLEqual(AppmtPayType, "M") == true || sQLUtil.SQLEqual(AppmtPayType, "H") == true) && sQLUtil.SQLGreaterThan(AppmtForCheckAmt, 0) == true)
                {
                    ForAmtPaid = (decimal?)(this.iMinQty.MinQtyFn(AppmtForCheckAmt, ForAmtPaid));
                    ForAmtDisc = 0;
                }
                if (sQLUtil.SQLEqual(TaxSystem1TaxMode, "I") == true && sQLUtil.SQLEqual(TaxSystem1TaxDiscAllow, 1) == true || sQLUtil.SQLEqual(TaxSystem2TaxMode, "I") == true && sQLUtil.SQLEqual(TaxSystem2TaxDiscAllow, 1) == true)
                {
                    #region CRUD LoadToVariable
                    var aptrxp3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_AptrxpSalesTax,"sales_tax"},
                            {_AptrxpDiscPct,"disc_pct"},
                        },
                        loadForChange: false, 
                        lockingType: LockingType.None,
                        tableName: "aptrxp",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("voucher = {0} AND type = 'V'", PVoucher),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var aptrxp3LoadResponse = this.appDB.Load(aptrxp3LoadRequest);
                    if (aptrxp3LoadResponse.Items.Count > 0)
                    {
                        AptrxpSalesTax = _AptrxpSalesTax;
                        AptrxpDiscPct = _AptrxpDiscPct;
                    }
                    #endregion  LoadToVariable

                    ForAmtDisc = (decimal?)((AptrxpInvAmt - AptrxpSalesTax) * (AptrxpDiscPct / 100M));
                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(CurrCode: AptrxpCurrCode
                    , FromDomestic: 0
                    , UseBuyRate: 1
                    , RoundResult: 1
                    , Date: AppmtCheckDate
                    , TRate: ExchRate
                    , Infobar: Infobar
                    , Amount1: ForAmtPaid
                    , Result1: DomAmtPaid
                    , Amount2: ForAmtDisc
                    , Result2: DomAmtDisc);
                Severity = CurrCnvt.ReturnCode;
                ExchRate = CurrCnvt.TRate;
                Infobar = CurrCnvt.Infobar;
                DomAmtPaid = CurrCnvt.Result1;
                DomAmtDisc = CurrCnvt.Result2;

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);
                }
            }
            if (sQLUtil.SQLNotEqual(PType, "O") == true)
            {
                AppmtdRowPointer = null;

                #region CRUD LoadToVariable
                var appmtd2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_AppmtdRowPointer,"appmtd.RowPointer"},
                        {_AppmtdBankCode,"appmtd.bank_code"},
                        {_AppmtdVendNum,"appmtd.vend_num"},
                        {_AppmtdVoucher,"appmtd.voucher"},
                        {_AppmtdCheckSeq,"appmtd.check_seq"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "appmtd",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("appmtd.bank_code = {0} AND appmtd.vend_num = {2} AND appmtd.check_seq = {1} AND appmtd.voucher = {3} AND appmtd.site = {4}", PBankCode, PCheckSeq, PVendNum, PVoucher, PSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var appmtd2LoadResponse = this.appDB.Load(appmtd2LoadRequest);
                if (appmtd2LoadResponse.Items.Count > 0)
                {
                    AppmtdRowPointer = _AppmtdRowPointer;
                    AppmtdBankCode = _AppmtdBankCode;
                    AppmtdVendNum = _AppmtdVendNum;
                    AppmtdVoucher = _AppmtdVoucher;
                    AppmtdCheckSeq = _AppmtdCheckSeq;
                }
                #endregion  LoadToVariable
            }

            if (AppmtdRowPointer == null && sQLUtil.SQLEqual(PSite, ParmsSite) == true)
            {
                AppmtdRowPointer = null;

                #region CRUD LoadToVariable
                var appmtd3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_AppmtdRowPointer,"appmtd.RowPointer"},
                        {_AppmtdBankCode,"appmtd.bank_code"},
                        {_AppmtdVendNum,"appmtd.vend_num"},
                        {_AppmtdVoucher,"appmtd.voucher"},
                        {_AppmtdCheckSeq,"appmtd.check_seq"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "appmtd",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("appmtd.bank_code = {0} AND appmtd.vend_num = {2} AND appmtd.check_seq = {1} AND appmtd.voucher = {3} AND (appmtd.site = '' OR appmtd.site IS NULL)", PBankCode, PCheckSeq, PVendNum, PVoucher),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var appmtd3LoadResponse = this.appDB.Load(appmtd3LoadRequest);
                if (appmtd3LoadResponse.Items.Count > 0)
                {
                    AppmtdRowPointer = _AppmtdRowPointer;
                    AppmtdBankCode = _AppmtdBankCode;
                    AppmtdVendNum = _AppmtdVendNum;
                    AppmtdVoucher = _AppmtdVoucher;
                    AppmtdCheckSeq = _AppmtdCheckSeq;
                }
                #endregion  LoadToVariable
            }
            if (AppmtdRowPointer != null)
            {
                Infobar = null;
                if (sQLUtil.SQLNotEqual(PType, "O") == true)
                {
                    #region CRUD ExecuteMethodCall

                    var MsgApp4 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                        , BaseMsg: "E=Exist5"
                        , Parm1: "@appmtd"
                        , Parm2: "@appmtd.bank_code"
                        , Parm3: PBankCode
                        , Parm4: "@appmtd.vend_num"
                        , Parm5: PVendNum
                        , Parm6: "@appmtd.check_seq"
                        , Parm7: convertToUtil.ToString(PCheckSeq)
                        , Parm8: "@appmtd.voucher"
                        , Parm9: convertToUtil.ToString(PVoucher)
                        , Parm10: "@appmtd.site"
                        , Parm11: PSite);
                    Severity = MsgApp4.ReturnCode;
                    Infobar = MsgApp4.Infobar;

                    #endregion ExecuteMethodCall
                }
                return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);//END

            }
            if (sQLUtil.SQLEqual(stringUtil.IsNull(VoucherHoldFlag, 0), 1) == true)
            {
                #region CRUD ExecuteMethodCall

                var MsgApp5 = this.iMsgApp.MsgAppSp(Infobar: Infobar
                    , BaseMsg: "I=IsCompare0"
                    , Parm1: "@ack.stat"
                    , Parm2: "@aptrxp.hold_flag"
                    , Parm3: "@aptrxp.voucher");
                Infobar = MsgApp5.Infobar;

                #endregion ExecuteMethodCall
            }
            return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);
        }

        public (int? ReturnCode,
            string PApplyVend,
            string PName,
            DateTime? PDueDate,
            string PGrnNum,
            decimal? ForAmtDisc,
            decimal? ForAmtPaid,
            decimal? DomAmtDisc,
            decimal? DomAmtPaid,
            decimal? ExchRate,
            string AptrxpCurrCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        AltExtGen_AppmtdValidateVoucherSp(
            string AltExtGenSp,
            string PType,
            int? PVoucher,
            string PSite,
            string PBankCode,
            string PVendNum,
            int? PCheckSeq,
            string PApplyVend,
            string PName,
            DateTime? PDueDate,
            string PGrnNum,
            decimal? ForAmtDisc,
            decimal? ForAmtPaid,
            decimal? DomAmtDisc,
            decimal? DomAmtPaid,
            decimal? ExchRate,
            string AptrxpCurrCode,
            string PromptMsg,
            string PromptButtons,
            string Infobar)
        {
            AppmtdTypeType _PType = PType;
            VoucherType _PVoucher = PVoucher;
            SiteType _PSite = PSite;
            BankCodeType _PBankCode = PBankCode;
            VendNumType _PVendNum = PVendNum;
            ApCheckSeqType _PCheckSeq = PCheckSeq;
            VendNumType _PApplyVend = PApplyVend;
            NameType _PName = PName;
            DateType _PDueDate = PDueDate;
            GrnNumType _PGrnNum = PGrnNum;
            AmountType _ForAmtDisc = ForAmtDisc;
            AmountType _ForAmtPaid = ForAmtPaid;
            AmountType _DomAmtDisc = DomAmtDisc;
            AmountType _DomAmtPaid = DomAmtPaid;
            ExchRateType _ExchRate = ExchRate;
            CurrCodeType _AptrxpCurrCode = AptrxpCurrCode;
            InfobarType _PromptMsg = PromptMsg;
            Infobar _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCheckSeq", _PCheckSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApplyVend", _PApplyVend, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PName", _PName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PDueDate", _PDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PGrnNum", _PGrnNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ForAmtDisc", _ForAmtDisc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ForAmtPaid", _ForAmtPaid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DomAmtDisc", _DomAmtDisc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DomAmtPaid", _DomAmtPaid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AptrxpCurrCode", _AptrxpCurrCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);




                PApplyVend = _PApplyVend;
                PName = _PName;
                PDueDate = _PDueDate;
                PGrnNum = _PGrnNum;
                ForAmtDisc = _ForAmtDisc;
                ForAmtPaid = _ForAmtPaid;
                DomAmtDisc = _DomAmtDisc;
                DomAmtPaid = _DomAmtPaid;
                ExchRate = _ExchRate;
                AptrxpCurrCode = _AptrxpCurrCode;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return (Severity, PApplyVend, PName, PDueDate, PGrnNum, ForAmtDisc, ForAmtPaid, DomAmtDisc, DomAmtPaid, ExchRate, AptrxpCurrCode, PromptMsg, PromptButtons, Infobar);
            }
        }
    }
}
