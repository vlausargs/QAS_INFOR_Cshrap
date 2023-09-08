//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ToBeShippedValue.cs

using System;
using CSI.Data;
using CSI.Data.CRUD;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Data.SQL;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Logistics.Vendor;
using CSI.DataCollection;
using CSI.Data.Utilities;
using CSI.Data.Cache;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.CRUD.Triggers;
using System.Diagnostics;

namespace CSI.Reporting
{
    public class Rpt_ToBeShippedValue : IRpt_ToBeShippedValue
    {
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IAddProcessErrorLog iAddProcessErrorLog;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IConvertToUtil convertToUtil;
        readonly IHighCharacter highCharacter;
        readonly ILowCharacter lowCharacter;
        readonly IGetSiteDate iGetSiteDate;
        readonly IUomConvAmt iUomConvAmt;
        readonly IUomConvQty iUomConvQty;
        readonly IStringUtil stringUtil;
        readonly IGetLabel iGetLabel;
        readonly ICurrCnvt iCurrCnvt;
        readonly IChkcred iChkcred;
        readonly IGetumcf iGetumcf;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IDefineVariable defineVariable;
        readonly IGetVariable getVariable;
        readonly int pageSize;
        readonly int recordCap;
        readonly LoadType loadType;
        readonly IRpt_ToBeShippedValueCRUD iRpt_ToBeShippedValueCRUD;

