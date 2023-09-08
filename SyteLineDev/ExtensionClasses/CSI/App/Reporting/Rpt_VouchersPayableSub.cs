using System;
using CSI.MG;
using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using System.Collections.Generic;
using CSI.Data.Functions;
using CSI.Data.SQL;
using CSI.Material;
using CSI.Logistics.Vendor;
using CSI.DataCollection;
using CSI.Data.Cache;
using CSI.Data.Utilities;
using CSI.Logistics.Customer;
using CSI.MG.MGCore;
using CSI.CRUD.Reporting;
using System.Linq;

namespace CSI.Reporting
{
    public class Rpt_VouchersPayableSub : IRpt_VouchersPayableSub
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IStringUtil stringUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IExpandKyByType iExpandKyByType;
        readonly IMathUtil mathUtil;
        readonly ICurrCnvt iCurrCnvt;
        readonly IGetumcf iGetumcf;
        readonly IUomConvQty iUomConvQty;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IMsgApp iMsgApp;
        readonly IUnionUtil unionUtil;
        readonly IQueryLanguage queryLanguage;
        readonly ISessionBasedCache mgSessionVariableBasedCache;
        readonly LoadType loadType;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ISortOrderFactory sortOrderFactory;
        readonly ILowCharacter lowCharacter;
        readonly IHighCharacter highCharacter;
        readonly ILowString lowString;
        readonly IHighString highString;
        readonly IRpt_VouchersPayableSubCRUD rpt_VouchersPayableSubCRUD;
        readonly ISessionBasedCache sessionBasedCache;

        public Rpt_VouchersPayableSub(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IStringUtil stringUtil,
            ISQLValueComparerUtil sQLUtil,
            IExpandKyByType iExpandKyByType,
            IMathUtil mathUtil,
            ICurrCnvt iCurrCnvt,
            IGetumcf iGetumcf,
            IUomConvQty iUomConvQty,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IMsgApp iMsgApp,
            IUnionUtil unionUtil,
            IRecordStreamFactory recordStreamFactory,
            ISortOrderFactory sortOrderFactory,
            IQueryLanguage queryLanguage,
            ISessionBasedCache mgSessionVariableBasedCache,
            ILowCharacter lowCharacter,
            IHighCharacter highCharacter,
            ILowString lowString,
            IHighString highString,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            IRpt_VouchersPayableSubCRUD rpt_VouchersPayableSubCRUD,
            ISessionBasedCache sessionBasedCache)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.stringUtil = stringUtil;
            this.sQLUtil = sQLUtil;
            this.iExpandKyByType = iExpandKyByType;
            this.mathUtil = mathUtil;
            this.iCurrCnvt = iCurrCnvt;
            this.iGetumcf = iGetumcf;
            this.iUomConvQty = iUomConvQty;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iMsgApp = iMsgApp;
            this.unionUtil = unionUtil;
            this.queryLanguage = queryLanguage;
            this.recordStreamFactory = recordStreamFactory;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.sortOrderFactory = sortOrderFactory;
            this.lowCharacter = lowCharacter;
            this.highCharacter = highCharacter;
            this.lowString = lowString;
            this.highString = highString;
            this.rpt_VouchersPayableSubCRUD = rpt_VouchersPayableSubCRUD;
            this.loadType = bunchedLoadCollection.LoadType;
            this.sessionBasedCache = sessionBasedCache;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_VouchersPayableSubSp(string POType = null,
            int? TransDomCurr = null,
            int? ShowDetail = null,
            DateTime? CutoffDate = null,
            string PoStarting = null,
            string PoEnding = null,
            string VendorStarting = null,
            string VendorEnding = null,
            int? CutoffDateOffset = null,
            int? DisplayHeader = null,
            string SiteGroup = null,
            string BuilderPoStarting = null,
            string BuilderPoEnding = null,
            string BGSessionId = null,
            int? TaskId = null,
            string Infobar = null,
            int? PrintItemOverview = null,
            int? UseSite = 0,
            int? recordCapOverwrite = null)
        {
            Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
            dicSortOrder.Add("po_all.site_ref", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_all.builder_po_orig_site", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_all.builder_po_num", SortOrderDirection.Ascending);
            dicSortOrder.Add("poitem_all.po_num", SortOrderDirection.Ascending);
            dicSortOrder.Add("poitem_all.po_line", SortOrderDirection.Ascending);
            dicSortOrder.Add("poitem_all.po_release", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_vch_all.type", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_vch_all.rcvd_date", SortOrderDirection.Ascending);
            dicSortOrder.Add("po_vch_all.date_seq", SortOrderDirection.Ascending);
            ISortOrder poVchSortOrder = sortOrderFactory.Create(dicSortOrder);

            int pageSize = Convert.ToInt32(CachePageSize.XLarge);
            int recordCap = this.bunchedLoadCollection.RecordCap;
            if (recordCap == -1) recordCap = 200;
            if (recordCap == 0) recordCap = int.MaxValue - 1;
            if (recordCapOverwrite != null)
                recordCap = (int)recordCapOverwrite;

            int processedRowCount = 0;
            SiteGroupType _SiteGroup = SiteGroup;
            ICollectionLoadResponse Data = null;

            StringType _ALTGEN_SpName = DBNull.Value;
            string LowCharacterValue = null;
            string HighCharacterValue = null;
            int? IncludeNull = null;
            string SiteGroupSite = null;
            int? FirstDetailRecFlag = null;
            int? Severity = null;
            decimal? ConvertedQty = null;
            string PoitemDescription = null;
            string PoitemItem = null;
            int? PoitemPoLine = null;
            int? PoitemPoRelease = null;
            string PoitemUM = null;
            string PoNum = null;
            int? PoVchDateSeq = null;
            decimal? PoVchExchRate = null;
            string PoVchGrnNum = null;
            decimal? PoVchItemCost = null;
            string PoVchPackNum = null;
            DateTime? PoVchRcvdDate = null;
            decimal? PoVchQtyReceived = null;
            decimal? PoVchQtyReturned = null;
            decimal? PoVchQtyVouchered = null;
            string PoVchType = null;
            string PoVendNum = null;
            DateTime? RateDate = null;
            decimal? TcAmtAmtWriteOff = null;
            AmountType _TcAmtBrokerage2 = DBNull.Value;
            decimal? TcAmtBrokerage2 = null;
            AmountType _TcAmtBrokerage = DBNull.Value;
            decimal? TcAmtBrokerage = null;
            AmountType _TcAmtBrokerageToVoucher = DBNull.Value;
            decimal? TcAmtBrokerageToVoucher = null;
            AmountType _TcAmtInsurance2 = DBNull.Value;
            decimal? TcAmtInsurance2 = null;
            AmountType _TcAmtInsurance = DBNull.Value;
            decimal? TcAmtInsurance = null;
            AmountType _TcAmtInsuranceToVoucher = DBNull.Value;
            decimal? TcAmtInsuranceToVoucher = null;
            AmountType _TcAmtLocFrt2 = DBNull.Value;
            decimal? TcAmtLocFrt2 = null;
            AmountType _TcAmtLocFrt = DBNull.Value;
            decimal? TcAmtLocFrt = null;
            AmountType _TcAmtLocFrtToVoucher = DBNull.Value;
            decimal? TcAmtLocFrtToVoucher = null;
            AmountType _TcAmtDuty2 = DBNull.Value;
            decimal? TcAmtDuty2 = null;
            AmountType _TcAmtDuty = DBNull.Value;
            decimal? TcAmtDuty = null;
            AmountType _TcAmtDutyToVoucher = DBNull.Value;
            decimal? TcAmtDutyToVoucher = null;
            AmountType _TcAmtFreight2 = DBNull.Value;
            decimal? TcAmtFreight2 = null;
            AmountType _TcAmtFreight = DBNull.Value;
            decimal? TcAmtFreight = null;
            AmountType _TcAmtFreightToVoucher = DBNull.Value;
            decimal? TcAmtFreightToVoucher = null;
            decimal? TcAmtReceivedCost = null;
            decimal? TcAmtVoucheredCost = null;
            decimal? TcAmtReturnedCost = null;
            decimal? TcAmtAdjustedCost = null;
            decimal? TcCprItemCost = null;
            decimal? TcQttTotToVoucher = null;
            decimal? TcQtuQuantity = null;
            AmountType _TcTotBrokVouch = DBNull.Value;
            decimal? TcTotBrokVouch = null;
            AmountType _TcTotDutyVouch = DBNull.Value;
            decimal? TcTotDutyVouch = null;
            AmountType _TcTotFreightVouch = DBNull.Value;
            decimal? TcTotFreightVouch = null;
            AmountType _TcTotInsuranceVouch = DBNull.Value;
            decimal? TcTotInsuranceVouch = null;
            AmountType _TcTotLocFrtVouch = DBNull.Value;
            decimal? TcTotLocFrtVouch = null;
            decimal? TcTotMatlVouch = null;
            decimal? TcTotVpDollars = null;
            int? TCurrencyPlaces = null;
            int? TLcVouchered = null;
            decimal? TmpAmt = null;
            string TNotInVend = null;
            decimal? TQtyAdjusted = null;
            decimal? TQtyReceived = null;
            decimal? TQtyReturned = null;
            decimal? TQtyVouchered = null;
            decimal? Trate = null;
            DescriptionType _TtCurrencyDescription = DBNull.Value;
            string TtCurrencyDescription = null;
            ListYesNoType _TtCurrencyRateIsDivisor = DBNull.Value;
            int? TtCurrencyRateIsDivisor = null;
            InputMaskType _TtCurrencyAmountFormat = DBNull.Value;
            string TtCurrencyAmountFormat = null;
            DecimalPlacesType _TtCurrencyAmountPlaces = DBNull.Value;
            int? TtCurrencyAmountPlaces = null;
            InputMaskType _TtCurrencyCostPriceFormat = DBNull.Value;
            string TtCurrencyCostPriceFormat = null;
            DecimalPlacesType _TtCurrencyCostPricePlaces = DBNull.Value;
            int? TtCurrencyCostPricePlaces = null;
            decimal? UomConvFactor = null;
            string VendaddrName = null;
            string PoCurrCode = null;
            CurrCodeType _CurrparmsCurrCode = DBNull.Value;
            string CurrparmsCurrCode = null;
            DescriptionType _DomCurrencyDescription = DBNull.Value;
            string DomCurrencyDescription = null;
            ListYesNoType _DomCurrencyRateIsDivisor = DBNull.Value;
            int? DomCurrencyRateIsDivisor = null;
            InputMaskType _DomCurrencyAmountFormat = DBNull.Value;
            string DomCurrencyAmountFormat = null;
            DecimalPlacesType _DomCurrencyAmountPlaces = DBNull.Value;
            int? DomCurrencyAmountPlaces = null;
            InputMaskType _DomCurrencyCostPriceFormat = DBNull.Value;
            string DomCurrencyCostPriceFormat = null;
            DecimalPlacesType _DomCurrencyCostPricePlaces = DBNull.Value;
            int? DomCurrencyCostPricePlaces = null;
            SiteType _ParmsSite = DBNull.Value;
            string ParmsSite = null;
            string ItemUM = null;
            decimal? GItemCost = null;
            string PoBuilderPoOrigSite = null;
            string PoBuilderPoNum = null;
            string PoSiteRef = null;
            InputMaskType _QtyUnitFormat = DBNull.Value;
            string QtyUnitFormat = null;
            DecimalPlacesType _QtyUnitPlaces = DBNull.Value;
            int? QtyUnitPlaces = null;
            DateTime? UsePoVchRcvdDate = null;
            int? UsePoVchDateSeq = null;
            decimal? UseTcQtuQuantity = null;
            string ItemOverview = null;
            CurrCodeType _OtherVendCurr = DBNull.Value;
            string OtherVendCurr = null;
            VoucherType _Voucher = DBNull.Value;
            int? Voucher = null;
            ListYesNoType _PoVchRateIsDivisor = DBNull.Value;
            int? PoVchRateIsDivisor = null;
            ICollectionLoadRequest Site_GroupCursLoadRequestForCursor = null;
            ICollectionLoadResponse Site_GroupCursLoadResponseForCursor = null;
            
            int Site_GroupCurs_CursorFetch_Status = -1;
            int Site_GroupCurs_CursorCounter = -1;

            int? PoNumLineRelChanged = null;
            bool isGroupFirstRow = true;
            ICollectionLoadRequest POCrsLoadRequestForCursor = null;
            ICollectionLoadRequest PovchCrsLoadRequestForCursor = null;
            ICollectionLoadResponse PovchCrsLoadResponseForCursor = null;
            int PovchCrs_CursorFetch_Status = -1;
            int PovchCrs_CursorCounter = -1;
            IBookmark siteBookmark;

            FirstDetailRecFlag = 0;
            LowCharacterValue = convertToUtil.ToString(this.lowCharacter.LowCharacterFn());
            HighCharacterValue = convertToUtil.ToString(this.highCharacter.HighCharacterFn());
            IncludeNull = convertToUtil.ToInt32((BuilderPoStarting != null ? 0 : 1));
            POType = stringUtil.IsNull(POType, "RB");
            TransDomCurr = (int?)(stringUtil.IsNull(TransDomCurr, 1));
            ShowDetail = (int?)(stringUtil.IsNull(ShowDetail, 1));
            DisplayHeader = (int?)(stringUtil.IsNull(DisplayHeader, 1));
            PrintItemOverview = (int?)(stringUtil.IsNull(PrintItemOverview, 0));
            PoStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("PoNumType", PoStarting), this.lowString.LowStringFn("PoNumType"));
            PoEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("PoNumType", PoEnding), this.highString.HighStringFn("PoNumType"));
            VendorStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("VendNumType", VendorStarting), this.lowString.LowStringFn("VendNumType"));
            VendorEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("VendNumType", VendorEnding), this.highString.HighStringFn("VendNumType"));
            BuilderPoStarting = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("BuilderPoNumType", BuilderPoStarting), this.lowString.LowStringFn("BuilderPoNumType"));
            BuilderPoEnding = stringUtil.IsNull(this.iExpandKyByType.ExpandKyByTypeFn("BuilderPoNumType", BuilderPoEnding), this.highString.HighStringFn("BuilderPoNumType"));

            this.sessionBasedCache.TryGet<IBookmark>("MyReport_Rpt", out siteBookmark);
            string site_ref = "";
            if (siteBookmark != null)
            {
                site_ref = (string)siteBookmark.Columns.Where(x => x.Name == "po_all.site_ref").FirstOrDefault().Value;
            }

            if (SiteGroup == null)
            {
                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SiteGroup,"parms.site_group"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var parmsLoadResponse = this.appDB.Load(parmsLoadRequest);
                if (parmsLoadResponse.Items.Count > 0)
                {
                    SiteGroup = _SiteGroup;
                }
                #endregion  LoadToVariable
            }
            PoSiteRef = null;
            Severity = 0;
            TLcVouchered = 0;
            PoitemPoLine = 0;
            TcCprItemCost = 0;
            TcQtuQuantity = 0;
            TQtyReceived = 0;
            TQtyReturned = 0;
            TQtyVouchered = 0;
            TcQttTotToVoucher = 0;
            TCurrencyPlaces = 0;
            Infobar = null;
            QtyUnitPlaces = 0;
            

            #region CRUD ExecuteMethodCall

            var MsgApp = this.iMsgApp.MsgAppSp(Infobar: TNotInVend
                , BaseMsg: "E=NotInMaster"
                , Parm1: "@vendor");
            TNotInVend = MsgApp.Infobar;

            #endregion ExecuteMethodCall

            //this temp table is a table variable in old stored procedure version.
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_VchPayTable") == null)
            {
                this.sQLExpressionExecutor.Execute(@"DECLARE @VchPayTable TABLE (
                        VendNum              VendNumType        ,
                        VendName             NameType           ,
                        ItemNum              ItemType           ,
                        ItemDesc             NVARCHAR (60)      ,
                        PoCurrCode           CurrCodeType       ,
                        CurrDesc             DescriptionType    ,
                        PoNum                PoNumType          ,
                        PoLine               PoLineType         ,
                        PoRelease            PoReleaseType      ,
                        PoitemDesc           DescriptionType    ,
                        RType                INT                ,
                        QtyNotVchd           QtyTotlType        ,
                        PUM                  UMType             ,
                        MatlRcvdAmt          AmountType         ,
                        MatlVchdAmt          AmountType         ,
                        VPMatlAmt            AmountType         ,
                        MatlAdj              AmountType         ,
                        LCType               NCHAR (10)         ,
                        LCAmt                AmountType         ,
                        LCVchd               AmountType         ,
                        LCToVch              AmountType         ,
                        PVRcvdDate           DateType           ,
                        PVType               NCHAR (10)         ,
                        PVQty                QtyTotlType        ,
                        PVItemCost           AmountType         ,
                        PVGrnNum             NVARCHAR (40)      ,
                        PVPackNum            NVARCHAR (40)      ,
                        LCTypeOrder          TINYINT            ,
                        PoBuilderPoOrigSite  SiteType           ,
                        PoBuilderPoNum       BuilderPoNumType   ,
                        PoSiteRef            SiteType           ,
                        QtyUnitFormat        InputMaskType      ,
                        QtyUnitPlaces        DecimalPlacesType  ,
                        AmountFormat         InputMaskType      ,
                        AmountPlaces         DecimalPlacesType  ,
                        CostPriceFormat      InputMaskType      ,
                        CostPricePlaces      DecimalPlacesType  ,
                        ItemOverview         ProductOverviewType,
                        DisplayDetailHeading FlagNyType         );
                    SELECT * into #tv_VchPayTable from @VchPayTable ");
            }
            this.sQLExpressionExecutor.Execute("DELETE #tv_VchPayTable");

            //this temp table is a table variable in old stored procedure version.
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_lc_rcpt") == null)
            {
                this.sQLExpressionExecutor.Execute(@"DECLARE @lc_rcpt TABLE (
                        rcvd_date     DateType     ,
                        date_seq      DateSeqType  ,
                        lc_type       LcTypeType   ,
                        duty_amt      AmountType   ,
                        freight_amt   AmountType   ,
                        brokerage_amt AmountType   ,
                        insurance_amt AmountType   ,
                        locfrt_amt    AmountType   ,
                        return_adj    AmountType   ,
                        vch_amt       AmountType   ,
                        vch_amt_dom   AmountType   ,
                        vouchered     ListYesNoType PRIMARY KEY (rcvd_date, date_seq, lc_type));
                    SELECT * into #tv_lc_rcpt from @lc_rcpt 
                    ALTER TABLE #tv_lc_rcpt ADD PRIMARY KEY (rcvd_date, date_seq, lc_type) ");
            }
            this.sQLExpressionExecutor.Execute("DELETE #tv_lc_rcpt");

            //this temp table is a table variable in old stored procedure version.
            if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_po_vch") == null)
            {
                this.sQLExpressionExecutor.Execute(@"DECLARE @po_vch TABLE (
                        type          NVARCHAR (10) ,
                        item_cost     CostPrcType   ,
                        exch_rate     ExchRateType  ,
                        qty_received  QtyTotlType   ,
                        qty_returned  QtyTotlType   ,
                        qty_vouchered QtyTotlType   ,
                        rcvd_date     DateType      ,
                        date_seq      DateSeqType   ,
                        grn_num       GrnNumType    ,
                        pack_num      GrnPackNumType PRIMARY KEY (rcvd_date, date_seq));
                    SELECT * into #tv_po_vch from @po_vch 
                    ALTER TABLE #tv_po_vch ADD PRIMARY KEY (rcvd_date, date_seq) ");
            }
            this.sQLExpressionExecutor.Execute("DELETE #tv_po_vch");
            

            #region CRUD LoadToVariable
            var parms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ParmsSite,"parms.site"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                tableName: "parms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
            var parms1LoadResponse = this.appDB.Load(parms1LoadRequest);
            if (parms1LoadResponse.Items.Count > 0)
            {
                ParmsSite = _ParmsSite;
            }
            #endregion  LoadToVariable

            if (sQLUtil.SQLEqual(UseSite, 0) == true)
            {
                #region Cursor Statement

                Site_GroupCursLoadRequestForCursor = rpt_VouchersPayableSubCRUD.GetSiteGroupCrsLoadRequestForCursor(SiteGroup, site_ref);

                #endregion Cursor Statement
            }
            else
            {
                #region Cursor Statement

                #region CRUD LoadToRecord
                Site_GroupCursLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"parms.site","parms.site"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                #endregion  LoadToRecord

                #endregion Cursor Statement
            }
            Site_GroupCursLoadResponseForCursor = this.appDB.Load(Site_GroupCursLoadRequestForCursor);
            Site_GroupCurs_CursorFetch_Status = Site_GroupCursLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
            Site_GroupCurs_CursorCounter = -1;
            Severity = 0;

            unionUtil.Clear();

            while (Severity == 0)
            {
                Site_GroupCurs_CursorCounter++;
                if (Site_GroupCursLoadResponseForCursor.Items.Count > Site_GroupCurs_CursorCounter)
                {
                    SiteGroupSite = Site_GroupCursLoadResponseForCursor.Items[Site_GroupCurs_CursorCounter].GetValue<string>(0);
                }
                Site_GroupCurs_CursorFetch_Status = (Site_GroupCurs_CursorCounter == Site_GroupCursLoadResponseForCursor.Items.Count ? -1 : 0);

                if (sQLUtil.SQLEqual(Site_GroupCurs_CursorFetch_Status, -1) == true)
                {
                    break;
                }
                CurrparmsCurrCode = null;
                DomCurrencyRateIsDivisor = 0;

                #region CRUD LoadToVariable
                var currparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_CurrparmsCurrCode,"currparms_all.curr_code"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    maximumRows: 1,
                    tableName: "currparms_all",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("currparms_all.Site_Ref = {0}", SiteGroupSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var currparms_allLoadResponse = this.appDB.Load(currparms_allLoadRequest);

                if (currparms_allLoadResponse.Items.Count > 0)
                {
                    CurrparmsCurrCode = _CurrparmsCurrCode;
                }
                #endregion  LoadToVariable
                


                DomCurrencyDescription = null;
                DomCurrencyAmountFormat = null;
                DomCurrencyAmountPlaces = 2;
                DomCurrencyCostPriceFormat = null;
                DomCurrencyCostPricePlaces = 2;

                #region CRUD LoadToVariable
                var currency_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_DomCurrencyDescription,"currency_all.description"},
                        {_DomCurrencyRateIsDivisor,"currency_all.rate_is_divisor"},
                        {_DomCurrencyAmountFormat,"currency_all.amt_format"},
                        {_DomCurrencyAmountPlaces,"currency_all.places"},
                        {_DomCurrencyCostPriceFormat,"currency_all.cst_prc_format"},
                        {_DomCurrencyCostPricePlaces,"currency_all.places_cp"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "currency_all",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("currency_all.curr_code = {0} AND currency_all.site_ref = {1}", CurrparmsCurrCode, SiteGroupSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var currency_allLoadResponse = this.appDB.Load(currency_allLoadRequest);
                if (currency_allLoadResponse.Items.Count > 0)
                {
                    DomCurrencyDescription = _DomCurrencyDescription;
                    DomCurrencyRateIsDivisor = _DomCurrencyRateIsDivisor;
                    DomCurrencyAmountFormat = _DomCurrencyAmountFormat;
                    DomCurrencyAmountPlaces = _DomCurrencyAmountPlaces;
                    DomCurrencyCostPriceFormat = _DomCurrencyCostPriceFormat;
                    DomCurrencyCostPricePlaces = _DomCurrencyCostPricePlaces;
                }
                #endregion  LoadToVariable


                DomCurrencyAmountFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(DomCurrencyAmountFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                DomCurrencyCostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(DomCurrencyCostPriceFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                QtyUnitFormat = null;

                #region CRUD LoadToVariable
                var invparms_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_QtyUnitFormat,"qty_unit_format"},
                        {_QtyUnitPlaces,"places_qty_unit"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "invparms_all",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("invparms_all.site_ref = {0}", SiteGroupSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var invparms_allLoadResponse = this.appDB.Load(invparms_allLoadRequest);
                if (invparms_allLoadResponse.Items.Count > 0)
                {
                    QtyUnitFormat = _QtyUnitFormat;
                    QtyUnitPlaces = _QtyUnitPlaces;
                }
                #endregion  LoadToVariable

                if (QtyUnitFormat == null)
                {
                    #region CRUD LoadToVariable
                    var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_QtyUnitFormat,"qty_unit_format"},
                            {_QtyUnitPlaces,"places_qty_unit"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "invparms",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var invparmsLoadResponse = this.appDB.Load(invparmsLoadRequest);
                    if (invparmsLoadResponse.Items.Count > 0)
                    {
                        QtyUnitFormat = _QtyUnitFormat;
                        QtyUnitPlaces = _QtyUnitPlaces;
                    }
                    #endregion  LoadToVariable
                }
                QtyUnitFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(QtyUnitFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                

                PoNumLineRelChanged = 1;
                #region Cursor Statement

                #region CRUD LoadToRecord
                POCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"vend_num","po_all.vend_num"},
                        {"poitem_all.po_num","po_all.po_num"},
                        {"curr_code","po_all.curr_code"},
                        {"u_m","poitem_all.u_m"},
                        {"item","poitem_all.item"},
                        {"poitem_all.po_line","poitem_all.po_line"},
                        {"poitem_all.po_release","poitem_all.po_release"},
                        {"u_m_","item_all.u_m"},
                        {"po_all.builder_po_orig_site","po_all.builder_po_orig_site"},
                        {"po_all.builder_po_num","po_all.builder_po_num"},
                        {"po_all.site_ref","po_all.site_ref"},
                        {"po_vch_all.type","po_vch_all.type"},
                        {"exch_rate","po_vch_all.exch_rate"},
                        {"qty_received","po_vch_all.qty_received"},
                        {"qty_returned","po_vch_all.qty_returned"},
                        {"qty_vouchered","po_vch_all.qty_vouchered"},
                        {"po_vch_all.rcvd_date","po_vch_all.rcvd_date"},
                        {"po_vch_all.date_seq","po_vch_all.date_seq"},
                        {"grn_num","po_vch_all.grn_num"},
                        {"pack_num","po_vch_all.pack_num"},
                        {"voucher","po_vch_mst.voucher"},
                        {"PoNumLineReleaseChanged", "LEAD(0, 1, 1) OVER (PARTITION BY poitem_all.po_num, poitem_all.po_line, poitem_all.po_release ORDER BY po_all.builder_po_orig_site, po_all.builder_po_num, poitem_all.po_num, poitem_all.po_line, poitem_all.po_release, po_vch_all.type, po_vch_all.rcvd_date, po_vch_all.date_seq)" },
                        {"u0","vendaddr.name"},
                        {"u1","poitem_all.description"},
                        {"u2","item_all.description"},
                        {"u3","item_lang_all.description"},
                        {"u4","item_lang_all.overview"},
                        {"u5","item_all.overview"},
                        {"u6","po_vch_all.item_cost"},
                    },
                    loadForChange: false,
                    lockingType: LockingType.None,
                    tableName: "po_all",
                    fromClause: collectionLoadRequestFactory.Clause(@" left outer join vendor_all on vendor_all.vend_num = po_all.vend_num 
                        and vendor_all.site_ref = po_all.site_ref left outer join vendaddr on vendaddr.vend_num = po_all.vend_num inner join poitem_all on poitem_all.po_num = po_all.po_num 
                        and charindex(poitem_all.stat, 'of') <> 0 
                        and poitem_all.site_ref = po_all.site_ref left outer join item_all on item_all.item = poitem_all.item 
                        and item_all.site_ref = po_all.site_ref left outer join item_lang_all on item_lang_all.item = poitem_all.item 
                        and item_lang_all.site_ref = po_all.site_ref 
                        and item_lang_all.lang_code = vendor_all.lang_code left outer join po_vch_all on po_vch_all.site_ref = po_all.site_ref 
                        and po_all.po_num = po_vch_all.po_num 
                        and po_vch_all.po_line = poitem_all.po_line 
                        and po_vch_all.po_release = poitem_all.po_release 
                        and (po_vch_all.rcvd_date <= {2} 
                             or po_vch_all.type = 'g') 
                        and (po_vch_all.type != 'g' 
                             or {1} = 1) 
                        and po_vch_all.site_ref = {0} left outer join po_vch_mst on po_vch_mst.rowpointer = po_vch_all.rowpointer 
                        and po_vch_mst.site_ref = po_vch_all.site_ref", SiteGroupSite, TransDomCurr, CutoffDate),
                    whereClause: collectionLoadRequestFactory.Clause(@"po_all.po_num BETWEEN {7} AND {9} AND po_all.vend_num BETWEEN {2} AND {4} AND ((po_all.builder_po_num BETWEEN {0} AND {1}) OR {6} = 1 
                        AND po_all.builder_po_num IS NULL) AND CHARINDEX(po_all.type, {10}) <> 0 AND CHARINDEX(po_all.stat, 'O') <> 0 AND po_all.site_ref = {3} AND EXISTS (SELECT 1 FROM po_vch_all WITH (NOLOCK) 
                        WHERE po_vch_all.po_num = po_all.po_num AND po_vch_all.po_line = poitem_all.po_line AND po_vch_all.po_release = poitem_all.po_release AND (po_vch_all.rcvd_date <= {8} OR po_vch_all.type = 'G') 
                        AND (po_vch_all.type != 'G' OR {5} = 1) AND po_vch_all.site_ref = {3})"
                        , BuilderPoStarting, BuilderPoEnding, VendorStarting, SiteGroupSite, VendorEnding, TransDomCurr, IncludeNull, PoStarting, CutoffDate, PoEnding, POType),
                    orderByClause: collectionLoadRequestFactory.Clause(" po_all.builder_po_orig_site, po_all.builder_po_num, poitem_all.po_num, poitem_all.po_line, poitem_all.po_release, po_vch_all.type, po_vch_all.rcvd_date, po_vch_all.date_seq"));
                #endregion  LoadToRecord

                #endregion Cursor Statement

                using (IRecordStream sQLPagedRecordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache,
                    collectionLoadRequestFactory, POCrsLoadRequestForCursor, poVchSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, loadType))
                {
                    while (sQLPagedRecordStream.Read())
                    {
                        var po_allItem = sQLPagedRecordStream.Current;
                        PoVendNum = po_allItem.GetValue<string>("vend_num");
                        PoNum = po_allItem.GetValue<string>("poitem_all.po_num");
                        PoCurrCode = po_allItem.GetValue<string>("curr_code");
                        VendaddrName = stringUtil.IsNull(po_allItem.GetValue<string>("u0"), TNotInVend);
                        PoitemUM = po_allItem.GetValue<string>("u_m");
                        PoitemItem = po_allItem.GetValue<string>("item");
                        PoitemPoLine = po_allItem.GetValue<int?>("poitem_all.po_line");
                        PoitemPoRelease = po_allItem.GetValue<int?>("poitem_all.po_release");
                        PoitemDescription = sQLUtil.SQLNotEqual(stringUtil.IsNull(po_allItem.GetValue<string>("u1"), ""), stringUtil.IsNull(po_allItem.GetValue<string>("u2"), "")) == true ? convertToUtil.ToString(po_allItem.GetValue<string>("u1")) : convertToUtil.ToString(stringUtil.IsNull(po_allItem.GetValue<string>("u3"), po_allItem.GetValue<string>("u2")));
                        ItemUM = po_allItem.GetValue<string>("u_m_");
                        PoBuilderPoOrigSite = po_allItem.GetValue<string>("po_all.builder_po_orig_site");
                        PoBuilderPoNum = po_allItem.GetValue<string>("po_all.builder_po_num");
                        PoSiteRef = po_allItem.GetValue<string>("po_all.site_ref");
                        ItemOverview = stringUtil.Left((sQLUtil.SQLEqual(PrintItemOverview, 1) == true ? convertToUtil.ToString(stringUtil.IsNull(po_allItem.GetValue<string>("u4"), po_allItem.GetValue<string>("u5"))) : convertToUtil.ToString<string>(null)), 100);
                        PoVchType = po_allItem.GetValue<string>("po_vch_all.type");
                        PoVchItemCost = stringUtil.IsNull<decimal?>(po_allItem.GetValue<decimal?>("u6"), 0);
                        PoVchExchRate = po_allItem.GetValue<decimal?>("exch_rate");
                        PoVchQtyReceived = po_allItem.GetValue<decimal?>("qty_received");
                        PoVchQtyReturned = po_allItem.GetValue<decimal?>("qty_returned");
                        PoVchQtyVouchered = po_allItem.GetValue<decimal?>("qty_vouchered");
                        PoVchRcvdDate = po_allItem.GetValue<DateTime?>("po_vch_all.rcvd_date");
                        PoVchDateSeq = po_allItem.GetValue<int?>("po_vch_all.date_seq");
                        PoVchGrnNum = po_allItem.GetValue<string>("grn_num");
                        PoVchPackNum = po_allItem.GetValue<string>("pack_num");
                        Voucher = po_allItem.GetValue<int?>("voucher");
                        PoNumLineRelChanged = po_allItem.GetValue<int?>("PoNumLineReleaseChanged");

                        #region PoCur level code 1st part
                        if (isGroupFirstRow)
                        {
                            if (sQLUtil.SQLEqual(PoCurrCode, CurrparmsCurrCode) == true)
                            {
                                TtCurrencyDescription = DomCurrencyDescription;
                                TtCurrencyRateIsDivisor = DomCurrencyRateIsDivisor;
                                TtCurrencyAmountFormat = DomCurrencyAmountFormat;
                                TtCurrencyAmountPlaces = DomCurrencyAmountPlaces;
                                TtCurrencyCostPriceFormat = DomCurrencyCostPriceFormat;
                                TtCurrencyCostPricePlaces = DomCurrencyCostPricePlaces;
                            }
                            else
                            {
                                #region CRUD LoadToVariable
                                var currency_all1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TtCurrencyDescription,"currency_all.description"},
                                        {_TtCurrencyRateIsDivisor,"currency_all.rate_is_divisor"},
                                        {_TtCurrencyAmountFormat,"currency_all.amt_format"},
                                        {_TtCurrencyAmountPlaces,"currency_all.places"},
                                        {_TtCurrencyCostPriceFormat,"currency_all.cst_prc_format"},
                                        {_TtCurrencyCostPricePlaces,"currency_all.places_cp"},
                                    },
                                    loadForChange: false,
                                    lockingType: LockingType.None,
                                    tableName: "currency_all",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("currency_all.curr_code = {1} AND currency_all.site_ref = {0}", SiteGroupSite, PoCurrCode),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var currency_all1LoadResponse = this.appDB.Load(currency_all1LoadRequest);
                                if (currency_all1LoadResponse.Items.Count > 0)
                                {
                                    TtCurrencyDescription = _TtCurrencyDescription;
                                    TtCurrencyRateIsDivisor = _TtCurrencyRateIsDivisor;
                                    TtCurrencyAmountFormat = _TtCurrencyAmountFormat;
                                    TtCurrencyAmountPlaces = _TtCurrencyAmountPlaces;
                                    TtCurrencyCostPriceFormat = _TtCurrencyCostPriceFormat;
                                    TtCurrencyCostPricePlaces = _TtCurrencyCostPricePlaces;
                                }
                                #endregion  LoadToVariable

                                TtCurrencyAmountFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(TtCurrencyAmountFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                                TtCurrencyCostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(TtCurrencyCostPriceFormat, this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                            }
                            if (sQLUtil.SQLEqual(TransDomCurr, 1) == true)
                            {
                                TCurrencyPlaces = DomCurrencyAmountPlaces;
                            }
                            else
                            {
                                TCurrencyPlaces = TtCurrencyAmountPlaces;
                            }
                            TcQttTotToVoucher = 0;
                            if (ItemUM != null && sQLUtil.SQLNotEqual(ItemUM, PoitemUM) == true)
                            {
                                #region CRUD ExecuteMethodCall
                                //Please Generate the bounce for this stored procedure: GetumcfSp
                                var Getumcf = this.iGetumcf.GetumcfSp(OtherUM: PoitemUM
                                    , Item: PoitemItem
                                    , VendNum: PoVendNum
                                    , Area: "P"
                                    , ConvFactor: UomConvFactor
                                    , Infobar: Infobar
                                    , Site: SiteGroupSite);
                                Severity = Getumcf.ReturnCode;
                                UomConvFactor = Getumcf.ConvFactor;
                                Infobar = Getumcf.Infobar;
                                #endregion ExecuteMethodCall
                                

                                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                {
                                    goto END_OF_PROG;
                                }
                            }
                            else
                            {
                                UomConvFactor = 1M;
                            }
                            TcAmtAmtWriteOff = 0;
                            TQtyReceived = 0;
                            TQtyReturned = 0;
                            TQtyVouchered = 0;
                            TcAmtReceivedCost = 0;
                            TcAmtVoucheredCost = 0;
                            GItemCost = 0;
                            TcAmtReturnedCost = 0;
                            TcAmtAdjustedCost = 0;
                            TQtyAdjusted = 0;
                            TcTotVpDollars = 0;
                            /*Needs to load at least one column from the table: #tv_po_vch for delete, Loads the record based on its where and from clause, then deletes it by record.*/

                            var tv_po_vchNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                                tableName: "#tv_po_vch",
                                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("")
                                );

                            this.appDB.DeleteWithoutTrigger(tv_po_vchNonTriggerDeleteRequest);
                        }
                        #endregion

                        #region POVchCrs level code
                        if ((sQLUtil.SQLEqual(1, 1) == true))
                        {
                            //BEGIN
                            if (sQLUtil.SQLEqual(PoVchType, "G") == true)
                            {
                                GItemCost = (decimal?)(stringUtil.IsNull<decimal?>(PoVchItemCost, 0));
                            }
                            if (stringUtil.In(PoVchType, new object[] { "F", "G" }) || (sQLUtil.SQLNotEqual(PoVchType, "L") == true && (sQLUtil.SQLEqual(TransDomCurr, 0) == true || sQLUtil.SQLEqual(PoCurrCode, CurrparmsCurrCode) == true)))
                            {
                                TcCprItemCost = PoVchItemCost;
                                if (sQLUtil.SQLEqual(TransDomCurr, 1) == true && sQLUtil.SQLNotEqual(TcCprItemCost, 0) == true && sQLUtil.SQLEqual(PoVchType, "F") == true && sQLUtil.SQLNotEqual(PoCurrCode, CurrparmsCurrCode) == true)
                                {
                                    #region CRUD ExecuteMethodCall
                                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                    var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(CurrCode: PoCurrCode
                                        , FromDomestic: 0
                                        , UseBuyRate: 1
                                        , RoundResult: 0
                                        , Date: null
                                        , RoundPlaces: TCurrencyPlaces
                                        , UseCustomsAndExciseRates: 0
                                        , ForceRate: null
                                        , FindTTFixed: null
                                        , TRate: PoVchExchRate
                                        , Infobar: Infobar
                                        , Amount1: TcCprItemCost
                                        , Result1: TcCprItemCost
                                        , DomCurrCode: CurrparmsCurrCode
                                        , Site: ParmsSite);
                                    Severity = CurrCnvt.ReturnCode;
                                    PoVchExchRate = CurrCnvt.TRate;
                                    Infobar = CurrCnvt.Infobar;
                                    TcCprItemCost = CurrCnvt.Result1;

                                    #endregion ExecuteMethodCall

                                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                    {
                                        goto END_OF_PROG;
                                    }
                                }
                            }
                            else
                            {
                                OtherVendCurr = PoCurrCode;
                                if (sQLUtil.SQLEqual(PoVchType, "L") == true)
                                {
                                    #region CRUD LoadToVariable
                                    var po_vchLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                        {
                                            {_OtherVendCurr,"vendor.curr_code"},
                                        },
                                        loadForChange: false, 
                                        lockingType: LockingType.None,
                                        tableName: "po_vch",
                                        fromClause: collectionLoadRequestFactory.Clause(@" INNER JOIN (SELECT vend_num, 
                                                    voucher 
                                             FROM   aptrxp 
                                             WHERE  voucher = {0} 
                                             UNION 
                                             SELECT vend_num, 
                                                    voucher 
                                             FROM   aptrx 
                                             WHERE  voucher = {0}) AS vends ON vends.voucher = po_vch.voucher INNER JOIN vendor ON vendor.vend_num = vends.vend_num", Voucher),
                                        whereClause: collectionLoadRequestFactory.Clause(""),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                        var po_vchLoadResponse = this.appDB.Load(po_vchLoadRequest);
                                    if (po_vchLoadResponse.Items.Count > 0)
                                    {
                                        OtherVendCurr = _OtherVendCurr;
                                    }
                                    #endregion  LoadToVariable
                                }
                                PoVchRateIsDivisor = null;

                                #region CRUD LoadToVariable
                                var currency_all2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_PoVchRateIsDivisor,"rate_is_divisor"},
                                    },
                                    loadForChange: false, 
                                    lockingType: LockingType.None,
                                    tableName: "currency_all",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("currency_all.curr_code = {0} AND currency_all.site_ref = {1}", OtherVendCurr, SiteGroupSite),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var currency_all2LoadResponse = this.appDB.Load(currency_all2LoadRequest);
                                if (currency_all2LoadResponse.Items.Count > 0)
                                {
                                    PoVchRateIsDivisor = _PoVchRateIsDivisor;
                                }
                                #endregion  LoadToVariable

                                if (PoVchRateIsDivisor == null)
                                {
                                    PoVchRateIsDivisor = TtCurrencyRateIsDivisor;
                                }
                                if (sQLUtil.SQLEqual(OtherVendCurr, CurrparmsCurrCode) == true)
                                {
                                    TcCprItemCost = PoVchItemCost;
                                }
                                else
                                {
                                    if (sQLUtil.SQLEqual(PoVchRateIsDivisor, 0) == true)
                                    {
                                        TcCprItemCost = (decimal?)(PoVchItemCost / PoVchExchRate);
                                    }
                                    else
                                    {
                                        TcCprItemCost = (decimal?)(PoVchItemCost * PoVchExchRate);
                                    }

                                }
                                if (sQLUtil.SQLEqual(TransDomCurr, 0) == true)
                                {
                                    Trate = null;

                                    #region CRUD ExecuteMethodCall

                                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                    var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(CurrCode: PoCurrCode
                                        , FromDomestic: 1
                                        , UseBuyRate: 1
                                        , RoundResult: 0
                                        , Date: null
                                        , RoundPlaces: TCurrencyPlaces
                                        , UseCustomsAndExciseRates: 0
                                        , ForceRate: null
                                        , FindTTFixed: null
                                        , TRate: Trate
                                        , Infobar: Infobar
                                        , Amount1: TcCprItemCost
                                        , Result1: TcCprItemCost
                                        , DomCurrCode: CurrparmsCurrCode
                                        , Site: ParmsSite);
                                    Severity = CurrCnvt1.ReturnCode;
                                    Trate = CurrCnvt1.TRate;
                                    Infobar = CurrCnvt1.Infobar;
                                    TcCprItemCost = CurrCnvt1.Result1;

                                    #endregion ExecuteMethodCall
                                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                    {
                                        goto END_OF_PROG;
                                    }
                                }
                            }

                            TmpAmt = (decimal?)(stringUtil.IsNull<decimal?>(PoVchQtyReceived, 0) - stringUtil.IsNull<decimal?>(PoVchQtyReturned, 0) - stringUtil.IsNull<decimal?>(PoVchQtyVouchered, 0));
                            if (sQLUtil.SQLEqual(PoVchType, "W") == true)
                            {
                                TQtyReturned = (decimal?)(TQtyReturned + stringUtil.IsNull<decimal?>(PoVchQtyReturned, 0));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "R") == true)
                            {
                                TQtyReceived = (decimal?)(TQtyReceived + stringUtil.IsNull<decimal?>(PoVchQtyReceived, 0));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "V") == true)
                            {
                                TQtyVouchered = (decimal?)(TQtyVouchered + stringUtil.IsNull<decimal?>(PoVchQtyVouchered, 0));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "A") == true)
                            {
                                TQtyAdjusted = (decimal?)(TQtyAdjusted + stringUtil.IsNull<decimal?>(PoVchQtyVouchered, 0));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "R") == true)
                            {
                                TcAmtReceivedCost = (decimal?)(TcAmtReceivedCost + mathUtil.Round<decimal?>(stringUtil.IsNull<decimal?>(PoVchQtyReceived, 0) * TcCprItemCost, TCurrencyPlaces));
                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(PoVchType, "G") == true)
                                {
                                    TcAmtReceivedCost = (decimal?)(TcAmtReceivedCost + TcCprItemCost);
                                }
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "W") == true)
                            {
                                TcAmtReturnedCost = (decimal?)(TcAmtReturnedCost + mathUtil.Round<decimal?>(stringUtil.IsNull<decimal?>(PoVchQtyReturned, 0) * TcCprItemCost, TCurrencyPlaces));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "V") == true)
                            {
                                TcAmtVoucheredCost = (decimal?)(TcAmtVoucheredCost + mathUtil.Round<decimal?>(stringUtil.IsNull<decimal?>(PoVchQtyVouchered, 0) * TcCprItemCost, TCurrencyPlaces));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "A") == true)
                            {
                                TcAmtAdjustedCost = (decimal?)(TcAmtAdjustedCost + mathUtil.Round<decimal?>(stringUtil.IsNull<decimal?>(PoVchQtyVouchered, 0) * TcCprItemCost, TCurrencyPlaces));
                            }
                            if (sQLUtil.SQLEqual(PoVchType, "F") == true)
                            {
                                TcAmtAmtWriteOff = (decimal?)(TcAmtAmtWriteOff + TcCprItemCost);
                                TcTotVpDollars = (decimal?)(TcTotVpDollars + TcCprItemCost);
                            }
                            if (sQLUtil.SQLEqual(ShowDetail, 1) == true)
                            {
                                #region CRUD LoadResponseWithoutTable
                                var nonTableLoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "type", variableUtil.GetValue<string>(PoVchType,true)},
                                        { "item_cost", variableUtil.GetValue<decimal?>(TcCprItemCost,true)},
                                        { "exch_rate", variableUtil.GetValue<decimal?>(PoVchExchRate,true)},
                                        { "qty_received", variableUtil.GetValue<decimal?>(PoVchQtyReceived,true)},
                                        { "qty_returned", variableUtil.GetValue<decimal?>(PoVchQtyReturned,true)},
                                        { "qty_vouchered", variableUtil.GetValue<decimal?>(PoVchQtyVouchered,true)},
                                        { "rcvd_date", variableUtil.GetValue<DateTime?>(PoVchRcvdDate,true)},
                                        { "date_seq", variableUtil.GetValue<int?>(PoVchDateSeq,true)},
                                        { "grn_num", variableUtil.GetValue<string>(PoVchGrnNum,true)},
                                        { "pack_num", variableUtil.GetValue<string>(PoVchPackNum,true)},
                                    });

                                var nonTableLoadResponse = this.appDB.Load(nonTableLoadRequest);
                                Data = nonTableLoadResponse;
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords
                                var nonTableInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_po_vch",
                                    items: nonTableLoadResponse.Items);

                                this.appDB.Insert(nonTableInsertRequest);
                                #endregion InsertByRecords
                                
                            }
                        }
                        #endregion

                        #region PoCur level code 2nd part
                        if (PoNumLineRelChanged == 1)
                        {
                            isGroupFirstRow = true;
                            TcQttTotToVoucher = (decimal?)(TQtyReceived - TQtyVouchered - (TQtyReturned - TQtyAdjusted));
                            if (sQLUtil.SQLEqual(TQtyReceived, TQtyVouchered - TQtyAdjusted) == true && sQLUtil.SQLEqual(TQtyReturned, 0) == true)
                            {
                                TcTotVpDollars = 0;
                            }
                            else
                            {
                                TcTotVpDollars = (decimal?)(stringUtil.IsNull<decimal?>(TcTotVpDollars, 0) + (TcAmtReceivedCost - TcAmtReturnedCost - (TcAmtVoucheredCost - TcAmtAdjustedCost)));
                            }
                            TcAmtReceivedCost = (decimal?)(TcAmtReceivedCost - TcAmtReturnedCost);
                            TcAmtVoucheredCost = (decimal?)(TcAmtVoucheredCost - TcAmtAdjustedCost);
                            TcAmtDuty = 0;
                            TcAmtDutyToVoucher = 0;
                            TcAmtFreight = 0;
                            TcAmtFreightToVoucher = 0;
                            TcAmtBrokerage = 0;
                            TcAmtBrokerageToVoucher = 0;
                            TcAmtInsurance = 0;
                            TcAmtInsuranceToVoucher = 0;
                            TcAmtLocFrt = 0;
                            TcAmtLocFrtToVoucher = 0;
                            TLcVouchered = 1;
                            TcTotDutyVouch = 0;
                            TcTotFreightVouch = 0;
                            TcTotBrokVouch = 0;
                            TcTotLocFrtVouch = 0;
                            TcTotInsuranceVouch = 0;
                            /*Needs to load at least one column from the table: #tv_lc_rcpt for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                            var tv_lc_rcptNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                                tableName: "#tv_lc_rcpt",
                                fromClause: collectionNonTriggerDeleteRequestFactory.Clause(""),
                                whereClause: collectionNonTriggerDeleteRequestFactory.Clause("")
                                );

                            this.appDB.DeleteWithoutTrigger(tv_lc_rcptNonTriggerDeleteRequest);

                            #region CRUD InsertByRecords
                            var tv_lc_rcptNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_lc_rcpt",
                                targetColumns: new List<string>()
                                {
                                    "rcvd_date",
                                    "date_seq",
                                    "lc_type",
                                    "duty_amt",
                                    "freight_amt",
                                    "brokerage_amt",
                                    "insurance_amt",
                                    "locfrt_amt",
                                    "return_adj",
                                    "vch_amt",
                                    "vch_amt_dom",
                                    "vouchered"
                                },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                    { "rcvd_date", collectionNonTriggerInsertRequestFactory.Clause("rcvd_date") },
                                    { "date_seq",  collectionNonTriggerInsertRequestFactory.Clause("date_seq") },
                                    { "lc_type",  collectionNonTriggerInsertRequestFactory.Clause("lc_type") },
                                    { "duty_amt",  collectionNonTriggerInsertRequestFactory.Clause(@"case when lc_type = 'D' then 
                                        round(case when isnull(currency_all.rate_is_divisor, {0}) = 1 then ISNULL(rcvd_amt, 0) * ISNULL(lc_rcpt_all.exch_rate, 1) else ISNULL(rcvd_amt, 0) / ISNULL(lc_rcpt_all.exch_rate, 1) end, {1}) else 0 end ",TtCurrencyRateIsDivisor,TCurrencyPlaces ) },
                                    { "freight_amt", collectionNonTriggerInsertRequestFactory.Clause(@"case when lc_type = 'F' then 
                                        round(case when isnull(currency_all.rate_is_divisor, {0}) = 1 then ISNULL(rcvd_amt, 0) * ISNULL(lc_rcpt_all.exch_rate, 1) else ISNULL(rcvd_amt, 0) / ISNULL(lc_rcpt_all.exch_rate, 1) end, {1}) else 0 end ",TtCurrencyRateIsDivisor,TCurrencyPlaces ) },
                                    { "brokerage_amt", collectionNonTriggerInsertRequestFactory.Clause(@"case when lc_type = 'B' then 
                                        round(case when isnull(currency_all.rate_is_divisor, {0}) = 1 then ISNULL(rcvd_amt, 0) * ISNULL(lc_rcpt_all.exch_rate, 1) else ISNULL(rcvd_amt, 0) / ISNULL(lc_rcpt_all.exch_rate, 1) end, {1}) else 0 end ",TtCurrencyRateIsDivisor,TCurrencyPlaces ) },
                                    { "insurance_amt", collectionNonTriggerInsertRequestFactory.Clause(@"case when lc_type = 'I' then 
                                        round(case when isnull(currency_all.rate_is_divisor, {0}) = 1 then ISNULL(rcvd_amt, 0) * ISNULL(lc_rcpt_all.exch_rate, 1) else ISNULL(rcvd_amt, 0) / ISNULL(lc_rcpt_all.exch_rate, 1) end, {1}) else 0 end ",TtCurrencyRateIsDivisor,TCurrencyPlaces ) },
                                    { "locfrt_amt", collectionNonTriggerInsertRequestFactory.Clause(@"case when lc_type = 'L' then 
                                        round(case when isnull(currency_all.rate_is_divisor, {0}) = 1 then ISNULL(rcvd_amt, 0) * ISNULL(lc_rcpt_all.exch_rate, 1) else ISNULL(rcvd_amt, 0) / ISNULL(lc_rcpt_all.exch_rate, 1) end, {1}) else 0 end ",TtCurrencyRateIsDivisor,TCurrencyPlaces ) },
                                    { "return_adj",  collectionNonTriggerInsertRequestFactory.Clause("qty_received / qty_ordered ") },
                                    { "vch_amt",  collectionNonTriggerInsertRequestFactory.Clause("case when ISNULL(dist_date,{0} + 1) > {0} then 0 else isnull(vch_amt, 0) end ", CutoffDate) },
                                    { "vch_amt_dom",  collectionNonTriggerInsertRequestFactory.Clause("case when ISNULL(dist_date,{0} + 1) > {0} then 0 else isnull(vch_amt, 0) end ", CutoffDate) },
                                    { "vouchered",  collectionNonTriggerInsertRequestFactory.Clause("case when ISNULL(dist_date,{0} + 1) > {0} then 0 else vouchered end   ", CutoffDate) },
                                },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause(@"lc_rcpt_all  
                                                                                    left outer join vendor_all on 
                                                                                    vendor_all.vend_num = lc_rcpt_all.vend_num 
                                                                                    and vendor_all.site_ref = lc_rcpt_all.site_ref 
                                                                                    left outer join currency_all on 
                                                                                    currency_all.curr_code = {0} 
                                                                                    and currency_all.site_ref = vendor_all.site_ref 
                                                                                    LEFT OUTER JOIN vch_hdr_all as vch_hdr on vch_hdr.voucher = lc_rcpt_all.voucher 
                                                                                    and  vch_hdr.site_ref = lc_rcpt_all.site_ref ", PoCurrCode),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause(""),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause(@"ref_num    = {0}  
                                                                                            AND ref_type = 'P' 
                                                                                            AND ref_line_suf = {1} 
                                                                                            AND ref_release = {2} 
                                                                                            AND rcvd_date <= {3} 
                                                                                            and lc_rcpt_all.site_ref = {4}", PoNum, PoitemPoLine, PoitemPoRelease, CutoffDate, SiteGroupSite)
                                );

                            this.appDB.InsertWithoutTrigger(tv_lc_rcptNonTriggerInsertRequest);
                            #endregion InsertByRecords
                            
                            if (existsChecker.Exists(
                                tableName: "#tv_lc_rcpt",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("")))
                            {
                                #region CRUD LoadToVariable
                                var tv_lc_rcpt2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TcAmtDuty,"SUM(CASE WHEN lc_type = 'D' THEN duty_amt ELSE 0 END)"},
                                        {_TcTotDutyVouch,"SUM(CASE WHEN lc_type = 'D' THEN vch_amt_dom ELSE 0 END)"},
                                        {_TcAmtDutyToVoucher,"SUM(CASE WHEN lc_type = 'D'              AND vouchered = 0 THEN duty_amt - vch_amt ELSE 0 END)"},
                                        {_TcAmtFreight,"SUM(CASE WHEN lc_type = 'F' THEN freight_amt ELSE 0 END)"},
                                        {_TcTotFreightVouch,"SUM(CASE WHEN lc_type = 'F' THEN vch_amt_dom ELSE 0 END)"},
                                        {_TcAmtFreightToVoucher,"SUM(CASE WHEN lc_type = 'F'              AND vouchered = 0 THEN freight_amt - vch_amt ELSE 0 END)"},
                                        {_TcAmtBrokerage,"SUM(CASE WHEN lc_type = 'B' THEN brokerage_amt ELSE 0 END)"},
                                        {_TcTotBrokVouch,"SUM(CASE WHEN lc_type = 'B' THEN vch_amt_dom ELSE 0 END)"},
                                        {_TcAmtBrokerageToVoucher,"SUM(CASE WHEN lc_type = 'B'              AND vouchered = 0 THEN brokerage_amt - vch_amt ELSE 0 END)"},
                                        {_TcAmtInsurance,"SUM(CASE WHEN lc_type = 'I' THEN insurance_amt ELSE 0 END)"},
                                        {_TcTotInsuranceVouch,"SUM(CASE WHEN lc_type = 'I' THEN vch_amt_dom ELSE 0 END)"},
                                        {_TcAmtInsuranceToVoucher,"SUM(CASE WHEN lc_type = 'I'              AND vouchered = 0 THEN insurance_amt - vch_amt ELSE 0 END)"},
                                        {_TcAmtLocFrt,"SUM(CASE WHEN lc_type = 'L' THEN locfrt_amt ELSE 0 END)"},
                                        {_TcTotLocFrtVouch,"SUM(CASE WHEN lc_type = 'L' THEN vch_amt_dom ELSE 0 END)"},
                                        {_TcAmtLocFrtToVoucher,"SUM(CASE WHEN lc_type = 'L'              AND vouchered = 0 THEN locfrt_amt - vch_amt ELSE 0 END)"},
                                    },
                                    loadForChange: false, 
                                    lockingType: LockingType.None,
                                    tableName: "#tv_lc_rcpt",
                                    fromClause: collectionLoadRequestFactory.Clause(" AS lc_rcpt"),
                                    whereClause: collectionLoadRequestFactory.Clause(""),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var tv_lc_rcpt2LoadResponse = this.appDB.Load(tv_lc_rcpt2LoadRequest);
                                if (tv_lc_rcpt2LoadResponse.Items.Count > 0)
                                {
                                    TcAmtDuty = _TcAmtDuty;
                                    TcTotDutyVouch = _TcTotDutyVouch;
                                    TcAmtDutyToVoucher = _TcAmtDutyToVoucher;
                                    TcAmtFreight = _TcAmtFreight;
                                    TcTotFreightVouch = _TcTotFreightVouch;
                                    TcAmtFreightToVoucher = _TcAmtFreightToVoucher;
                                    TcAmtBrokerage = _TcAmtBrokerage;
                                    TcTotBrokVouch = _TcTotBrokVouch;
                                    TcAmtBrokerageToVoucher = _TcAmtBrokerageToVoucher;
                                    TcAmtInsurance = _TcAmtInsurance;
                                    TcTotInsuranceVouch = _TcTotInsuranceVouch;
                                    TcAmtInsuranceToVoucher = _TcAmtInsuranceToVoucher;
                                    TcAmtLocFrt = _TcAmtLocFrt;
                                    TcTotLocFrtVouch = _TcTotLocFrtVouch;
                                    TcAmtLocFrtToVoucher = _TcAmtLocFrtToVoucher;
                                }
                                #endregion  LoadToVariable
                                

                                if (existsChecker.Exists(
                                    tableName: "#tv_lc_rcpt",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("vouchered = 0")))
                                {
                                    TLcVouchered = 0;
                                }

                                if (sQLUtil.SQLEqual(TransDomCurr, 0) == true && sQLUtil.SQLNotEqual(PoCurrCode, CurrparmsCurrCode) == true)
                                {
                                    Trate = PoVchExchRate;

                                    #region CRUD ExecuteMethodCall
                                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                    var CurrCnvt2 = this.iCurrCnvt.CurrCnvtSp(CurrCode: PoCurrCode
                                        , FromDomestic: 1
                                        , UseBuyRate: 1
                                        , RoundResult: 0
                                        , Date: RateDate
                                        , RoundPlaces: TCurrencyPlaces
                                        , UseCustomsAndExciseRates: 0
                                        , ForceRate: null
                                        , FindTTFixed: null
                                        , TRate: Trate
                                        , Infobar: Infobar
                                        , Amount1: TcAmtDuty
                                        , Result1: TcAmtDuty
                                        , Amount2: TcTotDutyVouch
                                        , Result2: TcTotDutyVouch
                                        , Amount3: TcAmtDutyToVoucher
                                        , Result3: TcAmtDutyToVoucher
                                        , Amount4: TcAmtFreight
                                        , Result4: TcAmtFreight
                                        , Amount5: TcTotFreightVouch
                                        , Result5: TcTotFreightVouch
                                        , Amount6: TcAmtFreightToVoucher
                                        , Result6: TcAmtFreightToVoucher
                                        , Amount7: TcAmtBrokerage
                                        , Result7: TcAmtBrokerage
                                        , Amount8: TcTotBrokVouch
                                        , Result8: TcTotBrokVouch
                                        , Amount9: TcAmtBrokerageToVoucher
                                        , Result9: TcAmtBrokerageToVoucher
                                        , Amount10: TcAmtInsurance
                                        , Result10: TcAmtInsurance
                                        , Amount11: TcTotInsuranceVouch
                                        , Result11: TcTotInsuranceVouch
                                        , Amount12: TcAmtInsuranceToVoucher
                                        , Result12: TcAmtInsuranceToVoucher
                                        , Amount13: TcAmtLocFrt
                                        , Result13: TcAmtLocFrt
                                        , Amount14: TcTotLocFrtVouch
                                        , Result14: TcTotLocFrtVouch
                                        , Amount15: TcAmtLocFrtToVoucher
                                        , Result15: TcAmtLocFrtToVoucher
                                        , DomCurrCode: CurrparmsCurrCode
                                        , Site: ParmsSite);
                                    Severity = CurrCnvt2.ReturnCode;
                                    Trate = CurrCnvt2.TRate;
                                    Infobar = CurrCnvt2.Infobar;
                                    TcAmtDuty = CurrCnvt2.Result1;
                                    TcTotDutyVouch = CurrCnvt2.Result2;
                                    TcAmtDutyToVoucher = CurrCnvt2.Result3;
                                    TcAmtFreight = CurrCnvt2.Result4;
                                    TcTotFreightVouch = CurrCnvt2.Result5;
                                    TcAmtFreightToVoucher = CurrCnvt2.Result6;
                                    TcAmtBrokerage = CurrCnvt2.Result7;
                                    TcTotBrokVouch = CurrCnvt2.Result8;
                                    TcAmtBrokerageToVoucher = CurrCnvt2.Result9;
                                    TcAmtInsurance = CurrCnvt2.Result10;
                                    TcTotInsuranceVouch = CurrCnvt2.Result11;
                                    TcAmtInsuranceToVoucher = CurrCnvt2.Result12;
                                    TcAmtLocFrt = CurrCnvt2.Result13;
                                    TcTotLocFrtVouch = CurrCnvt2.Result14;
                                    TcAmtLocFrtToVoucher = CurrCnvt2.Result15;
                                    #endregion ExecuteMethodCall

                                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                    {
                                        goto END_OF_PROG;
                                    }
                                }
                            }
                            else
                            {
                                TLcVouchered = 1;
                            }
                            if (sQLUtil.SQLNotEqual(mathUtil.Round<decimal?>(TQtyReceived - TQtyVouchered, QtyUnitPlaces), 0) == true || sQLUtil.SQLNotEqual(mathUtil.Round<decimal?>(TQtyAdjusted - TQtyReturned, QtyUnitPlaces), 0) == true || sQLUtil.SQLEqual(TLcVouchered, 0) == true)
                            {
                                TcTotVpDollars = (decimal?)(mathUtil.Round<decimal?>(TcTotVpDollars, TCurrencyPlaces));
                                TcTotMatlVouch = (decimal?)(TcTotMatlVouch + TcTotVpDollars);
                                TcAmtReceivedCost = (decimal?)(mathUtil.Round<decimal?>(TcAmtReceivedCost, TCurrencyPlaces));
                                TcAmtVoucheredCost = (decimal?)(mathUtil.Round<decimal?>(TcAmtVoucheredCost, TCurrencyPlaces));
                                TcAmtAmtWriteOff = (decimal?)(mathUtil.Round<decimal?>(TcAmtAmtWriteOff, TCurrencyPlaces));
                                ConvertedQty = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(TcQttTotToVoucher, UomConvFactor, "From Base"));

                                #region CRUD LoadResponseWithoutTable
                                var nonTable1LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>(PoVendNum,true)},
                                        { "VendName", variableUtil.GetValue<string>(VendaddrName,true)},
                                        { "ItemNum", variableUtil.GetValue<string>(PoitemItem,true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                        { "CurrDesc", variableUtil.GetValue<string>(TtCurrencyDescription,true)},
                                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                        { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                        { "RType", variableUtil.GetValue<int?>(0,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(ConvertedQty,true)},
                                        { "PUM", variableUtil.GetValue<string>(PoitemUM,true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(TcAmtReceivedCost,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(TcAmtVoucheredCost,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(TcTotVpDollars,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(TcAmtAmtWriteOff,true)},
                                        { "LCType", variableUtil.GetValue<string>("",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(0,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                        { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable1LoadResponse = this.appDB.Load(nonTable1LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords
                                unionUtil.Add(nonTable1LoadResponse);
                                processedRowCount += nonTable1LoadResponse.Items.Count;
                                #endregion InsertByRecords

                                if (sQLUtil.SQLEqual(ShowDetail, 1) == true)
                                {
                                    FirstDetailRecFlag = 1;
                                    #region Cursor Statement

                                    PovchCrsLoadRequestForCursor = this.rpt_VouchersPayableSubCRUD.GetPovchCrsLoadRequestForCursor(CutoffDate);

                                    #endregion Cursor Statement
                                    PovchCrsLoadResponseForCursor = this.appDB.Load(PovchCrsLoadRequestForCursor);
                                    PovchCrs_CursorFetch_Status = PovchCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                                    PovchCrs_CursorCounter = -1;
                                    

                                    while (sQLUtil.SQLEqual(Severity, 0) == true)
                                    {
                                        PovchCrs_CursorCounter++;
                                        if (PovchCrsLoadResponseForCursor.Items.Count > PovchCrs_CursorCounter)
                                        {
                                            var values = this.rpt_VouchersPayableSubCRUD.SetValues(PovchCrsLoadResponseForCursor.Items[PovchCrs_CursorCounter]);
                                            PoVchType = values.PoVchType;
                                            PoVchItemCost = values.PoVchItemCost;
                                            PoVchExchRate = values.PoVchExchRate;
                                            PoVchQtyReceived = values.PoVchQtyReceived;
                                            PoVchQtyReturned = values.PoVchQtyReturned;
                                            PoVchQtyVouchered = values.PoVchQtyVouchered;
                                            PoVchRcvdDate = values.PoVchRcvdDate;
                                            PoVchDateSeq = values.PoVchDateSeq;
                                            PoVchGrnNum = values.PoVchGrnNum;
                                            PoVchPackNum = values.PoVchPackNum;
                                        }
                                        PovchCrs_CursorFetch_Status = (PovchCrs_CursorCounter == PovchCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                                        if (sQLUtil.SQLEqual(PovchCrs_CursorFetch_Status, -1) == true)
                                        {
                                            break;
                                        }

                                        TcCprItemCost = PoVchItemCost;
                                        if (sQLUtil.SQLEqual(PoVchType, "R") == true)
                                        {
                                            TcQtuQuantity = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(stringUtil.IsNull<decimal?>(PoVchQtyReceived, 0), UomConvFactor, "From Base"));
                                        }
                                        else
                                        {
                                            if (sQLUtil.SQLEqual(PoVchType, "V") == true || sQLUtil.SQLEqual(PoVchType, "A") == true)
                                            {
                                                TcQtuQuantity = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(stringUtil.IsNull<decimal?>(PoVchQtyVouchered, 0), UomConvFactor, "From Base"));
                                            }
                                            else
                                            {
                                                if (sQLUtil.SQLEqual(PoVchType, "W") == true)
                                                {
                                                    TcQtuQuantity = convertToUtil.ToDecimal(this.iUomConvQty.UomConvQtyFn(stringUtil.IsNull<decimal?>(PoVchQtyReturned, 0), UomConvFactor, "From Base"));
                                                }
                                                else
                                                {
                                                    TcQtuQuantity = 0;
                                                }
                                            }
                                        }
                                        TcAmtDuty2 = 0;
                                        TcAmtFreight2 = 0;
                                        TcAmtBrokerage2 = 0;
                                        TcAmtInsurance2 = 0;
                                        TcAmtLocFrt2 = 0;
                                        if (UsePoVchRcvdDate == null || sQLUtil.SQLGreaterThan(TcQtuQuantity, 0) == true)
                                        {
                                            UsePoVchRcvdDate = convertToUtil.ToDateTime(PoVchRcvdDate);
                                            UsePoVchDateSeq = PoVchDateSeq;
                                            UseTcQtuQuantity = TcQtuQuantity;
                                        }

                                        #region CRUD LoadToVariable
                                        var tv_lc_rcpt4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                            {
                                                {_TcAmtDuty2,"ISNULL(SUM(duty_amt), 0)"},
                                                {_TcAmtFreight2,"ISNULL(SUM(freight_amt), 0)"},
                                                {_TcAmtBrokerage2,"ISNULL(SUM(brokerage_amt), 0)"},
                                                {_TcAmtInsurance2,"ISNULL(SUM(insurance_amt), 0)"},
                                                {_TcAmtLocFrt2,"ISNULL(SUM(locfrt_amt), 0)"},
                                            },
                                            loadForChange: false, 
                                            lockingType: LockingType.None,
                                            tableName: "#tv_lc_rcpt",
                                            fromClause: collectionLoadRequestFactory.Clause(" AS lc_rcpt"),
                                            whereClause: collectionLoadRequestFactory.Clause("lc_rcpt.rcvd_date = {0} AND lc_rcpt.date_seq = {1}", UsePoVchRcvdDate, UsePoVchDateSeq),
                                            orderByClause: collectionLoadRequestFactory.Clause(""));
                                        var tv_lc_rcpt4LoadResponse = this.appDB.Load(tv_lc_rcpt4LoadRequest);
                                        if (tv_lc_rcpt4LoadResponse.Items.Count > 0)
                                        {
                                            TcAmtDuty2 = _TcAmtDuty2;
                                            TcAmtFreight2 = _TcAmtFreight2;
                                            TcAmtBrokerage2 = _TcAmtBrokerage2;
                                            TcAmtInsurance2 = _TcAmtInsurance2;
                                            TcAmtLocFrt2 = _TcAmtLocFrt2;
                                        }
                                        #endregion  LoadToVariable
                                        


                                        if (sQLUtil.SQLNotEqual(PoVchType, "L") == true)
                                        {
                                            if (sQLUtil.SQLNotEqual(TcQtuQuantity, 0) == true)
                                            {
                                                if (sQLUtil.SQLEqual(TransDomCurr, 0) == true && sQLUtil.SQLNotEqual(PoCurrCode, CurrparmsCurrCode) == true && (sQLUtil.SQLNotEqual(TcAmtDuty2, 0) == true || sQLUtil.SQLNotEqual(TcAmtFreight2, 0) == true || sQLUtil.SQLNotEqual(TcAmtBrokerage2, 0) == true || sQLUtil.SQLNotEqual(TcAmtInsurance2, 0) == true || sQLUtil.SQLNotEqual(TcAmtLocFrt2, 0) == true))
                                                {
                                                    #region CRUD ExecuteMethodCall
                                                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                                    var CurrCnvt3 = this.iCurrCnvt.CurrCnvtSp(CurrCode: PoCurrCode
                                                        , FromDomestic: 1
                                                        , UseBuyRate: 1
                                                        , RoundResult: 0
                                                        , Date: RateDate
                                                        , RoundPlaces: TCurrencyPlaces
                                                        , UseCustomsAndExciseRates: 0
                                                        , ForceRate: null
                                                        , FindTTFixed: null
                                                        , TRate: Trate
                                                        , Infobar: Infobar
                                                        , Amount1: TcAmtDuty2
                                                        , Result1: TcAmtDuty2
                                                        , Amount2: TcAmtFreight2
                                                        , Result2: TcAmtFreight2
                                                        , Amount3: TcAmtBrokerage2
                                                        , Result3: TcAmtBrokerage2
                                                        , Amount4: TcAmtInsurance2
                                                        , Result4: TcAmtInsurance2
                                                        , Amount5: TcAmtLocFrt2
                                                        , Result5: TcAmtLocFrt2
                                                        , DomCurrCode: CurrparmsCurrCode
                                                        , Site: ParmsSite);
                                                    Severity = CurrCnvt3.ReturnCode;
                                                    Trate = CurrCnvt3.TRate;
                                                    Infobar = CurrCnvt3.Infobar;
                                                    TcAmtDuty2 = CurrCnvt3.Result1;
                                                    TcAmtFreight2 = CurrCnvt3.Result2;
                                                    TcAmtBrokerage2 = CurrCnvt3.Result3;
                                                    TcAmtInsurance2 = CurrCnvt3.Result4;
                                                    TcAmtLocFrt2 = CurrCnvt3.Result5;
                                                    #endregion ExecuteMethodCall
                                                    

                                                    if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                                                    {
                                                        goto END_OF_PROG;
                                                    }
                                                }
                                                TmpAmt = (decimal?)(TcCprItemCost + ((TcAmtDuty2 + TcAmtFreight2 + TcAmtBrokerage2 + TcAmtInsurance2 + TcAmtLocFrt2) / UseTcQtuQuantity));
                                            }
                                            else
                                            {
                                                TmpAmt = TcCprItemCost;
                                            }
                                        }
                                        else
                                        {
                                            TmpAmt = TcCprItemCost;
                                        }
                                        TmpAmt = (decimal?)(mathUtil.Round<decimal?>(TmpAmt, TCurrencyPlaces));
                                        if ((sQLUtil.SQLNotEqual(PoVchType, "G") == true) || (sQLUtil.SQLEqual(PoVchType, "G") == true && sQLUtil.SQLNotEqual(TmpAmt, 0) == true && sQLUtil.SQLEqual(TransDomCurr, 1) == true))
                                        {
                                            #region CRUD LoadResponseWithoutTable
                                            var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                                {
                                                    { "VendNum", variableUtil.GetValue<string>("",true)},
                                                    { "VendName", variableUtil.GetValue<string>("",true)},
                                                    { "ItemNum", variableUtil.GetValue<string>("",true)},
                                                    { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                                    { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                                    { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                                    { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                                    { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                                    { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                                    { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                                    { "RType", variableUtil.GetValue<int?>(2,true)},
                                                    { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "PUM", variableUtil.GetValue<string>("",true)},
                                                    { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "LCType", variableUtil.GetValue<string>("",true)},
                                                    { "LCAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "LCVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "LCToVch", variableUtil.GetValue<decimal?>(0.0M,true)},
                                                    { "PVRcvdDate", PoVchRcvdDate},
                                                    { "PVType", variableUtil.GetValue<string>(PoVchType,true)},
                                                    { "PVQty", variableUtil.GetValue<decimal?>(TcQtuQuantity,true)},
                                                    { "PVItemCost", variableUtil.GetValue<decimal?>(TmpAmt,true)},
                                                    { "PVGrnNum", variableUtil.GetValue<string>(PoVchGrnNum,true)},
                                                    { "PVPackNum", variableUtil.GetValue<string>(PoVchPackNum,true)},
                                                    { "LCTypeOrder", variableUtil.GetValue<int?>(0,true)},
                                                    { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                                    { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                                    { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                                    { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                                    { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                                    { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                                    { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                                    { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                                    { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                                    { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                                    { "DisplayDetailHeading", variableUtil.GetValue<int?>(FirstDetailRecFlag,true)},
                                                });

                                            var nonTable2LoadResponse = this.appDB.Load(nonTable2LoadRequest);
                                            #endregion CRUD LoadResponseWithoutTable

                                            #region CRUD InsertByRecords

                                            unionUtil.Add(nonTable2LoadResponse);
                                            processedRowCount += nonTable2LoadResponse.Items.Count;
                                            #endregion InsertByRecords
                                        }
                                        FirstDetailRecFlag = 0;
                                    }
                                    //Deallocate Cursor PovchCrs
                                }

                                #region CRUD LoadResponseWithoutTable
                                var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>("",true)},
                                        { "VendName", variableUtil.GetValue<string>("",true)},
                                        { "ItemNum", variableUtil.GetValue<string>("",true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                        { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                        { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                        { "RType", variableUtil.GetValue<int?>(1,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PUM", variableUtil.GetValue<string>("",true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCType", variableUtil.GetValue<string>("F",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(TcAmtFreight,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(TcTotFreightVouch,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(TcAmtFreightToVoucher,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(1,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                        { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable3LoadResponse = this.appDB.Load(nonTable3LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords

                                unionUtil.Add(nonTable3LoadResponse);
                                processedRowCount += nonTable3LoadResponse.Items.Count;
                                #endregion InsertByRecords

                                #region CRUD LoadResponseWithoutTable
                                var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>("",true)},
                                        { "VendName", variableUtil.GetValue<string>("",true)},
                                        { "ItemNum", variableUtil.GetValue<string>("",true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                        { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                        { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                        { "RType", variableUtil.GetValue<int?>(1,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PUM", variableUtil.GetValue<string>("",true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCType", variableUtil.GetValue<string>("D",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(TcAmtDuty,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(TcTotDutyVouch,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(TcAmtDutyToVoucher,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(2,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                        { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable4LoadResponse = this.appDB.Load(nonTable4LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords

                                unionUtil.Add(nonTable4LoadResponse);
                                processedRowCount += nonTable4LoadResponse.Items.Count;
                                #endregion InsertByRecords

                                #region CRUD LoadResponseWithoutTable
                                var nonTable5LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>("",true)},
                                        { "VendName", variableUtil.GetValue<string>("",true)},
                                        { "ItemNum", variableUtil.GetValue<string>("",true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                        { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                        { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                        { "RType", variableUtil.GetValue<int?>(1,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PUM", variableUtil.GetValue<string>("",true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCType", variableUtil.GetValue<string>("B",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(TcAmtBrokerage,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(TcTotBrokVouch,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(TcAmtBrokerageToVoucher,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(3,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                        { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable5LoadResponse = this.appDB.Load(nonTable5LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords

                                unionUtil.Add(nonTable5LoadResponse);
                                processedRowCount += nonTable5LoadResponse.Items.Count;
                                #endregion InsertByRecords

                                #region CRUD LoadResponseWithoutTable
                                var nonTable6LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>("",true)},
                                        { "VendName", variableUtil.GetValue<string>("",true)},
                                        { "ItemNum", variableUtil.GetValue<string>("",true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                        { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                        { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                        { "RType", variableUtil.GetValue<int?>(1,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PUM", variableUtil.GetValue<string>("",true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCType", variableUtil.GetValue<string>("I",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(TcAmtInsurance,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(TcTotInsuranceVouch,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(TcAmtInsuranceToVoucher,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(4,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                        { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable6LoadResponse = this.appDB.Load(nonTable6LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords

                                unionUtil.Add(nonTable6LoadResponse);
                                processedRowCount += nonTable6LoadResponse.Items.Count;
                                #endregion InsertByRecords

                                #region CRUD LoadResponseWithoutTable
                                var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>("",true)},
                                        { "VendName", variableUtil.GetValue<string>("",true)},
                                        { "ItemNum", variableUtil.GetValue<string>("",true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>(PoCurrCode,true)},
                                        { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoNum", variableUtil.GetValue<string>(PoNum,true)},
                                        { "PoLine", variableUtil.GetValue<int?>(PoitemPoLine,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(PoitemPoRelease,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>(PoitemDescription,true)},
                                        { "RType", variableUtil.GetValue<int?>(1,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PUM", variableUtil.GetValue<string>("",true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCType", variableUtil.GetValue<string>("L",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(TcAmtLocFrt,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(TcTotLocFrtVouch,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(TcAmtLocFrtToVoucher,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(5,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>(PoBuilderPoOrigSite,true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>(PoBuilderPoNum,true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>(PoSiteRef,true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>(QtyUnitFormat,true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(QtyUnitPlaces,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountFormat : TtCurrencyAmountFormat),true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyAmountPlaces : TtCurrencyAmountPlaces),true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPriceFormat : TtCurrencyCostPriceFormat),true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>((sQLUtil.SQLEqual(TransDomCurr, 1) == true ? DomCurrencyCostPricePlaces : TtCurrencyCostPricePlaces),true)},
                                        { "ItemOverview", variableUtil.GetValue<string>(ItemOverview,true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable7LoadResponse = this.appDB.Load(nonTable7LoadRequest);
                                #endregion CRUD LoadResponseWithoutTable

                                #region CRUD InsertByRecords

                                unionUtil.Add(nonTable7LoadResponse);
                                processedRowCount += nonTable7LoadResponse.Items.Count;
                                #endregion InsertByRecords
                            }
                            // Do not return until all rows are processed.
                            if (processedRowCount > recordCap)
                            {
                                // Insert one more row so that get more row is enabled.
                                var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                        { "VendNum", variableUtil.GetValue<string>("",true)},
                                        { "VendName", variableUtil.GetValue<string>("",true)},
                                        { "ItemNum", variableUtil.GetValue<string>("",true)},
                                        { "ItemDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoCurrCode", variableUtil.GetValue<string>("",true)},
                                        { "CurrDesc", variableUtil.GetValue<string>("",true)},
                                        { "PoNum", variableUtil.GetValue<string>("",true)},
                                        { "PoLine", variableUtil.GetValue<int?>(0,true)},
                                        { "PoRelease", variableUtil.GetValue<int?>(0,true)},
                                        { "PoitemDesc", variableUtil.GetValue<string>("",true)},
                                        { "RType", variableUtil.GetValue<int?>(0,true)},
                                        { "QtyNotVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PUM", variableUtil.GetValue<string>("",true)},
                                        { "MatlRcvdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlVchdAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "VPMatlAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "MatlAdj", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCType", variableUtil.GetValue<string>("L",true)},
                                        { "LCAmt", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCVchd", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "LCToVch", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVRcvdDate", variableUtil.GetValue<DateTime?>(null,true)},
                                        { "PVType", variableUtil.GetValue<string>("",true)},
                                        { "PVQty", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVItemCost", variableUtil.GetValue<decimal?>(0.0M,true)},
                                        { "PVGrnNum", variableUtil.GetValue<string>("",true)},
                                        { "PVPackNum", variableUtil.GetValue<string>("",true)},
                                        { "LCTypeOrder", variableUtil.GetValue<int?>(0,true)},
                                        { "PoBuilderPoOrigSite", variableUtil.GetValue<string>("",true)},
                                        { "PoBuilderPoNum", variableUtil.GetValue<string>("",true)},
                                        { "PoSiteRef", variableUtil.GetValue<string>("",true)},
                                        { "QtyUnitFormat", variableUtil.GetValue<string>("",true)},
                                        { "QtyUnitPlaces", variableUtil.GetValue<int?>(0,true)},
                                        { "AmountFormat", variableUtil.GetValue<string>("",true)},
                                        { "AmountPlaces", variableUtil.GetValue<int?>(0,true)},
                                        { "CostPriceFormat", variableUtil.GetValue<string>("",true)},
                                        { "CostPricePlaces", variableUtil.GetValue<int?>(0,true)},
                                        { "ItemOverview", variableUtil.GetValue<string>("",true)},
                                        { "DisplayDetailHeading", variableUtil.GetValue<int?>(0,true)},
                                    });

                                var nonTable8LoadResponse = this.appDB.Load(nonTable8LoadRequest);

                                unionUtil.Add(nonTable8LoadResponse);
                                break;
                            }
                        }
                        else
                        {
                            isGroupFirstRow = false;
                        }
                        #endregion
                    }
                }
            }
            //Deallocate Cursor Site_GroupCurs
            

        END_OF_PROG:;
            Data = unionUtil.Process(UnionType.UnionAll, "PoBuilderPoOrigSite, PoBuilderPoNum, PoNum, PoLine, PoRelease, RType, LCTypeOrder");
            return (Data, Severity, Infobar);
        }
    }
}