        public Rpt_ToBeShippedValue(
            IBunchedLoadCollection bunchedLoadCollection,
            IAddProcessErrorLog iAddProcessErrorLog,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IApplyDateOffset iApplyDateOffset,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IConvertToUtil convertToUtil,
            IHighCharacter highCharacter,
            ILowCharacter lowCharacter,
            IGetSiteDate iGetSiteDate,
            IUomConvAmt iUomConvAmt,
            IUomConvQty iUomConvQty,
            IStringUtil stringUtil,
            IGetLabel iGetLabel,
            ICurrCnvt iCurrCnvt,
            IChkcred iChkcred,
            IGetumcf iGetumcf,
            IMathUtil mathUtil,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IDefineProcessVariable defineProcessVariable,
            IDefineVariable defineVariable,
            IGetVariable getVariable,
            CachePageSize pageSize,
            IRpt_ToBeShippedValueCRUD iRpt_ToBeShippedValueCRUD)
        {
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.iAddProcessErrorLog = iAddProcessErrorLog;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.convertToUtil = convertToUtil;
            this.highCharacter = highCharacter;
            this.lowCharacter = lowCharacter;
            this.iGetSiteDate = iGetSiteDate;
            this.iUomConvAmt = iUomConvAmt;
            this.iUomConvQty = iUomConvQty;
            this.stringUtil = stringUtil;
            this.iGetLabel = iGetLabel;
            this.iCurrCnvt = iCurrCnvt;
            this.iChkcred = iChkcred;
            this.iGetumcf = iGetumcf;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.defineProcessVariable = defineProcessVariable;
            this.defineVariable = defineVariable;
            this.getVariable = getVariable;
            this.pageSize = Convert.ToInt32(pageSize);
            recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1)
            {
                recordCap = 200;
            }
            loadType = bunchedLoadCollection.LoadType;
            this.iRpt_ToBeShippedValueCRUD = iRpt_ToBeShippedValueCRUD;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_ToBeShippedValueSp(
            string pCoType = null,
            string pCoStat = null,
            string pCoitemStat = null,
            int? pTransDomCurr = null,
            int? pSortByCurrency = null,
            string pCreditHold = null,
            int? pDispSubTots = null,
            string pStartCoNum = null,
            string pEndCoNum = null,
            string pStartCustNum = null,
            string pEndCustNum = null,
            DateTime? pStartOrderDate = null,
            DateTime? pEndOrderDate = null,
            string pStartCustPo = null,
            string pEndCustPo = null,
            string pStartItem = null,
            string pEndItem = null,
            string pStartCustItem = null,
            string pEndCustItem = null,
            DateTime? pStartDueDate = null,
            DateTime? pEndDueDate = null,
            DateTime? pStartShipDate = null,
            DateTime? pEndShipDate = null,
            string pStartCurrCode = null,
            string pEndCurrCode = null,
            int? PrintCost = 0,
            int? PrintPrice = 0,
            int? DisplayHeader = null,
            string BGSessionId = null,
            int? TaskId = null,
            string pSite = null,
            string BGUser = null)
        {

            ICollectionLoadResponse Data = null;

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? rowCount = null;
                string LowChar = null;
                string HighChar = null;
                int? UnitQtyPlaces = null;
                string UnitQtyFormat = null;
                string ParmsSite = null;
                string CurrparmsCurrCode = null;
                string CurrparmsCurrDescription = null;
                DateTime? TDate = null;
                string CoCoNum = null;
                string CoCustNum = null;
                int? CoCustSeq = null;
                decimal? CoExchRate = null;
                decimal? CoDisc = null;
                string CoLcrNum = null;
                DateTime? CoOrderDate = null;
                Guid? CoRowPointer = null;
                int? CoCreditHold = null;
                string CoitemUM = null;
                string CoitemItem = null;
                string CoitemWhse = null;
                decimal? CoitemPriceConv = null;
                decimal? CoitemCost = null;
                decimal? CoitemQtyOrdered = null;
                decimal? CoitemQtyShipped = null;
                decimal? CoitemDisc = null;
                decimal? CoitemQtyInvoiced = null;
                string CoitemCoNum = null;
                int? CoitemCoLine = null;
                int? CoitemCoRelease = null;
                decimal? CoitemQtyOrderedConv = null;
                DateTime? CoitemDueDate = null;
                string CoitemStat = null;
                decimal? CoitemQtyReady = null;
                decimal? CoitemQtyRsvd = null;
                string CoitemRefType = null;
                string CoitemRefNum = null;
                Guid? CoitemRowPointer = null;
                string CoitemDescription = null;
                Guid? CustaddrRowPointer = null;
                string CoCurrCode = null;
                string CustaddrCustNum = null;
                int? CustaddrCustSeq = null;
                Guid? CustLcrRowPointer = null;
                DateTime? CustLcrExpDate = null;
                string CustLcrStat = null;
                string CustLcrCurrCode = null;
                int? CustLcrRevolv = null;
                decimal? CustLcrShipValue = null;
                decimal? CustLcrLcrAmt = null;
                string CustLcrCustNum = null;
                string CustLcrLcrNum = null;
                string CustCreditHold = null;
                Guid? ItemRowPointer = null;
                decimal? ItemMatlCost = null;
                decimal? ItemLbrCost = null;
                decimal? ItemFovhdCost = null;
                decimal? ItemVovhdCost = null;
                decimal? ItemOutCost = null;
                Guid? BCurrencyRowPointer = null;
                Guid? CustomerRowPointer = null;
                string CustomerCustNum = null;
                int? CustomerLcrReqd = null;
                string PrevCoNum = null;
                decimal? TToBeShipped = null;
                Guid? CurrencyRowPointer = null;
                string CurrencyCurrCode = null;
                string CurrencyDescription = null;
                int? Severity = null;
                string Area = null;
                DateTime? RateDate = null;
                string TDesc = null;
                decimal? TcCprItemPrice = null;
                decimal? TcAmtNetPrice = null;
                decimal? TcCprItemCost = null;
                decimal? TcQtuQtyInv = null;
                decimal? TcQtuQtyShp = null;
                decimal? TcQtuQtyRmn = null;
                decimal? TcAmtNetCost = null;
                decimal? TShipPrice = null;
                decimal? TRate = null;
                decimal? ConvFactor = null;
                string Infobar = null;
                int? TDone = null;
                string TErrMsg = null;
                string ErrorMsgNoLcrForCo = null;
                string ErrorMsgPastExpDate = null;
                string ErrorMsgStatusNotOpen = null;
                string ErrorMsgShippedGTLcrAmt = null;
                string WarnMsgPastExpDate = null;
                string WarnMsgStatusNotOpen = null;
                string WarnMsgShippedGTLcrAmt = null;
                int? CurrPlaces = null;
                Guid? TemplcrRowPointer = null;
                decimal? TemplcrShipValue = null;
                string Warning = null;
                string Error = null;
                string StatusNotOpen = null;
                string PastExpDate = null;
                string NoLcrForCo = null;
                string ShippedGTLcrAmt = null;
                int? IncludeNull = null;
                int? CoParmsUseAltPriceCalc = null;
                int? CostItemAtWhse = null;
                string DefaultWhse = null;
                if (this.iRpt_ToBeShippedValueCRUD.Optional_ModuleForExists())
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.iRpt_ToBeShippedValueCRUD.DeclareALTGEN();
                    this.iRpt_ToBeShippedValueCRUD.InsertOptional_Module();

                    while (this.iRpt_ToBeShippedValueCRUD.Tv_ALTGENForExists())
                    {
                        (ALTGEN_SpName, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadTv_ALTGEN(ALTGEN_SpName);
                        var ALTGEN = this.iRpt_ToBeShippedValueCRUD.AltExtGen_Rpt_ToBeShippedValueSp(ALTGEN_SpName,
                            pCoType,
                            pCoStat,
                            pCoitemStat,
                            pTransDomCurr,
                            pSortByCurrency,
                            pCreditHold,
                            pDispSubTots,
                            pStartCoNum,
                            pEndCoNum,
                            pStartCustNum,
                            pEndCustNum,
                            pStartOrderDate,
                            pEndOrderDate,
                            pStartCustPo,
                            pEndCustPo,
                            pStartItem,
                            pEndItem,
                            pStartCustItem,
                            pEndCustItem,
                            pStartDueDate,
                            pEndDueDate,
                            pStartShipDate,
                            pEndShipDate,
                            pStartCurrCode,
                            pEndCurrCode,
                            PrintCost,
                            PrintPrice,
                            DisplayHeader,
                            BGSessionId,
                            TaskId,
                            pSite,
                            BGUser);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }

                        this.iRpt_ToBeShippedValueCRUD.DeleteTv_ALTGEN(ALTGEN_SpName);
                    }

                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_ToBeShippedValueSp") != null)
                {
                    var EXTGEN = this.iRpt_ToBeShippedValueCRUD.AltExtGen_Rpt_ToBeShippedValueSp("dbo.EXTGEN_Rpt_ToBeShippedValueSp",
                        pCoType,
                        pCoStat,
                        pCoitemStat,
                        pTransDomCurr,
                        pSortByCurrency,
                        pCreditHold,
                        pDispSubTots,
                        pStartCoNum,
                        pEndCoNum,
                        pStartCustNum,
                        pEndCustNum,
                        pStartOrderDate,
                        pEndOrderDate,
                        pStartCustPo,
                        pEndCustPo,
                        pStartItem,
                        pEndItem,
                        pStartCustItem,
                        pEndCustItem,
                        pStartDueDate,
                        pEndDueDate,
                        pStartShipDate,
                        pEndShipDate,
                        pStartCurrCode,
                        pEndCurrCode,
                        PrintCost,
                        PrintPrice,
                        DisplayHeader,
                        BGSessionId,
                        TaskId,
                        pSite,
                        BGUser);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }


                this.iRpt_ToBeShippedValueCRUD.SetIsolationLevel();

                LowChar = convertToUtil.ToString(lowCharacter.LowCharacterFn());
                HighChar = convertToUtil.ToString(highCharacter.HighCharacterFn());
                PrevCoNum = "";
                TToBeShipped = 0;
                Severity = 0;
                (UnitQtyPlaces, UnitQtyFormat, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadUnitQtyFromInvparms(UnitQtyPlaces, UnitQtyFormat);
                UnitQtyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    UnitQtyFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                pCoType = stringUtil.IsNull(
                    pCoType,
                    "RB");
                pCoStat = stringUtil.IsNull(
                    pCoStat,
                    "POS");
                pCoitemStat = stringUtil.IsNull(
                    pCoitemStat,
                    "PO");
                pTransDomCurr = (int?)(stringUtil.IsNull(
                    pTransDomCurr,
                    1));
                pDispSubTots = (int?)(stringUtil.IsNull(
                    pDispSubTots,
                    1));
                pSortByCurrency = (int?)(stringUtil.IsNull(
                    pSortByCurrency,
                    0));
                pStartCoNum = stringUtil.IsNull(
                    this.iExpandKyByType.ExpandKyByTypeFn(
                        "CoNumType",
                        pStartCoNum),
                    LowChar);
                pEndCoNum = stringUtil.IsNull(
                    this.iExpandKyByType.ExpandKyByTypeFn(
                        "CoNumType",
                        pEndCoNum),
                    HighChar);
                pStartCustNum = stringUtil.IsNull(
                    this.iExpandKyByType.ExpandKyByTypeFn(
                        "CustNumType",
                        pStartCustNum),
                    LowChar);
                pEndCustNum = stringUtil.IsNull(
                    this.iExpandKyByType.ExpandKyByTypeFn(
                        "CustNumType",
                        pEndCustNum),
                    HighChar);
                pCreditHold = (sQLUtil.SQLEqual(pCreditHold, "Y") == true ? "C" : (sQLUtil.SQLEqual(pCreditHold, "N") == true ? "N" : ""));
                pStartCustPo = stringUtil.IsNull(
                    pStartCustPo,
                    LowChar);
                pEndCustPo = stringUtil.IsNull(
                    pEndCustPo,
                    HighChar);
                pStartItem = stringUtil.IsNull(
                    pStartItem,
                    LowChar);
                pEndItem = stringUtil.IsNull(
                    pEndItem,
                    HighChar);
                pStartCustItem = stringUtil.IsNull(
                    pStartCustItem,
                    LowChar);
                pEndCustItem = stringUtil.IsNull(
                    pEndCustItem,
                    HighChar);
                pStartCurrCode = stringUtil.IsNull(
                    pStartCurrCode,
                    LowChar);
                pEndCurrCode = stringUtil.IsNull(
                    pEndCurrCode,
                    HighChar);
                PrintCost = (int?)(stringUtil.IsNull(
                    PrintCost,
                    0));
                PrintPrice = (int?)(stringUtil.IsNull(
                    PrintPrice,
                    0));
                IncludeNull = (int?)((pStartShipDate == null ? 1 : 0));

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: pStartOrderDate,
                    Offset: null,
                    IsEndDate: 0);
                pStartOrderDate = ApplyDateOffset.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: pEndOrderDate,
                    Offset: null,
                    IsEndDate: 1);
                pEndOrderDate = ApplyDateOffset1.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset2 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: pStartDueDate,
                    Offset: null,
                    IsEndDate: 0);
                pStartDueDate = ApplyDateOffset2.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset3 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: pEndDueDate,
                    Offset: null,
                    IsEndDate: 1);
                pEndDueDate = ApplyDateOffset3.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset4 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: pStartShipDate,
                    Offset: null,
                    IsEndDate: 0);
                pStartShipDate = ApplyDateOffset4.Date;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                var ApplyDateOffset5 = this.iApplyDateOffset.ApplyDateOffsetSp(
                    Date: pEndShipDate,
                    Offset: null,
                    IsEndDate: 1);
                pEndShipDate = ApplyDateOffset5.Date;

                #endregion ExecuteMethodCall

                Warning = stringUtil.Concat(this.iGetLabel.GetLabelFn("@!warning"), " - ");
                Error = stringUtil.Concat(this.iGetLabel.GetLabelFn("@!error"), " - ");

                #region CRUD ExecuteMethodCall

                var MsgApp = this.iMsgApp.MsgAppSp(
                    Infobar: StatusNotOpen,
                    BaseMsg: "E=IsCompare<>",
                    Parm1: "@cust_lcr.stat",
                    Parm2: "@:LcrStatus:O");
                StatusNotOpen = MsgApp.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                var MsgApp1 = this.iMsgApp.MsgAppSp(
                    Infobar: PastExpDate,
                    BaseMsg: "I=IsCompareAfter0",
                    Parm1: "@co.lcr_num",
                    Parm2: "@cust_lcr.exp_date",
                    Parm3: "@cust_lcr");
                PastExpDate = MsgApp1.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                var MsgApp2 = this.iMsgApp.MsgAppSp(
                    Infobar: NoLcrForCo,
                    BaseMsg: "E=NoExistFor0",
                    Parm1: "@co.lcr_num",
                    Parm2: "@co");
                NoLcrForCo = MsgApp2.Infobar;

                #endregion ExecuteMethodCall

                #region CRUD ExecuteMethodCall

                var MsgApp3 = this.iMsgApp.MsgAppSp(
                    Infobar: ShippedGTLcrAmt,
                    BaseMsg: "E=NoCompare>",
                    Parm1: "@shipco.shipped",
                    Parm2: "@cust_lcr.lcr_amt");
                ShippedGTLcrAmt = MsgApp3.Infobar;

                #endregion ExecuteMethodCall

                ErrorMsgNoLcrForCo = stringUtil.Concat(Error, NoLcrForCo);
                ErrorMsgPastExpDate = stringUtil.Concat(Error, PastExpDate);
                ErrorMsgStatusNotOpen = stringUtil.Concat(Error, StatusNotOpen);
                ErrorMsgShippedGTLcrAmt = stringUtil.Concat(Error, ShippedGTLcrAmt);
                WarnMsgPastExpDate = stringUtil.Concat(Warning, PastExpDate);
                WarnMsgStatusNotOpen = stringUtil.Concat(Warning, StatusNotOpen);
                WarnMsgShippedGTLcrAmt = stringUtil.Concat(Warning, ShippedGTLcrAmt);
                RateDate = convertToUtil.ToDateTime(this.iGetSiteDate.GetSiteDateFn(scalarFunction.Execute<DateTime>("GETDATE")));
                TDate = convertToUtil.ToDateTime(RateDate);
                //this temp table is a table variable in old stored procedure version.
                this.iRpt_ToBeShippedValueCRUD.DeclareTempLcr();

                (CostItemAtWhse, DefaultWhse, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadWhseFromInvparms(CostItemAtWhse, DefaultWhse);
                (ParmsSite, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadParms(ParmsSite);
                (CurrparmsCurrCode, CurrparmsCurrDescription, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadCurrparms(CurrparmsCurrCode, CurrparmsCurrDescription);
                (CoParmsUseAltPriceCalc, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadCoparms(CoParmsUseAltPriceCalc);

                int seq = 1;
                int processRecordCount = 0;
                IRecordReadOnly previousRow = null;

                decimal? OrderTotalToBeShippedPrice = 0;
                decimal? OrderTotalCost = 0;
                decimal? TotalToBeShippedPriceByCurrency = 0;
                decimal? TotalOrderCostByCurrency = 0;
                decimal? TotalToBeShippedPrice = 0;
                decimal? TotalCost = 0;

                if (loadType == LoadType.Next)
                {
                    (int? returnCode0, string varValue, string bar) = getVariable.GetVariableSp("PreviousSeq", "0", 0, "", "");
                    seq = int.Parse(varValue);

                    (int? returnCode1, string varValue1, string bar1) = getVariable.GetVariableSp("OrderTotalToBeShippedPrice", "0", 0, "", "");
                    OrderTotalToBeShippedPrice = decimal.Parse(varValue1);

                    (int? returnCode2, string varValue2, string bar2) = getVariable.GetVariableSp("OrderTotalCost", "0", 0, "", "");
                    OrderTotalCost = decimal.Parse(varValue2);

                    (int? returnCode3, string varValue3, string bar3) = getVariable.GetVariableSp("TotalToBeShippedPriceByCurrency", "0", 0, "", "");
                    TotalToBeShippedPriceByCurrency = decimal.Parse(varValue3);

                    (int? returnCode4, string varValue4, string bar4) = getVariable.GetVariableSp("TotalOrderCostByCurrency", "0", 0, "", "");
                    TotalOrderCostByCurrency = decimal.Parse(varValue4);

                    (int? returnCode5, string varValue5, string bar5) = getVariable.GetVariableSp("TotalToBeShippedPrice", "0", 0, "", "");
                    TotalToBeShippedPrice = decimal.Parse(varValue5);

                    (int? returnCode6, string varValue6, string bar6) = getVariable.GetVariableSp("TotalCost", "0", 0, "", "");
                    TotalCost = decimal.Parse(varValue6);

                }

                var unionUtil = new UnionUtil(UnionType.UnionAll);
                using (IRecordStream sQLPagedRecordStream = this.iRpt_ToBeShippedValueCRUD.SelectCo(pageSize, loadType, pSortByCurrency, pTransDomCurr, pCoType, pCoStat, pCoitemStat, pStartCoNum, pEndCoNum, pStartCustNum, pEndCustNum, pStartOrderDate, pEndOrderDate, pStartCustPo, pEndCustPo, pStartItem, pEndItem, pStartCustItem, pEndCustItem, pStartDueDate, pEndDueDate, pStartShipDate, pEndShipDate, pStartCurrCode, pEndCurrCode, ParmsSite, IncludeNull, CostItemAtWhse))
                {
                    while (sQLPagedRecordStream.Read())
                    {
                        var toBeShippedItem = sQLPagedRecordStream.Current;

                        CurrencyRowPointer = toBeShippedItem.GetValue<Guid?>(0);
                        CurrencyCurrCode = toBeShippedItem.GetValue<string>(1);
                        CurrencyDescription = toBeShippedItem.GetValue<string>(2);
                        CurrPlaces = toBeShippedItem.GetValue<int?>(3);
                        CustaddrRowPointer = toBeShippedItem.GetValue<Guid?>(4);
                        CoCurrCode = toBeShippedItem.GetValue<string>(5);
                        CustaddrCustNum = toBeShippedItem.GetValue<string>(6);
                        CustaddrCustSeq = toBeShippedItem.GetValue<int?>(7);
                        CoCoNum = toBeShippedItem.GetValue<string>(8);
                        CoCustNum = toBeShippedItem.GetValue<string>(9);
                        CoCustSeq = toBeShippedItem.GetValue<int?>(10);
                        CoExchRate = toBeShippedItem.GetValue<decimal?>(11);
                        CoDisc = toBeShippedItem.GetValue<decimal?>(12);
                        CoLcrNum = toBeShippedItem.GetValue<string>(13);
                        CoOrderDate = toBeShippedItem.GetValue<DateTime?>(14);
                        CoRowPointer = toBeShippedItem.GetValue<Guid?>(15);
                        CoCreditHold = toBeShippedItem.GetValue<int?>(16);
                        CoitemUM = toBeShippedItem.GetValue<string>(17);
                        CoitemItem = toBeShippedItem.GetValue<string>(18);
                        CoitemWhse = toBeShippedItem.GetValue<string>(19);
                        CoitemPriceConv = toBeShippedItem.GetValue<decimal?>(20);
                        CoitemCost = toBeShippedItem.GetValue<decimal?>(21);
                        CoitemQtyOrdered = toBeShippedItem.GetValue<decimal?>(22);
                        CoitemQtyShipped = toBeShippedItem.GetValue<decimal?>(23);
                        CoitemDisc = toBeShippedItem.GetValue<decimal?>(24);
                        CoitemQtyInvoiced = toBeShippedItem.GetValue<decimal?>(25);
                        CoitemCoNum = toBeShippedItem.GetValue<string>(26);
                        CoitemCoLine = toBeShippedItem.GetValue<int?>(27);
                        CoitemCoRelease = toBeShippedItem.GetValue<int?>(28);
                        CoitemQtyOrderedConv = toBeShippedItem.GetValue<decimal?>(29);
                        CoitemDueDate = toBeShippedItem.GetValue<DateTime?>(30);
                        CoitemStat = toBeShippedItem.GetValue<string>(31);
                        CoitemRowPointer = toBeShippedItem.GetValue<Guid?>(32);
                        CoitemDescription = toBeShippedItem.GetValue<string>(33);
                        CoitemQtyRsvd = toBeShippedItem.GetValue<decimal?>(34);
                        CoitemRefType = toBeShippedItem.GetValue<string>(35);
                        CoitemRefNum = toBeShippedItem.GetValue<string>(36);
                        CustLcrRowPointer = toBeShippedItem.GetValue<Guid?>(37);
                        CustLcrExpDate = toBeShippedItem.GetValue<DateTime?>(38);
                        CustLcrStat = toBeShippedItem.GetValue<string>(39);
                        CustLcrCurrCode = toBeShippedItem.GetValue<string>(40);
                        CustLcrRevolv = toBeShippedItem.GetValue<int?>(41);
                        CustLcrShipValue = toBeShippedItem.GetValue<decimal?>(42);
                        CustLcrLcrAmt = toBeShippedItem.GetValue<decimal?>(43);
                        CustLcrCustNum = toBeShippedItem.GetValue<string>(44);
                        CustLcrLcrNum = toBeShippedItem.GetValue<string>(45);
                        CustomerRowPointer = toBeShippedItem.GetValue<Guid?>(46);
                        CustomerCustNum = toBeShippedItem.GetValue<string>(47);
                        CustomerLcrReqd = toBeShippedItem.GetValue<int?>(48);
                        CoitemQtyReady = toBeShippedItem.GetValue<decimal?>(49);
                        ItemRowPointer = toBeShippedItem.GetValue<Guid?>(50);
                        ItemMatlCost = toBeShippedItem.GetValue<decimal?>(51);
                        ItemLbrCost = toBeShippedItem.GetValue<decimal?>(52);
                        ItemFovhdCost = toBeShippedItem.GetValue<decimal?>(53);
                        ItemVovhdCost = toBeShippedItem.GetValue<decimal?>(54);
                        ItemOutCost = toBeShippedItem.GetValue<decimal?>(55);
                        BCurrencyRowPointer = toBeShippedItem.GetValue<Guid?>(56);

                        if (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                pCreditHold,
                                "CN"), 0) == true)
                        {

                            #region CRUD ExecuteMethodCall

                            //Please Generate the bounce for this stored procedure: ChkcredSp
                            var Chkcred = this.iChkcred.ChkcredSp(
                                CustNum: CustaddrCustNum,
                                CredHold: CustCreditHold);
                            CustCreditHold = Chkcred.CredHold;

                            #endregion ExecuteMethodCall

                            if (sQLUtil.SQLEqual(((CustCreditHold == null ? "N" : "C")), "C") == true && sQLUtil.SQLEqual(pCreditHold, "N") == true)
                            {

                                continue;

                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(((CustCreditHold == null ? "N" : "C")), "N") == true && sQLUtil.SQLEqual(pCreditHold, "N") == true && sQLUtil.SQLEqual(CoCreditHold, 1) == true)
                                {

                                    continue;

                                }
                                else
                                {
                                    if (sQLUtil.SQLEqual(((CustCreditHold == null ? "N" : "C")), "N") == true && sQLUtil.SQLEqual(pCreditHold, "C") == true && sQLUtil.SQLEqual(CoCreditHold, 0) == true)
                                    {

                                        continue;

                                    }

                                }

                            }

                        }
                        if (sQLUtil.SQLNotEqual(CoCoNum, PrevCoNum) == true)
                        {
                            TToBeShipped = 0;
                            PrevCoNum = CoCoNum;

                        }
                        Severity = 0;
                        Area = "C";
                        TDesc = CoitemDescription;

                        #region CRUD ExecuteMethodCall
                        //Please Generate the bounce for this stored procedure: GetumcfSp
                        var Getumcf = this.iGetumcf.GetumcfSp(
                            OtherUM: CoitemUM,
                            Item: CoitemItem,
                            VendNum: CoCustNum,
                            Area: Area,
                            ConvFactor: ConvFactor,
                            Infobar: Infobar,
                            Site: ParmsSite);
                        Severity = Getumcf.ReturnCode;
                        ConvFactor = Getumcf.ConvFactor;
                        Infobar = Getumcf.Infobar;
                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            goto END_OF_PROG;

                        }
                        TcCprItemPrice = CoitemPriceConv;
                        if (CoitemCost == null && ItemRowPointer != null)
                        {
                            TcCprItemCost = (decimal?)(ItemMatlCost + ItemLbrCost + ItemFovhdCost + ItemVovhdCost + ItemOutCost);

                        }
                        else
                        {
                            TcCprItemCost = 0;

                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: UomConvAmtSp
                        TcCprItemCost = this.iUomConvAmt.UomConvAmtFn(
                            AmtToBeConverted: CoitemCost,
                            UomConvFactor: ConvFactor,
                            FromBase: "From Base");
                        

                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLBool(sQLUtil.SQLNot(this.iRpt_ToBeShippedValueCRUD.ItemForExists(Severity, CoitemCost, ConvFactor, TcCprItemCost, Infobar, CoitemItem))))
                        {
                            TcCprItemCost = 0;

                        }
                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            goto END_OF_PROG;

                        }
                        if (sQLUtil.SQLEqual(pTransDomCurr, 1) == true)
                        {
                            TRate = CoExchRate;

                            #region CRUD ExecuteMethodCall

                            //Please Generate the bounce for this stored procedure: CurrCnvtSp
                            var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
                                CurrCode: CoCurrCode,
                                FromDomestic: 0,
                                UseBuyRate: 0,
                                RoundResult: 0,
                                Date: RateDate,
                                RoundPlaces: CurrPlaces,
                                UseCustomsAndExciseRates: 0,
                                ForceRate: null,
                                FindTTFixed: null,
                                TRate: TRate,
                                Infobar: Infobar,
                                Amount1: CoitemPriceConv,
                                Result1: TcCprItemPrice,
                                Site: ParmsSite);
                            Severity = CurrCnvt.ReturnCode;
                            TRate = CurrCnvt.TRate;
                            Infobar = CurrCnvt.Infobar;
                            TcCprItemPrice = CurrCnvt.Result1;

                            #endregion ExecuteMethodCall

                            if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                            {
                                goto END_OF_PROG;

                            }

                        }
                        TcQtuQtyRmn = (decimal?)(CoitemQtyOrdered - CoitemQtyShipped);

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: UomConvQtySp
                        TcQtuQtyRmn = this.iUomConvQty.UomConvQtyFn(
                            QtyToBeConverted: TcQtuQtyRmn,
                            UomConvFactor: ConvFactor,
                            FromBase: "From Base");

                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            goto END_OF_PROG;

                        }
                        TcAmtNetPrice = (decimal?)(((sQLUtil.SQLEqual(CoParmsUseAltPriceCalc, 1) == true ? mathUtil.Round<decimal?>(TcCprItemPrice * (1M - CoitemDisc / 100M), CurrPlaces) * TcQtuQtyRmn * (1M - CoDisc / 100M) : TcQtuQtyRmn * TcCprItemPrice * (1M - CoitemDisc / 100M) * (1M - CoDisc / 100M))));

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: UomConvQtySp
                        TcQtuQtyInv = this.iUomConvQty.UomConvQtyFn(
                            QtyToBeConverted: CoitemQtyInvoiced,
                            UomConvFactor: ConvFactor,
                            FromBase: "From Base");
                       
                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            goto END_OF_PROG;

                        }

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: UomConvQtySp
                        TcQtuQtyShp = this.iUomConvQty.UomConvQtyFn(
                            QtyToBeConverted: CoitemQtyShipped,
                            UomConvFactor: ConvFactor,
                            FromBase: "From Base");                     
                        #endregion ExecuteMethodCall

                        if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                        {
                            goto END_OF_PROG;

                        }
                        TcAmtNetCost = (decimal?)(TcQtuQtyRmn * TcCprItemCost);
                        TToBeShipped = (decimal?)(TToBeShipped + TcAmtNetPrice);
                        TErrMsg = "";
                        TDone = 0;
                        while (sQLUtil.SQLEqual(TDone, 0) == true)
                        {
                            if (CustomerRowPointer == null || CustaddrRowPointer == null || BCurrencyRowPointer == null)
                            {

                                break;

                            }
                            if (CustLcrRowPointer == null)
                            {
                                if (sQLUtil.SQLEqual(CustomerLcrReqd, 1) == true)
                                {
                                    TErrMsg = ErrorMsgNoLcrForCo;

                                    break;

                                }

                                break;

                            }
                            if (sQLUtil.SQLLessThan(CustLcrExpDate, TDate) == true)
                            {
                                if (sQLUtil.SQLEqual(CustomerLcrReqd, 1) == true)
                                {
                                    TErrMsg = ErrorMsgPastExpDate;

                                    break;

                                }
                                else
                                {
                                    TErrMsg = WarnMsgPastExpDate;

                                    break;

                                }

                            }
                            if (sQLUtil.SQLNotEqual(CustLcrStat, "O") == true)
                            {
                                if (sQLUtil.SQLEqual(CustomerLcrReqd, 1) == true)
                                {
                                    TErrMsg = ErrorMsgStatusNotOpen;

                                    break;

                                }
                                else
                                {
                                    TErrMsg = WarnMsgStatusNotOpen;

                                    break;

                                }

                            }
                            if (sQLUtil.SQLEqual(pTransDomCurr, 1) == true && sQLUtil.SQLNotEqual(CurrparmsCurrCode, CustLcrCurrCode) == true && sQLUtil.SQLEqual(CustLcrCurrCode, CoCurrCode) == true)
                            {
                                TRate = CoExchRate;

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(
                                    CurrCode: CoCurrCode,
                                    FromDomestic: 1,
                                    UseBuyRate: 0,
                                    RoundResult: 0,
                                    Date: RateDate,
                                    RoundPlaces: CurrPlaces,
                                    UseCustomsAndExciseRates: 0,
                                    ForceRate: null,
                                    FindTTFixed: null,
                                    TRate: TRate,
                                    Infobar: Infobar,
                                    Amount1: TToBeShipped,
                                    Result1: TToBeShipped,
                                    Site: ParmsSite);
                                Severity = CurrCnvt1.ReturnCode;
                                TRate = CurrCnvt1.TRate;
                                Infobar = CurrCnvt1.Infobar;
                                TToBeShipped = CurrCnvt1.Result1;

                                #endregion ExecuteMethodCall

                                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                {
                                    goto END_OF_PROG;

                                }

                            }
                            if (sQLUtil.SQLEqual(pTransDomCurr, 0) == true && sQLUtil.SQLNotEqual(CustLcrCurrCode, CoCurrCode) == true)
                            {
                                TRate = CoExchRate;

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                var CurrCnvt2 = this.iCurrCnvt.CurrCnvtSp(
                                    CurrCode: CoCurrCode,
                                    FromDomestic: 0,
                                    UseBuyRate: 0,
                                    RoundResult: 0,
                                    Date: RateDate,
                                    RoundPlaces: CurrPlaces,
                                    UseCustomsAndExciseRates: 0,
                                    ForceRate: null,
                                    FindTTFixed: null,
                                    TRate: TRate,
                                    Infobar: Infobar,
                                    Amount1: TToBeShipped,
                                    Result1: TToBeShipped,
                                    Site: ParmsSite);
                                Severity = CurrCnvt2.ReturnCode;
                                TRate = CurrCnvt2.TRate;
                                Infobar = CurrCnvt2.Infobar;
                                TToBeShipped = CurrCnvt2.Result1;

                                #endregion ExecuteMethodCall

                                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                {
                                    goto END_OF_PROG;

                                }

                            }
                            TShipPrice = TToBeShipped;
                            if (sQLUtil.SQLEqual(CustLcrRevolv, 1) == true)
                            {
                                (TemplcrRowPointer, TemplcrShipValue, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadTv_Templcr(CoCustNum, CoLcrNum, TemplcrRowPointer, TemplcrShipValue);
                                if (rowCount == 1)
                                {
                                    TemplcrRowPointer = null;

                                }
                                if ((TemplcrRowPointer != null))
                                {
                                    TShipPrice = (decimal?)(TemplcrShipValue + TToBeShipped);

                                }

                            }
                            if (sQLUtil.SQLGreaterThan(TShipPrice + CustLcrShipValue, CustLcrLcrAmt) == true)
                            {
                                if (sQLUtil.SQLEqual(CustomerLcrReqd, 1) == true)
                                {
                                    TErrMsg = ErrorMsgShippedGTLcrAmt;

                                    break;

                                }
                                else
                                {
                                    TErrMsg = WarnMsgShippedGTLcrAmt;

                                    break;

                                }

                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(CustLcrRevolv, 1) == true)
                                {
                                    (TemplcrRowPointer, TemplcrShipValue, rowCount) = this.iRpt_ToBeShippedValueCRUD.LoadTv_Templcr(CoCustNum, CoLcrNum, TemplcrRowPointer, TemplcrShipValue);
                                    if (rowCount == 1)
                                    {
                                        TemplcrRowPointer = null;

                                    }
                                    if ((TemplcrRowPointer != null))
                                    {
                                        TemplcrShipValue = (decimal?)(TemplcrShipValue + TToBeShipped);

                                    }
                                    else
                                    {
                                        this.iRpt_ToBeShippedValueCRUD.InsertLcrNontable(CustLcrCustNum, CustLcrLcrNum, TToBeShipped);

                                    }

                                }

                            }
                            TDone = 1;

                        }
                        if (sQLUtil.SQLEqual(PrintPrice, 0) == true)
                        {
                            TcCprItemPrice = 0;
                            TcAmtNetPrice = 0;

                        }
                        if (sQLUtil.SQLEqual(PrintCost, 0) == true)
                        {
                            TcCprItemCost = 0;
                            TcAmtNetCost = 0;

                        }
                        if (sQLUtil.SQLEqual(pTransDomCurr, 1) == true)
                        {
                            CurrencyCurrCode = CurrparmsCurrCode;
                            CurrencyDescription = CurrparmsCurrDescription;

                        }

                        var nonTable1LoadResponse = this.iRpt_ToBeShippedValueCRUD.SelectReportSetNontable(pSortByCurrency, seq, 0, 0, CoitemCoNum, CoOrderDate, CoitemCoLine, CoitemCoRelease, CoitemItem, CoDisc, CoitemQtyOrderedConv, TcQtuQtyInv, TcCprItemPrice, CoitemDisc, TcAmtNetPrice, CoitemDueDate, CoitemStat, TDesc, TcQtuQtyShp, TcQtuQtyRmn, TcCprItemCost, CoitemUM, TcAmtNetCost, CurrencyCurrCode, CurrencyDescription, TErrMsg, UnitQtyPlaces, UnitQtyFormat, pSortByCurrency == 1 ? CurrencyCurrCode : CoitemCoNum);
                        unionUtil.Add(nonTable1LoadResponse);
                        seq += 1;
                        processRecordCount += 1;

                        if (recordCap != 0 && processRecordCount > recordCap)
                        {
                            break;
                        }

                        previousRow = toBeShippedItem;
                    }
                }

            //Deallocate Cursor @ToBeShipped_crs
            END_OF_PROG:;
                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    Infobar = stringUtil.IsNull(Infobar, "");
                    if (TaskId != null)
                    {

                        #region CRUD ExecuteMethodCall

                        //Please Generate the bounce for this stored procedure: AddProcessErrorLogSp
                        var AddProcessErrorLog = this.iAddProcessErrorLog.AddProcessErrorLogSp(
                            ProcessID: TaskId,
                            InfobarText: Infobar,
                            MessageSeverity: Severity);

                        #endregion ExecuteMethodCall

                    }
                    /*Clear all records when error occur*/
                    unionUtil.Clear();
                    processRecordCount = 0;
                }

                Data = unionUtil.Process();
                if (processRecordCount > 0)
                {
                    if (pSortByCurrency == 1)
                    {
                        for (int i = 0; i < Data.Items.Count - 1; i++)
                        {
                            var dataItem = Data.Items[i];
                            string currColumnValue = dataItem.GetValue<string>("curr_code");
                            string nextCurrColumnValue = Data.Items[i + 1].GetValue<string>("curr_code");

                            string coColumnValue = dataItem.GetValue<string>("co_num");
                            string nextCoColumnValue = Data.Items[i + 1].GetValue<string>("co_num");

                            var tempErrMsg = dataItem.GetValue<string>("err_msg");
                            if (tempErrMsg == null || tempErrMsg.Equals(""))
                            {
                                TotalToBeShippedPrice += dataItem.GetValue<decimal?>("Amt_Net_Price");
                                TotalCost += dataItem.GetValue<decimal?>("net_item_cost");

                                OrderTotalToBeShippedPrice += dataItem.GetValue<decimal?>("Amt_Net_Price");
                                OrderTotalCost += dataItem.GetValue<decimal?>("net_item_cost");

                                TotalToBeShippedPriceByCurrency += dataItem.GetValue<decimal?>("Amt_Net_Price");
                                TotalOrderCostByCurrency += dataItem.GetValue<decimal?>("net_item_cost");
                            }

                            if (!currColumnValue.Equals(nextCurrColumnValue))
                            {
                                dataItem.SetValue<decimal?>("TotalToBeShippedPriceByCurrency", TotalToBeShippedPriceByCurrency);
                                dataItem.SetValue<decimal?>("TotalOrderCostByCurrency", TotalOrderCostByCurrency);
                                TotalToBeShippedPriceByCurrency = 0;
                                TotalOrderCostByCurrency = 0;
                            }

                            if (!coColumnValue.Equals(nextCoColumnValue))
                            {
                                dataItem.SetValue<decimal?>("OrderTotalToBeShippedPrice", OrderTotalToBeShippedPrice);
                                dataItem.SetValue<decimal?>("OrderTotalCost", OrderTotalCost);
                                OrderTotalToBeShippedPrice = 0;
                                OrderTotalCost = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < Data.Items.Count - 1; i++)
                        {
                            var dataItem = Data.Items[i];

                            string coColumnValue = dataItem.GetValue<string>("co_num");
                            string nextCoColumnValue = Data.Items[i + 1].GetValue<string>("co_num");

                            var tempErrMsg = dataItem.GetValue<string>("err_msg");
                            if (tempErrMsg == null || tempErrMsg.Equals(""))
                            {
                                TotalToBeShippedPrice += dataItem.GetValue<decimal?>("Amt_Net_Price");
                                TotalCost += dataItem.GetValue<decimal?>("net_item_cost");

                                OrderTotalToBeShippedPrice += dataItem.GetValue<decimal?>("Amt_Net_Price");
                                OrderTotalCost += dataItem.GetValue<decimal?>("net_item_cost");

                                TotalToBeShippedPriceByCurrency += dataItem.GetValue<decimal?>("Amt_Net_Price");
                                TotalOrderCostByCurrency += dataItem.GetValue<decimal?>("net_item_cost");
                            }


                            if (!coColumnValue.Equals(nextCoColumnValue))
                            {
                                dataItem.SetValue<decimal?>("OrderTotalToBeShippedPrice", OrderTotalToBeShippedPrice);
                                dataItem.SetValue<decimal?>("OrderTotalCost", OrderTotalCost);
                                dataItem.SetValue<decimal?>("TotalToBeShippedPriceByCurrency", TotalToBeShippedPriceByCurrency);
                                dataItem.SetValue<decimal?>("TotalOrderCostByCurrency", TotalOrderCostByCurrency);
                                OrderTotalToBeShippedPrice = 0;
                                OrderTotalCost = 0;
                                TotalToBeShippedPriceByCurrency = 0;
                                TotalOrderCostByCurrency = 0;
                            }
                        }
                    }

                    if (recordCap != 0 && processRecordCount > recordCap)
                    {

                        defineVariable.DefineVariableSp("TotalToBeShippedPriceByCurrency", TotalToBeShippedPriceByCurrency.ToString(), null);
                        defineVariable.DefineVariableSp("TotalOrderCostByCurrency", TotalOrderCostByCurrency.ToString(), null);

                        defineVariable.DefineVariableSp("OrderTotalToBeShippedPrice", OrderTotalToBeShippedPrice.ToString(), null);
                        defineVariable.DefineVariableSp("OrderTotalCost", OrderTotalCost.ToString(), null);

                        defineVariable.DefineVariableSp("TotalToBeShippedPrice", TotalToBeShippedPrice.ToString(), null);
                        defineVariable.DefineVariableSp("TotalCost", TotalCost.ToString(), null);
                        this.iRpt_ToBeShippedValueCRUD.InsertBookmark(previousRow);
                    }
                    else
                    {
                        var lastErrMsgFlag = Data.Items[processRecordCount - 1].GetValue<string>("err_msg") == null || Data.Items[processRecordCount - 1].GetValue<string>("err_msg").Equals("");
                        var lastAmtNetPrice = lastErrMsgFlag ? Data.Items[processRecordCount - 1].GetValue<decimal>("Amt_Net_Price") : 0;
                        var lastNetItemCost = lastErrMsgFlag ? Data.Items[processRecordCount - 1].GetValue<decimal>("net_item_cost") : 0;

                        Data.Items[processRecordCount - 1].SetValue<decimal?>("TotalToBeShippedPrice", TotalToBeShippedPrice + lastAmtNetPrice);
                        Data.Items[processRecordCount - 1].SetValue<decimal?>("TotalCost", TotalCost + lastNetItemCost);

                        Data.Items[processRecordCount - 1].SetValue<decimal?>("TotalToBeShippedPriceByCurrency", TotalToBeShippedPriceByCurrency + lastAmtNetPrice);
                        Data.Items[processRecordCount - 1].SetValue<decimal?>("TotalOrderCostByCurrency", TotalOrderCostByCurrency + lastNetItemCost);
                        Data.Items[processRecordCount - 1].SetValue<decimal?>("OrderTotalToBeShippedPrice", OrderTotalToBeShippedPrice + lastAmtNetPrice);
                        Data.Items[processRecordCount - 1].SetValue<decimal?>("OrderTotalCost", OrderTotalCost + lastNetItemCost);
                    }

                    defineVariable.DefineVariableSp("PreviousSeq", seq.ToString(), null);
                    if (recordCap > 0 && processRecordCount > recordCap)
                    {
                        defineProcessVariable.DefineProcessVariableSp("RecordCap", (Data.Items.Count - 1).ToString(), null);
                        (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp(Enum.GetName(typeof(SQLPagedRecordStreamBookmarkID), SQLPagedRecordStreamBookmarkID.MyReport_Rpt), "", 0, "", "");
                        defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                    }
                }
                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

    }
}
