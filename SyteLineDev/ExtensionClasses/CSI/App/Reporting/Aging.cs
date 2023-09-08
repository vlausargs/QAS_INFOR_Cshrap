//PROJECT NAME: Reporting
//CLASS NAME: Aging.cs

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
using CSI.Admin;
using CSI.Logistics.Vendor;
using CSI.Adapters;
using CSI.Finance.AR;
using CSI.Logistics.Customer;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Aging : IAging
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionUpdateRequestFactory collectionUpdateRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IDataTableUtil dataTableUtil;
        readonly IVariableUtil variableUtil;
        readonly IDateTimeUtil dateTimeUtil;
        readonly IGainLossAr iGainLossAr;
        readonly IStringUtil stringUtil;
        readonly IArTermDue iArTermDue;
        readonly ITwoCurrCnvt i2CurrCnvt;
        readonly IIsInteger iIsInteger;
        readonly IGetLabel iGetLabel;
        readonly ICurrCnvt iCurrCnvt;
        readonly IStringOf iStringOf;
        readonly ILowDate iLowDate;
        readonly IChkcred iChkcred;
        readonly IGetCode iGetCode;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly IMsgApp iMsgApp;
        readonly IQueryLanguage queryLanguage;
        readonly IRecordStreamFactory recordStreamFactory;
        readonly ICache mgSessionVariableBasedCache;
        readonly ISortOrderFactory sortOrderFactory;
        readonly int pageSize = Convert.ToInt32(CachePageSize.XLarge);
        readonly ILowCharacter lowCharacter;
        readonly ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory;
        readonly ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory;
        readonly ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory;
        readonly ILogger logger;

        public Aging(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadStatementRequestFactory collectionLoadStatementRequestFactory,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionUpdateRequestFactory collectionUpdateRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IIsAddonAvailable iIsAddonAvailable,
            IIsFeatureActive iIsFeatureActive,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IDataTableUtil dataTableUtil,
            IVariableUtil variableUtil,
            IDateTimeUtil dateTimeUtil,
            IGainLossAr iGainLossAr,
            IStringUtil stringUtil,
            IArTermDue iArTermDue,
            ITwoCurrCnvt i2CurrCnvt,
            IIsInteger iIsInteger,
            IGetLabel iGetLabel,
            ICurrCnvt iCurrCnvt,
            IStringOf iStringOf,
            ILowDate iLowDate,
            IChkcred iChkcred,
            IGetCode iGetCode,
            ISQLValueComparerUtil sQLUtil,
            IMsgApp iMsgApp,
            IQueryLanguage queryLanguage,
            IRecordStreamFactory recordStreamFactory,
            ICache mgSessionVariableBasedCache,
            ISortOrderFactory sortOrderFactory,
            ILowCharacter lowCharacter,
            ICollectionNonTriggerDeleteRequestFactory collectionNonTriggerDeleteRequestFactory,
            ICollectionNonTriggerInsertRequestFactory collectionNonTriggerInsertRequestFactory,
            ICollectionNonTriggerUpdateRequestFactory collectionNonTriggerUpdateRequestFactory,
            ILogger logger)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadStatementRequestFactory = collectionLoadStatementRequestFactory;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionUpdateRequestFactory = collectionUpdateRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.iIsFeatureActive = iIsFeatureActive;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.dataTableUtil = dataTableUtil;
            this.variableUtil = variableUtil;
            this.dateTimeUtil = dateTimeUtil;
            this.iGainLossAr = iGainLossAr;
            this.stringUtil = stringUtil;
            this.iArTermDue = iArTermDue;
            this.i2CurrCnvt = i2CurrCnvt;
            this.iIsInteger = iIsInteger;
            this.iGetLabel = iGetLabel;
            this.iCurrCnvt = iCurrCnvt;
            this.iStringOf = iStringOf;
            this.iLowDate = iLowDate;
            this.iChkcred = iChkcred;
            this.iGetCode = iGetCode;
            this.sQLUtil = sQLUtil;
            this.iMsgApp = iMsgApp;
            this.queryLanguage = queryLanguage;
            this.recordStreamFactory = recordStreamFactory;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.sortOrderFactory = sortOrderFactory;
            this.lowCharacter = lowCharacter;

            this.collectionNonTriggerDeleteRequestFactory = collectionNonTriggerDeleteRequestFactory;
            this.collectionNonTriggerInsertRequestFactory = collectionNonTriggerInsertRequestFactory;
            this.collectionNonTriggerUpdateRequestFactory = collectionNonTriggerUpdateRequestFactory;
            this.logger = logger;
        }


        void LogTiming(string message)
        {
            //var timing = DateTime.Now - startTime;
            //logger.Performance(this.GetType().Name, $"{message} - {timing.ToString("c")}");
            //startTime = DateTime.Now;
        }


        public (
            int? ReturnCode,
            int? TGrand,
            int? FirstOfCustomer,
            int? UseHistRate,
            int? TranslateForAging,
            string SiteLabel,
            int? TTransDom,
            int? AnyTrans)
        AgingSp(
            int? ConsolidateCustomers,
            string PSite,
            string PPrOpenItem,
            DateTime? PAgingDate,
            int? PSumToCorp,
            string PSSlsman,
            string PESlsman,
            string PStateCycle,
            string PCreditHold,
            int? PShowActive,
            int? PPrZeroBal,
            int? PPrCreditBal,
            int? PSortByCurr,
            int? PPrOpenPay,
            DateTime? PCutoffDate,
            string PInvDue,
            int? PAgeDays1,
            int? PAgeDays2,
            int? PAgeDays3,
            int? PAgeDays4,
            int? PAgeDays5,
            int? PHidePaid,
            string PAgeBucket,
            int? TGrand,
            int? FirstOfCustomer,
            int? UseHistRate,
            int? TranslateForAging,
            string SiteLabel,
            int? TTransDom,
            string CurCustNum,
            int? AnyTrans,
            string PAgeDesc1,
            string PAgeDesc2,
            string PAgeDesc3,
            string PAgeDesc4,
            string PAgeDesc5,
            string PArSortBy,
            Guid? ProcessID,
            int? IncludeEstCurrGainLossAmtsInTotals)
        {
            LogTiming("AGING SP START");

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();
            try
            {
                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                string Infobar = null;
                InputMaskType _CurrencyFormat = DBNull.Value;
                string CurrencyFormat = null;
                DecimalPlacesType _CurrencyPlaces = DBNull.Value;
                int? CurrencyPlaces = null;
                string StdCh = null;
                AmountType _TcAmtTran = DBNull.Value;
                decimal? TcAmtTran = null;
                decimal? TcAmtTemp = null;
                string StdCh1 = null;
                string ApplyToInv = null;
                RowPointerType _ArtranRowPointer = DBNull.Value;
                Guid? ArtranRowPointer = null;
                int? ArtranInvSeq = null;
                InvNumType _ArtranInvNum = DBNull.Value;
                string ArtranInvNum = null;
                string ArtranApplyToInvNum = null;
                decimal? ArtranExchRate = null;
                int? ArtranFixedRate = null;
                decimal? ArtranAmount = null;
                decimal? ArtranMiscCharges = null;
                decimal? ArtranSalesTax = null;
                decimal? ArtranSalesTax2 = null;
                decimal? ArtranFreight = null;
                DateType _ArtranDueDate = DBNull.Value;
                DateTime? ArtranDueDate = null;
                DateType _ArtranInvDate = DBNull.Value;
                DateTime? ArtranInvDate = null;
                ArtranTypeType _ArtranType = DBNull.Value;
                string ArtranType = null;
                int? ArtranCheckSeq = null;
                string ArtranCustNum = null;
                string ArtranCurrCode = null;
                PaymentNumberType _ArtranPaymentNumber = DBNull.Value;
                string ArtranPaymentNumber = null;
                string ArtranApprovalStatus = null;
                decimal? ArtdOrigAmount = null;
                decimal? DomArtdBalAmount = null;
                Guid? __ArtranRowPointer = null;
                int? __ArtranInvSeq = null;
                string __ArtranInvNum = null;
                string __ArtranApplyToInvNum = null;
                decimal? __ArtranExchRate = null;
                int? __ArtranFixedRate = null;
                decimal? __ArtranAmount = null;
                decimal? __ArtranMiscCharges = null;
                decimal? __ArtranSalesTax = null;
                decimal? __ArtranSalesTax2 = null;
                decimal? __ArtranFreight = null;
                DateTime? __ArtranDueDate = null;
                DateTime? __ArtranInvDate = null;
                string __ArtranType = null;
                int? __ArtranCheckSeq = null;
                string __ArtranCustNum = null;
                string __ArtranApprovalStatus = null;
                string __ArtranCurrCode = null;
                string __ArtranPaymentNumber = null;
                int? __usemultiduedate = null;
                ArInvSeqType _TtArtrancInvSeq = DBNull.Value;
                int? TtArtrancInvSeq = null;
                ExchRateType _TtArtrancExchRate = DBNull.Value;
                decimal? TtArtrancExchRate = null;
                AmountType _TtArtrancGainLoss = DBNull.Value;
                decimal? TtArtrancGainLoss = null;
                RowPointerType _TtInvRowPointer = DBNull.Value;
                Guid? TtInvRowPointer = null;
                InvNumType _TtInvInvNum = DBNull.Value;
                string TtInvInvNum = null;
                int? TtInvInvSeq = null;
                RowPointerType _TtInvArtranRecid = DBNull.Value;
                Guid? TtInvArtranRecid = null;
                CustNumType _TtInvCustNum = DBNull.Value;
                string TtInvCustNum = null;
                RowPointerType _YArtranRowPointer = DBNull.Value;
                Guid? YArtranRowPointer = null;
                InvNumType _YArtranInvNum = DBNull.Value;
                string YArtranInvNum = null;
                DateType _YArtranInvDate = DBNull.Value;
                DateTime? YArtranInvDate = null;
                DateType _YArtranDueDate = DBNull.Value;
                DateTime? YArtranDueDate = null;
                ArtranTypeType _YArtranType = DBNull.Value;
                string YArtranType = null;
                int? EofArtran = null;
                int? LastOfArtranInvNum = null;
                int? ArtranInvNumForFirstOF = null;
                string GetWinRegDecGroup = null;
                int? Severity = null;
                int? TTotal = null;
                decimal? TRate = null;
                decimal? TcTotBal = null;
                decimal? TcTotMinorBal = null;
                DateTime? TAgeDate = null;
                int? NDays = null;
                GenericNoType _I = DBNull.Value;
                int? I = null;
                string TOpt = null;
                string TempTermsCode = null;
                decimal? TcAmtDCreditLimit = null;
                AmountType _TmpAmount = DBNull.Value;
                decimal? TmpAmount = null;
                decimal? TcAmtTAmt = null;
                DateTime? TDate = null;
                DateTime? SDate = null;
                string TCredhold = null;
                int? CheckBalNow = null;
                string TInvSeq = null;
                string TOpen = null;
                int? TOpenLength = null;
                int? TFirstBucket = null;
                int? TLastBucket = null;
                int? TOldTransDom = null;
                string TtSite = null;
                string TCurrText = null;
                int? AgingReport = null;
                InputMaskType _TotalCurrencyFormat = DBNull.Value;
                string TotalCurrencyFormat = null;
                int? TotalCurrencyPlaces = null;
                int? DecimalPlaces = null;
                int? IntPosition = null;
                string CurrencyCode = null;
                int? SpecialInvNum = null;
                ListYesNoType _MultiApplyInvNum = DBNull.Value;
                int? MultiApplyInvNum = null;
                int? usemultiduedate = null;
                string __Site = null;
                int? __active = null;
                string __description = null;
                DateTime? LowDate = null;
                int? TranslateToDom = null;
                string SubCustaddrCustNum = null;
                string SubCustaddrCurrCode = null;
                CurrCodeType _ParmsCurrCode = DBNull.Value;
                string ParmsCurrCode = null;
                RowPointerType _CustomerRowPointer = DBNull.Value;
                Guid? CustomerRowPointer = null;
                SlsmanType _CustomerSlsman = DBNull.Value;
                string CustomerSlsman = null;
                StatementCycleType _CustomerStateCycle = DBNull.Value;
                string CustomerStateCycle = null;
                ContactType _CustomerContact__3 = DBNull.Value;
                string CustomerContact__3 = null;
                PhoneType _CustomerPhone__3 = DBNull.Value;
                string CustomerPhone__3 = null;
                CustTypeType _CustomerCustType = DBNull.Value;
                string CustomerCustType = null;
                TermsCodeType _CustomerTermsCode = DBNull.Value;
                string CustomerTermsCode = null;
                RowPointerType _CustaddrRowPointer = DBNull.Value;
                Guid? CustaddrRowPointer = null;
                CustNumType _CustaddrCorpCust = DBNull.Value;
                string CustaddrCorpCust = null;
                CustNumType _CustaddrCustNum = DBNull.Value;
                string CustaddrCustNum = null;
                AmountType _CustaddrCreditLimit = DBNull.Value;
                decimal? CustaddrCreditLimit = null;
                CurrCodeType _CustaddrCurrCode = DBNull.Value;
                string CustaddrCurrCode = null;
                NameType _CustaddrName = DBNull.Value;
                string CustaddrName = null;
                CityType _CustaddrCity = DBNull.Value;
                string CustaddrCity = null;
                StateType _CustaddrState = DBNull.Value;
                string CustaddrState = null;
                RowPointerType _TermsRowPointer = DBNull.Value;
                Guid? TermsRowPointer = null;
                DescriptionType _TermsDescription = DBNull.Value;
                string TermsDescription = null;
                decimal? TtInvInvBal = null;
                int? TtInvBucket = null;
                string TtInvApplyToInvNum = null;
                int? FirstArtranInvSeq = null;
                int? FirstArtranInvSeq1 = null;
                IntType _CustRevDay = DBNull.Value;
                int? CustRevDay = null;
                decimal? TRate1 = null;
                decimal? TRate2 = null;
                decimal? TGainLoss = null;
                decimal? TAmount = null;
                decimal? TAmount1 = null;
                decimal? TAmount2 = null;
                decimal? TDomBal = null;
                decimal? TForBal = null;
                DateTime? ToCustInvDate = null;
                decimal? Amount = null;
                decimal? CustAmtTran = null;
                decimal? FinanceChargeBalance = null;
                decimal? FinanceChargeAmount = null;
                int? FinanceChargeInvSeq = null;
                DateTime? FinanceChargeDueDate = null;
                string FinanceChargeCustNum = null;
                ICollectionLoadRequest curArtranLoadRequestForCursor = null;
                ICollectionLoadResponse curArtranLoadResponseForCursor = null;
                int curArtran_CursorFetch_Status = -1;
                int curArtran_CursorCounter = -1;
                string ProductName = null;
                string FeatureRS6483 = null;
                int? FeatureRS6483Active = null;
                string FeatureInfoBar = null;
                string FeatureRS8071 = null;
                int? FeatureRS8071Active = null;
                ICollectionLoadRequest aCursorLoadRequestForCursor = null;
                ICollectionLoadRequest curSubCustAddrLoadRequestForCursor = null;
                ICollectionLoadResponse curSubCustAddrLoadResponseForCursor = null;
                int curSubCustAddr_CursorFetch_Status = -1;
                int curSubCustAddr_CursorCounter = -1;
                ICollectionLoadRequest fcCrsLoadRequestForCursor = null;
                ICollectionLoadResponse fcCrsLoadResponseForCursor = null;
                int fcCrs_CursorFetch_Status = -1;
                int fcCrs_CursorCounter = -1;
                ICollectionLoadRequest curTtInvLoadRequestForCursor = null;
                ICollectionLoadResponse curTtInvLoadResponseForCursor = null;
                int curTtInv_CursorFetch_Status = -1;
                int curTtInv_CursorCounter = -1;

                #region ETP Block
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AgingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
                )
                {
                    //BEGIN
                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @ALTGEN TABLE (
						    [SpName] SYSNAME);
						SELECT * into #tv_ALTGEN from @ALTGEN");

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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('AgingSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("AgingSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                        items: optional_module1LoadResponse.Items);

                    this.appDB.Insert(optional_module1InsertRequest);
                    #endregion InsertByRecords

                    while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause(""))
                    )
                    {
                        //BEGIN
                        #region CRUD LoadToVariable
                        var tv_ALTGEN1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_ALTGEN_SpName,"[SpName]"},
                            },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            //maximumRows: 1,
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

                        var ALTGEN = AltExtGen_AgingSp(ALTGEN_SpName,
                            ConsolidateCustomers,
                            PSite,
                            PPrOpenItem,
                            PAgingDate,
                            PSumToCorp,
                            PSSlsman,
                            PESlsman,
                            PStateCycle,
                            PCreditHold,
                            PShowActive,
                            PPrZeroBal,
                            PPrCreditBal,
                            PSortByCurr,
                            PPrOpenPay,
                            PCutoffDate,
                            PInvDue,
                            PAgeDays1,
                            PAgeDays2,
                            PAgeDays3,
                            PAgeDays4,
                            PAgeDays5,
                            PHidePaid,
                            PAgeBucket,
                            TGrand,
                            FirstOfCustomer,
                            UseHistRate,
                            TranslateForAging,
                            SiteLabel,
                            TTransDom,
                            CurCustNum,
                            AnyTrans,
                            PAgeDesc1,
                            PAgeDesc2,
                            PAgeDesc3,
                            PAgeDesc4,
                            PAgeDesc5,
                            PArSortBy,
                            ProcessID,
                            IncludeEstCurrGainLossAmtsInTotals);
                        ALTGEN_Severity = ALTGEN.ReturnCode;

                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN_Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                        }
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        #region CRUD LoadToRecord
                        var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"[SpName]","[SpName]"},
                            },
                            loadForChange: false,
                            lockingType: LockingType.None,
                            tableName: "#tv_ALTGEN",
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
                        //END
                    }
                    //END
                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_AgingSp") != null)
                {
                    var EXTGEN = AltExtGen_AgingSp("dbo.EXTGEN_AgingSp",
                        ConsolidateCustomers,
                        PSite,
                        PPrOpenItem,
                        PAgingDate,
                        PSumToCorp,
                        PSSlsman,
                        PESlsman,
                        PStateCycle,
                        PCreditHold,
                        PShowActive,
                        PPrZeroBal,
                        PPrCreditBal,
                        PSortByCurr,
                        PPrOpenPay,
                        PCutoffDate,
                        PInvDue,
                        PAgeDays1,
                        PAgeDays2,
                        PAgeDays3,
                        PAgeDays4,
                        PAgeDays5,
                        PHidePaid,
                        PAgeBucket,
                        TGrand,
                        FirstOfCustomer,
                        UseHistRate,
                        TranslateForAging,
                        SiteLabel,
                        TTransDom,
                        CurCustNum,
                        AnyTrans,
                        PAgeDesc1,
                        PAgeDesc2,
                        PAgeDesc3,
                        PAgeDesc4,
                        PAgeDesc5,
                        PArSortBy,
                        ProcessID,
                        IncludeEstCurrGainLossAmtsInTotals);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN_Severity, EXTGEN.TGrand, EXTGEN.FirstOfCustomer, EXTGEN.UseHistRate, EXTGEN.TranslateForAging, EXTGEN.SiteLabel, EXTGEN.TTransDom, EXTGEN.AnyTrans);
                    }
                }
                #endregion ETP Block

                LogTiming("ALTEXTGEN");

                AnyTrans = 0;
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#AccountsReceivableAging") != null)
                {
                    AgingReport = 1;
                }
                Severity = 0;
                TTotal = 0;
                TcAmtTran = 0;
                NDays = 0;
                I = 0;
                TcAmtDCreditLimit = 0;
                TmpAmount = 0;
                TcAmtTAmt = 0;
                TcAmtTemp = 0;
                CheckBalNow = 0;
                TInvSeq = "0";
                TOpenLength = 0;
                TFirstBucket = 0;
                TLastBucket = 0;
                TOldTransDom = 0;
                usemultiduedate = 0;
                DomArtdBalAmount = 0;
                LowDate = convertToUtil.ToDateTime(this.iLowDate.LowDateFn());
                TOpen = this.iGetLabel.GetLabelFn("@:misc.codes:O");
                TOpenLength = convertToUtil.ToInt32(stringUtil.Len(TOpen));
                Severity = 0;
                TRate1 = 0;
                TRate2 = 0;
                TGainLoss = 0;
                TAmount = 0;
                TAmount1 = 0;
                TAmount2 = 0;
                TDomBal = 0;
                TForBal = 0;
                CustRevDay = null;
                if (this.scalarFunction.Execute<int?>(
                    "OBJECT_ID",
                    "tempdb..#artranc") == null)
                {
                    //BEGIN
                    this.sQLExpressionExecutor.Execute(@"Declare
						@SubCustaddrCustNum CustNumType
						,@TtInvApplyToInvNum InvNumType
						,@InvSeq InvSeqType
						,@CheckSeq ArCheckNumType
						,@TRate ExchRateType
						,@TGainLoss AmountType
						SELECT @SubCustaddrCustNum AS CustNum,
						       @TtInvApplyToInvNum AS InvNum,
						       @InvSeq AS InvSeq,
						       @CheckSeq AS CheckSeq,
						       @TRate AS ExchRate,
						       @TGainLoss AS GainLoss
						INTO   #artranc
						WHERE  1 = 2");
                    this.sQLExpressionExecutor.Execute(@"CREATE INDEX #artranc_2
						    ON #artranc(CustNum, InvNum, InvSeq, CheckSeq)");
                    //END
                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_tt_inv") == null)
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @tt_inv TABLE (
					    RowPointer    RowPointerType,
					    CustNum       CustNumType   ,
					    InvNum        InvNumType    ,
					    InvSeq        InvSeqType    ,
					    ArtranRecid   RowPointerType,
					    Type          ArtranTypeType,
					    InvBal        AmountType    ,
					    Bucket        INT           ,
					    DueDate       DateType      ,
					    Site          SiteType      ,
					    ApplyToInvNum InvNumType     PRIMARY KEY (InvNum, ArtranRecid, CustNum, DueDate, RowPointer));
					SELECT * into #tv_tt_inv from @tt_inv
					ALTER TABLE #tv_tt_inv ADD PRIMARY KEY (InvNum, ArtranRecid, CustNum, DueDate, RowPointer)");
                }

                //this temp table is a table variable in old stored procedure version.
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_artran_all") == null)
                {
                    this.sQLExpressionExecutor.Execute(@"DECLARE @artran_all TABLE (
					    RowPointer        RowPointerType                 ,
					    active            ListYesNoType                  ,
					    exch_rate         ExchRateType                   ,
					    fixed_rate        ListYesNoType                  ,
					    amount            AmountType                     ,
					    misc_charges      AmountType                     ,
					    sales_tax         AmountType                     ,
					    sales_tax_2       AmountType                     ,
					    freight           AmountType                     ,
					    inv_num           InvNumType                     ,
					    apply_to_inv_num  InvNumType                     ,
					    description       DescriptionType                ,
					    due_date          DateType                       ,
					    inv_date          DateType                       ,
					    type              ArtranTypeType                 ,
					    inv_seq           InvSeqType                     ,
					    check_seq         ArCheckNumType                 ,
					    cust_num          CustNumType                    ,
					    site_ref          SiteType                       ,
					    multi_due_date    ListYesNoType                  ,
					    approval_status   ListPendingApprovedRejectedType,
					    OrigAmount        AmountType                     ,
					    seq               INT                            ,
					    curr_code         CurrCodeType                   ,
					    TH_payment_number PaymentNumberType               PRIMARY KEY (cust_num, active, site_ref, apply_to_inv_num, inv_date, inv_num, inv_seq, check_seq, due_date),
					    UNIQUE (inv_num, type, cust_num, inv_seq, site_ref, due_date, check_seq),
					    UNIQUE (type, apply_to_inv_num, due_date, RowPointer));
					SELECT * into #tv_artran_all from @artran_all
					ALTER TABLE #tv_artran_all ADD PRIMARY KEY (cust_num, active, site_ref, apply_to_inv_num, inv_date, inv_num, inv_seq, check_seq, due_date)");
                }

                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_FinList") == null)
                {
                    //this temp table is a table variable in old stored procedure version.
                    this.sQLExpressionExecutor.Execute(@"DECLARE @FinList TABLE (
					    InvSeq  ArInvSeqType,
					    CustNum CustNumType );
					SELECT * into #tv_FinList from @FinList");
                }

                #region CRUD LoadToVariable
                var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_ParmsCurrCode,"currparms.curr_code"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    tableName: "currparms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var currparmsLoadResponse = this.appDB.Load(currparmsLoadRequest);
                if (currparmsLoadResponse.Items.Count > 0)
                {
                    ParmsCurrCode = _ParmsCurrCode;
                }
                #endregion  LoadToVariable

                ProductName = "CSI";
                FeatureRS6483 = "RS6483";

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: IsFeatureActiveSp
                var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
                    ProductName: ProductName,
                    FeatureID: FeatureRS6483,
                    FeatureActive: FeatureRS6483Active,
                    InfoBar: FeatureInfoBar);
                Severity = IsFeatureActive.ReturnCode;
                FeatureRS6483Active = IsFeatureActive.FeatureActive;
                FeatureInfoBar = IsFeatureActive.InfoBar;

                #endregion ExecuteMethodCall

                LogTiming("AGING IS FEATURE ACTIVE");

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    //BEGIN
                    return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);//END
                }
                ProductName = "CSI";
                FeatureRS8071 = "RS8071";

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: IsFeatureActiveSp
                var IsFeatureActive1 = this.iIsFeatureActive.IsFeatureActiveSp(
                    ProductName: ProductName,
                    FeatureID: FeatureRS8071,
                    FeatureActive: FeatureRS8071Active,
                    InfoBar: FeatureInfoBar);
                Severity = IsFeatureActive1.ReturnCode;
                FeatureRS8071Active = IsFeatureActive1.FeatureActive;
                FeatureInfoBar = IsFeatureActive1.InfoBar;

                #endregion ExecuteMethodCall

                LogTiming("AGING currency load to variable");

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                }
                if (sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ThailandCountryPack"), 1) == true && sQLUtil.SQLEqual(FeatureRS8071Active, 1) == true)
                {
                    #region CRUD LoadToVariable
                    var artran_allLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_ArtranPaymentNumber,"TH_payment_number"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        //maximumRows: 1,
                        tableName: "artran_all",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("cust_num = {0} AND inv_seq = {1}", ArtranCustNum, ArtranInvSeq),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var artran_allLoadResponse = this.appDB.Load(artran_allLoadRequest);
                    if (artran_allLoadResponse.Items.Count > 0)
                    {
                        ArtranPaymentNumber = _ArtranPaymentNumber;
                    }
                    #endregion  LoadToVariable
                    LogTiming("AGING artran_all load to variable");
                }
                TFirstBucket = (int?)((sQLUtil.SQLNotEqual(PAgeDays1, 0) == true ? 1 :
                sQLUtil.SQLNotEqual(PAgeDays2, 0) == true ? 1 :
                sQLUtil.SQLNotEqual(PAgeDays3, 0) == true ? 2 :
                sQLUtil.SQLNotEqual(PAgeDays4, 0) == true ? 3 :
                sQLUtil.SQLNotEqual(PAgeDays5, 0) == true ? 4 : 1));
                TLastBucket = (int?)((sQLUtil.SQLNotEqual(PAgeDays5, 0) == true ? 5 :
                sQLUtil.SQLNotEqual(PAgeDays4, 0) == true ? 4 :
                sQLUtil.SQLNotEqual(PAgeDays3, 0) == true ? 3 :
                sQLUtil.SQLNotEqual(PAgeDays2, 0) == true ? 2 : 1));
                TOpt = (sQLUtil.SQLEqual(PPrOpenItem, "N") == true ? "I" : PPrOpenItem);
                SDate = convertToUtil.ToDateTime(PAgingDate);
                CheckBalNow = 1;
                AnyTrans = 0;
                if (sQLUtil.SQLEqual(PSumToCorp, 1) == true && existsChecker.Exists(tableName: "custaddr",
                    fromClause: collectionLoadRequestFactory.Clause(" AS sub_custaddr"),
                    whereClause: collectionLoadRequestFactory.Clause("sub_custaddr.Corp_Cust = {0}", CurCustNum))
                )
                {
                    CheckBalNow = 0;
                }
                CustomerRowPointer = null;
                CustomerSlsman = null;
                CustomerStateCycle = null;
                CustomerContact__3 = null;
                CustomerPhone__3 = null;
                CustomerCustType = null;
                CustomerTermsCode = null;

                #region CRUD LoadToVariable
                var customer_allAScustomerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_CustomerRowPointer,"customer.RowPointer"},
                        {_CustomerSlsman,"customer.slsman"},
                        {_CustomerStateCycle,"customer.state_cycle"},
                        {_CustomerContact__3,"customer.contact##3"},
                        {_CustomerPhone__3,"customer.phone##3"},
                        {_CustomerCustType,"customer.cust_type"},
                        {_CustomerTermsCode,"customer.terms_code"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    //maximumRows: 1,
                    tableName: "customer_all AS customer",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("customer.cust_num = {0} AND customer.cust_seq = 0 AND customer.site_ref = {1}", CurCustNum, PSite),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var customer_allAScustomerLoadResponse = this.appDB.Load(customer_allAScustomerLoadRequest);
                if (customer_allAScustomerLoadResponse.Items.Count > 0)
                {
                    CustomerRowPointer = _CustomerRowPointer;
                    CustomerSlsman = _CustomerSlsman;
                    CustomerStateCycle = _CustomerStateCycle;
                    CustomerContact__3 = _CustomerContact__3;
                    CustomerPhone__3 = _CustomerPhone__3;
                    CustomerCustType = _CustomerCustType;
                    CustomerTermsCode = _CustomerTermsCode;
                }
                #endregion  LoadToVariable

                LogTiming("AGING customer_all load to variable");

                if (CustomerRowPointer != null)
                {
                    //BEGIN
                    if (sQLUtil.SQLBetween(stringUtil.IsNull(
                            CustomerSlsman,
                            this.lowCharacter.LowCharacterFn()), PSSlsman, PESlsman) == true && (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                CustomerStateCycle,
                                PStateCycle), 0) == true || sQLUtil.SQLEqual(PStateCycle, "") == true || PStateCycle == null))
                    {
                        //BEGIN
                        CustaddrRowPointer = null;
                        CustaddrCorpCust = null;
                        CustaddrCustNum = null;
                        CustaddrCreditLimit = 0;
                        CustaddrCurrCode = null;
                        CustaddrName = null;
                        CustaddrCity = null;
                        CustaddrState = null;

                        #region CRUD LoadToVariable
                        var custaddr1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_CustaddrRowPointer,"custaddr.RowPointer"},
                                {_CustaddrCorpCust,"custaddr.corp_cust"},
                                {_CustaddrCustNum,"custaddr.cust_num"},
                                {_CustaddrCreditLimit,"custaddr.credit_limit"},
                                {_CustaddrCurrCode,"custaddr.curr_code"},
                                {_CustaddrName,"custaddr.name"},
                                {_CustaddrCity,"custaddr.city"},
                                {_CustaddrState,"custaddr.state"},
                            },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            //maximumRows: 1,
                            tableName: "custaddr",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num = {0} AND custaddr.cust_seq = 0", CurCustNum),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var custaddr1LoadResponse = this.appDB.Load(custaddr1LoadRequest);
                        if (custaddr1LoadResponse.Items.Count > 0)
                        {
                            CustaddrRowPointer = _CustaddrRowPointer;
                            CustaddrCorpCust = _CustaddrCorpCust;
                            CustaddrCustNum = _CustaddrCustNum;
                            CustaddrCreditLimit = _CustaddrCreditLimit;
                            CustaddrCurrCode = _CustaddrCurrCode;
                            CustaddrName = _CustaddrName;
                            CustaddrCity = _CustaddrCity;
                            CustaddrState = _CustaddrState;
                        }
                        #endregion  LoadToVariable
                        //END

                        LogTiming("AGING custaddr load to variable");
                    }
                    else
                    {
                        return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                    }
                    //END
                }
                else
                {
                    //BEGIN
                    CustaddrRowPointer = null;
                    CustaddrCorpCust = null;
                    CustaddrCustNum = null;
                    CustaddrCreditLimit = 0;
                    CustaddrCurrCode = null;
                    CustaddrName = null;
                    CustaddrCity = null;
                    CustaddrState = null;

                    #region CRUD LoadToVariable
                    var custaddr2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_CustaddrRowPointer,"custaddr.RowPointer"},
                            {_CustaddrCorpCust,"custaddr.corp_cust"},
                            {_CustaddrCustNum,"custaddr.cust_num"},
                            {_CustaddrCreditLimit,"custaddr.credit_limit"},
                            {_CustaddrCurrCode,"custaddr.curr_code"},
                            {_CustaddrName,"custaddr.name"},
                            {_CustaddrCity,"custaddr.city"},
                            {_CustaddrState,"custaddr.state"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        //maximumRows: 1,
                        tableName: "custaddr",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("custaddr.cust_num = {0} AND custaddr.cust_seq = 0", CurCustNum),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var custaddr2LoadResponse = this.appDB.Load(custaddr2LoadRequest);
                    if (custaddr2LoadResponse.Items.Count > 0)
                    {
                        CustaddrRowPointer = _CustaddrRowPointer;
                        CustaddrCorpCust = _CustaddrCorpCust;
                        CustaddrCustNum = _CustaddrCustNum;
                        CustaddrCreditLimit = _CustaddrCreditLimit;
                        CustaddrCurrCode = _CustaddrCurrCode;
                        CustaddrName = _CustaddrName;
                        CustaddrCity = _CustaddrCity;
                        CustaddrState = _CustaddrState;
                    }
                    #endregion  LoadToVariable
                    LogTiming("AGING custaddr load to variable");

                    if (CustaddrRowPointer == null)
                    {
                        return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                    }
                    //END
                }

                #region CRUD LoadToVariable
                var customerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_CustRevDay,"customer.use_revision_pay_days"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    //maximumRows: 1,
                    tableName: "customer",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("customer.cust_num = {0} AND customer.cust_seq = 0", CurCustNum),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var customerLoadResponse = this.appDB.Load(customerLoadRequest);
                if (customerLoadResponse.Items.Count > 0)
                {
                    CustRevDay = _CustRevDay;
                }
                #endregion  LoadToVariable
                LogTiming("AGING customer load to variable");

                if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                {
                    //BEGIN
                    #region CRUD LoadToVariable
                    var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_CurrencyPlaces,"places"},
                            {_CurrencyFormat,"amt_format"},
                            {_TotalCurrencyFormat,"amt_tot_format"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        //maximumRows: 1,
                        tableName: "currency",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("curr_code = {0}", ParmsCurrCode),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
                    if (currencyLoadResponse.Items.Count > 0)
                    {
                        CurrencyPlaces = _CurrencyPlaces;
                        CurrencyFormat = _CurrencyFormat;
                        TotalCurrencyFormat = _TotalCurrencyFormat;
                    }
                    #endregion  LoadToVariable
                    LogTiming("AGING currency load to variable");

                    CurrencyCode = ParmsCurrCode;
                    //END
                }
                else
                {
                    //BEGIN
                    #region CRUD LoadToVariable
                    var currency1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_CurrencyPlaces,"places"},
                            {_CurrencyFormat,"amt_format"},
                            {_TotalCurrencyFormat,"amt_tot_format"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        //maximumRows: 1,
                        tableName: "currency",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("curr_code = {0}", CustaddrCurrCode),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var currency1LoadResponse = this.appDB.Load(currency1LoadRequest);
                    if (currency1LoadResponse.Items.Count > 0)
                    {
                        CurrencyPlaces = _CurrencyPlaces;
                        CurrencyFormat = _CurrencyFormat;
                        TotalCurrencyFormat = _TotalCurrencyFormat;
                    }
                    #endregion  LoadToVariable

                    LogTiming("AGING currency load to variable");

                    CurrencyCode = CustaddrCurrCode;
                    //END
                }
                GetWinRegDecGroup = convertToUtil.ToString(this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                LogTiming("AGING GetWinRegDecGroupFn");

                CurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    CurrencyFormat,
                    GetWinRegDecGroup);

                LogTiming("AGING CurrencyFormat FixMaskForCrystalFn");

                TotalCurrencyFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    TotalCurrencyFormat,
                    GetWinRegDecGroup);

                LogTiming("AGING TotalCurrencyFormat FixMaskForCrystalFn");

                DecimalPlaces = 0;
                IntPosition = convertToUtil.ToInt32(stringUtil.CharIndex(
                    ".",
                    TotalCurrencyFormat));
                if (sQLUtil.SQLGreaterThan(IntPosition, 0) == true)
                {
                    DecimalPlaces = convertToUtil.ToInt32(stringUtil.Len(stringUtil.Substring(
                        TotalCurrencyFormat,
                        IntPosition + 1,
                        stringUtil.Len(TotalCurrencyFormat))));

                }
                TotalCurrencyPlaces = DecimalPlaces;
                if (sQLUtil.SQLEqual(PSumToCorp, 1) == true && sQLUtil.SQLNotEqual(CustaddrCorpCust, "") == true)
                {
                    return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                }

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: ChkcredSp
                var Chkcred = this.iChkcred.ChkcredSp(
                    CustNum: CustaddrCustNum,
                    CredHold: TCredhold);
                TCredhold = Chkcred.CredHold;

                LogTiming("AGING ChkcredSp");

                #endregion ExecuteMethodCall

                if (sQLUtil.SQLNotEqual(TCredhold, "") == true)
                {
                    TCredhold = stringUtil.Concat("*", stringUtil.Upper(this.iGetLabel.GetLabelFn("@co.credit_hold")), "*");

                }
                if (sQLUtil.SQLEqual(FirstOfCustomer, 1) == true && sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                        PCreditHold,
                        "Y,N"), 0) == true)
                {
                    if (sQLUtil.SQLNotEqual(((sQLUtil.SQLEqual(TCredhold, "") == true || TCredhold == null ? "N" : "Y")), PCreditHold) == true)
                    {
                        return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                    }

                }
                TcTotMinorBal = 0;
                TcTotBal = 0;

                #region DeleteNonTrigger
                var tv_tt_invTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                    tableName: "#tv_tt_inv",
                    fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                    whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                    );
                this.appDB.DeleteWithoutTrigger(tv_tt_invTriggerDeleteRequest);
                #endregion DeleteNonTrigger

                #region InsertNonTrigger
                var tmp_artran_allNonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                    targetTableName: "#tv_artran_all",
                    targetColumns: new List<string>()
                    { "RowPointer",
                      "active",
                      "exch_rate",
                      "fixed_rate",
                      "amount",
                      "misc_charges",
                      "sales_tax",
                      "sales_tax_2",
                      "freight",
                      "inv_num",
                      "apply_to_inv_num",
                      "description",
                      "due_date",
                      "inv_date",
                      "type",
                      "inv_seq",
                      "check_seq",
                      "cust_num",
                      "site_ref",
                      "multi_due_date",
                      "approval_status",
                      "OrigAmount",
                      "seq",
                      "curr_code",
                      "TH_payment_number"
                    },
                    valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                    {
                        {"RowPointer",collectionNonTriggerInsertRequestFactory.Clause("artran.RowPointer")},
                        {"active",collectionNonTriggerInsertRequestFactory.Clause("artran.active")},
                        {"exch_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.exch_rate")},
                        {"fixed_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.fixed_rate")},
                        {"amount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                        {"misc_charges",collectionNonTriggerInsertRequestFactory.Clause("artran.misc_charges")},
                        {"sales_tax",collectionNonTriggerInsertRequestFactory.Clause("artran.sales_tax")},
                        {"sales_tax_2",collectionNonTriggerInsertRequestFactory.Clause("artran.sales_tax_2")},
                        {"freight",collectionNonTriggerInsertRequestFactory.Clause("artran.freight")},
                        {"inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_num")},
                        {"apply_to_inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.apply_to_inv_num")},
                        {"description",collectionNonTriggerInsertRequestFactory.Clause("artran.description")},
                        {"due_date",collectionNonTriggerInsertRequestFactory.Clause("ISNULL(artran.due_date,{0})",LowDate)},
                        {"inv_date",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_date")},
                        {"type",collectionNonTriggerInsertRequestFactory.Clause("artran.type")},
                        {"inv_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_seq")},
                        {"check_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.check_seq")},
                        {"cust_num",collectionNonTriggerInsertRequestFactory.Clause("artran.cust_num")},
                        {"site_ref",collectionNonTriggerInsertRequestFactory.Clause("artran.site_ref")},
                        {"multi_due_date",collectionNonTriggerInsertRequestFactory.Clause("0")},
                        {"approval_status",collectionNonTriggerInsertRequestFactory.Clause("artran.approval_status")},
                        {"OrigAmount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                        {"seq",collectionNonTriggerInsertRequestFactory.Clause("case when artran.type = 'I' then 0 else 1 end")},
                        {"curr_code",collectionNonTriggerInsertRequestFactory.Clause("artran.curr_code")},
                        {"TH_payment_number",collectionNonTriggerInsertRequestFactory.Clause("artran.TH_payment_number")},
                    },
                    fromClause: collectionNonTriggerInsertRequestFactory.Clause("tmp_artran_all AS artran"),
                    whereClause: collectionNonTriggerInsertRequestFactory.Clause("artran.ProcessID = {4} AND artran.site_ref = {5} AND artran.cust_num = {0} AND artran.active = (CASE WHEN {1} = 1 THEN 1 ELSE artran.active END) AND artran.inv_date <= (CASE WHEN {2} IS NOT NULL THEN {2} ELSE artran.inv_date END) AND ({3} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0')", CustaddrCustNum, PShowActive, PCutoffDate, PPrOpenPay, ProcessID, PSite),
                    orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                    );

                this.appDB.InsertWithoutTrigger(tmp_artran_allNonTriggerInsertRequest);
                #endregion InsertNonTrigger

                LogTiming("AGING INSERT TO #tv_artran_all");

                if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(PPrOpenPay, 1), sQLUtil.SQLEqual(FeatureRS6483Active, 1)), sQLUtil.SQLEqual(AgingReport, 1))))
                {
                    //BEGIN

                    #region CRUD LoadArbitrary
                    var tv_artran_allLoadRequest = collectionLoadStatementRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            { "RowPointer", "artran.RowPointer" },
                            { "active", "1" },
                            { "exch_rate", "artran.exch_rate" },
                            { "fixed_rate", "0" },
                            { "amount", "artran.amount" },
                            { "misc_charges", "artran.misc_charges" },
                            { "sales_tax", "0" },
                            { "sales_tax_2", "0" },
                            { "freight", "0" },
                            { "inv_num", "artran.inv_num" },
                            { "apply_to_inv_num", "0" },
                            { "description", "null" },
                            { "due_date", $"isnull(artran.due_date, {variableUtil.GetQuotedValue<DateTime?>(LowDate)})" },
                            { "inv_date", "artran.inv_date" },
                            { "type", "artran.type" },
                            { "inv_seq", "artran.inv_seq" },
                            { "check_seq", "artran.check_seq" },
                            { "cust_num", "artran.cust_num" },
                            { "site_ref", "artran.site_ref" },
                            { "multi_due_date", "0" },
                            { "approval_status", "null" },
                            { "OrigAmount", "artran.amount" },
                            { "seq", "1" },
                            { "curr_code", "artran.curr_code" },
                            { "TH_payment_number", "null" },
                        },
                        selectStatement: collectionLoadRequestFactory.Clause(@";WITH ARAll
							AS (SELECT   artopen.cust_num,
								artopen.type,
								CASE WHEN artopen.type = 'C' THEN ISNULL(artopen.inv_num, '') ELSE ISNULL(CAST (artopen.inv_seq AS NVARCHAR (24)), '') END AS number,
								ISNULL(SUM((artall.amount + artall.misc_charges + artall.sales_tax + artall.sales_tax_2 + artall.freight) / artall.exch_rate), 0) AS amount
								FROM     artran_open_all AS artopen
								LEFT OUTER JOIN
								artran_all AS artall
								ON ((artopen.type = 'P'
										AND artall.type = 'P'
										AND artall.inv_seq = artopen.inv_seq
										AND artall.orig_site = {3} )
									OR (artopen.type = 'C'
										AND artall.type = 'C'
										AND artall.inv_num = artopen.inv_num
										AND artall.orig_site = {3} ))
								AND (artall.orig_cust_num = artopen.cust_num
									OR artall.cust_num = artopen.cust_num)
								AND artall.inv_date <= (CASE WHEN {2}  IS NOT NULL THEN {2}  ELSE artall.inv_date END)
								WHERE    artopen.inv_date <= (CASE WHEN {2}  IS NOT NULL THEN {2}  ELSE artopen.inv_date END)
								AND artopen.cust_num = {0}
								AND artopen.site_ref = {3}
								GROUP BY artopen.cust_num, artopen.type, CASE WHEN artopen.type = 'C' THEN ISNULL(artopen.inv_num, '') ELSE ISNULL(CAST (artopen.inv_seq AS NVARCHAR (24)), '') END)
							SELECT @selectList
							FROM artran_open_all AS artran
							LEFT OUTER JOIN
							ARAll
							ON ARAll.cust_num = artran.cust_num
							AND ARAll.type = artran.type
							AND ARAll.number = CASE WHEN artran.type = 'C' THEN ISNULL(artran.inv_num, '') ELSE ISNULL(CAST (artran.inv_seq AS NVARCHAR (24)), '') END
							WHERE artran.inv_date <= (CASE WHEN {6}  IS NOT NULL THEN {6}  ELSE artran.inv_date END)
							AND artran.cust_num = {4}
							AND artran.site_ref = {7}
							AND NOT EXISTS (SELECT 1
								FROM   #tv_artran_all AS tmp_artran
								WHERE  tmp_artran.apply_to_inv_num = '0'
								AND tmp_artran.cust_num = artran.cust_num
								AND tmp_artran.inv_num = artran.inv_num
								AND tmp_artran.inv_seq = artran.inv_seq
								AND tmp_artran.check_seq = artran.check_seq)
                            AND NOT EXISTS(SELECT 1
                                FROM artran_all temp_artran_all
                                WHERE temp_artran_all.cust_num = artran.cust_num
                                AND temp_artran_all.type = artran.type
                                AND temp_artran_all.inv_num = artran.inv_num
                                AND temp_artran_all.inv_seq = artran.inv_seq
                                AND temp_artran_all.check_seq = artran.check_seq)
                            and not exists (select 1 from artran_all as aa2
                                  where aa2.site_ref = artran.site_ref
                                  and aa2.cust_num = artran.cust_num
                                  and aa2.inv_seq = artran.inv_seq)
							AND artran.amount <> ARAll.amount", CustaddrCustNum, PShowActive, PCutoffDate, PSite, CustaddrCustNum, PShowActive, PCutoffDate, PSite));

                    var tv_artran_allLoadResponse = this.appDB.Load(tv_artran_allLoadRequest);
                    #endregion  LoadArbitrary

                    #region CRUD InsertByRecords
                    var tv_artran_allInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_artran_all",
                        items: tv_artran_allLoadResponse.Items);

                    this.appDB.Insert(tv_artran_allInsertRequest);
                    #endregion InsertByRecords

                    //END
                    LogTiming("AGING INSERT TO #tv_artran_all");

                }

                #region Cursor Statement

                #region CRUD LoadToRecord
                aCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"RowPointer","artran.RowPointer"},
                        {"active","artran.active"},
                        {"exch_rate","artran.exch_rate"},
                        {"fixed_rate","artran.fixed_rate"},
                        {"amount","artran.amount"},
                        {"misc_charges","artran.misc_charges"},
                        {"sales_tax","artran.sales_tax"},
                        {"sales_tax_2","artran.sales_tax_2"},
                        {"freight","artran.freight"},
                        {"inv_num","artran.inv_num"},
                        {"apply_to_inv_num","artran.apply_to_inv_num"},
                        {"description","artran.description"},
                        {"col0","CAST (NULL AS DATETIME)"},
                        {"inv_date","artran.inv_date"},
                        {"type","artran.type"},
                        {"inv_seq","artran.inv_seq"},
                        {"check_seq","artran.check_seq"},
                        {"cust_num","artran.cust_num"},
                        {"site_ref","artran.site_ref"},
                        {"approval_status","artran.approval_status"},
                        {"TH_payment_number","artran.TH_payment_number"},
                        {"u0","artran.due_date"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    tableName: "artran_all",
                    fromClause: collectionLoadRequestFactory.Clause(" AS artran"),
                    whereClause: collectionLoadRequestFactory.Clause("artran.site_ref = {4} AND artran.cust_num = {0} AND artran.inv_date <= (CASE WHEN {1} IS NOT NULL THEN {1} ELSE artran.inv_date END) AND artran.active = (CASE WHEN {2} = 1 THEN 1 ELSE artran.active END) AND ({3} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0') AND (EXISTS (SELECT 1 FROM ar_terms_due_all WHERE site_ref = artran.site_ref AND cust_num = {0} AND inv_num = artran.inv_num AND inv_seq = artran.inv_seq) AND CHARINDEX(artran.type, 'ID') <> 0)", CustaddrCustNum, PCutoffDate, PShowActive, PPrOpenPay, PSite),
                    orderByClause: collectionLoadRequestFactory.Clause(" cust_num, apply_to_inv_num, site_ref, inv_num, inv_seq, check_seq"));
                #endregion LoadToRecord


                #region aCursor Refactored
                Dictionary<string, SortOrderDirection> aCursorSort = new Dictionary<string, SortOrderDirection>();
                aCursorSort.Add("cust_num", SortOrderDirection.Ascending);
                aCursorSort.Add("apply_to_inv_num", SortOrderDirection.Ascending);
                aCursorSort.Add("site_ref", SortOrderDirection.Ascending);
                aCursorSort.Add("inv_num", SortOrderDirection.Ascending);
                aCursorSort.Add("inv_seq", SortOrderDirection.Ascending);
                aCursorSort.Add("check_seq", SortOrderDirection.Ascending);

                using (IRecordStream aCursorRecordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory, aCursorLoadRequestForCursor,
                    sortOrderFactory.Create(aCursorSort), SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, LoadType.First, false))
                {
                    __Site = null;
                    __active = null;
                    __description = null;

                    while (aCursorRecordStream.Read())
                    {
                        IRecordReadOnly aCursorCurrent = aCursorRecordStream.Current;
                        __ArtranRowPointer = aCursorCurrent.GetValue<Guid?>("RowPointer");
                        __active = aCursorCurrent.GetValue<int?>("active");
                        __ArtranExchRate = aCursorCurrent.GetValue<decimal?>("exch_rate");
                        __ArtranFixedRate = aCursorCurrent.GetValue<int?>("fixed_rate");
                        __ArtranAmount = aCursorCurrent.GetValue<decimal?>("amount");
                        __ArtranMiscCharges = aCursorCurrent.GetValue<decimal?>("misc_charges");
                        __ArtranSalesTax = aCursorCurrent.GetValue<decimal?>("sales_tax");
                        __ArtranSalesTax2 = aCursorCurrent.GetValue<decimal?>("sales_tax_2");
                        __ArtranFreight = aCursorCurrent.GetValue<decimal?>("freight");
                        __ArtranInvNum = aCursorCurrent.GetValue<string>("inv_num");
                        __ArtranApplyToInvNum = aCursorCurrent.GetValue<string>("apply_to_inv_num");
                        __description = aCursorCurrent.GetValue<string>("description");
                        __ArtranDueDate = stringUtil.IsNull(aCursorCurrent.GetValue<DateTime?>("u0"), LowDate);
                        __ArtranInvDate = aCursorCurrent.GetValue<DateTime?>("inv_date");
                        __ArtranType = aCursorCurrent.GetValue<string>("type");
                        __ArtranInvSeq = aCursorCurrent.GetValue<int?>("inv_seq");
                        __ArtranCheckSeq = aCursorCurrent.GetValue<int?>("check_seq");
                        __ArtranCustNum = aCursorCurrent.GetValue<string>("cust_num");
                        __Site = aCursorCurrent.GetValue<string>("site_ref");
                        __ArtranApprovalStatus = aCursorCurrent.GetValue<string>("approval_status");
                        __ArtranPaymentNumber = aCursorCurrent.GetValue<string>("TH_payment_number");

                        iArTermDue.ArTermDueFn(PSite, __ArtranCustNum, __ArtranInvNum, __ArtranInvSeq, PCutoffDate);

                        #region CRUD LoadToRecord
                        var fnt_ArTermDueLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"RowPointer","CAST (NULL AS NVARCHAR)"},
                            {"active","CAST (NULL AS INT)"},
                            {"exch_rate","CAST (NULL AS DECIMAL)"},
                            {"fixed_rate","CAST (NULL AS INT)"},
                            {"amount","CAST (NULL AS DECIMAL)"},
                            {"misc_charges","CAST (NULL AS INT)"},
                            {"sales_tax","CAST (NULL AS INT)"},
                            {"sales_tax_2","CAST (NULL AS INT)"},
                            {"freight","CAST (NULL AS INT)"},
                            {"inv_num","CAST (NULL AS NVARCHAR)"},
                            {"apply_to_inv_num","CAST (NULL AS NVARCHAR)"},
                            {"description","CAST (NULL AS NVARCHAR)"},
                            {"due_date","CAST (NULL AS DATETIME)"},
                            {"inv_date","CAST (NULL AS DATETIME)"},
                            {"type","CAST (NULL AS NVARCHAR)"},
                            {"inv_seq","CAST (NULL AS INT)"},
                            {"check_seq","CAST (NULL AS INT)"},
                            {"cust_num","CAST (NULL AS NVARCHAR)"},
                            {"site_ref","CAST (NULL AS NVARCHAR)"},
                            {"multi_due_date","CAST (NULL AS INT)"},
                            {"approval_status","CAST (NULL AS NVARCHAR)"},
                            {"OrigAmount","CAST (NULL AS DECIMAL)"},
                            {"seq","CAST (NULL AS INT)"},
                            {"curr_code","CAST (NULL AS NVARCHAR)"},
                            {"TH_payment_number","CAST (NULL AS NVARCHAR)"},
                            {"u0","pamount"},
                            {"u1","DueDate"},
                            {"u2","balance2"},
                        },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            tableName: "#fnt_ArTermDue",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause(""),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var fnt_ArTermDueLoadResponse = this.appDB.Load(fnt_ArTermDueLoadRequest);
                        #endregion  LoadToRecord

                        #region CRUD InsertByRecords
                        foreach (var fnt_ArTermDueItem in fnt_ArTermDueLoadResponse.Items)
                        {
                            fnt_ArTermDueItem.SetValue<Guid?>("RowPointer", __ArtranRowPointer);
                            fnt_ArTermDueItem.SetValue<int?>("active", __active);
                            fnt_ArTermDueItem.SetValue<decimal?>("exch_rate", __ArtranExchRate);
                            fnt_ArTermDueItem.SetValue<int?>("fixed_rate", __ArtranFixedRate);
                            fnt_ArTermDueItem.SetValue<decimal?>("amount", fnt_ArTermDueItem.GetValue<decimal?>("u0"));
                            fnt_ArTermDueItem.SetValue<int?>("misc_charges", 0);
                            fnt_ArTermDueItem.SetValue<int?>("sales_tax", 0);
                            fnt_ArTermDueItem.SetValue<int?>("sales_tax_2", 0);
                            fnt_ArTermDueItem.SetValue<int?>("freight", 0);
                            fnt_ArTermDueItem.SetValue<string>("inv_num", __ArtranInvNum);
                            fnt_ArTermDueItem.SetValue<string>("apply_to_inv_num", __ArtranApplyToInvNum);
                            fnt_ArTermDueItem.SetValue<string>("description", __description);
                            fnt_ArTermDueItem.SetValue<DateTime?>("due_date", fnt_ArTermDueItem.GetValue<DateTime?>("u1"));
                            fnt_ArTermDueItem.SetValue<DateTime?>("inv_date", __ArtranInvDate);
                            fnt_ArTermDueItem.SetValue<string>("type", __ArtranType);
                            fnt_ArTermDueItem.SetValue<int?>("inv_seq", __ArtranInvSeq);
                            fnt_ArTermDueItem.SetValue<int?>("check_seq", __ArtranCheckSeq);
                            fnt_ArTermDueItem.SetValue<string>("cust_num", __ArtranCustNum);
                            fnt_ArTermDueItem.SetValue<string>("site_ref", PSite);
                            fnt_ArTermDueItem.SetValue<int?>("multi_due_date", 1);
                            fnt_ArTermDueItem.SetValue<string>("approval_status", __ArtranApprovalStatus);
                            fnt_ArTermDueItem.SetValue<decimal?>("OrigAmount", fnt_ArTermDueItem.GetValue<decimal?>("u2"));
                            fnt_ArTermDueItem.SetValue<int?>("seq", (sQLUtil.SQLEqual(__ArtranType, "I") == true ? 0 : 1));
                            fnt_ArTermDueItem.SetValue<string>("curr_code", __ArtranCurrCode);
                            fnt_ArTermDueItem.SetValue<string>("TH_payment_number", __ArtranPaymentNumber);
                        };

                        var fnt_ArTermDueRequiredColumns = new List<string>() { "RowPointer", "active", "exch_rate", "fixed_rate", "amount", "misc_charges", "sales_tax", "sales_tax_2", "freight", "inv_num", "apply_to_inv_num", "description", "due_date", "inv_date", "type", "inv_seq", "check_seq", "cust_num", "site_ref", "multi_due_date", "approval_status", "OrigAmount", "seq", "curr_code", "TH_payment_number" };

                        fnt_ArTermDueLoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(fnt_ArTermDueLoadResponse, fnt_ArTermDueRequiredColumns);

                        var fnt_ArTermDueInsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_artran_all",
                            items: fnt_ArTermDueLoadResponse.Items);

                        this.appDB.Insert(fnt_ArTermDueInsertRequest);
                        #endregion InsertByRecords

                        if (sQLUtil.SQLEqual(fnt_ArTermDueLoadResponse.Items.Count, 0) == true)
                        {
                            #region InsertNonTrigger
                            var tmp_artran_all2NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_artran_all",
                                targetColumns: new List<string>()
                                { "RowPointer",
                                  "active",
                                  "exch_rate",
                                  "fixed_rate",
                                  "amount",
                                  "misc_charges",
                                  "sales_tax",
                                  "sales_tax_2",
                                  "freight",
                                  "inv_num",
                                  "apply_to_inv_num",
                                  "description",
                                  "due_date",
                                  "inv_date",
                                  "type",
                                  "inv_seq",
                                  "check_seq",
                                  "cust_num",
                                  "site_ref",
                                  "multi_due_date",
                                  "approval_status",
                                  "OrigAmount",
                                  "seq",
                                  "curr_code",
                                  "TH_payment_number"
                                },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                    {"RowPointer",collectionNonTriggerInsertRequestFactory.Clause("artran.RowPointer")},
                                    {"active",collectionNonTriggerInsertRequestFactory.Clause("artran.active")},
                                    {"exch_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.exch_rate")},
                                    {"fixed_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.fixed_rate")},
                                    {"amount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                                    {"misc_charges",collectionNonTriggerInsertRequestFactory.Clause("artran.misc_charges")},
                                    {"sales_tax",collectionNonTriggerInsertRequestFactory.Clause("artran.sales_tax")},
                                    {"sales_tax_2",collectionNonTriggerInsertRequestFactory.Clause("artran.sales_tax_2")},
                                    {"freight",collectionNonTriggerInsertRequestFactory.Clause("artran.freight")},
                                    {"inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_num")},
                                    {"apply_to_inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.apply_to_inv_num")},
                                    {"description",collectionNonTriggerInsertRequestFactory.Clause("artran.description")},
                                    {"due_date",collectionNonTriggerInsertRequestFactory.Clause("ISNULL(artran.due_date,{0})",LowDate)},
                                    {"inv_date",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_date")},
                                    {"type",collectionNonTriggerInsertRequestFactory.Clause("artran.type")},
                                    {"inv_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_seq")},
                                    {"check_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.check_seq")},
                                    {"cust_num",collectionNonTriggerInsertRequestFactory.Clause("artran.cust_num")},
                                    {"site_ref",collectionNonTriggerInsertRequestFactory.Clause("artran.site_ref")},
                                    {"multi_due_date",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"approval_status",collectionNonTriggerInsertRequestFactory.Clause("artran.approval_status")},
                                    {"OrigAmount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                                    {"seq",collectionNonTriggerInsertRequestFactory.Clause("case when artran.type = 'I' then 0 else 1 end")},
                                    {"curr_code",collectionNonTriggerInsertRequestFactory.Clause("artran.curr_code")},
                                    {"TH_payment_number",collectionNonTriggerInsertRequestFactory.Clause("artran.TH_payment_number")},
                                },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause("artran_all AS artran"),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause("artran.site_ref = {3} AND artran.cust_num = {0} AND artran.inv_num = {1} AND artran.inv_seq = {2}", CustaddrCustNum, __ArtranInvNum, __ArtranInvSeq, PSite),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                );

                            this.appDB.InsertWithoutTrigger(tmp_artran_all2NonTriggerInsertRequest);
                            #endregion InsertNonTrigger
                        }
                    }
                }
                #endregion

                #endregion Cursor Statement                
                //Deallocate Cursor aCursor

                #region CRUD LoadToRecord
                curArtranLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"RowPointer","artran.RowPointer"},
                        {"exch_rate","artran.exch_rate"},
                        {"fixed_rate","artran.fixed_rate"},
                        {"amount","artran.amount"},
                        {"misc_charges","artran.misc_charges"},
                        {"sales_tax","artran.sales_tax"},
                        {"sales_tax_2","artran.sales_tax_2"},
                        {"freight","artran.freight"},
                        {"inv_num","artran.inv_num"},
                        {"apply_to_inv_num","artran.apply_to_inv_num"},
                        {"col0","CAST (NULL AS DATETIME)"},
                        {"inv_date","artran.inv_date"},
                        {"type","artran.type"},
                        {"inv_seq","artran.inv_seq"},
                        {"check_seq","artran.check_seq"},
                        {"cust_num","artran.cust_num"},
                        {"multi_due_date","artran.multi_due_date"},
                        {"approval_status","artran.approval_status"},
                        {"curr_code","artran.curr_code"},
                        {"TH_payment_number","artran.TH_payment_number"},
                        {"u0","artran.due_date"},
                        {"seq", "seq"},
                        {"site_ref", "site_ref"},
                        {"due_date", "due_date"},
                        {"active", "active"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    tableName: "#tv_artran_all",
                    fromClause: collectionLoadRequestFactory.Clause(" AS artran"),
                    whereClause: collectionLoadRequestFactory.Clause("artran.cust_num = {0} AND artran.active = (CASE WHEN {1} = 1 THEN 1 ELSE artran.active END) AND artran.site_ref = {4} AND artran.inv_date <= (CASE WHEN {2} IS NOT NULL THEN {2} ELSE artran.inv_date END) AND ({3} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0')", CustaddrCustNum, PShowActive, PCutoffDate, PPrOpenPay, PSite),
                    orderByClause: collectionLoadRequestFactory.Clause(" cust_num, apply_to_inv_num, seq, inv_num, inv_seq, check_seq, site_ref, inv_date, due_date, active"));
                #endregion  LoadToRecord

                LogTiming("AGING RECORD STREAM LOAD from #tv_artran_all");

                Dictionary<string, SortOrderDirection> dicCurArtranSort = new Dictionary<string, SortOrderDirection>();
                dicCurArtranSort.Add("cust_num", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("apply_to_inv_num", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("seq", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("inv_num", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("inv_seq", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("check_seq", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("site_ref", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("inv_date", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("due_date", SortOrderDirection.Ascending);
                dicCurArtranSort.Add("active", SortOrderDirection.Ascending);
                ISortOrder curArtranSortOrder = sortOrderFactory.Create(dicCurArtranSort);

                using (IRecordStream curArtranStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory,
                    curArtranLoadRequestForCursor, curArtranSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, LoadType.First, false))
                {
                    bool readStatus = curArtranStream.Read();

                    if (readStatus)
                    {
                        IRecordReadOnly currentCurArtran = curArtranStream.Current;
                        __ArtranRowPointer = currentCurArtran.GetValue<Guid?>("RowPointer");
                        __ArtranExchRate = currentCurArtran.GetValue<decimal?>("exch_rate");
                        __ArtranFixedRate = currentCurArtran.GetValue<int?>("fixed_rate");
                        __ArtranAmount = currentCurArtran.GetValue<decimal?>("amount");
                        __ArtranMiscCharges = currentCurArtran.GetValue<decimal?>("misc_charges");
                        __ArtranSalesTax = currentCurArtran.GetValue<decimal?>("sales_tax");
                        __ArtranSalesTax2 = currentCurArtran.GetValue<decimal?>("sales_tax_2");
                        __ArtranFreight = currentCurArtran.GetValue<decimal?>("freight");
                        __ArtranInvNum = currentCurArtran.GetValue<string>("inv_num");
                        __ArtranApplyToInvNum = currentCurArtran.GetValue<string>("apply_to_inv_num");
                        __ArtranDueDate = currentCurArtran.GetValue<DateTime?>("u0") == LowDate ? null : currentCurArtran.GetValue<DateTime?>("u0");
                        __ArtranInvDate = currentCurArtran.GetValue<DateTime?>("inv_date");
                        __ArtranType = currentCurArtran.GetValue<string>("type");
                        __ArtranInvSeq = currentCurArtran.GetValue<int?>("inv_seq");
                        __ArtranCheckSeq = currentCurArtran.GetValue<int?>("check_seq");
                        __ArtranCustNum = currentCurArtran.GetValue<string>("cust_num");
                        __usemultiduedate = currentCurArtran.GetValue<int?>("multi_due_date");
                        __ArtranApprovalStatus = currentCurArtran.GetValue<string>("approval_status");
                        __ArtranCurrCode = currentCurArtran.GetValue<string>("curr_code");
                        __ArtranPaymentNumber = currentCurArtran.GetValue<string>("TH_payment_number");
                    }

                    EofArtran = readStatus ? 0 : 1;
                    LastOfArtranInvNum = 1;
                    while (1 == 1)
                    {
                        if (EofArtran != 0)
                        {
                            break;
                        }
                        ArtranInvNumForFirstOF = LastOfArtranInvNum;

                        ArtranRowPointer = __ArtranRowPointer;
                        ArtranExchRate = __ArtranExchRate;
                        ArtranFixedRate = __ArtranFixedRate;
                        ArtranAmount = __ArtranAmount;
                        ArtranMiscCharges = __ArtranMiscCharges;
                        ArtranSalesTax = __ArtranSalesTax;
                        ArtranSalesTax2 = __ArtranSalesTax2;
                        ArtranFreight = __ArtranFreight;
                        ArtranInvNum = __ArtranInvNum;
                        ArtranApplyToInvNum = __ArtranApplyToInvNum;
                        ArtranDueDate = __ArtranDueDate;
                        ArtranInvDate = __ArtranInvDate;
                        ArtranType = __ArtranType;
                        ArtranInvSeq = __ArtranInvSeq;
                        ArtranCheckSeq = __ArtranCheckSeq;
                        ArtranCustNum = __ArtranCustNum;
                        usemultiduedate = __usemultiduedate;
                        ArtranApprovalStatus = __ArtranApprovalStatus;
                        ArtranCurrCode = __ArtranCurrCode;
                        ArtranPaymentNumber = __ArtranPaymentNumber;

                        readStatus = curArtranStream.Read();
                        EofArtran = readStatus ? 0 : 1;

                        if (readStatus)
                        {
                            IRecordReadOnly currentCurArtran = curArtranStream.Current;
                            __ArtranRowPointer = currentCurArtran.GetValue<Guid?>("RowPointer");
                            __ArtranExchRate = currentCurArtran.GetValue<decimal?>("exch_rate");
                            __ArtranFixedRate = currentCurArtran.GetValue<int?>("fixed_rate");
                            __ArtranAmount = currentCurArtran.GetValue<decimal?>("amount");
                            __ArtranMiscCharges = currentCurArtran.GetValue<decimal?>("misc_charges");
                            __ArtranSalesTax = currentCurArtran.GetValue<decimal?>("sales_tax");
                            __ArtranSalesTax2 = currentCurArtran.GetValue<decimal?>("sales_tax_2");
                            __ArtranFreight = currentCurArtran.GetValue<decimal?>("freight");
                            __ArtranInvNum = currentCurArtran.GetValue<string>("inv_num");
                            __ArtranApplyToInvNum = currentCurArtran.GetValue<string>("apply_to_inv_num");
                            __ArtranDueDate = currentCurArtran.GetValue<DateTime?>("u0") == LowDate ? null : currentCurArtran.GetValue<DateTime?>("u0");
                            __ArtranInvDate = currentCurArtran.GetValue<DateTime?>("inv_date");
                            __ArtranType = currentCurArtran.GetValue<string>("type");
                            __ArtranInvSeq = currentCurArtran.GetValue<int?>("inv_seq");
                            __ArtranCheckSeq = currentCurArtran.GetValue<int?>("check_seq");
                            __ArtranCustNum = currentCurArtran.GetValue<string>("cust_num");
                            __usemultiduedate = currentCurArtran.GetValue<int?>("multi_due_date");
                            __ArtranApprovalStatus = currentCurArtran.GetValue<string>("approval_status");
                            __ArtranCurrCode = currentCurArtran.GetValue<string>("curr_code");
                            __ArtranPaymentNumber = currentCurArtran.GetValue<string>("TH_payment_number");
                        }
                        TranslateToDom = convertToUtil.ToInt32((sQLUtil.SQLEqual(TranslateForAging, 1) == true && sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true ? 1 : 0));

                        #region CRUD LoadToVariable
                        var tv_artran_all2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                               {_MultiApplyInvNum,"multi_due_date"},
                            },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            //maximumRows: 1,
                            tableName: "#tv_artran_all",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("inv_num = {0} AND type = 'I'", ArtranApplyToInvNum),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var tv_artran_all2LoadResponse = this.appDB.Load(tv_artran_all2LoadRequest);
                        if (tv_artran_all2LoadResponse.Items.Count > 0)
                        {
                            MultiApplyInvNum = _MultiApplyInvNum;
                        }
                        #endregion  LoadToVariable
                        LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from #tv_artran_all");

                        MultiApplyInvNum = (int?)(stringUtil.IsNull(
                            MultiApplyInvNum,
                            0));
                        LastOfArtranInvNum = convertToUtil.ToInt32((sQLUtil.SQLEqual(EofArtran, 0) == true && (sQLUtil.SQLNotEqual(ArtranApplyToInvNum, "0") == true && stringUtil.IsNull(
                            ArtranApplyToInvNum == __ArtranApplyToInvNum ? null : ArtranApplyToInvNum,
                            __ArtranApplyToInvNum == ArtranApplyToInvNum ? null : __ArtranApplyToInvNum) == null || (sQLUtil.SQLEqual(ArtranApplyToInvNum, "0") == true && sQLUtil.SQLEqual(ArtranInvNum, __ArtranInvNum) == true)) ? 0 : 1));
                        if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                        {
                            TRate = (decimal?)((sQLUtil.SQLEqual(UseHistRate, 1) == true ? ArtranExchRate : (sQLUtil.SQLEqual(ArtranFixedRate, 1) == true ? ArtranExchRate : null)));
                        }
                        else
                        {
                            //BEGIN
                            TRate = null;
                            Amount = 1.0M;
                            ToCustInvDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(UseHistRate, 1) == true ? ArtranInvDate : null));
                            //END
                        }
                        TcAmtTran = (decimal?)(ArtranAmount + ArtranMiscCharges + ArtranSalesTax + ArtranSalesTax2 + ArtranFreight);
                        if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(FeatureRS6483Active, 1), sQLUtil.SQLEqual(AgingReport, 1)), sQLUtil.SQLEqual(ArtranApplyToInvNum, "0")), sQLUtil.SQLNot(existsChecker.Exists(tableName: "artran_all",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}", ArtranRowPointer))
                                ))))
                        {
                            //BEGIN
                            #region CRUD LoadToVariable
                            var artran_allASartranLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_TcAmtTran,$"SUM((artran.amount + artran.misc_charges + artran.sales_tax + artran.sales_tax_2 + artran.freight) / artran.exch_rate) * {variableUtil.GetQuotedValue<decimal?>(ArtranExchRate)}"},
                            },
                                loadForChange: false,
                        lockingType: LockingType.None,
                                //maximumRows: 1,
                                tableName: "artran_all AS artran",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("(artran.cust_num = {0} OR (artran.orig_cust_num = {0} AND artran.orig_site = {5})) AND artran.active = (CASE WHEN {3} = 1 THEN 1 ELSE artran.active END) AND artran.site_ref = {5} AND artran.inv_date > (CASE WHEN {4} IS NOT NULL THEN {4} ELSE artran.inv_date END) AND CHARINDEX(artran.type, 'PC') > 0 AND ((artran.type = 'C' AND inv_num = {1}) OR (artran.type = 'P' AND inv_seq = {2}))", CustaddrCustNum, ArtranInvNum, ArtranInvSeq, PShowActive, PCutoffDate, PSite),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var artran_allASartranLoadResponse = this.appDB.Load(artran_allASartranLoadRequest);
                            if (artran_allASartranLoadResponse.Items.Count > 0)
                            {
                                TcAmtTran = _TcAmtTran;
                            }
                            #endregion  LoadToVariable

                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from artran_all");

                            TcAmtTran = (decimal?)(stringUtil.IsNull<decimal?>(
                                TcAmtTran,
                                0));
                            //END
                        }
                        if (sQLUtil.SQLEqual(FeatureRS6483Active, 1) == true && sQLUtil.SQLEqual(AgingReport, 1) == true && existsChecker.Exists(tableName: "artran_open_all",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("inv_num = {2} AND cust_num = {1} AND inv_seq = {3} AND check_seq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq))
                        )
                        {
                            //BEGIN
                            #region CRUD LoadToVariable
                            var artran_open_all1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_ArtranDueDate,"due_date"},
                            },
                                loadForChange: false,
                        lockingType: LockingType.None,
                                //maximumRows: 1,
                                tableName: "artran_open_all",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("inv_num = {2} AND cust_num = {1} AND inv_seq = {3} AND check_seq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var artran_open_all1LoadResponse = this.appDB.Load(artran_open_all1LoadRequest);
                            if (artran_open_all1LoadResponse.Items.Count > 0)
                            {
                                ArtranDueDate = _ArtranDueDate;
                            }
                            #endregion  LoadToVariable

                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from artran_open_all");
                            //END
                        }
                        if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                        {
                            //BEGIN
                            if (sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true)
                            {
                                #region CRUD ExecuteMethodCall
                                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                var CurrCnvt = this.iCurrCnvt.CurrCnvtSp(
                                    CurrCode: ArtranCurrCode,
                                    FromDomestic: 0,
                                    UseBuyRate: 0,
                                    RoundResult: 1,
                                    Date: null,
                                    TRate: TRate,
                                    Infobar: Infobar,
                                    Amount1: TcAmtTran,
                                    Result1: TcAmtTran,
                                    Site: PSite,
                                    DomCurrCode: ParmsCurrCode);
                                Severity = CurrCnvt.ReturnCode;
                                TRate = CurrCnvt.TRate;
                                Infobar = CurrCnvt.Infobar;
                                TcAmtTran = CurrCnvt.Result1;

                                #endregion ExecuteMethodCall

                                LogTiming("AGING STREAMING CurrCnvtSp");
                            }
                            //END
                        }
                        else
                        {
                            #region CRUD ExecuteMethodCall

                            //Please Generate the bounce for this stored procedure: TwoCurrCnvtSp
                            var TwoCurrCnvt = this.i2CurrCnvt.TwoCurrCnvtSp(
                                FromCurrCode: ArtranCurrCode,
                                UseBuyRate: 0,
                                RoundResult: 1,
                                Date: ToCustInvDate,
                                TRate: TRate,
                                Infobar: Infobar,
                                ToCurrCode: CustaddrCurrCode,
                                Amount1: Amount,
                                Result1: Amount);
                            Severity = TwoCurrCnvt.ReturnCode;
                            TRate = TwoCurrCnvt.TRate;
                            Infobar = TwoCurrCnvt.Infobar;
                            Amount = TwoCurrCnvt.Result1;

                            #endregion ExecuteMethodCall

                            LogTiming("AGING STREAMING TwoCurrCnvtSp");
                        }
                        SpecialInvNum = convertToUtil.ToInt32((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranApplyToInvNum), 1) == true && sQLUtil.SQLLessThanOrEqual(convertToUtil.ToInt64(ArtranApplyToInvNum), 0) == true ? 1 : 0));
                        if (sQLUtil.SQLNotEqual(ArtranInvNumForFirstOF, 0) == true || sQLUtil.SQLEqual(SpecialInvNum, 1) == true)
                        {
                            //BEGIN
                            TAgeDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(PInvDue, "D") == true ? convertToUtil.ToDateTime(ArtranDueDate) : ArtranInvDate));
                            TcTotBal = 0;
                            ArtranDueDate = convertToUtil.ToDateTime(ArtranDueDate);
                            if (sQLUtil.SQLEqual(TranslateToDom, 1) == true && (sQLUtil.SQLNotEqual(ArtranInvNumForFirstOF, 0) == true))
                            {
                                //BEGIN
                                TOldTransDom = TTransDom;
                                TTransDom = convertToUtil.ToInt32((sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true ? 1 : 0));

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: GainLossArSp
                                var GainLossAr = this.iGainLossAr.GainLossArSp(
                                    pCustNum: CustaddrCustNum,
                                    pInvNum: ArtranInvNum,
                                    pCustCurrCode: ArtranCurrCode,
                                    pUseHistRate: UseHistRate,
                                    pTTransDom: TTransDom,
                                    pSite: PSite,
                                    rTDomBal: TDomBal,
                                    rTForBal: TForBal,
                                    rTGainLoss: TGainLoss,
                                    rInfobar: Infobar,
                                    pCutoffDate: PCutoffDate,
                                    ReturnTable: 1,
                                    AgingDate: PAgingDate);
                                TDomBal = GainLossAr.rTDomBal;
                                TForBal = GainLossAr.rTForBal;
                                TGainLoss = GainLossAr.rTGainLoss;
                                Infobar = GainLossAr.rInfobar;

                                #endregion ExecuteMethodCall
                                LogTiming("AGING STREAMING GainLossArSp");

                                TTransDom = TOldTransDom;
                                //END
                            }
                            //END
                        }
                        TcTotBal = convertToUtil.ToDecimal(TcTotBal + (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "IBF"), 0) == true ? TcAmtTran :
                        sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "D"), 0) == true && sQLUtil.SQLNotEqual(usemultiduedate, 1) == true ? TcAmtTran :
                        sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "D"), 0) == true && sQLUtil.SQLEqual(usemultiduedate, 1) == true ? 0 : (sQLUtil.SQLNotEqual(MultiApplyInvNum, 1) == true ? (-TcAmtTran) : 0)));
                        if (sQLUtil.SQLEqual(TranslateToDom, 1) == true && sQLUtil.SQLEqual(UseHistRate, 1) == true && stringUtil.In(ArtranType, new object[] { "C", "P", "D" }))
                        {
                            //BEGIN
                            TtArtrancGainLoss = null;

                            #region CRUD LoadToVariable
                            var artrancASartrancLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_TtArtrancGainLoss,"sum(artranc.GainLoss)"},
                            },
                                loadForChange: false,
                        lockingType: LockingType.None,
                                //maximumRows: 1,
                                tableName: "#artranc AS artranc",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("artranc.CustNum = {0} AND artranc.InvNum = {2} AND artranc.InvSeq = {3} AND artranc.CheckSeq = {1}", CustaddrCustNum, ArtranCheckSeq, ArtranInvNum, ArtranInvSeq),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var artrancASartrancLoadResponse = this.appDB.Load(artrancASartrancLoadRequest);
                            if (artrancASartrancLoadResponse.Items.Count > 0)
                            {
                                TtArtrancGainLoss = _TtArtrancGainLoss;
                            }
                            #endregion  LoadToVariable
                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #artranc ");

                            if (sQLUtil.SQLGreaterThan(artrancASartrancLoadResponse.Items.Count, 0) == true && sQLUtil.SQLNotEqual(TtArtrancGainLoss, 0) == true)
                            {
                                TcTotBal = (decimal?)(TcTotBal + TtArtrancGainLoss);
                            }
                            //END
                        }
                        if (sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranInvNum), 1) == true && sQLUtil.SQLLessThan(convertToUtil.ToInt64(ArtranInvNum), 0) == true)
                        {
                            if (sQLUtil.SQLGreaterThan(TAgeDate, (sQLUtil.SQLEqual(PInvDue, "D") == true ? ArtranDueDate : ArtranInvDate)) == true)
                            {
                                TAgeDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(PInvDue, "D") == true ? convertToUtil.ToDateTime(ArtranDueDate) : ArtranInvDate));
                            }
                        }
                        if ((sQLUtil.SQLNotEqual(LastOfArtranInvNum, 0) == true) || (sQLUtil.SQLEqual(SpecialInvNum, 1) == true && sQLUtil.SQLNotEqual(usemultiduedate, 1) == true))
                        {
                            //BEGIN
                            NDays = (int?)(dateTimeUtil.DateDiff("Day", TAgeDate, SDate));
                            I = (int?)((sQLUtil.SQLGreaterThan(NDays, PAgeDays4) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 5) == true && sQLUtil.SQLEqual(TLastBucket, 5) == true ? 5 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays3) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 4) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 4) == true ? 4 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays2) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 3) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 3) == true ? 3 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays1) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 2) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 2) == true ? 2 : (sQLUtil.SQLGreaterThan(TFirstBucket, 1) == true ? TFirstBucket : 1))))));
                            if (((sQLUtil.SQLNotEqual(TcTotBal, 0) == true || sQLUtil.SQLLessThan(NDays, PHidePaid) == true || sQLUtil.SQLEqual(ArtranApplyToInvNum, "0") == true) && (sQLUtil.SQLEqual(PAgeBucket, "12345") == true || sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                            Convert.ToString(I),
                                            PAgeBucket), 0) == true && sQLUtil.SQLNotEqual(TcTotBal, 0) == true) && (sQLUtil.SQLNotEqual(TOpt, "O") == true || sQLUtil.SQLGreaterThan(NDays, 0) == true)) && sQLUtil.SQLNotEqual(TOpt, "N") == true)
                            {
                                //BEGIN
                                TcTotMinorBal = (decimal?)(TcTotMinorBal + TcTotBal);
                                if (sQLUtil.SQLEqual(ArtranInvNum, "-1") == true)
                                {
                                    //BEGIN
                                    TtInvRowPointer = null;
                                    TtInvInvNum = null;
                                    TtInvArtranRecid = null;
                                    TtInvCustNum = null;

                                    #region CRUD LoadToVariable
                                    var tv_tt_inv1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TtInvRowPointer,"tt_inv.RowPointer"},
                                        {_TtInvInvNum,"tt_inv.InvNum"},
                                        {_TtInvArtranRecid,"tt_inv.ArtranRecid"},
                                        {_TtInvCustNum,"tt_inv.CustNum"},
                                    },
                                        loadForChange: false,
                        lockingType: LockingType.None,
                                        //maximumRows: 1,
                                        tableName: "#tv_tt_inv",
                                        fromClause: collectionLoadRequestFactory.Clause(" AS tt_inv"),
                                        whereClause: collectionLoadRequestFactory.Clause("tt_inv.InvNum = {3} AND tt_inv.ArtranRecid = {0} AND tt_inv.CustNum = {1} AND ({4} = 'I' OR tt_inv.DueDate = {2})", ArtranRowPointer, CustaddrCustNum, ArtranDueDate, ArtranInvNum, TOpt),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    var tv_tt_inv1LoadResponse = this.appDB.Load(tv_tt_inv1LoadRequest);
                                    if (tv_tt_inv1LoadResponse.Items.Count > 0)
                                    {
                                        TtInvRowPointer = _TtInvRowPointer;
                                        TtInvInvNum = _TtInvInvNum;
                                        TtInvArtranRecid = _TtInvArtranRecid;
                                        TtInvCustNum = _TtInvCustNum;
                                    }
                                    #endregion  LoadToVariable
                                    LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_tt_inv ");
                                    if (TtInvRowPointer == null)
                                    {
                                        //BEGIN
                                        #region CRUD LoadResponseWithoutTable
                                        var nonTable2LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                        {
                                                { "RowPointer", Guid.NewGuid()},
                                                { "CustNum", CustaddrCustNum},
                                                { "InvNum", ArtranInvNum},
                                                { "InvSeq", ArtranInvSeq},
                                                { "ArtranRecid", ArtranRowPointer},
                                                { "Type", ArtranType},
                                                { "InvBal", TcTotBal},
                                                { "Bucket", I},
                                                { "DueDate", stringUtil.IsNull(
                                                    (sQLUtil.SQLEqual(TOpt, "I") == true ? convertToUtil.ToDateTime(ArtranInvDate) : ArtranDueDate),
                                                    LowDate)},
                                                { "Site", PSite},
                                                { "ApplyToInvNum", ArtranApplyToInvNum},
                                        });

                                        var nonTable2LoadResponse = this.appDB.Load(nonTable2LoadRequest);
                                        #endregion CRUD LoadResponseWithoutTable

                                        LogTiming("AGING STREAMING LOOPED INSERT TO tv_tt_inv");

                                        #region CRUD InsertByRecords
                                        var nonTable2InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_inv",
                                            items: nonTable2LoadResponse.Items);

                                        this.appDB.Insert(nonTable2InsertRequest);
                                        #endregion InsertByRecords
                                        //END
                                    }
                                    //END
                                }
                                else
                                {
                                    //BEGIN
                                    TtInvRowPointer = null;
                                    TtInvInvNum = null;
                                    TtInvArtranRecid = null;
                                    TtInvCustNum = null;

                                    #region CRUD LoadToVariable
                                    var tv_tt_inv2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TtInvRowPointer,"tt_inv.RowPointer"},
                                        {_TtInvInvNum,"tt_inv.InvNum"},
                                        {_TtInvArtranRecid,"tt_inv.ArtranRecid"},
                                        {_TtInvCustNum,"tt_inv.CustNum"},
                                    },
                                        loadForChange: false,
                        lockingType: LockingType.None,
                                        //maximumRows: 1,
                                        tableName: "#tv_tt_inv",
                                        fromClause: collectionLoadRequestFactory.Clause(" AS tt_inv"),
                                        whereClause: collectionLoadRequestFactory.Clause("tt_inv.InvNum = {3} AND tt_inv.ArtranRecid = {0} AND tt_inv.CustNum = {1} AND ({4} = 'I' OR tt_inv.DueDate = {2})", ArtranRowPointer, CustaddrCustNum, ArtranDueDate, ArtranInvNum, TOpt),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    var tv_tt_inv2LoadResponse = this.appDB.Load(tv_tt_inv2LoadRequest);
                                    if (tv_tt_inv2LoadResponse.Items.Count > 0)
                                    {
                                        TtInvRowPointer = _TtInvRowPointer;
                                        TtInvInvNum = _TtInvInvNum;
                                        TtInvArtranRecid = _TtInvArtranRecid;
                                        TtInvCustNum = _TtInvCustNum;
                                    }
                                    #endregion  LoadToVariable
                                    LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_tt_inv ");

                                    if (TtInvRowPointer == null)
                                    {
                                        //BEGIN
                                        YArtranRowPointer = null;
                                        YArtranInvNum = null;
                                        YArtranType = null;
                                        if (sQLUtil.SQLNotEqual(ArtranType, "I") == true)
                                        {
                                            #region CRUD LoadToVariable
                                            var tv_artran_all3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                            {
                                                {_YArtranRowPointer,"y_artran.RowPointer"},
                                                {_YArtranInvNum,"y_artran.inv_num"},
                                                {_YArtranInvDate,"y_artran.inv_date"},
                                                {_YArtranDueDate,$"NULLIF (y_artran.due_date, {variableUtil.GetQuotedValue<DateTime?>(LowDate)})"},
                                                {_YArtranType,"y_artran.type"},
                                            },
                                                loadForChange: false,
                        lockingType: LockingType.None,
                                                //maximumRows: 1,
                                                tableName: "#tv_artran_all",
                                                fromClause: collectionLoadRequestFactory.Clause(" AS y_artran"),
                                                whereClause: collectionLoadRequestFactory.Clause("y_artran.cust_num = {0} AND y_artran.inv_num = {1} AND y_artran.site_ref = {2} AND y_artran.inv_seq = 0 AND y_artran.type = 'I'", ArtranCustNum, ArtranInvNum, PSite),
                                                orderByClause: collectionLoadRequestFactory.Clause(""));
                                            var tv_artran_all3LoadResponse = this.appDB.Load(tv_artran_all3LoadRequest);
                                            if (tv_artran_all3LoadResponse.Items.Count > 0)
                                            {
                                                YArtranRowPointer = _YArtranRowPointer;
                                                YArtranInvNum = _YArtranInvNum;
                                                YArtranInvDate = _YArtranInvDate;
                                                YArtranDueDate = _YArtranDueDate;
                                                YArtranType = _YArtranType;
                                            }
                                            #endregion  LoadToVariable
                                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_artran_all ");
                                        }
                                        if (sQLUtil.SQLNotEqual(ArtranType, "I") == true && YArtranRowPointer != null)
                                        {
                                            //BEGIN

                                            #region CRUD LoadResponseWithoutTable
                                            var nonTable3LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                                {
                                                { "RowPointer", Guid.NewGuid()},
                                                { "CustNum", CustaddrCustNum},
                                                { "InvNum", YArtranInvNum},
                                                { "InvSeq", ArtranInvSeq},
                                                { "ArtranRecid", YArtranRowPointer},
                                                { "Type", YArtranType},
                                                { "InvBal", TcTotBal},
                                                { "Bucket", I},
                                                { "DueDate", stringUtil.IsNull(
                                                    (sQLUtil.SQLEqual(TOpt, "I") == true ? convertToUtil.ToDateTime(YArtranInvDate) : YArtranDueDate),
                                                    LowDate)},
                                                { "Site", PSite},
                                                { "ApplyToInvNum", ArtranApplyToInvNum},
                                                });

                                            var nonTable3LoadResponse = this.appDB.Load(nonTable3LoadRequest);
                                            #endregion CRUD LoadResponseWithoutTable

                                            #region CRUD InsertByRecords
                                            var nonTable3InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_inv",
                                                items: nonTable3LoadResponse.Items);

                                            this.appDB.Insert(nonTable3InsertRequest);
                                            #endregion InsertByRecords
                                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_tt_inv ");
                                            //END
                                        }
                                        else
                                        {
                                            #region CRUD LoadResponseWithoutTable
                                            var nonTable4LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                        {
                                                { "RowPointer", Guid.NewGuid()},
                                                { "CustNum", CustaddrCustNum},
                                                { "InvNum", ((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranApplyToInvNum), 1) == true && sQLUtil.SQLLessThanOrEqual(convertToUtil.ToInt64(ArtranApplyToInvNum), 0) == true) ? ArtranInvNum : ArtranApplyToInvNum)},
                                                { "InvSeq", ArtranInvSeq},
                                                { "ArtranRecid", ArtranRowPointer},
                                                { "Type", ArtranType},
                                                { "InvBal", TcTotBal},
                                                { "Bucket", I},
                                                { "DueDate", stringUtil.IsNull(
                                                    (sQLUtil.SQLEqual(TOpt, "I") == true ? convertToUtil.ToDateTime(ArtranInvDate) : ArtranDueDate),
                                                    LowDate)},
                                                { "Site", PSite},
                                                { "ApplyToInvNum", ArtranApplyToInvNum},
                                        });

                                            var nonTable4LoadResponse = this.appDB.Load(nonTable4LoadRequest);
                                            #endregion CRUD LoadResponseWithoutTable

                                            #region CRUD InsertByRecords
                                            var nonTable4InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_inv",
                                                items: nonTable4LoadResponse.Items);

                                            this.appDB.Insert(nonTable4InsertRequest);
                                            #endregion InsertByRecords
                                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_tt_inv ");
                                        }
                                        //END
                                    }
                                    //END
                                }
                                //END
                            }
                            //END
                        }
                        else
                        {
                            //BEGIN
                            if ((sQLUtil.SQLEqual(TOpt, "N") == true && ((sQLUtil.SQLEqual(PAgeBucket, "12345") == true) || (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                                Convert.ToString(I),
                                                PAgeBucket), 0) == true) && sQLUtil.SQLNotEqual(TcTotBal, 0) == true)))
                            {
                                //BEGIN
                                TcTotMinorBal = (decimal?)(TcTotMinorBal + TcTotBal);
                                //END
                            }
                            //END
                        }
                        //END                        
                    }
                }
                curArtranLoadResponseForCursor = null;
                //Deallocate Cursor @curArtran
                if (sQLUtil.SQLEqual(CheckBalNow, 1) == true)
                {
                    if ((sQLUtil.SQLEqual(TcTotMinorBal, 0) == true && sQLUtil.SQLEqual(PPrZeroBal, 0) == true) || (sQLUtil.SQLLessThan(TcTotMinorBal, 0) == true && sQLUtil.SQLEqual(PPrCreditBal, 0) == true))
                    {
                        return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                    }
                }
                if (sQLUtil.SQLBool(sQLUtil.SQLEqual(PSumToCorp, 1)))
                {
                    //BEGIN
                    #region Cursor Statement

                    #region CRUD LoadToRecord
                    curSubCustAddrLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"sub_custaddr.cust_num","sub_custaddr.cust_num"},
                            {"sub_custaddr.curr_code","sub_custaddr.curr_code"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "custaddr",
                        fromClause: collectionLoadRequestFactory.Clause(@" as sub_custaddr inner join customer_all as sub_customer on sub_customer.cust_num = sub_custaddr.cust_num
							and sub_customer.cust_seq = sub_custaddr.cust_seq
							and sub_customer.site_ref = {0}", PSite),
                        whereClause: collectionLoadRequestFactory.Clause("sub_custaddr.corp_cust = {0} AND sub_custaddr.cust_seq = 0", CustaddrCustNum),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    #endregion  LoadToRecord

                    #endregion Cursor Statement
                    curSubCustAddrLoadResponseForCursor = this.appDB.Load(curSubCustAddrLoadRequestForCursor);
                    curSubCustAddr_CursorFetch_Status = curSubCustAddrLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    curSubCustAddr_CursorCounter = -1;

                    while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
                    {
                        //BEGIN
                        curSubCustAddr_CursorCounter++;
                        if (curSubCustAddrLoadResponseForCursor.Items.Count > curSubCustAddr_CursorCounter)
                        {
                            SubCustaddrCustNum = curSubCustAddrLoadResponseForCursor.Items[curSubCustAddr_CursorCounter].GetValue<string>(0);
                            SubCustaddrCurrCode = curSubCustAddrLoadResponseForCursor.Items[curSubCustAddr_CursorCounter].GetValue<string>(1);
                        }
                        curSubCustAddr_CursorFetch_Status = (curSubCustAddr_CursorCounter == curSubCustAddrLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLEqual(curSubCustAddr_CursorFetch_Status, -1) == true)
                        {
                            break;
                        }

                        #region InsertNonTrigger
                        var tmp_artran_all3NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                            targetTableName: "#tv_artran_all",
                            targetColumns: new List<string>()
                            { "RowPointer",
                              "active",
                              "exch_rate",
                              "fixed_rate",
                              "amount",
                              "misc_charges",
                              "sales_tax",
                              "sales_tax_2",
                              "freight",
                              "inv_num",
                              "apply_to_inv_num",
                              "description",
                              "due_date",
                              "inv_date",
                              "type",
                              "inv_seq",
                              "check_seq",
                              "cust_num",
                              "site_ref",
                              "multi_due_date",
                              "approval_status",
                              "OrigAmount",
                              "seq",
                              "curr_code",
                              "TH_payment_number"
                            },
                            valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                            {
                                {"RowPointer",collectionNonTriggerInsertRequestFactory.Clause("artran.RowPointer")},
                                {"active",collectionNonTriggerInsertRequestFactory.Clause("artran.active")},
                                {"exch_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.exch_rate")},
                                {"fixed_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.fixed_rate")},
                                {"amount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                                {"misc_charges",collectionNonTriggerInsertRequestFactory.Clause("artran.misc_charges")},
                                {"sales_tax",collectionNonTriggerInsertRequestFactory.Clause("artran.sales_tax")},
                                {"sales_tax_2",collectionNonTriggerInsertRequestFactory.Clause("artran.sales_tax_2")},
                                {"freight",collectionNonTriggerInsertRequestFactory.Clause("artran.freight")},
                                {"inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_num")},
                                {"apply_to_inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.apply_to_inv_num")},
                                {"description",collectionNonTriggerInsertRequestFactory.Clause("artran.description")},
                                {"due_date",collectionNonTriggerInsertRequestFactory.Clause("ISNULL(artran.due_date,{0})",LowDate)},
                                {"inv_date",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_date")},
                                {"type",collectionNonTriggerInsertRequestFactory.Clause("artran.type")},
                                {"inv_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_seq")},
                                {"check_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.check_seq")},
                                {"cust_num",collectionNonTriggerInsertRequestFactory.Clause("artran.cust_num")},
                                {"site_ref",collectionNonTriggerInsertRequestFactory.Clause("artran.site_ref")},
                                {"multi_due_date",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                {"approval_status",collectionNonTriggerInsertRequestFactory.Clause("artran.approval_status")},
                                {"OrigAmount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                                {"seq",collectionNonTriggerInsertRequestFactory.Clause("case when artran.type = 'I' then 0 else 1 end")},
                                {"curr_code",collectionNonTriggerInsertRequestFactory.Clause("artran.curr_code")},
                                {"TH_payment_number",collectionNonTriggerInsertRequestFactory.Clause("artran.TH_payment_number")},
                            },
                            fromClause: collectionNonTriggerInsertRequestFactory.Clause("artran_all AS artran"),
                            whereClause: collectionNonTriggerInsertRequestFactory.Clause("artran.site_ref = {5} AND artran.cust_num = {0} AND artran.active = (CASE WHEN {2} = 1 THEN 1 ELSE artran.active END) AND artran.inv_date <= (CASE WHEN {3} IS NOT NULL THEN {3} ELSE artran.inv_date END) AND ({4} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0') AND NOT (EXISTS (SELECT 1 FROM ar_terms_due_all WHERE site_ref = artran.site_ref AND cust_num = {1} AND inv_num = artran.inv_num AND inv_seq = artran.inv_seq) AND CHARINDEX(artran.type, 'ID') <> 0)", SubCustaddrCustNum, CustaddrCustNum, PShowActive, PCutoffDate, PPrOpenPay, PSite),
                            orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                            );

                        this.appDB.InsertWithoutTrigger(tmp_artran_all3NonTriggerInsertRequest);
                        #endregion InsertNonTrigger

                        LogTiming("AGING INSERT TO #tv_artran_all ");

                        if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(PPrOpenPay, 1), sQLUtil.SQLEqual(FeatureRS6483Active, 1)), sQLUtil.SQLEqual(AgingReport, 1))))
                        {
                            //BEGIN
                            #region InsertNonTrigger
                            var tmp_artran_all4NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                targetTableName: "#tv_artran_all",
                                targetColumns: new List<string>()
                                { "RowPointer",
                                  "active",
                                  "exch_rate",
                                  "fixed_rate",
                                  "amount",
                                  "misc_charges",
                                  "sales_tax",
                                  "sales_tax_2",
                                  "freight",
                                  "inv_num",
                                  "apply_to_inv_num",
                                  "description",
                                  "due_date",
                                  "inv_date",
                                  "type",
                                  "inv_seq",
                                  "check_seq",
                                  "cust_num",
                                  "site_ref",
                                  "multi_due_date",
                                  "approval_status",
                                  "OrigAmount",
                                  "seq",
                                  "curr_code",
                                  "TH_payment_number"
                                },
                                valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                {
                                    {"RowPointer",collectionNonTriggerInsertRequestFactory.Clause("artran.RowPointer")},
                                    {"active",collectionNonTriggerInsertRequestFactory.Clause("1")},
                                    { "exch_rate",collectionNonTriggerInsertRequestFactory.Clause("artran.exch_rate")},
                                    {"fixed_rate",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"amount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                                    {"misc_charges",collectionNonTriggerInsertRequestFactory.Clause("artran.misc_charges")},
                                    {"sales_tax",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"sales_tax_2",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"freight",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"inv_num",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_num")},
                                    {"apply_to_inv_num",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"description",collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                    {"due_date",collectionNonTriggerInsertRequestFactory.Clause("{0}",LowDate)},
                                    {"inv_date",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_date")},
                                    {"type",collectionNonTriggerInsertRequestFactory.Clause("artran.type")},
                                    {"inv_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.inv_seq")},
                                    {"check_seq",collectionNonTriggerInsertRequestFactory.Clause("artran.check_seq")},
                                    {"cust_num",collectionNonTriggerInsertRequestFactory.Clause("artran.cust_num")},
                                    {"site_ref",collectionNonTriggerInsertRequestFactory.Clause("artran.site_ref")},
                                    {"multi_due_date",collectionNonTriggerInsertRequestFactory.Clause("0")},
                                    {"approval_status",collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                    {"OrigAmount",collectionNonTriggerInsertRequestFactory.Clause("artran.amount")},
                                    {"seq",collectionNonTriggerInsertRequestFactory.Clause("1")},
                                    {"curr_code",collectionNonTriggerInsertRequestFactory.Clause("artran.curr_code")},
                                    {"TH_payment_number",collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                },
                                fromClause: collectionNonTriggerInsertRequestFactory.Clause("artran_open_all AS artran"),
                                whereClause: collectionNonTriggerInsertRequestFactory.Clause("NOT EXISTS(SELECT 1 FROM artran_all temp_artran_all WHERE temp_artran_all.cust_num = artran.cust_num AND temp_artran_all.type = artran.type AND temp_artran_all.inv_num = artran.inv_num AND temp_artran_all.inv_seq = artran.inv_seq AND temp_artran_all.check_seq = artran.check_seq) AND artran.inv_date <= (CASE WHEN {2} IS NOT NULL THEN {2} ELSE artran.inv_date END) AND artran.cust_num = {0} AND artran.site_ref = {3} AND NOT EXISTS (SELECT 1 FROM #tv_artran_all AS tmp_artran WHERE tmp_artran.apply_to_inv_num = '0' AND tmp_artran.cust_num = artran.cust_num AND tmp_artran.inv_num = artran.inv_num AND tmp_artran.inv_seq = artran.inv_seq AND tmp_artran.check_seq = artran.check_seq) AND artran.amount <> (CASE WHEN artran.type = 'C' THEN (SELECT ISNULL(SUM(amount), 0) FROM #tv_artran_all WHERE cust_num = artran.cust_num AND inv_num = artran.inv_num AND type = 'C' AND site_ref = {3}) WHEN artran.type = 'P' THEN (SELECT ISNULL(SUM(amount), 0) FROM #tv_artran_all WHERE cust_num = artran.cust_num AND inv_seq = artran.inv_seq AND type = 'P' AND site_ref = {3}) ELSE 0 END)", CustaddrCustNum, PShowActive, PCutoffDate, PSite),
                                orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                );

                            this.appDB.InsertWithoutTrigger(tmp_artran_all4NonTriggerInsertRequest);
                            #endregion InsertNonTrigger

                            LogTiming("AGING INSERT TO #tv_artran_all ");
                            //END
                        }
                        #region Cursor Statement

                        #region CRUD LoadToRecord
                        aCursorLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"RowPointer","artran.RowPointer"},
                                {"active","artran.active"},
                                {"exch_rate","artran.exch_rate"},
                                {"fixed_rate","artran.fixed_rate"},
                                {"amount","artran.amount"},
                                {"misc_charges","artran.misc_charges"},
                                {"sales_tax","artran.sales_tax"},
                                {"sales_tax_2","artran.sales_tax_2"},
                                {"freight","artran.freight"},
                                {"inv_num","artran.inv_num"},
                                {"apply_to_inv_num","artran.apply_to_inv_num"},
                                {"description","artran.description"},
                                {"col0","CAST (NULL AS DATETIME)"},
                                {"inv_date","artran.inv_date"},
                                {"type","artran.type"},
                                {"inv_seq","artran.inv_seq"},
                                {"check_seq","artran.check_seq"},
                                {"cust_num","artran.cust_num"},
                                {"site_ref","artran.site_ref"},
                                {"approval_status","artran.approval_status"},
                                {"TH_payment_number","artran.TH_payment_number"},
                                {"u0","artran.due_date"},
                            },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            tableName: "artran_all",
                            fromClause: collectionLoadRequestFactory.Clause(" AS artran"),
                            whereClause: collectionLoadRequestFactory.Clause("artran.site_ref = {5} AND artran.cust_num = {0} AND artran.inv_date <= (CASE WHEN {2} IS NOT NULL THEN {2} ELSE artran.inv_date END) AND artran.active = (CASE WHEN {3} = 1 THEN 1 ELSE artran.active END) AND ({4} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0') AND (EXISTS (SELECT 1 FROM ar_terms_due_all WHERE site_ref = artran.site_ref AND cust_num = {1} AND inv_num = artran.inv_num AND inv_seq = artran.inv_seq) AND CHARINDEX(artran.type, 'ID') <> 0)", SubCustaddrCustNum, CustaddrCustNum, PCutoffDate, PShowActive, PPrOpenPay, PSite),
                            orderByClause: collectionLoadRequestFactory.Clause(" cust_num, apply_to_inv_num, site_ref, inv_num, inv_seq, check_seq"));
                        #endregion  LoadToRecord

                        using (IRecordStream aCursorRecordStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory, aCursorLoadRequestForCursor,
                               sortOrderFactory.Create(aCursorSort), SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, LoadType.First, false))
                        {
                            while (aCursorRecordStream.Read())
                            {
                                IRecordReadOnly aCursorCurrent = aCursorRecordStream.Current;
                                __ArtranRowPointer = aCursorCurrent.GetValue<Guid?>("RowPointer");
                                __active = aCursorCurrent.GetValue<int?>("active");
                                __ArtranExchRate = aCursorCurrent.GetValue<decimal?>("exch_rate");
                                __ArtranFixedRate = aCursorCurrent.GetValue<int?>("fixed_rate");
                                __ArtranAmount = aCursorCurrent.GetValue<decimal?>("amount");
                                __ArtranMiscCharges = aCursorCurrent.GetValue<decimal?>("misc_charges");
                                __ArtranSalesTax = aCursorCurrent.GetValue<decimal?>("sales_tax");
                                __ArtranSalesTax2 = aCursorCurrent.GetValue<decimal?>("sales_tax_2");
                                __ArtranFreight = aCursorCurrent.GetValue<decimal?>("freight");
                                __ArtranInvNum = aCursorCurrent.GetValue<string>("inv_num");
                                __ArtranApplyToInvNum = aCursorCurrent.GetValue<string>("apply_to_inv_num");
                                __description = aCursorCurrent.GetValue<string>("description");
                                __ArtranDueDate = stringUtil.IsNull(aCursorCurrent.GetValue<DateTime?>("u0"), LowDate);
                                __ArtranInvDate = aCursorCurrent.GetValue<DateTime?>("inv_date");
                                __ArtranType = aCursorCurrent.GetValue<string>("type");
                                __ArtranInvSeq = aCursorCurrent.GetValue<int?>("inv_seq");
                                __ArtranCheckSeq = aCursorCurrent.GetValue<int?>("check_seq");
                                __ArtranCustNum = aCursorCurrent.GetValue<string>("cust_num");
                                __Site = aCursorCurrent.GetValue<string>("site_ref");
                                __ArtranApprovalStatus = aCursorCurrent.GetValue<string>("approval_status");
                                __ArtranPaymentNumber = aCursorCurrent.GetValue<string>("TH_payment_number");

                                //Please Generate the bounce for this function: ArTermDue.
                                iArTermDue.ArTermDueFn(PSite, __ArtranCustNum, __ArtranInvNum, __ArtranInvSeq, PCutoffDate);

                                #region CRUD LoadToRecord
                                var fnt_ArTermDue1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                                {
                                    {"RowPointer","CAST (NULL AS NVARCHAR)"},
                                    {"active","CAST (NULL AS INT)"},
                                    {"exch_rate","CAST (NULL AS DECIMAL)"},
                                    {"fixed_rate","CAST (NULL AS INT)"},
                                    {"amount","CAST (NULL AS DECIMAL)"},
                                    {"misc_charges","CAST (NULL AS INT)"},
                                    {"sales_tax","CAST (NULL AS INT)"},
                                    {"sales_tax_2","CAST (NULL AS INT)"},
                                    {"freight","CAST (NULL AS INT)"},
                                    {"inv_num","CAST (NULL AS NVARCHAR)"},
                                    {"apply_to_inv_num","CAST (NULL AS NVARCHAR)"},
                                    {"description","CAST (NULL AS NVARCHAR)"},
                                    {"due_date","CAST (NULL AS DATETIME)"},
                                    {"inv_date","CAST (NULL AS DATETIME)"},
                                    {"type","CAST (NULL AS NVARCHAR)"},
                                    {"inv_seq","CAST (NULL AS INT)"},
                                    {"check_seq","CAST (NULL AS INT)"},
                                    {"cust_num","CAST (NULL AS NVARCHAR)"},
                                    {"site_ref","CAST (NULL AS NVARCHAR)"},
                                    {"multi_due_date","CAST (NULL AS INT)"},
                                    {"approval_status","CAST (NULL AS NVARCHAR)"},
                                    {"OrigAmount","CAST (NULL AS DECIMAL)"},
                                    {"seq","CAST (NULL AS INT)"},
                                    {"curr_code","CAST (NULL AS NVARCHAR)"},
                                    {"TH_payment_number","CAST (NULL AS NVARCHAR)"},
                                    {"u0","pamount"},
                                    {"u1","DueDate"},
                                    {"u2","balance2"},
                                },
                                    loadForChange: false,
                        lockingType: LockingType.None,
                                    tableName: "#fnt_ArTermDue",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause(""),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var fnt_ArTermDue1LoadResponse = this.appDB.Load(fnt_ArTermDue1LoadRequest);
                                #endregion  LoadToRecord

                                #region CRUD InsertByRecords
                                foreach (var fnt_ArTermDue1Item in fnt_ArTermDue1LoadResponse.Items)
                                {
                                    fnt_ArTermDue1Item.SetValue<Guid?>("RowPointer", __ArtranRowPointer);
                                    fnt_ArTermDue1Item.SetValue<int?>("active", __active);
                                    fnt_ArTermDue1Item.SetValue<decimal?>("exch_rate", __ArtranExchRate);
                                    fnt_ArTermDue1Item.SetValue<int?>("fixed_rate", __ArtranFixedRate);
                                    fnt_ArTermDue1Item.SetValue<decimal?>("amount", fnt_ArTermDue1Item.GetValue<decimal?>("u0"));
                                    fnt_ArTermDue1Item.SetValue<int?>("misc_charges", 0);
                                    fnt_ArTermDue1Item.SetValue<int?>("sales_tax", 0);
                                    fnt_ArTermDue1Item.SetValue<int?>("sales_tax_2", 0);
                                    fnt_ArTermDue1Item.SetValue<int?>("freight", 0);
                                    fnt_ArTermDue1Item.SetValue<string>("inv_num", __ArtranInvNum);
                                    fnt_ArTermDue1Item.SetValue<string>("apply_to_inv_num", __ArtranApplyToInvNum);
                                    fnt_ArTermDue1Item.SetValue<string>("description", __description);
                                    fnt_ArTermDue1Item.SetValue<DateTime?>("due_date", fnt_ArTermDue1Item.GetValue<DateTime?>("u1"));
                                    fnt_ArTermDue1Item.SetValue<DateTime?>("inv_date", __ArtranInvDate);
                                    fnt_ArTermDue1Item.SetValue<string>("type", __ArtranType);
                                    fnt_ArTermDue1Item.SetValue<int?>("inv_seq", __ArtranInvSeq);
                                    fnt_ArTermDue1Item.SetValue<int?>("check_seq", __ArtranCheckSeq);
                                    fnt_ArTermDue1Item.SetValue<string>("cust_num", __ArtranCustNum);
                                    fnt_ArTermDue1Item.SetValue<string>("site_ref", PSite);
                                    fnt_ArTermDue1Item.SetValue<int?>("multi_due_date", 1);
                                    fnt_ArTermDue1Item.SetValue<string>("approval_status", ArtranApprovalStatus);
                                    fnt_ArTermDue1Item.SetValue<decimal?>("OrigAmount", fnt_ArTermDue1Item.GetValue<decimal?>("u2"));
                                    fnt_ArTermDue1Item.SetValue<int?>("seq", (sQLUtil.SQLEqual(__ArtranType, "I") == true ? 0 : 1));
                                    fnt_ArTermDue1Item.SetValue<string>("curr_code", __ArtranCurrCode);
                                    fnt_ArTermDue1Item.SetValue<string>("TH_payment_number", __ArtranPaymentNumber);
                                };

                                var fnt_ArTermDue1RequiredColumns = new List<string>() { "RowPointer", "active", "exch_rate", "fixed_rate", "amount", "misc_charges", "sales_tax", "sales_tax_2", "freight", "inv_num", "apply_to_inv_num", "description", "due_date", "inv_date", "type", "inv_seq", "check_seq", "cust_num", "site_ref", "multi_due_date", "approval_status", "OrigAmount", "seq", "curr_code", "TH_payment_number" };

                                fnt_ArTermDue1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(fnt_ArTermDue1LoadResponse, fnt_ArTermDue1RequiredColumns);

                                var fnt_ArTermDue1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_artran_all",
                                    items: fnt_ArTermDue1LoadResponse.Items);

                                this.appDB.Insert(fnt_ArTermDue1InsertRequest);
                                #endregion InsertByRecords
                                //END
                            }
                        }
                        #endregion Cursor Statement                        

                        #region CRUD LoadToRecord
                        curArtranLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                            {
                                {"RowPointer","artran.RowPointer"},
                                {"exch_rate","artran.exch_rate"},
                                {"fixed_rate","artran.fixed_rate"},
                                {"amount","artran.amount"},
                                {"misc_charges","artran.misc_charges"},
                                {"sales_tax","artran.sales_tax"},
                                {"sales_tax_2","artran.sales_tax_2"},
                                {"freight","artran.freight"},
                                {"inv_num","artran.inv_num"},
                                {"apply_to_inv_num","artran.apply_to_inv_num"},
                                {"col0","CAST (NULL AS DATETIME)"},
                                {"inv_date","artran.inv_date"},
                                {"type","artran.type"},
                                {"inv_seq","artran.inv_seq"},
                                {"check_seq","artran.check_seq"},
                                {"cust_num","artran.cust_num"},
                                {"approval_status","artran.approval_status"},
                                {"multi_due_date","artran.multi_due_date"},
                                {"curr_code","artran.curr_code"},
                                {"TH_payment_number","artran.TH_payment_number"},
                                {"u0","artran.due_date"},
                                {"seq", "seq"},
                                {"site_ref", "site_ref"},
                                {"due_date", "due_date"},
                                {"active", "active"},
                            },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            tableName: "#tv_artran_all",
                            fromClause: collectionLoadRequestFactory.Clause(" AS artran"),
                            whereClause: collectionLoadRequestFactory.Clause("artran.cust_num = {0} AND artran.active = (CASE WHEN {1} = 1 THEN 1 ELSE artran.active END) AND artran.site_ref = {4} AND artran.inv_date <= (CASE WHEN {2} IS NOT NULL THEN {2} ELSE artran.inv_date END) AND ({3} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0')", SubCustaddrCustNum, PShowActive, PCutoffDate, PPrOpenPay, PSite),
                            orderByClause: collectionLoadRequestFactory.Clause(" cust_num, apply_to_inv_num, seq, inv_num, inv_seq, check_seq, site_ref, inv_date, due_date, active"));
                        #endregion  LoadToRecord

                        LogTiming("AGING STREAM LOAD FROM #tv_artran_all ");

                        using (IRecordStream curArtranStream = recordStreamFactory.Create(appDB, queryLanguage, mgSessionVariableBasedCache, collectionLoadRequestFactory,
                               curArtranLoadRequestForCursor, curArtranSortOrder, SQLPagedRecordStreamBookmarkID.MyReport_Rpt, pageSize, LoadType.First, false))
                        {
                            bool readStatus = curArtranStream.Read();

                            if (readStatus)
                            {
                                IRecordReadOnly currentCurArtran = curArtranStream.Current;
                                __ArtranRowPointer = currentCurArtran.GetValue<Guid?>("RowPointer");
                                __ArtranExchRate = currentCurArtran.GetValue<decimal?>("exch_rate");
                                __ArtranFixedRate = currentCurArtran.GetValue<int?>("fixed_rate");
                                __ArtranAmount = currentCurArtran.GetValue<decimal?>("amount");
                                __ArtranMiscCharges = currentCurArtran.GetValue<decimal?>("misc_charges");
                                __ArtranSalesTax = currentCurArtran.GetValue<decimal?>("sales_tax");
                                __ArtranSalesTax2 = currentCurArtran.GetValue<decimal?>("sales_tax_2");
                                __ArtranFreight = currentCurArtran.GetValue<decimal?>("freight");
                                __ArtranInvNum = currentCurArtran.GetValue<string>("inv_num");
                                __ArtranApplyToInvNum = currentCurArtran.GetValue<string>("apply_to_inv_num");
                                __ArtranDueDate = currentCurArtran.GetValue<DateTime?>("u0") == LowDate ? null : currentCurArtran.GetValue<DateTime?>("u0");
                                __ArtranInvDate = currentCurArtran.GetValue<DateTime?>("inv_date");
                                __ArtranType = currentCurArtran.GetValue<string>("type");
                                __ArtranInvSeq = currentCurArtran.GetValue<int?>("inv_seq");
                                __ArtranCheckSeq = currentCurArtran.GetValue<int?>("check_seq");
                                __ArtranCustNum = currentCurArtran.GetValue<string>("cust_num");
                                __usemultiduedate = currentCurArtran.GetValue<int?>("multi_due_date");
                                __ArtranApprovalStatus = currentCurArtran.GetValue<string>("approval_status");
                                __ArtranCurrCode = currentCurArtran.GetValue<string>("curr_code");
                                __ArtranPaymentNumber = currentCurArtran.GetValue<string>("TH_payment_number");
                            }

                            EofArtran = readStatus ? 0 : 1;
                            LastOfArtranInvNum = 1;

                            while (1 == 1)
                            {
                                if (EofArtran != 0)
                                {
                                    break;
                                }
                                ArtranInvNumForFirstOF = LastOfArtranInvNum;

                                ArtranRowPointer = __ArtranRowPointer;
                                ArtranExchRate = __ArtranExchRate;
                                ArtranFixedRate = __ArtranFixedRate;
                                ArtranAmount = __ArtranAmount;
                                ArtranMiscCharges = __ArtranMiscCharges;
                                ArtranSalesTax = __ArtranSalesTax;
                                ArtranSalesTax2 = __ArtranSalesTax2;
                                ArtranFreight = __ArtranFreight;
                                ArtranInvNum = __ArtranInvNum;
                                ArtranApplyToInvNum = __ArtranApplyToInvNum;
                                ArtranDueDate = __ArtranDueDate;
                                ArtranInvDate = __ArtranInvDate;
                                ArtranType = __ArtranType;
                                ArtranInvSeq = __ArtranInvSeq;
                                ArtranCheckSeq = __ArtranCheckSeq;
                                ArtranCustNum = __ArtranCustNum;
                                usemultiduedate = __usemultiduedate;
                                ArtranApprovalStatus = __ArtranApprovalStatus;
                                ArtranCurrCode = __ArtranCurrCode;
                                ArtranPaymentNumber = __ArtranPaymentNumber;

                                readStatus = curArtranStream.Read();
                                EofArtran = readStatus ? 0 : 1;

                                if (readStatus)
                                {
                                    IRecordReadOnly currentCurArtran = curArtranStream.Current;
                                    __ArtranRowPointer = currentCurArtran.GetValue<Guid?>("RowPointer");
                                    __ArtranExchRate = currentCurArtran.GetValue<decimal?>("exch_rate");
                                    __ArtranFixedRate = currentCurArtran.GetValue<int?>("fixed_rate");
                                    __ArtranAmount = currentCurArtran.GetValue<decimal?>("amount");
                                    __ArtranMiscCharges = currentCurArtran.GetValue<decimal?>("misc_charges");
                                    __ArtranSalesTax = currentCurArtran.GetValue<decimal?>("sales_tax");
                                    __ArtranSalesTax2 = currentCurArtran.GetValue<decimal?>("sales_tax_2");
                                    __ArtranFreight = currentCurArtran.GetValue<decimal?>("freight");
                                    __ArtranInvNum = currentCurArtran.GetValue<string>("inv_num");
                                    __ArtranApplyToInvNum = currentCurArtran.GetValue<string>("apply_to_inv_num");
                                    __ArtranDueDate = currentCurArtran.GetValue<DateTime?>("u0") == LowDate ? null : currentCurArtran.GetValue<DateTime?>("u0");
                                    __ArtranInvDate = currentCurArtran.GetValue<DateTime?>("inv_date");
                                    __ArtranType = currentCurArtran.GetValue<string>("type");
                                    __ArtranInvSeq = currentCurArtran.GetValue<int?>("inv_seq");
                                    __ArtranCheckSeq = currentCurArtran.GetValue<int?>("check_seq");
                                    __ArtranCustNum = currentCurArtran.GetValue<string>("cust_num");
                                    __usemultiduedate = currentCurArtran.GetValue<int?>("multi_due_date");
                                    __ArtranApprovalStatus = currentCurArtran.GetValue<string>("approval_status");
                                    __ArtranCurrCode = currentCurArtran.GetValue<string>("curr_code");
                                    __ArtranPaymentNumber = currentCurArtran.GetValue<string>("TH_payment_number");
                                }

                                TranslateToDom = convertToUtil.ToInt32((sQLUtil.SQLEqual(TranslateForAging, 1) == true && sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true ? 1 : 0));

                                #region CRUD LoadToVariable
                                var tv_artran_all5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_MultiApplyInvNum,"multi_due_date"},
                                },
                                    loadForChange: false,
                        lockingType: LockingType.None,
                                    //maximumRows: 1,
                                    tableName: "#tv_artran_all",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("inv_num = {0} AND type = 'I'", ArtranApplyToInvNum),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var tv_artran_all5LoadResponse = this.appDB.Load(tv_artran_all5LoadRequest);
                                if (tv_artran_all5LoadResponse.Items.Count > 0)
                                {
                                    MultiApplyInvNum = _MultiApplyInvNum;
                                }
                                #endregion  LoadToVariable
                                LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_artran_all ");

                                MultiApplyInvNum = (int?)(stringUtil.IsNull(
                                    MultiApplyInvNum,
                                    0));
                                LastOfArtranInvNum = convertToUtil.ToInt32((sQLUtil.SQLEqual(EofArtran, 0) == true && (sQLUtil.SQLNotEqual(ArtranApplyToInvNum, "0") == true && stringUtil.IsNull(
                                    ArtranApplyToInvNum == __ArtranApplyToInvNum ? null : ArtranApplyToInvNum,
                                    __ArtranApplyToInvNum == ArtranApplyToInvNum ? null : __ArtranApplyToInvNum) == null || (sQLUtil.SQLEqual(ArtranApplyToInvNum, "0") == true && sQLUtil.SQLEqual(ArtranInvNum, __ArtranInvNum) == true)) ? 0 : 1));
                                if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                                {
                                    TRate = (decimal?)((sQLUtil.SQLEqual(UseHistRate, 1) == true ? ArtranExchRate : (sQLUtil.SQLEqual(ArtranFixedRate, 1) == true ? ArtranExchRate : null)));

                                }
                                else
                                {
                                    //BEGIN
                                    TRate = null;
                                    Amount = 1.0M;
                                    ToCustInvDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(UseHistRate, 1) == true ? ArtranInvDate : null));
                                    //END

                                }
                                TcAmtTran = (decimal?)(ArtranAmount + ArtranMiscCharges + ArtranSalesTax + ArtranSalesTax2 + ArtranFreight);
                                if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(FeatureRS6483Active, 1), sQLUtil.SQLEqual(AgingReport, 1)), sQLUtil.SQLEqual(ArtranApplyToInvNum, "0")), sQLUtil.SQLNot(existsChecker.Exists(tableName: "artran_all",
                                            fromClause: collectionLoadRequestFactory.Clause(""),
                                            whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}", ArtranRowPointer))
                                        ))))
                                {
                                    //BEGIN

                                    #region CRUD LoadToVariable
                                    var artran_allASartran1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TcAmtTran,$"SUM((artran.amount + artran.misc_charges + artran.sales_tax + artran.sales_tax_2 + artran.freight) / artran.exch_rate) * {variableUtil.GetQuotedValue<decimal?>(ArtranExchRate)}"},
                                    },
                                        loadForChange: false,
                        lockingType: LockingType.None,
                                        //maximumRows: 1,
                                        tableName: "artran_all AS artran",
                                        fromClause: collectionLoadRequestFactory.Clause(""),
                                        whereClause: collectionLoadRequestFactory.Clause("(artran.cust_num = {0} OR (artran.orig_cust_num = {0} AND artran.orig_site = {5})) AND artran.active = (CASE WHEN {3} = 1 THEN 1 ELSE artran.active END) AND artran.site_ref = {5} AND artran.inv_date > (CASE WHEN {4} IS NOT NULL THEN {4} ELSE artran.inv_date END) AND CHARINDEX(artran.type, 'PC') > 0 AND ((artran.type = 'C' AND inv_num = {1}) OR (artran.type = 'P' AND inv_seq = {2}))", CustaddrCustNum, ArtranInvNum, ArtranInvSeq, PShowActive, PCutoffDate, PSite),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    var artran_allASartran1LoadResponse = this.appDB.Load(artran_allASartran1LoadRequest);
                                    if (artran_allASartran1LoadResponse.Items.Count > 0)
                                    {
                                        TcAmtTran = _TcAmtTran;
                                    }
                                    #endregion  LoadToVariable
                                    LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  artran_all ");
                                    //END

                                }
                                if (sQLUtil.SQLEqual(FeatureRS6483Active, 1) == true && sQLUtil.SQLEqual(AgingReport, 1) == true && existsChecker.Exists(tableName: "artran_open_all",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("inv_num = {2} AND cust_num = {1} AND inv_seq = {3} AND check_seq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq))
                                )
                                {
                                    //BEGIN

                                    #region CRUD LoadToVariable
                                    var artran_open_all3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_ArtranDueDate,"due_date"},
                                    },
                                        loadForChange: false,
                        lockingType: LockingType.None,
                                        //maximumRows: 1,
                                        tableName: "artran_open_all",
                                        fromClause: collectionLoadRequestFactory.Clause(""),
                                        whereClause: collectionLoadRequestFactory.Clause("inv_num = {2} AND cust_num = {1} AND inv_seq = {3} AND check_seq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    var artran_open_all3LoadResponse = this.appDB.Load(artran_open_all3LoadRequest);
                                    if (artran_open_all3LoadResponse.Items.Count > 0)
                                    {
                                        ArtranDueDate = _ArtranDueDate;
                                    }
                                    #endregion  LoadToVariable

                                    LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  artran_open_all ");
                                    //END

                                }
                                if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                                {
                                    //BEGIN
                                    if (sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true)
                                    {

                                        #region CRUD ExecuteMethodCall

                                        //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                        var CurrCnvt1 = this.iCurrCnvt.CurrCnvtSp(
                                            CurrCode: ArtranCurrCode,
                                            FromDomestic: 0,
                                            UseBuyRate: 0,
                                            RoundResult: 1,
                                            Date: null,
                                            TRate: TRate,
                                            Infobar: Infobar,
                                            Amount1: TcAmtTran,
                                            Result1: TcAmtTran,
                                            Site: PSite,
                                            DomCurrCode: ParmsCurrCode);
                                        Severity = CurrCnvt1.ReturnCode;
                                        TRate = CurrCnvt1.TRate;
                                        Infobar = CurrCnvt1.Infobar;
                                        TcAmtTran = CurrCnvt1.Result1;

                                        #endregion ExecuteMethodCall

                                        LogTiming("AGING STREAMING LOOPED CurrCnvtSp");
                                    }
                                    //END

                                }
                                else
                                {

                                    #region CRUD ExecuteMethodCall

                                    //Please Generate the bounce for this stored procedure: TwoCurrCnvtSp
                                    var TwoCurrCnvt1 = this.i2CurrCnvt.TwoCurrCnvtSp(
                                        FromCurrCode: ArtranCurrCode,
                                        UseBuyRate: 0,
                                        RoundResult: 1,
                                        Date: ToCustInvDate,
                                        TRate: TRate,
                                        Infobar: Infobar,
                                        ToCurrCode: SubCustaddrCurrCode,
                                        Amount1: Amount,
                                        Result1: Amount);
                                    Severity = TwoCurrCnvt1.ReturnCode;
                                    TRate = TwoCurrCnvt1.TRate;
                                    Infobar = TwoCurrCnvt1.Infobar;
                                    Amount = TwoCurrCnvt1.Result1;

                                    #endregion ExecuteMethodCall

                                    LogTiming("AGING STREAMING LOOPED TwoCurrCnvtSp");

                                }
                                SpecialInvNum = convertToUtil.ToInt32((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranApplyToInvNum), 1) == true && sQLUtil.SQLLessThanOrEqual(convertToUtil.ToInt64(ArtranApplyToInvNum), 0) == true ? 1 : 0));
                                if (sQLUtil.SQLNotEqual(ArtranInvNumForFirstOF, 0) == true || sQLUtil.SQLEqual(SpecialInvNum, 1) == true)
                                {
                                    //BEGIN
                                    TAgeDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(PInvDue, "D") == true ? convertToUtil.ToDateTime(ArtranDueDate) : ArtranInvDate));
                                    TcTotBal = 0;
                                    if (sQLUtil.SQLEqual(TranslateToDom, 1) == true && (sQLUtil.SQLNotEqual(ArtranInvNumForFirstOF, 0) == true))
                                    {
                                        //BEGIN
                                        TOldTransDom = TTransDom;
                                        TTransDom = convertToUtil.ToInt32((sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true ? 1 : 0));

                                        #region CRUD ExecuteMethodCall

                                        //Please Generate the bounce for this stored procedure: GainLossArSp
                                        var GainLossAr1 = this.iGainLossAr.GainLossArSp(
                                            pCustNum: SubCustaddrCustNum,
                                            pInvNum: ArtranInvNum,
                                            pCustCurrCode: ArtranCurrCode,
                                            pUseHistRate: UseHistRate,
                                            pTTransDom: TTransDom,
                                            pSite: PSite,
                                            rTDomBal: TDomBal,
                                            rTForBal: TForBal,
                                            rTGainLoss: TGainLoss,
                                            rInfobar: Infobar,
                                            pCutoffDate: PCutoffDate,
                                            ReturnTable: 1,
                                            AgingDate: PAgingDate);
                                        TDomBal = GainLossAr1.rTDomBal;
                                        TForBal = GainLossAr1.rTForBal;
                                        TGainLoss = GainLossAr1.rTGainLoss;
                                        Infobar = GainLossAr1.rInfobar;

                                        #endregion ExecuteMethodCall

                                        LogTiming("AGING STREAMING LOOPED GainLossArSp");

                                        TTransDom = TOldTransDom;
                                        //END

                                    }
                                    //END

                                }
                                TcTotBal = convertToUtil.ToDecimal(TcTotBal + (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                    ArtranType,
                                    "IBF"), 0) == true ? TcAmtTran :
                                sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                    ArtranType,
                                    "D"), 0) == true && sQLUtil.SQLNotEqual(usemultiduedate, 1) == true ? TcAmtTran :
                                sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                    ArtranType,
                                    "D"), 0) == true && sQLUtil.SQLEqual(usemultiduedate, 1) == true ? 0 : (sQLUtil.SQLNotEqual(MultiApplyInvNum, 1) == true ? (-TcAmtTran) : 0)));
                                if (sQLUtil.SQLEqual(TranslateToDom, 1) == true && sQLUtil.SQLEqual(UseHistRate, 1) == true && stringUtil.In(ArtranType, new object[] { "C", "P", "D" }))
                                {
                                    //BEGIN
                                    TtArtrancGainLoss = null;

                                    #region CRUD LoadToVariable
                                    var artrancASartranc1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TtArtrancGainLoss,"sum(artranc.GainLoss)"},
                                    },
                                        loadForChange: false,
                        lockingType: LockingType.None,
                                        //maximumRows: 1,
                                        tableName: "#artranc AS artranc",
                                        fromClause: collectionLoadRequestFactory.Clause(""),
                                        whereClause: collectionLoadRequestFactory.Clause("artranc.CustNum = {0} AND artranc.InvNum = {2} AND artranc.InvSeq = {3} AND artranc.CheckSeq = {1}", SubCustaddrCustNum, ArtranCheckSeq, ArtranInvNum, ArtranInvSeq),
                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                    var artrancASartranc1LoadResponse = this.appDB.Load(artrancASartranc1LoadRequest);
                                    if (artrancASartranc1LoadResponse.Items.Count > 0)
                                    {
                                        TtArtrancGainLoss = _TtArtrancGainLoss;
                                    }
                                    #endregion  LoadToVariable

                                    LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #artranc ");

                                    if (sQLUtil.SQLGreaterThan(artrancASartranc1LoadResponse.Items.Count, 0) == true && sQLUtil.SQLNotEqual(TtArtrancGainLoss, 0) == true)
                                    {
                                        TcTotBal = (decimal?)(TcTotBal + TtArtrancGainLoss);

                                    }
                                    //END

                                }
                                if (sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranInvNum), 1) == true && sQLUtil.SQLLessThan(convertToUtil.ToInt64(ArtranInvNum), 0) == true)
                                {
                                    if (sQLUtil.SQLGreaterThan(TAgeDate, (sQLUtil.SQLEqual(PInvDue, "D") == true ? ArtranDueDate : ArtranInvDate)) == true)
                                    {
                                        TAgeDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(PInvDue, "D") == true ? convertToUtil.ToDateTime(ArtranDueDate) : ArtranInvDate));

                                    }

                                }
                                if ((sQLUtil.SQLNotEqual(LastOfArtranInvNum, 0) == true) || (sQLUtil.SQLEqual(SpecialInvNum, 1) == true && sQLUtil.SQLNotEqual(usemultiduedate, 1) == true))
                                {
                                    //BEGIN
                                    NDays = (int?)(dateTimeUtil.DateDiff("Day", TAgeDate, SDate));
                                    I = (int?)((sQLUtil.SQLGreaterThan(NDays, PAgeDays4) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 5) == true && sQLUtil.SQLEqual(TLastBucket, 5) == true ? 5 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays3) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 4) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 4) == true ? 4 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays2) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 3) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 3) == true ? 3 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays1) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 2) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 2) == true ? 2 : (sQLUtil.SQLGreaterThan(TFirstBucket, 1) == true ? TFirstBucket : 1))))));
                                    if (((sQLUtil.SQLNotEqual(TcTotBal, 0) == true || sQLUtil.SQLLessThan(NDays, PHidePaid) == true || sQLUtil.SQLEqual(ArtranApplyToInvNum, "0") == true) && (sQLUtil.SQLEqual(PAgeBucket, "12345") == true || sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                                    Convert.ToString(I),
                                                    PAgeBucket), 0) == true && sQLUtil.SQLNotEqual(TcTotBal, 0) == true) && (sQLUtil.SQLNotEqual(TOpt, "O") == true || sQLUtil.SQLGreaterThan(NDays, 0) == true)) && sQLUtil.SQLNotEqual(TOpt, "N") == true)
                                    {
                                        //BEGIN
                                        TcTotMinorBal = (decimal?)(TcTotMinorBal + TcTotBal);
                                        if (sQLUtil.SQLEqual(ArtranInvNum, "-1") == true)
                                        {
                                            //BEGIN
                                            TtInvRowPointer = null;
                                            TtInvInvNum = null;
                                            TtInvArtranRecid = null;
                                            TtInvCustNum = null;

                                            #region CRUD LoadToVariable
                                            var tv_tt_inv3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                            {
                                                {_TtInvRowPointer,"tt_inv.RowPointer"},
                                                {_TtInvInvNum,"tt_inv.InvNum"},
                                                {_TtInvArtranRecid,"tt_inv.ArtranRecid"},
                                                {_TtInvCustNum,"tt_inv.CustNum"},
                                            },
                                                loadForChange: false,
                        lockingType: LockingType.None,
                                                //maximumRows: 1,
                                                tableName: "#tv_tt_inv",
                                                fromClause: collectionLoadRequestFactory.Clause(" AS tt_inv"),
                                                whereClause: collectionLoadRequestFactory.Clause("tt_inv.InvNum = {3} AND tt_inv.ArtranRecid = {1} AND tt_inv.CustNum = {0} AND ({4} = 'I' OR tt_inv.DueDate = {2})", SubCustaddrCustNum, ArtranRowPointer, ArtranDueDate, ArtranInvNum, TOpt),
                                                orderByClause: collectionLoadRequestFactory.Clause(""));
                                            var tv_tt_inv3LoadResponse = this.appDB.Load(tv_tt_inv3LoadRequest);
                                            if (tv_tt_inv3LoadResponse.Items.Count > 0)
                                            {
                                                TtInvRowPointer = _TtInvRowPointer;
                                                TtInvInvNum = _TtInvInvNum;
                                                TtInvArtranRecid = _TtInvArtranRecid;
                                                TtInvCustNum = _TtInvCustNum;
                                            }
                                            #endregion  LoadToVariable
                                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_tt_inv ");

                                            if (TtInvRowPointer == null)
                                            {
                                                //BEGIN

                                                #region CRUD LoadResponseWithoutTable
                                                var nonTable6LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                            {
                                                    { "RowPointer", Guid.NewGuid()},
                                                    { "CustNum", SubCustaddrCustNum},
                                                    { "InvNum", ArtranInvNum},
                                                    { "InvSeq", ArtranInvSeq},
                                                    { "ArtranRecid", ArtranRowPointer},
                                                    { "Type", ArtranType},
                                                    { "InvBal", TcTotBal},
                                                    { "Bucket", I},
                                                    { "DueDate", stringUtil.IsNull(
                                                        (sQLUtil.SQLEqual(TOpt, "I") == true ? convertToUtil.ToDateTime(ArtranInvDate) : ArtranDueDate),
                                                        LowDate)},
                                                    { "Site", PSite},
                                                    { "ApplyToInvNum", ArtranApplyToInvNum},
                                            });

                                                var nonTable6LoadResponse = this.appDB.Load(nonTable6LoadRequest);
                                                #endregion CRUD LoadResponseWithoutTable

                                                #region CRUD InsertByRecords
                                                var nonTable6InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_inv",
                                                    items: nonTable6LoadResponse.Items);

                                                this.appDB.Insert(nonTable6InsertRequest);
                                                #endregion InsertByRecords
                                                LogTiming("AGING STREAMING LOOPED INSERT TO #tv_tt_inv ");
                                                //END

                                            }
                                            //END

                                        }
                                        else
                                        {
                                            //BEGIN
                                            TtInvRowPointer = null;
                                            TtInvInvNum = null;
                                            TtInvArtranRecid = null;
                                            TtInvCustNum = null;

                                            #region CRUD LoadToVariable
                                            var tv_tt_inv4LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                            {
                                                {_TtInvRowPointer,"tt_inv.RowPointer"},
                                                {_TtInvInvNum,"tt_inv.InvNum"},
                                                {_TtInvArtranRecid,"tt_inv.ArtranRecid"},
                                                {_TtInvCustNum,"tt_inv.CustNum"},
                                            },
                                                loadForChange: false,
                        lockingType: LockingType.None,
                                                //maximumRows: 1,
                                                tableName: "#tv_tt_inv",
                                                fromClause: collectionLoadRequestFactory.Clause(" AS tt_inv"),
                                                whereClause: collectionLoadRequestFactory.Clause("tt_inv.InvNum = {3} AND tt_inv.ArtranRecid = {1} AND tt_inv.CustNum = {0} AND ({4} = 'I' OR tt_inv.DueDate = {2})", SubCustaddrCustNum, ArtranRowPointer, ArtranDueDate, ArtranInvNum, TOpt),
                                                orderByClause: collectionLoadRequestFactory.Clause(""));
                                            var tv_tt_inv4LoadResponse = this.appDB.Load(tv_tt_inv4LoadRequest);
                                            if (tv_tt_inv4LoadResponse.Items.Count > 0)
                                            {
                                                TtInvRowPointer = _TtInvRowPointer;
                                                TtInvInvNum = _TtInvInvNum;
                                                TtInvArtranRecid = _TtInvArtranRecid;
                                                TtInvCustNum = _TtInvCustNum;
                                            }
                                            #endregion  LoadToVariable

                                            LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_tt_inv ");

                                            if (TtInvRowPointer == null)
                                            {
                                                //BEGIN
                                                YArtranRowPointer = null;
                                                YArtranInvNum = null;
                                                YArtranType = null;
                                                if (sQLUtil.SQLNotEqual(ArtranType, "I") == true)
                                                {
                                                    #region CRUD LoadToVariable
                                                    var tv_artran_all6LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                                    {
                                                        {_YArtranRowPointer,"y_artran.RowPointer"},
                                                        {_YArtranInvNum,"y_artran.inv_num"},
                                                        {_YArtranInvDate,"y_artran.inv_date"},
                                                        {_YArtranDueDate,$"NULLIF (y_artran.due_date, {variableUtil.GetQuotedValue<DateTime?>(LowDate)})"},
                                                        {_YArtranType,"y_artran.type"},
                                                    },
                                                        loadForChange: false,
                        lockingType: LockingType.None,
                                                        //maximumRows: 1,
                                                        tableName: "#tv_artran_all",
                                                        fromClause: collectionLoadRequestFactory.Clause(" AS y_artran"),
                                                        whereClause: collectionLoadRequestFactory.Clause("y_artran.cust_num = {0} AND y_artran.inv_num = {1} AND y_artran.site_ref = {2} AND y_artran.inv_seq = 0 AND y_artran.type = 'I'", ArtranCustNum, ArtranInvNum, PSite),
                                                        orderByClause: collectionLoadRequestFactory.Clause(""));
                                                    var tv_artran_all6LoadResponse = this.appDB.Load(tv_artran_all6LoadRequest);
                                                    if (tv_artran_all6LoadResponse.Items.Count > 0)
                                                    {
                                                        YArtranRowPointer = _YArtranRowPointer;
                                                        YArtranInvNum = _YArtranInvNum;
                                                        YArtranInvDate = _YArtranInvDate;
                                                        YArtranDueDate = _YArtranDueDate;
                                                        YArtranType = _YArtranType;
                                                    }
                                                    #endregion  LoadToVariable
                                                    LogTiming("AGING STREAMING LOOPED LOAD TO VARIABLE from  #tv_artran_all ");
                                                }
                                                if (sQLUtil.SQLNotEqual(ArtranType, "I") == true && YArtranRowPointer != null)
                                                {
                                                    //BEGIN
                                                    #region CRUD LoadResponseWithoutTable
                                                    var nonTable7LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                                    {
                                                        { "RowPointer", Guid.NewGuid()},
                                                        { "CustNum", SubCustaddrCustNum},
                                                        { "InvNum", YArtranInvNum},
                                                        { "InvSeq", ArtranInvSeq},
                                                        { "ArtranRecid", YArtranRowPointer},
                                                        { "Type", YArtranType},
                                                        { "InvBal", TcTotBal},
                                                        { "Bucket", I},
                                                        { "DueDate", stringUtil.IsNull(
                                                            (sQLUtil.SQLEqual(TOpt, "I") == true ? convertToUtil.ToDateTime(YArtranInvDate) : YArtranDueDate),
                                                            LowDate)},
                                                        { "Site", PSite},
                                                        { "ApplyToInvNum", ArtranApplyToInvNum},
                                                    });

                                                    var nonTable7LoadResponse = this.appDB.Load(nonTable7LoadRequest);
                                                    #endregion CRUD LoadResponseWithoutTable

                                                    #region CRUD InsertByRecords
                                                    var nonTable7InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_inv",
                                                        items: nonTable7LoadResponse.Items);

                                                    this.appDB.Insert(nonTable7InsertRequest);
                                                    #endregion InsertByRecords
                                                    LogTiming("AGING STREAMING LOOPED INSERT TO #tv_tt_inv ");
                                                    //END
                                                }
                                                else
                                                {
                                                    #region CRUD LoadResponseWithoutTable
                                                    var nonTable8LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                                    {
                                                        { "RowPointer", Guid.NewGuid()},
                                                        { "CustNum", SubCustaddrCustNum},
                                                        { "InvNum", ((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranApplyToInvNum), 1) == true && sQLUtil.SQLLessThanOrEqual(convertToUtil.ToInt64(ArtranApplyToInvNum), 0) == true) ? ArtranInvNum : ArtranApplyToInvNum)},
                                                        { "InvSeq", ArtranInvSeq},
                                                        { "ArtranRecid", ArtranRowPointer},
                                                        { "Type", ArtranType},
                                                        { "InvBal", TcTotBal},
                                                        { "Bucket", I},
                                                        { "DueDate", stringUtil.IsNull(
                                                            (sQLUtil.SQLEqual(TOpt, "I") == true ? convertToUtil.ToDateTime(ArtranInvDate) : ArtranDueDate),
                                                            LowDate)},
                                                        { "Site", PSite},
                                                        { "ApplyToInvNum", ArtranApplyToInvNum},
                                                    });

                                                    var nonTable8LoadResponse = this.appDB.Load(nonTable8LoadRequest);
                                                    #endregion CRUD LoadResponseWithoutTable

                                                    #region CRUD InsertByRecords
                                                    var nonTable8InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_tt_inv",
                                                        items: nonTable8LoadResponse.Items);

                                                    this.appDB.Insert(nonTable8InsertRequest);
                                                    #endregion InsertByRecords
                                                    LogTiming("AGING STREAMING LOOPED INSERT TO #tv_tt_inv ");
                                                }
                                                //END
                                            }
                                            //END
                                        }
                                        //END
                                    }
                                    //END
                                }
                                else
                                {
                                    //BEGIN
                                    if ((sQLUtil.SQLEqual(TOpt, "N") == true && ((sQLUtil.SQLEqual(PAgeBucket, "12345") == true) || (sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                                        Convert.ToString(I),
                                                        PAgeBucket), 0) == true) && sQLUtil.SQLNotEqual(TcTotBal, 0) == true)))
                                    {
                                        //BEGIN
                                        TcTotMinorBal = (decimal?)(TcTotMinorBal + TcTotBal);
                                        //END

                                    }
                                    //END

                                }
                                //END
                            }
                        }
                        curArtranLoadResponseForCursor = null;
                        //Deallocate Cursor @curArtran
                        //END
                    }
                    //Deallocate Cursor curSubCustAddr
                    if ((sQLUtil.SQLEqual(TcTotMinorBal, 0) == true && sQLUtil.SQLEqual(PPrZeroBal, 0) == true) || (sQLUtil.SQLLessThan(TcTotMinorBal, 0) == true && sQLUtil.SQLEqual(PPrCreditBal, 0) == true))
                    {
                        return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
                    }
                    //END
                }
                AnyTrans = 1;
                if (CustomerRowPointer != null)
                {
                    //BEGIN
                    TermsRowPointer = null;
                    TermsDescription = null;

                    #region CRUD LoadToVariable
                    var termsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                        {
                            {_TermsRowPointer,"terms.RowPointer"},
                            {_TermsDescription,"terms.description"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        //maximumRows: 1,
                        tableName: "terms",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("terms.terms_code = {0}", CustomerTermsCode),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var termsLoadResponse = this.appDB.Load(termsLoadRequest);
                    if (termsLoadResponse.Items.Count > 0)
                    {
                        TermsRowPointer = _TermsRowPointer;
                        TermsDescription = _TermsDescription;
                    }
                    #endregion  LoadToVariable
                    LogTiming("AGING LOAD TO VARIABLE terms");
                    //END
                }
                if (TermsRowPointer != null)
                {
                    TempTermsCode = TermsDescription;
                }
                else
                {
                    #region CRUD ExecuteMethodCall

                    var MsgApp = this.iMsgApp.MsgAppSp(
                        Infobar: TempTermsCode,
                        BaseMsg: "E=NotInMaster",
                        Parm1: "@terms");
                    TempTermsCode = MsgApp.Infobar;

                    #endregion ExecuteMethodCall
                    LogTiming("AGING MsgAppSp");
                }
                TcAmtDCreditLimit = CustaddrCreditLimit;
                TRate = null;
                if (sQLUtil.SQLEqual(TranslateForAging, 1) == true && sQLUtil.SQLNotEqual(CustaddrCurrCode, ParmsCurrCode) == true)
                {
                    #region CRUD ExecuteMethodCall
                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                    var CurrCnvt2 = this.iCurrCnvt.CurrCnvtSp(
                        CurrCode: CustaddrCurrCode,
                        FromDomestic: 0,
                        UseBuyRate: 0,
                        RoundResult: 1,
                        Date: null,
                        TRate: TRate,
                        Infobar: Infobar,
                        Amount1: TcAmtDCreditLimit,
                        Result1: TcAmtDCreditLimit,
                        Site: PSite,
                        DomCurrCode: ParmsCurrCode);
                    Severity = CurrCnvt2.ReturnCode;
                    TRate = CurrCnvt2.TRate;
                    Infobar = CurrCnvt2.Infobar;
                    TcAmtDCreditLimit = CurrCnvt2.Result1;

                    #endregion ExecuteMethodCall
                    LogTiming("AGING CurrCnvtSp");
                }
                FinanceChargeBalance = 0;
                #region Cursor Statement

                #region CRUD LoadToRecord
                fcCrsLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"InvSeq","InvSeq"},
                        {"InvBal","InvBal"},
                        {"DueDate","DueDate"},
                        {"CustNum","CustNum"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    tableName: "#tv_tt_inv",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("CHARINDEX(Type, 'FDCP') > 0 AND ApplyToInvNum = '-1'"),
                    orderByClause: collectionLoadRequestFactory.Clause(" DueDate, InvSeq"));
                #endregion  LoadToRecord



                #endregion Cursor Statement
                fcCrsLoadResponseForCursor = this.appDB.Load(fcCrsLoadRequestForCursor);
                fcCrs_CursorFetch_Status = fcCrsLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                fcCrs_CursorCounter = -1;

                LogTiming($"AGING LOAD CURSOR #tv_tt_inv ({fcCrsLoadResponseForCursor.Items.Count})");

                while (sQLUtil.SQLEqual(1, 1) == true)
                {
                    //BEGIN
                    fcCrs_CursorCounter++;
                    if (fcCrsLoadResponseForCursor.Items.Count > fcCrs_CursorCounter)
                    {
                        FinanceChargeInvSeq = fcCrsLoadResponseForCursor.Items[fcCrs_CursorCounter].GetValue<int?>(0);
                        FinanceChargeAmount = fcCrsLoadResponseForCursor.Items[fcCrs_CursorCounter].GetValue<decimal?>(1);
                        FinanceChargeDueDate = fcCrsLoadResponseForCursor.Items[fcCrs_CursorCounter].GetValue<DateTime?>(2);
                        FinanceChargeCustNum = fcCrsLoadResponseForCursor.Items[fcCrs_CursorCounter].GetValue<string>(3);
                    }
                    fcCrs_CursorFetch_Status = (fcCrs_CursorCounter == fcCrsLoadResponseForCursor.Items.Count ? -1 : 0);

                    if (sQLUtil.SQLNotEqual(fcCrs_CursorFetch_Status, 0) == true)
                    {
                        break;
                    }
                    FinanceChargeBalance = (decimal?)(FinanceChargeBalance + FinanceChargeAmount);

                    #region CRUD LoadResponseWithoutTable
                    var nonTable9LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                    {
                            { "InvSeq", FinanceChargeInvSeq},
                            { "CustNum", FinanceChargeCustNum},
                    });

                    var nonTable9LoadResponse = this.appDB.Load(nonTable9LoadRequest);
                    #endregion CRUD LoadResponseWithoutTable

                    #region CRUD InsertByRecords
                    var nonTable9InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_FinList",
                        items: nonTable9LoadResponse.Items);

                    this.appDB.Insert(nonTable9InsertRequest);
                    #endregion InsertByRecords

                    LogTiming("AGING CURSOR INSERT TO #tv_FinList");


                    if (sQLUtil.SQLEqual(FinanceChargeBalance, 0) == true)
                    {
                        //BEGIN
                        if (sQLUtil.SQLGreaterThan(dateTimeUtil.DateDiff("Day", FinanceChargeDueDate, PAgingDate), PHidePaid) == true)
                        {

                            #region DeleteNonTrigger
                            var tt_invNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                                tableName: "#tv_tt_inv",
                                fromClause: collectionNonTriggerUpdateRequestFactory.Clause("#tv_tt_inv AS tt_inv INNER JOIN #tv_FinList AS fl ON fl.InvSeq = tt_inv.InvSeq"),
                                whereClause: collectionNonTriggerUpdateRequestFactory.Clause("CHARINDEX(tt_inv.Type, 'FDCP') > 0 AND tt_inv.ApplyToInvNum = '-1'")
                                );

                            this.appDB.DeleteWithoutTrigger(tt_invNonTriggerDeleteRequest);
                            #endregion DeleteNonTrigger

                            LogTiming("AGING CURSOR INSERT TO #tv_tt_inv");
                        }
                        else
                        {
                            if (sQLUtil.SQLEqual(PInvDue, "D") == true)
                            {
                                #region UpdateNonTrigger
                                var tv_artran_allNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                                    tableName: "#tv_artran_all",
                                    expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        { "due_date", collectionNonTriggerUpdateRequestFactory.Clause("{0}",FinanceChargeDueDate) },
                                    },
                                    fromClause: collectionNonTriggerUpdateRequestFactory.Clause("#tv_artran_all AS aa INNER JOIN #tv_FinList AS fl ON fl.InvSeq = aa.inv_seq AND fl.CustNum = aa.cust_num"),
                                    whereClause: collectionNonTriggerUpdateRequestFactory.Clause("CHARINDEX(aa.Type, 'FDCP') > 0 AND aa.apply_to_inv_num = '-1'")
                                    );

                                this.appDB.UpdateWithoutTrigger(tv_artran_allNonTriggerUpdateRequest);
                                #endregion UpdateNonTrigger

                                LogTiming("AGING CURSOR UPDATE TO #tv_artran_all");
                            }
                            else
                            {
                                #region UpdateNonTrigger
                                var tv_artran_allNonTriggerUpdateRequest = collectionNonTriggerUpdateRequestFactory.SQLUpdate(
                                    tableName: "#tv_artran_all",
                                    expressionByColumnToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        { "inv_date", collectionNonTriggerUpdateRequestFactory.Clause("{0}",FinanceChargeDueDate) },
                                    },
                                    fromClause: collectionNonTriggerUpdateRequestFactory.Clause("#tv_artran_all AS aa INNER JOIN #tv_FinList AS fl ON fl.InvSeq = aa.inv_seq AND fl.CustNum = aa.cust_num"),
                                    whereClause: collectionNonTriggerUpdateRequestFactory.Clause("CHARINDEX(aa.Type, 'FDCP') > 0 AND aa.apply_to_inv_num = '-1'")
                                    );

                                this.appDB.UpdateWithoutTrigger(tv_artran_allNonTriggerUpdateRequest);
                                #endregion UpdateNonTrigger
                                LogTiming("AGING CURSOR UPDATE TO #tv_artran_all");
                            }
                        }
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_FinList ADD tempTableId INT IDENTITY");

                        #region DeleteNonTrigger
                        var NonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                            tableName: "#tv_FinList",
                            fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                            whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                            );

                        this.appDB.DeleteWithoutTrigger(NonTriggerDeleteRequest);
                        #endregion DeleteNonTrigger

                        LogTiming("AGING CURSOR DELETE TO #tv_FinList");

                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_FinList DROP COLUMN tempTableId");
                        //END
                    }
                    //END
                }
                //Deallocate Cursor fcCrs
                #region Cursor Statement

                #region CRUD LoadToRecord
                curTtInvLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                    {
                        {"tt_inv.RowPointer","tt_inv.RowPointer"},
                        {"tt_inv.CustNum","tt_inv.CustNum"},
                        {"tt_inv.InvBal","tt_inv.InvBal"},
                        {"tt_inv.bucket","tt_inv.bucket"},
                        {"tt_inv.InvNum","tt_inv.InvNum"},
                        {"tt_inv.InvSeq","tt_inv.InvSeq"},
                        {"tt_inv.ArtranRecid","tt_inv.ArtranRecid"},
                        {"tt_inv.site","tt_inv.site"},
                        {"tt_inv.ApplyToInvNum","tt_inv.ApplyToInvNum"},
                    },
                    loadForChange: false,
                        lockingType: LockingType.None,
                    tableName: "#tv_tt_inv",
                    fromClause: collectionLoadRequestFactory.Clause(" tt_inv"),
                    whereClause: collectionLoadRequestFactory.Clause(""),
                    orderByClause: collectionLoadRequestFactory.Clause(" tt_inv.DueDate, tt_inv.InvNum, tt_inv.ArtranRecid, tt_inv.CustNum"));

                #endregion  LoadToRecord
                #endregion Cursor Statement
                curTtInvLoadResponseForCursor = this.appDB.Load(curTtInvLoadRequestForCursor);
                curTtInv_CursorFetch_Status = curTtInvLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                curTtInv_CursorCounter = -1;

                LogTiming($"AGING LOAD CURSOR #tv_tt_inv ({curTtInvLoadResponseForCursor.Items.Count})");

                while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
                {
                    //BEGIN
                    curTtInv_CursorCounter++;
                    if (curTtInvLoadResponseForCursor.Items.Count > curTtInv_CursorCounter)
                    {
                        TtInvRowPointer = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<Guid?>(0);
                        TtInvCustNum = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<string>(1);
                        TtInvInvBal = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<decimal?>(2);
                        TtInvBucket = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<int?>(3);
                        TtInvInvNum = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<string>(4);
                        TtInvInvSeq = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<int?>(5);
                        TtInvArtranRecid = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<Guid?>(6);
                        TtSite = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<string>(7);
                        TtInvApplyToInvNum = curTtInvLoadResponseForCursor.Items[curTtInv_CursorCounter].GetValue<string>(8);
                    }
                    curTtInv_CursorFetch_Status = (curTtInv_CursorCounter == curTtInvLoadResponseForCursor.Items.Count ? -1 : 0);

                    if (sQLUtil.SQLEqual(curTtInv_CursorFetch_Status, -1) == true)
                    {
                        break;
                    }

                    #region CRUD LoadToRecord
                    curArtranLoadRequestForCursor = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"RowPointer","artran.RowPointer"},
                            {"inv_seq","artran.inv_seq"},
                            {"inv_num","artran.inv_num"},
                            {"apply_to_inv_num","artran.apply_to_inv_num"},
                            {"type","artran.type"},
                            {"exch_rate","artran.exch_rate"},
                            {"fixed_rate","artran.fixed_rate"},
                            {"amount","artran.amount"},
                            {"misc_charges","artran.misc_charges"},
                            {"sales_tax","artran.sales_tax"},
                            {"sales_tax_2","artran.sales_tax_2"},
                            {"freight","artran.freight"},
                            {"cust_num","artran.cust_num"},
                            {"inv_date","artran.inv_date"},
                            {"col0","CAST (NULL AS DATETIME)"},
                            {"check_seq","artran.check_seq"},
                            {"multi_due_date","artran.multi_due_date"},
                            {"approval_status","artran.approval_status"},
                            {"OrigAmount","artran.OrigAmount"},
                            {"curr_code","artran.curr_code"},
                            {"TH_payment_number","artran.TH_payment_number"},
                            {"u0","artran.due_date"},
                        },
                        loadForChange: false,
                        lockingType: LockingType.None,
                        tableName: "#tv_artran_all",
                        fromClause: collectionLoadRequestFactory.Clause(" AS artran"),
                        whereClause: collectionLoadRequestFactory.Clause("artran.cust_num = {2} AND artran.active = (CASE WHEN {3} = 1 THEN 1 ELSE artran.active END) AND artran.site_ref = {8} AND artran.apply_to_inv_num = {0} AND artran.inv_date <= (CASE WHEN {4} IS NOT NULL THEN {4} ELSE artran.inv_date END) AND artran.inv_num = CASE WHEN {0} = '0' THEN {5} ELSE artran.inv_num END AND artran.inv_seq = CASE WHEN {0} = '0' THEN {6} ELSE artran.inv_seq END AND (((CASE WHEN dbo.IsInteger(artran.apply_to_inv_num) = 1 THEN CONVERT (BIGINT, artran.apply_to_inv_num) ELSE 1 END <= 0) AND artran.RowPointer = {1}) OR (NOT (CASE WHEN dbo.IsInteger(artran.inv_num) = 1 THEN CONVERT (BIGINT, artran.inv_num) ELSE 1 END <= 0) AND ({0} <> '-1'))) AND ({7} = 1 OR artran.type <> 'P' OR artran.apply_to_inv_num <> '0') AND 1 = CASE WHEN artran.type != 'F' OR artran.apply_to_inv_num = '0' THEN 1 WHEN EXISTS (SELECT 1 FROM #tv_artran_all AS artranI WHERE artranI.inv_num = artran.apply_to_inv_num AND artranI.type = 'I' AND artranI.cust_num = artran.cust_num AND artranI.multi_due_date = 0) THEN 0 ELSE 1 END", TtInvApplyToInvNum, TtInvArtranRecid, TtInvCustNum, PShowActive, PCutoffDate, TtInvInvNum, TtInvInvSeq, PPrOpenPay, TtSite),
                        orderByClause: collectionLoadRequestFactory.Clause(" cust_num, apply_to_inv_num, seq, inv_num, inv_seq, check_seq"));
                    #endregion  LoadToRecord



                    curArtranLoadResponseForCursor = this.appDB.Load(curArtranLoadRequestForCursor);
                    foreach (var tv_artran_all9Item in curArtranLoadResponseForCursor.Items)
                    {
                        tv_artran_all9Item.SetValue<Guid?>("RowPointer", tv_artran_all9Item.GetValue<Guid?>("RowPointer"));
                        tv_artran_all9Item.SetValue<int?>("inv_seq", tv_artran_all9Item.GetValue<int?>("inv_seq"));
                        tv_artran_all9Item.SetValue<string>("inv_num", tv_artran_all9Item.GetValue<string>("inv_num"));
                        tv_artran_all9Item.SetValue<string>("apply_to_inv_num", tv_artran_all9Item.GetValue<string>("apply_to_inv_num"));
                        tv_artran_all9Item.SetValue<string>("type", tv_artran_all9Item.GetValue<string>("type"));
                        tv_artran_all9Item.SetValue<decimal?>("exch_rate", tv_artran_all9Item.GetValue<decimal?>("exch_rate"));
                        tv_artran_all9Item.SetValue<int?>("fixed_rate", tv_artran_all9Item.GetValue<int?>("fixed_rate"));
                        tv_artran_all9Item.SetValue<decimal?>("amount", tv_artran_all9Item.GetValue<decimal?>("amount"));
                        tv_artran_all9Item.SetValue<decimal?>("misc_charges", tv_artran_all9Item.GetValue<decimal?>("misc_charges"));
                        tv_artran_all9Item.SetValue<decimal?>("sales_tax", tv_artran_all9Item.GetValue<decimal?>("sales_tax"));
                        tv_artran_all9Item.SetValue<decimal?>("sales_tax_2", tv_artran_all9Item.GetValue<decimal?>("sales_tax_2"));
                        tv_artran_all9Item.SetValue<decimal?>("freight", tv_artran_all9Item.GetValue<decimal?>("freight"));
                        tv_artran_all9Item.SetValue<string>("cust_num", tv_artran_all9Item.GetValue<string>("cust_num"));
                        tv_artran_all9Item.SetValue<DateTime?>("inv_date", tv_artran_all9Item.GetValue<DateTime?>("inv_date"));
                        tv_artran_all9Item.SetValue<DateTime?>("col0", tv_artran_all9Item.GetValue<DateTime?>("u0") == LowDate ? null : tv_artran_all9Item.GetValue<DateTime?>("u0"));
                        tv_artran_all9Item.SetValue<int?>("check_seq", tv_artran_all9Item.GetValue<int?>("check_seq"));
                        tv_artran_all9Item.SetValue<int?>("multi_due_date", tv_artran_all9Item.GetValue<int?>("multi_due_date"));
                        tv_artran_all9Item.SetValue<string>("approval_status", tv_artran_all9Item.GetValue<string>("approval_status"));
                        tv_artran_all9Item.SetValue<decimal?>("OrigAmount", tv_artran_all9Item.GetValue<decimal?>("OrigAmount"));
                        tv_artran_all9Item.SetValue<string>("curr_code", tv_artran_all9Item.GetValue<string>("curr_code"));
                        tv_artran_all9Item.SetValue<string>("TH_payment_number", tv_artran_all9Item.GetValue<string>("TH_payment_number"));
                    };

                    curArtran_CursorFetch_Status = curArtranLoadResponseForCursor.Items.Count > 0 ? 0 : -1;
                    curArtran_CursorCounter = -1;

                    LogTiming($"AGING LOAD CURSOR FROM #tv_artran_all ({ curArtranLoadResponseForCursor.Items.Count})");

                    FirstArtranInvSeq = 1;
                    FirstArtranInvSeq1 = 1;
                    while (sQLUtil.SQLBool(sQLUtil.SQLEqual(Severity, 0)))
                    {
                        //BEGIN
                        curArtran_CursorCounter++;
                        if (curArtranLoadResponseForCursor.Items.Count > curArtran_CursorCounter)
                        {
                            ArtranRowPointer = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<Guid?>(0);
                            ArtranInvSeq = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<int?>(1);
                            ArtranInvNum = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(2);
                            ArtranApplyToInvNum = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(3);
                            ArtranType = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(4);
                            ArtranExchRate = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(5);
                            ArtranFixedRate = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<int?>(6);
                            ArtranAmount = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(7);
                            ArtranMiscCharges = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(8);
                            ArtranSalesTax = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(9);
                            ArtranSalesTax2 = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(10);
                            ArtranFreight = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(11);
                            ArtranCustNum = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(12);
                            ArtranInvDate = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<DateTime?>(13);
                            ArtranDueDate = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<DateTime?>(14);
                            ArtranCheckSeq = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<int?>(15);
                            usemultiduedate = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<int?>(16);
                            ArtranApprovalStatus = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(17);
                            ArtdOrigAmount = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<decimal?>(18);
                            ArtranCurrCode = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(19);
                            ArtranPaymentNumber = curArtranLoadResponseForCursor.Items[curArtran_CursorCounter].GetValue<string>(20);
                        }
                        curArtran_CursorFetch_Status = (curArtran_CursorCounter == curArtranLoadResponseForCursor.Items.Count ? -1 : 0);

                        if (sQLUtil.SQLEqual(curArtran_CursorFetch_Status, -1) == true)
                        {
                            break;
                        }
                        TRate1 = 0;
                        SpecialInvNum = convertToUtil.ToInt32((sQLUtil.SQLEqual(this.iIsInteger.IsIntegerFn(ArtranApplyToInvNum), 1) == true && sQLUtil.SQLLessThanOrEqual(convertToUtil.ToInt64(ArtranApplyToInvNum), 0) == true ? 1 : 0));
                        TranslateToDom = convertToUtil.ToInt32((sQLUtil.SQLEqual(TranslateForAging, 1) == true && sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true ? 1 : 0));
                        if (sQLUtil.SQLEqual(FirstArtranInvSeq, 1) == true || sQLUtil.SQLEqual(SpecialInvNum, 1) == true)
                        {
                            //BEGIN
                            FirstArtranInvSeq = 0;
                            if (sQLUtil.SQLEqual(ArtranType, "I") == true && sQLUtil.SQLEqual(TranslateToDom, 1) == true && sQLUtil.SQLEqual(ArtranFixedRate, 0) == true)
                            {
                                sQLExpressionExecutor.Execute("DELETE #artranc");
                                TOldTransDom = TTransDom;
                                TTransDom = convertToUtil.ToInt32((sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true ? 1 : 0));

                                #region CRUD ExecuteMethodCall

                                //Please Generate the bounce for this stored procedure: GainLossArSp
                                var GainLossAr2 = this.iGainLossAr.GainLossArSp(
                                    pCustNum: ArtranCustNum,
                                    pInvNum: ArtranInvNum,
                                    pCustCurrCode: ArtranCurrCode,
                                    pUseHistRate: UseHistRate,
                                    pTTransDom: TTransDom,
                                    pSite: TtSite,
                                    rTDomBal: TDomBal,
                                    rTForBal: TForBal,
                                    rTGainLoss: TGainLoss,
                                    rInfobar: Infobar,
                                    pCutoffDate: PCutoffDate,
                                    ReturnTable: 1,
                                    AgingDate: PAgingDate);
                                TDomBal = GainLossAr2.rTDomBal;
                                TForBal = GainLossAr2.rTForBal;
                                TGainLoss = GainLossAr2.rTGainLoss;
                                Infobar = GainLossAr2.rInfobar;

                                #endregion ExecuteMethodCall
                                LogTiming("AGING CURSOR GainLossArSp");
                                TTransDom = TOldTransDom;
                                //END
                            }
                            else
                            {
                                if (sQLUtil.SQLEqual(ArtranApplyToInvNum, "0") == true && sQLUtil.SQLEqual(TranslateToDom, 1) == true && sQLUtil.SQLEqual(ArtranFixedRate, 0) == true)
                                {
                                    //BEGIN
                                    this.sQLExpressionExecutor.Execute("ALTER TABLE #artranc ADD tempTableId INT IDENTITY");

                                    #region DeleteNonTrigger
                                    var artrancNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                                        tableName: "#artranc",
                                        fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                                        whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                                        );

                                    this.appDB.DeleteWithoutTrigger(artrancNonTriggerDeleteRequest);
                                    #endregion DeleteNonTrigger

                                    LogTiming("AGING CURSOR DELETE #artranc");

                                    this.sQLExpressionExecutor.Execute("ALTER TABLE #artranc DROP COLUMN tempTableId");
                                    TRate1 = ArtranExchRate;
                                    TRate2 = null;
                                    TAmount = (decimal?)(ArtranAmount + ArtranMiscCharges + ArtranSalesTax + ArtranSalesTax2 + ArtranFreight);

                                    #region CRUD ExecuteMethodCall

                                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                    var CurrCnvt3 = this.iCurrCnvt.CurrCnvtSp(
                                        CurrCode: ArtranCurrCode,
                                        FromDomestic: 0,
                                        UseBuyRate: 0,
                                        RoundResult: 1,
                                        Date: null,
                                        TRate: TRate1,
                                        Infobar: Infobar,
                                        Amount1: TAmount,
                                        Result1: TAmount1,
                                        Site: PSite,
                                        DomCurrCode: ParmsCurrCode);
                                    Severity = CurrCnvt3.ReturnCode;
                                    TRate1 = CurrCnvt3.TRate;
                                    Infobar = CurrCnvt3.Infobar;
                                    TAmount1 = CurrCnvt3.Result1;

                                    #endregion ExecuteMethodCall

                                    LogTiming("AGING CURSOR CurrCnvtSp");

                                    #region CRUD ExecuteMethodCall
                                    //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                    var CurrCnvt4 = this.iCurrCnvt.CurrCnvtSp(
                                        CurrCode: ArtranCurrCode,
                                        FromDomestic: 0,
                                        UseBuyRate: 0,
                                        RoundResult: 1,
                                        Date: PAgingDate,
                                        TRate: TRate2,
                                        Infobar: Infobar,
                                        Amount1: TAmount,
                                        Result1: TAmount2,
                                        Site: PSite,
                                        DomCurrCode: ParmsCurrCode);
                                    Severity = CurrCnvt4.ReturnCode;
                                    TRate2 = CurrCnvt4.TRate;
                                    Infobar = CurrCnvt4.Infobar;
                                    TAmount2 = CurrCnvt4.Result1;

                                    #endregion ExecuteMethodCall

                                    LogTiming("AGING CURSOR CurrCnvtSp");

                                    TForBal = TAmount;
                                    TDomBal = TAmount1;
                                    TGainLoss = (decimal?)(TAmount2 - TAmount1);

                                    #region CRUD LoadResponseWithoutTable
                                    var nonTable10LoadRequest = collectionLoadBuilderRequestFactory.Create(columnExpressionByColumnName: new Dictionary<string, object>()
                                    {
                                            { "CustNum", ArtranCustNum},
                                            { "InvNum", ArtranInvNum},
                                            { "InvSeq", 999999999},
                                            { "CheckSeq", null},
                                            { "ExchRate", TRate2},
                                            { "GainLoss", ((sQLUtil.SQLEqual(ArtranType, "C") == true || sQLUtil.SQLEqual(ArtranType, "P") == true) && sQLUtil.SQLNotEqual(TGainLoss, 0) == true ? -TGainLoss : TGainLoss)},
                                    });

                                    var nonTable10LoadResponse = this.appDB.Load(nonTable10LoadRequest);
                                    #endregion CRUD LoadResponseWithoutTable

                                    #region CRUD InsertByRecords
                                    var nonTable10InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#artranc",
                                        items: nonTable10LoadResponse.Items);

                                    this.appDB.Insert(nonTable10InsertRequest);
                                    #endregion InsertByRecords

                                    LogTiming("AGING CURSOR INSERT TO artranc");
                                    //END
                                }
                                else
                                {
                                    if (sQLUtil.SQLNotEqual(ArtranInvNum, "0") == true && sQLUtil.SQLEqual(TranslateToDom, 1) == true)
                                    {
                                        //BEGIN
                                        this.sQLExpressionExecutor.Execute("ALTER TABLE #artranc ADD tempTableId INT IDENTITY");

                                        #region DeleteNonTrigger
                                        var artrancNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                                            tableName: "#artranc",
                                            fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                                            whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                                            );

                                        this.appDB.DeleteWithoutTrigger(artrancNonTriggerDeleteRequest);
                                        #endregion DeleteNonTrigger

                                        LogTiming("AGING CURSOR DELETE FROM #artranc");

                                        this.sQLExpressionExecutor.Execute("ALTER TABLE #artranc DROP COLUMN tempTableId");
                                        //END
                                    }
                                }
                            }
                            //END
                        }
                        if (sQLUtil.SQLBool(sQLUtil.SQLEqual(usemultiduedate, 1)))
                        {
                            TmpAmount = ArtdOrigAmount;
                        }
                        else
                        {
                            //BEGIN
                            TmpAmount = (decimal?)(stringUtil.IsNull<decimal?>(
                                ArtranAmount,
                                0) + stringUtil.IsNull<decimal?>(
                                ArtranMiscCharges,
                                0) + stringUtil.IsNull<decimal?>(
                                ArtranSalesTax,
                                0) + stringUtil.IsNull<decimal?>(
                                ArtranSalesTax2,
                                0) + stringUtil.IsNull<decimal?>(
                                ArtranFreight,
                                0));
                            if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(FeatureRS6483Active, 1), sQLUtil.SQLEqual(AgingReport, 1)), sQLUtil.SQLEqual(ArtranApplyToInvNum, "0"))))
                            {
                                //BEGIN
                                #region CRUD LoadToVariable
                                var artran_allASartran2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_TmpAmount,$"SUM((artran.amount + artran.misc_charges + artran.sales_tax + artran.sales_tax_2 + artran.freight) / artran.exch_rate) * {variableUtil.GetQuotedValue<decimal?>(ArtranExchRate)}"},
                                    },
                                    loadForChange: false,
                        lockingType: LockingType.None,
                                    //maximumRows: 1,
                                    tableName: "artran_all AS artran",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("(artran.cust_num = {0} OR (artran.orig_cust_num = {0} AND artran.orig_site = {5})) AND artran.active = (CASE WHEN {3} = 1 THEN 1 ELSE artran.active END) AND artran.inv_date > (CASE WHEN {4} IS NOT NULL THEN {4} ELSE artran.inv_date END) AND CHARINDEX(artran.type, 'PC') > 0 AND ((artran.type = 'C' AND inv_num = {1}) OR (artran.type = 'P' AND inv_seq = {2}))", CustaddrCustNum, ArtranInvNum, ArtranInvSeq, PShowActive, PCutoffDate, PSite),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var artran_allASartran2LoadResponse = this.appDB.Load(artran_allASartran2LoadRequest);
                                if (artran_allASartran2LoadResponse.Items.Count > 0)
                                {
                                    TmpAmount = _TmpAmount;
                                }
                                #endregion  LoadToVariable
                                LogTiming("AGING CURSOR LOAD TO VARIABLE artran_all");

                                if (sQLUtil.SQLBool(sQLUtil.SQLNot(existsChecker.Exists(tableName: "artran_all",
                                        fromClause: collectionLoadRequestFactory.Clause(""),
                                        whereClause: collectionLoadRequestFactory.Clause("RowPointer = {0}", ArtranRowPointer))
                                    )))
                                {
                                    //BEGIN
                                    TmpAmount = (decimal?)(stringUtil.IsNull<decimal?>(
                                        TmpAmount,
                                        0));
                                    //END
                                }
                                else
                                {
                                    //BEGIN
                                    TmpAmount = (decimal?)(stringUtil.IsNull<decimal?>(
                                        TmpAmount,
                                        0) + stringUtil.IsNull<decimal?>(
                                        ArtranAmount,
                                        0) + stringUtil.IsNull<decimal?>(
                                        ArtranMiscCharges,
                                        0) + stringUtil.IsNull<decimal?>(
                                        ArtranSalesTax,
                                        0) + stringUtil.IsNull<decimal?>(
                                        ArtranSalesTax2,
                                        0) + stringUtil.IsNull<decimal?>(
                                        ArtranFreight,
                                        0));
                                    //END
                                }
                                //END
                            }
                            if (sQLUtil.SQLEqual(FeatureRS6483Active, 1) == true && sQLUtil.SQLEqual(AgingReport, 1) == true && existsChecker.Exists(tableName: "artran_open_all",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("inv_num = {2} AND cust_num = {1} AND inv_seq = {3} AND check_seq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq))
                            )
                            {
                                //BEGIN
                                #region CRUD LoadToVariable
                                var artran_open_all5LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                    {
                                        {_ArtranDueDate,"due_date"},
                                    },
                                    loadForChange: false,
                        lockingType: LockingType.None,
                                    //maximumRows: 1,
                                    tableName: "artran_open_all",
                                    fromClause: collectionLoadRequestFactory.Clause(""),
                                    whereClause: collectionLoadRequestFactory.Clause("inv_num = {2} AND cust_num = {1} AND inv_seq = {3} AND check_seq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq),
                                    orderByClause: collectionLoadRequestFactory.Clause(""));
                                var artran_open_all5LoadResponse = this.appDB.Load(artran_open_all5LoadRequest);
                                if (artran_open_all5LoadResponse.Items.Count > 0)
                                {
                                    ArtranDueDate = _ArtranDueDate;
                                }
                                #endregion  LoadToVariable

                                LogTiming("AGING CURSOR LOAD TO VARIABLE artran_open_all");
                                //END
                            }
                            //END
                        }
                        if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                        {
                            TRate = (decimal?)((sQLUtil.SQLEqual(UseHistRate, 1) == true ? ArtranExchRate : null));
                        }
                        else
                        {
                            //BEGIN
                            TRate = null;
                            Amount = 1.0M;
                            ToCustInvDate = convertToUtil.ToDateTime((sQLUtil.SQLEqual(UseHistRate, 1) == true ? ArtranInvDate : null));
                            //END
                        }
                        TcAmtTran = 0.0M;
                        CustAmtTran = 0.0M;
                        if (sQLUtil.SQLEqual(TranslateForAging, 1) == true)
                        {
                            if (sQLUtil.SQLNotEqual(ArtranCurrCode, ParmsCurrCode) == true)
                            {
                                //BEGIN
                                #region CRUD ExecuteMethodCall
                                //Please Generate the bounce for this stored procedure: CurrCnvtSp
                                var CurrCnvt5 = this.iCurrCnvt.CurrCnvtSp(
                                    CurrCode: ArtranCurrCode,
                                    FromDomestic: 0,
                                    UseBuyRate: 0,
                                    RoundResult: 1,
                                    Date: null,
                                    TRate: TRate,
                                    Infobar: Infobar,
                                    Amount1: TmpAmount,
                                    Result1: TcAmtTran,
                                    Amount2: ArtranAmount,
                                    Result2: DomArtdBalAmount,
                                    Site: PSite,
                                    DomCurrCode: ParmsCurrCode);
                                Severity = CurrCnvt5.ReturnCode;
                                TRate = CurrCnvt5.TRate;
                                Infobar = CurrCnvt5.Infobar;
                                TcAmtTran = CurrCnvt5.Result1;
                                DomArtdBalAmount = CurrCnvt5.Result2;

                                #endregion ExecuteMethodCall
                                LogTiming("AGING CURSOR CurrCnvtSp");
                                CustAmtTran = TmpAmount;
                                //END
                            }
                            else
                            {
                                //BEGIN
                                TcAmtTran = TmpAmount;
                                CustAmtTran = TmpAmount;
                                DomArtdBalAmount = ArtranAmount;
                                //END
                            }
                        }
                        else
                        {
                            #region CRUD ExecuteMethodCall
                            //Please Generate the bounce for this stored procedure: TwoCurrCnvtSp
                            var TwoCurrCnvt2 = this.i2CurrCnvt.TwoCurrCnvtSp(
                                FromCurrCode: ArtranCurrCode,
                                UseBuyRate: 0,
                                RoundResult: 1,
                                Date: ToCustInvDate,
                                TRate: TRate,
                                Infobar: Infobar,
                                ToCurrCode: CustaddrCurrCode,
                                Amount1: TmpAmount,
                                Result1: CustAmtTran);
                            Severity = TwoCurrCnvt2.ReturnCode;
                            TRate = TwoCurrCnvt2.TRate;
                            Infobar = TwoCurrCnvt2.Infobar;
                            CustAmtTran = TwoCurrCnvt2.Result1;
                            #endregion ExecuteMethodCall

                            LogTiming("AGING CURSOR TwoCurrCnvtSp");

                            TcAmtTran = TmpAmount;
                            DomArtdBalAmount = ArtranAmount;
                        }
                        TcAmtTAmt = convertToUtil.ToDecimal((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "I"), 0) == true && sQLUtil.SQLEqual(usemultiduedate, 0) == true ? TtInvInvBal :
                        sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "ID"), 0) == true && sQLUtil.SQLEqual(usemultiduedate, 1) == true ? DomArtdBalAmount :
                        sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "CP"), 0) == true ? (-TcAmtTran) : TcAmtTran));
                        TcTotBal = convertToUtil.ToDecimal((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "CP"), 0) == true ? (-TcAmtTran) : TcAmtTran));
                        TDate = convertToUtil.ToDateTime((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                            ArtranType,
                            "CP"), 0) == true ? null : ArtranInvDate));
                        NDays = convertToUtil.ToInt32(dateTimeUtil.DateDiff("Day", (sQLUtil.SQLEqual(PInvDue, "D") == true ? ArtranDueDate : ArtranInvDate), PAgingDate));
                        I = (int?)((sQLUtil.SQLGreaterThan(NDays, PAgeDays4) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 5) == true && sQLUtil.SQLEqual(TLastBucket, 5) == true ? 5 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays3) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 4) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 4) == true ? 4 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays2) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 3) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 3) == true ? 3 : (sQLUtil.SQLGreaterThan(NDays, PAgeDays1) == true && sQLUtil.SQLLessThanOrEqual(TFirstBucket, 2) == true && sQLUtil.SQLGreaterThanOrEqual(TLastBucket, 2) == true ? 2 : (sQLUtil.SQLGreaterThan(TFirstBucket, 1) == true ? TFirstBucket : 1))))));
                        if (existsChecker.Exists(tableName: "#tv_artran_all",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("apply_to_inv_num = {0} AND ({2} NOT IN ('I', 'F', 'D') OR ({2} = 'D' AND {1} = 0)) AND Type = 'I'", ArtranApplyToInvNum, usemultiduedate, ArtranType))
                        )
                        {
                            TcAmtTemp = 0;
                        }
                        else
                        {
                            TcAmtTemp = TcAmtTAmt;
                        }
                        if (sQLUtil.SQLEqual(usemultiduedate, 1) == true)
                        {
                            //BEGIN
                            if (sQLUtil.SQLNotEqual(ArtranType, "I") == true)
                            {
                                FirstArtranInvSeq1 = 0;
                            }
                            else
                            {
                                FirstArtranInvSeq1 = 1;
                            }
                        }

                        if (FirstArtranInvSeq1 == 1 || iIsInteger.IsIntegerFn(ArtranApplyToInvNum) == 1 && convertToUtil.ToInt64(ArtranApplyToInvNum) == 0)
                        {
                            //BEGIN
                            FirstArtranInvSeq1 = 0;
                            TcAmtTAmt = convertToUtil.ToDecimal(((sQLUtil.SQLEqual(ArtranInvNum, "0") == true && sQLUtil.SQLEqual(TranslateToDom, 1) == true && sQLUtil.SQLEqual(TForBal, 0) == true) ? 0 : TcAmtTAmt));
                            TcAmtTemp = TcAmtTAmt;
                            TcTotMinorBal = (decimal?)(TcTotMinorBal + TcAmtTAmt);
                            //END
                        }
                        if (sQLUtil.SQLBool(sQLUtil.SQLOr(sQLUtil.SQLOr(sQLUtil.SQLEqual(ArtranType, "I"), sQLUtil.SQLEqual(ArtranType, "C")), sQLUtil.SQLEqual(ArtranType, "D"))))
                        {
                            StdCh = ArtranInvNum;
                        }
                        else
                        {
                            if (iIsInteger.IsIntegerFn(ArtranApplyToInvNum) != 1 || iIsInteger.IsIntegerFn(ArtranApplyToInvNum) == 1 && convertToUtil.ToInt64(ArtranApplyToInvNum) > 0)
                            {
                                //BEGIN
                                StdCh = ArtranInvNum;
                                //END
                            }
                            else
                            {
                                #region CRUD ExecuteMethodCall
                                //Please Generate the bounce for this stored procedure: GetCodeSp
                                var GetCode = this.iGetCode.GetCodeSp(
                                    PClass: "artran.inv_num",
                                    PCode: ArtranApplyToInvNum,
                                    PDesc: StdCh);
                                StdCh = GetCode.PDesc;

                                #endregion ExecuteMethodCall

                                LogTiming("AGING CURSOR GetCodeSp");
                            }
                        }
                        TInvSeq = Convert.ToString(ArtranInvSeq);
                        if (StdCh == null)
                        {
                            StdCh = "0";
                        }
                        ApplyToInv = ArtranApplyToInvNum;
                        if (sQLUtil.SQLBool(sQLUtil.SQLEqual(ArtranType, "I")))
                        {
                            StdCh1 = ArtranApplyToInvNum;
                        }
                        else
                        {
                            if (iIsInteger.IsIntegerFn(ArtranApplyToInvNum) != 1 || iIsInteger.IsIntegerFn(ArtranApplyToInvNum) == 1 && convertToUtil.ToInt64(ArtranApplyToInvNum) > 0)
                            {
                                //BEGIN
                                StdCh1 = ArtranApplyToInvNum;
                                //END
                            }
                            else
                            {
                                #region CRUD ExecuteMethodCall
                                //Please Generate the bounce for this stored procedure: GetCodeSp
                                var GetCode1 = this.iGetCode.GetCodeSp(
                                    PClass: "artran.inv_num",
                                    PCode: ArtranApplyToInvNum,
                                    PDesc: StdCh1);
                                StdCh1 = GetCode1.PDesc;

                                #endregion ExecuteMethodCall
                                LogTiming("AGING CURSOR GetCodeSp");
                            }
                        }
                        //BEGIN
                        if (sQLUtil.SQLEqual(ConsolidateCustomers, 1) == true)
                        {
                            //BEGIN
                            if (sQLUtil.SQLEqual(AgingReport, 1) == true)
                            {
                                #region InsertNonTrigger
                                var AccountsReceivableAging1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                    targetTableName: "#AccountsReceivableAging",
                                    targetColumns: new List<string>()
                                     { "TcSortCurrCode",
                                        "CurrencyFormat",
                                        "CurrencyPlaces",
                                        "TotCurrencyFormat",
                                        "TotCurrencyPlaces",
                                        "TcSortBy",
                                        "TcCustNum",
                                        "TcCustName",
                                        "TcCity",
                                        "TcState",
                                        "TcSite",
                                        "TcSiteName",
                                        "TcContact",
                                        "TcPhone",
                                        "TcTempTermsCode",
                                        "TcCustType",
                                        "TcCreditLimit",
                                        "TcCredhold",
                                        "TcCurrCode",
                                        "TcArtranType",
                                        "StdCh",
                                        "TcArtranInvSeq",
                                        "TcArtranDate",
                                        "TcArtranDueDate",
                                        "TcAmtTran",
                                        "TcArtranExchRate",
                                        "TcArtranCurrCode",
                                        "CustAmtTran",
                                        "TcAmtTemp",
                                        "PAgeDesc",
                                        "PAgeDescNum",
                                        "TcApprovalStatus",
                                        "StdCh1",
                                        "TcCustCurrCode",
                                        "OrderByDate",
                                        "ApplyToInv",
                                        "TcArTranIvDate",
                                        "TcArTranChkSeq",
                                        "InvNum",
                                        "TotalDays",
                                        "THPaymentNumber" },
                                    valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        {"TcSortCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PSortByCurr, 0) == true ? null : CustaddrCurrCode))},
                                        {"CurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyFormat)},
                                        {"CurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyPlaces)},
                                        {"TotCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyFormat)},
                                        {"TotCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyPlaces)},
                                        {"TcSortBy", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PArSortBy, "B") == true ? CustaddrCustNum : (sQLUtil.SQLEqual(PArSortBy, "A") == true ? CustaddrName : CustomerSlsman)))},
                                        {"TcCustNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCustNum)},
                                        {"TcCustName", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrName)},
                                        {"TcCity", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCity)},
                                        {"TcState", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrState)},
                                        {"TcSite", collectionNonTriggerInsertRequestFactory.Clause("{0}",PSite)},
                                        {"TcSiteName", collectionNonTriggerInsertRequestFactory.Clause("site.Site_name")},
                                        {"TcContact", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerContact__3 : ""))},
                                        {"TcPhone", collectionNonTriggerInsertRequestFactory.Clause("{0}", (CustomerRowPointer != null ? CustomerPhone__3 : ""))},
                                        {"TcTempTermsCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? TempTermsCode : ""))},
                                        {"TcCustType", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerCustType : ""))},
                                        {"TcCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("{0}",TcAmtDCreditLimit)},
                                        {"TcCredhold", collectionNonTriggerInsertRequestFactory.Clause("{0}",TCredhold)},
                                        {"TcCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyCode)},
                                        {"TcArtranType", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranType)},
                                        {"StdCh", collectionNonTriggerInsertRequestFactory.Clause("{0}",StdCh)},
                                        {"TcArtranInvSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}",TInvSeq)},
                                        {"TcArtranDate", collectionNonTriggerInsertRequestFactory.Clause("{0}",TDate)},
                                        {"TcArtranDueDate", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranDueDate)},
                                        {"TcAmtTran", collectionNonTriggerInsertRequestFactory.Clause("{0}",((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                        ArtranType,
                                        "CP"), 0) == true ? (-TcAmtTran) : TcAmtTran)))},
                                        {"TcArtranExchRate", collectionNonTriggerInsertRequestFactory.Clause("{0}",TRate)},
                                        {"TcArtranCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranCurrCode)},
                                        {"CustAmtTran", collectionNonTriggerInsertRequestFactory.Clause("{0}", ((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                        ArtranType,
                                        "CP"), 0) == true ? (-CustAmtTran) : CustAmtTran)))},
                                        {"TcAmtTemp", collectionNonTriggerInsertRequestFactory.Clause("{0}",TcAmtTemp)},
                                        {"PAgeDesc", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(I, 1) == true ? PAgeDesc1 :
                                    sQLUtil.SQLEqual(I, 2) == true ? PAgeDesc2 :
                                    sQLUtil.SQLEqual(I, 3) == true ? PAgeDesc3 :
                                    sQLUtil.SQLEqual(I, 4) == true ? PAgeDesc4 :
                                    sQLUtil.SQLEqual(I, 5) == true ? PAgeDesc5 : null))},
                                        {"PAgeDescNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",I)},
                                        {"TcApprovalStatus", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(ArtranType, "I") == true && sQLUtil.SQLEqual(CustRevDay, 1) == true ? ArtranApprovalStatus : null))},
                                        {"StdCh1", collectionNonTriggerInsertRequestFactory.Clause("{0}",StdCh1)},
                                        {"TcCustCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCurrCode)},
                                        {"OrderByDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"ApplyToInv", collectionNonTriggerInsertRequestFactory.Clause("{0}",ApplyToInv)},
                                        {"TcArTranIvDate", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranInvDate)},
                                        {"TcArTranChkSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}", ArtranCheckSeq)},
                                        {"InvNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranInvNum)},
                                        {"TotalDays", collectionNonTriggerInsertRequestFactory.Clause("{0}",NDays)},
                                        {"THPaymentNumber", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranPaymentNumber)},
                                    },
                                    fromClause: collectionNonTriggerInsertRequestFactory.Clause("site"),
                                    whereClause: collectionNonTriggerInsertRequestFactory.Clause("site = {0}", PSite),
                                    orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                    );
                                this.appDB.InsertWithoutTrigger(AccountsReceivableAging1NonTriggerInsertRequest);
                                #endregion InsertNonTrigger

                                LogTiming("AGING CURSOR INSERT TO #AccountsReceivableAging - Refactored");

                            }
                            FirstOfCustomer = 0;
                        }
                        else
                        {
                            //BEGIN
                            if (sQLUtil.SQLEqual(TGrand, 1) == true)
                            {
                                //BEGIN
                                if (sQLUtil.SQLEqual(AgingReport, 1) == true)
                                {
                                    #region InsertNonTrigger
                                    var AccountsReceivableAging1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                        targetTableName: "#AccountsReceivableAging",
                                        targetColumns: new List<string>()
                                         { "TcSortCurrCode",
                                        "CurrencyFormat",
                                        "CurrencyPlaces",
                                        "TotCurrencyFormat",
                                        "TotCurrencyPlaces",
                                        "TcSortBy",
                                        "TcCustNum",
                                        "TcCustName",
                                        "TcCity",
                                        "TcState",
                                        "TcSite",
                                        "TcSiteName",
                                        "TcContact",
                                        "TcPhone",
                                        "TcTempTermsCode",
                                        "TcCustType",
                                        "TcCreditLimit",
                                        "TcCredhold",
                                        "TcCurrCode",
                                        "TcArtranType",
                                        "StdCh",
                                        "TcArtranInvSeq",
                                        "TcArtranDate",
                                        "TcArtranDueDate",
                                        "TcAmtTran",
                                        "TcArtranExchRate",
                                        "TcArtranCurrCode",
                                        "CustAmtTran",
                                        "TcAmtTemp",
                                        "PAgeDesc",
                                        "PAgeDescNum",
                                        "TcApprovalStatus",
                                        "StdCh1",
                                        "TcCustCurrCode",
                                        "OrderByDate",
                                        "ApplyToInv",
                                        "TcArTranIvDate",
                                        "TcArTranChkSeq",
                                        "InvNum",
                                        "TotalDays",
                                        "THPaymentNumber" },
                                        valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                        {
                                        {"TcSortCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PSortByCurr, 0) == true ? null : CustaddrCurrCode))},
                                        {"CurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyFormat)},
                                        {"CurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyPlaces)},
                                        {"TotCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyFormat)},
                                        {"TotCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyPlaces)},
                                        {"TcSortBy", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PArSortBy, "B") == true ? CustaddrCustNum : (sQLUtil.SQLEqual(PArSortBy, "A") == true ? CustaddrName : CustomerSlsman)))},
                                        {"TcCustNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCustNum)},
                                        {"TcCustName", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrName)},
                                        {"TcCity", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCity)},
                                        {"TcState", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrState)},
                                        {"TcSite", collectionNonTriggerInsertRequestFactory.Clause("{0}",PSite)},
                                        {"TcSiteName", collectionNonTriggerInsertRequestFactory.Clause("site.Site_name")},
                                        {"TcContact", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerContact__3 : ""))},
                                        {"TcPhone", collectionNonTriggerInsertRequestFactory.Clause("{0}", (CustomerRowPointer != null ? CustomerPhone__3 : ""))},
                                        {"TcTempTermsCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? TempTermsCode : ""))},
                                        {"TcCustType", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerCustType : ""))},
                                        {"TcCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("{0}",TcAmtDCreditLimit)},
                                        {"TcCredhold", collectionNonTriggerInsertRequestFactory.Clause("{0}",TCredhold)},
                                        {"TcCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyCode)},
                                        {"TcArtranType", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranType)},
                                        {"StdCh", collectionNonTriggerInsertRequestFactory.Clause("{0}",StdCh)},
                                        {"TcArtranInvSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}",TInvSeq)},
                                        {"TcArtranDate", collectionNonTriggerInsertRequestFactory.Clause("{0}",TDate)},
                                        {"TcArtranDueDate", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranDueDate)},
                                        {"TcAmtTran", collectionNonTriggerInsertRequestFactory.Clause("{0}",((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                        ArtranType,
                                        "CP"), 0) == true ? (-TcAmtTran) : TcAmtTran)))},
                                        {"TcArtranExchRate", collectionNonTriggerInsertRequestFactory.Clause("{0}",TRate)},
                                        {"TcArtranCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranCurrCode)},
                                        {"CustAmtTran", collectionNonTriggerInsertRequestFactory.Clause("{0}", ((sQLUtil.SQLNotEqual(stringUtil.CharIndex(
                                        ArtranType,
                                        "CP"), 0) == true ? (-CustAmtTran) : CustAmtTran)))},
                                        {"TcAmtTemp", collectionNonTriggerInsertRequestFactory.Clause("{0}",TcAmtTemp)},
                                        {"PAgeDesc", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(I, 1) == true ? PAgeDesc1 :
                                    sQLUtil.SQLEqual(I, 2) == true ? PAgeDesc2 :
                                    sQLUtil.SQLEqual(I, 3) == true ? PAgeDesc3 :
                                    sQLUtil.SQLEqual(I, 4) == true ? PAgeDesc4 :
                                    sQLUtil.SQLEqual(I, 5) == true ? PAgeDesc5 : null))},
                                        {"PAgeDescNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",I)},
                                        {"TcApprovalStatus", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(ArtranType, "I") == true && sQLUtil.SQLEqual(CustRevDay, 1) == true ? ArtranApprovalStatus : null))},
                                        {"StdCh1", collectionNonTriggerInsertRequestFactory.Clause("{0}",StdCh1)},
                                        {"TcCustCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCurrCode)},
                                        {"OrderByDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"ApplyToInv", collectionNonTriggerInsertRequestFactory.Clause("{0}",ApplyToInv)},
                                        {"TcArTranIvDate", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranInvDate)},
                                        {"TcArTranChkSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}", ArtranCheckSeq)},
                                        {"InvNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranInvNum)},
                                        {"TotalDays", collectionNonTriggerInsertRequestFactory.Clause("{0}",NDays)},
                                        {"THPaymentNumber", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranPaymentNumber)},
                                        },
                                        fromClause: collectionNonTriggerInsertRequestFactory.Clause("site"),
                                        whereClause: collectionNonTriggerInsertRequestFactory.Clause("site = {0}", PSite),
                                        orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                        );
                                    this.appDB.InsertWithoutTrigger(AccountsReceivableAging1NonTriggerInsertRequest);
                                    #endregion InsertNonTrigger

                                    LogTiming("AGING CURSOR INSERT TO #AccountsReceivableAging");
                                }
                            }
                        }

                        //END
                        if (TranslateToDom == 1 && UseHistRate == 1 && PPrOpenItem != "N" &&
                        (iIsInteger.IsIntegerFn(ArtranInvNum) != 1 || iIsInteger.IsIntegerFn(ArtranInvNum) == 1 && Convert.ToInt64(ArtranInvNum) > 0)
                        && stringUtil.In(ArtranType, new object[] { "C", "P", "D" }))
                        {
                            //BEGIN
                            TtArtrancInvSeq = null;
                            TtArtrancExchRate = null;
                            TtArtrancGainLoss = null;

                            #region CRUD LoadToVariable
                            var artrancASartranc2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                                {
                                    {_TtArtrancInvSeq,"artranc.InvSeq"},
                                    {_TtArtrancExchRate,"artranc.ExchRate"},
                                    {_TtArtrancGainLoss,"artranc.GainLoss"},
                                },
                                loadForChange: false,
                        lockingType: LockingType.None,
                                //maximumRows: 1,
                                tableName: "#artranc AS artranc",
                                fromClause: collectionLoadRequestFactory.Clause(""),
                                whereClause: collectionLoadRequestFactory.Clause("artranc.CustNum = {1} AND artranc.InvNum = {2} AND artranc.InvSeq = {3} AND artranc.CheckSeq = {0}", ArtranCheckSeq, ArtranCustNum, ArtranInvNum, ArtranInvSeq),
                                orderByClause: collectionLoadRequestFactory.Clause(""));
                            var artrancASartranc2LoadResponse = this.appDB.Load(artrancASartranc2LoadRequest);
                            if (artrancASartranc2LoadResponse.Items.Count > 0)
                            {
                                TtArtrancInvSeq = _TtArtrancInvSeq;
                                TtArtrancExchRate = _TtArtrancExchRate;
                                TtArtrancGainLoss = _TtArtrancGainLoss;
                            }
                            #endregion  LoadToVariable

                            LogTiming("AGING CURSOR LOAD TO VAR #artran");

                            if ((sQLUtil.SQLGreaterThan(artrancASartranc2LoadResponse.Items.Count, 0) == true && sQLUtil.SQLNotEqual(TtArtrancGainLoss, 0) == true) && (sQLUtil.SQLNotEqual(TRate1, TtArtrancExchRate) == true || sQLUtil.SQLNotEqual(TForBal, 0) == true))
                            {
                                //BEGIN
                                if (sQLUtil.SQLGreaterThan(TtArtrancGainLoss, 0) == true)
                                {
                                    TCurrText = this.iStringOf.StringOfFn("@!CurrencyGain");
                                }
                                else
                                {
                                    TCurrText = this.iStringOf.StringOfFn("@!CurrencyLoss");
                                }
                                if (sQLUtil.SQLEqual(AgingReport, 1) == true)
                                {
                                    #region InsertNonTrigger
                                    var AccountsReceivableAging1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                        targetTableName: "#AccountsReceivableAging",
                                        targetColumns: new List<string>()
                                         { "TcSortCurrCode",
                                            "CurrencyFormat",
                                            "CurrencyPlaces",
                                            "TotCurrencyFormat",
                                            "TotCurrencyPlaces",
                                            "TcSortBy",
                                            "TcCustNum",
                                            "TcCustName",
                                            "TcCity",
                                            "TcState",
                                            "TcSite",
                                            "TcSiteName",
                                            "TcContact",
                                            "TcPhone",
                                            "TcTempTermsCode",
                                            "TcCustType",
                                            "TcCreditLimit",
                                            "TcCredhold",
                                            "TcCurrCode",
                                            "TcArtranType",
                                            "StdCh",
                                            "TcArtranInvSeq",
                                            "TcArtranDate",
                                            "TcArtranDueDate",
                                            "TcAmtTran",
                                            "TcArtranExchRate",
                                            "TcArtranCurrCode",
                                            "CustAmtTran",
                                            "TcAmtTemp",
                                            "PAgeDesc",
                                            "PAgeDescNum",
                                            "TcApprovalStatus",
                                            "StdCh1",
                                            "TcCustCurrCode",
                                            "OrderByDate",
                                            "ApplyToInv",
                                            "TcArTranIvDate",
                                            "TcArTranChkSeq",
                                            "InvNum",
                                            "TotalDays",
                                            "THPaymentNumber" },
                                        valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                        {
                                        {"TcSortCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PSortByCurr, 0) == true ? null : CustaddrCurrCode))},
                                        {"CurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyFormat)},
                                        {"CurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyPlaces)},
                                        {"TotCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyFormat)},
                                        {"TotCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyPlaces)},
                                        {"TcSortBy", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PArSortBy, "B") == true ? CustaddrCustNum : (sQLUtil.SQLEqual(PArSortBy, "A") == true ? CustaddrName : CustomerSlsman)))},
                                        {"TcCustNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCustNum)},
                                        {"TcCustName", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrName)},
                                        {"TcCity", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCity)},
                                        {"TcState", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrState)},
                                        {"TcSite", collectionNonTriggerInsertRequestFactory.Clause("{0}",PSite)},
                                        {"TcSiteName", collectionNonTriggerInsertRequestFactory.Clause("site.Site_name")},
                                        {"TcContact", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerContact__3 : ""))},
                                        {"TcPhone", collectionNonTriggerInsertRequestFactory.Clause("{0}", (CustomerRowPointer != null ? CustomerPhone__3 : ""))},
                                        {"TcTempTermsCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? TempTermsCode : ""))},
                                        {"TcCustType", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerCustType : ""))},
                                        {"TcCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("{0}",TcAmtDCreditLimit)},
                                        {"TcCredhold", collectionNonTriggerInsertRequestFactory.Clause("{0}",TCredhold)},
                                        {"TcCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyCode)},
                                        {"TcArtranType", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"StdCh", collectionNonTriggerInsertRequestFactory.Clause("{0}",TCurrText)},
                                        {"TcArtranInvSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}",TInvSeq)},
                                        {"TcArtranDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcArtranDueDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcAmtTran", collectionNonTriggerInsertRequestFactory.Clause("{0}",TtArtrancGainLoss)},
                                        {"TcArtranExchRate", collectionNonTriggerInsertRequestFactory.Clause("{0}",TRate)},
                                        {"TcArtranCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranCurrCode)},
                                        {"CustAmtTran", collectionNonTriggerInsertRequestFactory.Clause("0.0")},
                                        {"TcAmtTemp", collectionNonTriggerInsertRequestFactory.Clause("{0}", (sQLUtil.SQLNotEqual(TcAmtTemp, 0) == true ? TcAmtTemp : 0))},
                                        {"PAgeDesc", collectionNonTriggerInsertRequestFactory.Clause("{0}", (sQLUtil.SQLEqual(I, 1) == true ? PAgeDesc1 :
                                        sQLUtil.SQLEqual(I, 2) == true ? PAgeDesc2 :
                                        sQLUtil.SQLEqual(I, 3) == true ? PAgeDesc3 :
                                        sQLUtil.SQLEqual(I, 4) == true ? PAgeDesc4 :
                                        sQLUtil.SQLEqual(I, 5) == true ? PAgeDesc5 : null))},
                                        {"PAgeDescNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",I)},
                                        {"TcApprovalStatus", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"StdCh1", collectionNonTriggerInsertRequestFactory.Clause("{0}",StdCh1)},
                                        {"TcCustCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCurrCode)},
                                        {"OrderByDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"ApplyToInv", collectionNonTriggerInsertRequestFactory.Clause("{0}",ApplyToInv)},
                                        {"TcArTranIvDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcArTranChkSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}", ArtranCheckSeq)},
                                        {"InvNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranInvNum)},
                                        {"TotalDays", collectionNonTriggerInsertRequestFactory.Clause("{0}",NDays)},
                                        {"THPaymentNumber", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranPaymentNumber)},
                                        },
                                        fromClause: collectionNonTriggerInsertRequestFactory.Clause("site"),
                                        whereClause: collectionNonTriggerInsertRequestFactory.Clause("site = {0}", PSite),
                                        orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                        );
                                    this.appDB.InsertWithoutTrigger(AccountsReceivableAging1NonTriggerInsertRequest);
                                    #endregion InsertNonTrigger

                                    LogTiming("AGING CURSOR INSERT TO #AccountsReceivableAging");
                                }
                            }
                        }
                    }
                    curArtranLoadResponseForCursor = null;
                    //Deallocate Cursor @curArtran
                    if (TranslateToDom == 1 && UseHistRate == 1 && PPrOpenItem != "N" &&
                        (iIsInteger.IsIntegerFn(ArtranInvNum) != 1 || iIsInteger.IsIntegerFn(ArtranInvNum) == 1 && Convert.ToInt64(ArtranInvNum) >= 0))
                    {
                        //BEGIN
                        TtArtrancInvSeq = null;
                        TtArtrancExchRate = null;
                        TtArtrancGainLoss = null;

                        #region CRUD LoadToVariable
                        var artrancASartranc3LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                            {
                                {_TtArtrancInvSeq,"artranc.InvSeq"},
                                {_TtArtrancExchRate,"artranc.ExchRate"},
                                {_TtArtrancGainLoss,"artranc.GainLoss"},
                            },
                            loadForChange: false,
                        lockingType: LockingType.None,
                            //maximumRows: 1,
                            tableName: "#artranc AS artranc",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause("GainLoss <> 0 AND InvSeq = 999999999"),
                            orderByClause: collectionLoadRequestFactory.Clause(""));
                        var artrancASartranc3LoadResponse = this.appDB.Load(artrancASartranc3LoadRequest);
                        if (artrancASartranc3LoadResponse.Items.Count > 0)
                        {
                            TtArtrancInvSeq = _TtArtrancInvSeq;
                            TtArtrancExchRate = _TtArtrancExchRate;
                            TtArtrancGainLoss = _TtArtrancGainLoss;
                        }
                        #endregion  LoadToVariable

                        LogTiming("AGING LOAD TO VAR #artranc");

                        if (sQLUtil.SQLGreaterThan(artrancASartranc3LoadResponse.Items.Count, 0) == true && sQLUtil.SQLNotEqual(IncludeEstCurrGainLossAmtsInTotals, 0) == true)
                        {
                            //BEGIN
                            if (sQLUtil.SQLGreaterThan(TtArtrancGainLoss, 0) == true)
                            {
                                TCurrText = this.iStringOf.StringOfFn("@!EstCurrencyGain");
                            }
                            else
                            {
                                TCurrText = this.iStringOf.StringOfFn("@!EstCurrencyLoss");
                            }
                            if (sQLUtil.SQLEqual(AgingReport, 1) == true)
                            {

                                #region InsertNonTrigger
                                var AccountsReceivableAging1NonTriggerInsertRequest = collectionNonTriggerInsertRequestFactory.SQLInsert(
                                    targetTableName: "#AccountsReceivableAging",
                                    targetColumns: new List<string>()
                                     { "TcSortCurrCode",
                                            "CurrencyFormat",
                                            "CurrencyPlaces",
                                            "TotCurrencyFormat",
                                            "TotCurrencyPlaces",
                                            "TcSortBy",
                                            "TcCustNum",
                                            "TcCustName",
                                            "TcCity",
                                            "TcState",
                                            "TcSite",
                                            "TcSiteName",
                                            "TcContact",
                                            "TcPhone",
                                            "TcTempTermsCode",
                                            "TcCustType",
                                            "TcCreditLimit",
                                            "TcCredhold",
                                            "TcCurrCode",
                                            "TcArtranType",
                                            "StdCh",
                                            "TcArtranInvSeq",
                                            "TcArtranDate",
                                            "TcArtranDueDate",
                                            "TcAmtTran",
                                            "TcArtranExchRate",
                                            "TcArtranCurrCode",
                                            "CustAmtTran",
                                            "TcAmtTemp",
                                            "PAgeDesc",
                                            "PAgeDescNum",
                                            "TcApprovalStatus",
                                            "StdCh1",
                                            "TcCustCurrCode",
                                            "OrderByDate",
                                            "ApplyToInv",
                                            "TcArTranIvDate",
                                            "TcArTranChkSeq",
                                            "InvNum",
                                            "TotalDays",
                                            "THPaymentNumber" },
                                    valuesByExpressionToAssign: new Dictionary<string, IParameterizedCommand>()
                                    {
                                        {"TcSortCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PSortByCurr, 0) == true ? null : CustaddrCurrCode))},
                                        {"CurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyFormat)},
                                        {"CurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyPlaces)},
                                        {"TotCurrencyFormat", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyFormat)},
                                        {"TotCurrencyPlaces", collectionNonTriggerInsertRequestFactory.Clause("{0}",TotalCurrencyPlaces)},
                                        {"TcSortBy", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(PArSortBy, "B") == true ? CustaddrCustNum : (sQLUtil.SQLEqual(PArSortBy, "A") == true ? CustaddrName : CustomerSlsman)))},
                                        {"TcCustNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCustNum)},
                                        {"TcCustName", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrName)},
                                        {"TcCity", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCity)},
                                        {"TcState", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrState)},
                                        {"TcSite", collectionNonTriggerInsertRequestFactory.Clause("{0}",PSite)},
                                        {"TcSiteName", collectionNonTriggerInsertRequestFactory.Clause("site.Site_name")},
                                        {"TcContact", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerContact__3 : ""))},
                                        {"TcPhone", collectionNonTriggerInsertRequestFactory.Clause("{0}", (CustomerRowPointer != null ? CustomerPhone__3 : ""))},
                                        {"TcTempTermsCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? TempTermsCode : ""))},
                                        {"TcCustType", collectionNonTriggerInsertRequestFactory.Clause("{0}",(CustomerRowPointer != null ? CustomerCustType : ""))},
                                        {"TcCreditLimit", collectionNonTriggerInsertRequestFactory.Clause("{0}",TcAmtDCreditLimit)},
                                        {"TcCredhold", collectionNonTriggerInsertRequestFactory.Clause("{0}",TCredhold)},
                                        {"TcCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CurrencyCode)},
                                        {"TcArtranType", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"StdCh", collectionNonTriggerInsertRequestFactory.Clause("{0}",TCurrText)},
                                        {"TcArtranInvSeq", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcArtranDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcArtranDueDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcAmtTran", collectionNonTriggerInsertRequestFactory.Clause("{0}",TtArtrancGainLoss)},
                                        {"TcArtranExchRate", collectionNonTriggerInsertRequestFactory.Clause("{0}",TtArtrancExchRate)},
                                        {"TcArtranCurrCode", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"CustAmtTran", collectionNonTriggerInsertRequestFactory.Clause("0.0")},
                                        {"TcAmtTemp", collectionNonTriggerInsertRequestFactory.Clause("{0}", (sQLUtil.SQLEqual(IncludeEstCurrGainLossAmtsInTotals, 1) == true && sQLUtil.SQLNotEqual(TtArtrancGainLoss, 0) == true ? TtArtrancGainLoss : 0.0M))},
                                        {"PAgeDesc", collectionNonTriggerInsertRequestFactory.Clause("{0}", (sQLUtil.SQLEqual(IncludeEstCurrGainLossAmtsInTotals, 1) == true ? (sQLUtil.SQLEqual(I, 1) == true ? PAgeDesc1 :
                                            sQLUtil.SQLEqual(I, 2) == true ? PAgeDesc2 :
                                            sQLUtil.SQLEqual(I, 3) == true ? PAgeDesc3 :
                                            sQLUtil.SQLEqual(I, 4) == true ? PAgeDesc4 :
                                            sQLUtil.SQLEqual(I, 5) == true ? PAgeDesc5 : null) : null))},
                                        {"PAgeDescNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",(sQLUtil.SQLEqual(IncludeEstCurrGainLossAmtsInTotals, 1) == true ? I : null))},
                                        {"TcApprovalStatus", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"StdCh1", collectionNonTriggerInsertRequestFactory.Clause("{0}",StdCh1)},
                                        {"TcCustCurrCode", collectionNonTriggerInsertRequestFactory.Clause("{0}",CustaddrCurrCode)},
                                        {"OrderByDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"ApplyToInv", collectionNonTriggerInsertRequestFactory.Clause("{0}",ApplyToInv)},
                                        {"TcArTranIvDate", collectionNonTriggerInsertRequestFactory.Clause("NULL")},
                                        {"TcArTranChkSeq", collectionNonTriggerInsertRequestFactory.Clause("{0}", ArtranCheckSeq)},
                                        {"InvNum", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranInvNum)},
                                        {"TotalDays", collectionNonTriggerInsertRequestFactory.Clause("{0}",NDays)},
                                        {"THPaymentNumber", collectionNonTriggerInsertRequestFactory.Clause("{0}",ArtranPaymentNumber)},
                                    },
                                    fromClause: collectionNonTriggerInsertRequestFactory.Clause("site"),
                                    whereClause: collectionNonTriggerInsertRequestFactory.Clause("site = {0}", PSite),
                                    orderByClause: collectionNonTriggerInsertRequestFactory.Clause("")
                                    );
                                this.appDB.InsertWithoutTrigger(AccountsReceivableAging1NonTriggerInsertRequest);
                                #endregion InsertNonTrigger

                                LogTiming("AGING CURSOR INSERT TO #AccountsReceivableAging");
                            }
                        }
                    }
                    TTotal = 1;
                }
                //Deallocate Cursor curTtInv
                if (sQLUtil.SQLBool(sQLUtil.SQLAnd(sQLUtil.SQLAnd(sQLUtil.SQLEqual(TTotal, 0), sQLUtil.SQLEqual(PPrZeroBal, 1)), sQLUtil.SQLNot(existsChecker.Exists(tableName: "#tv_tt_inv",
                            fromClause: collectionLoadRequestFactory.Clause(""),
                            whereClause: collectionLoadRequestFactory.Clause(""))
                        ))))
                {
                    TTotal = 1;
                }

                #region DeleteNonTrigger
                var tv_tt_invNonTriggerDeleteRequest = collectionNonTriggerDeleteRequestFactory.SQLDelete(
                    tableName: "#tv_tt_inv",
                    fromClause: collectionNonTriggerUpdateRequestFactory.Clause(""),
                    whereClause: collectionNonTriggerUpdateRequestFactory.Clause("")
                    );

                this.appDB.DeleteWithoutTrigger(tv_tt_invNonTriggerDeleteRequest);
                #endregion DeleteNonTrigger

                LogTiming("AGING END");
                return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
            }
            finally
            {
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_tt_inv") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #tv_tt_inv");
                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_artran_all") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #tv_artran_all");
                }
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "tempdb..#tv_FinList") != null)
                {
                    this.sQLExpressionExecutor.Execute("DROP TABLE #tv_FinList");
                }

                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
        }

        public (int? ReturnCode,
            int? TGrand,
            int? FirstOfCustomer,
            int? UseHistRate,
            int? TranslateForAging,
            string SiteLabel,
            int? TTransDom,
            int? AnyTrans)
        AltExtGen_AgingSp(
            string AltExtGenSp,
            int? ConsolidateCustomers,
            string PSite,
            string PPrOpenItem,
            DateTime? PAgingDate,
            int? PSumToCorp,
            string PSSlsman,
            string PESlsman,
            string PStateCycle,
            string PCreditHold,
            int? PShowActive,
            int? PPrZeroBal,
            int? PPrCreditBal,
            int? PSortByCurr,
            int? PPrOpenPay,
            DateTime? PCutoffDate,
            string PInvDue,
            int? PAgeDays1,
            int? PAgeDays2,
            int? PAgeDays3,
            int? PAgeDays4,
            int? PAgeDays5,
            int? PHidePaid,
            string PAgeBucket,
            int? TGrand,
            int? FirstOfCustomer,
            int? UseHistRate,
            int? TranslateForAging,
            string SiteLabel,
            int? TTransDom,
            string CurCustNum,
            int? AnyTrans,
            string PAgeDesc1,
            string PAgeDesc2,
            string PAgeDesc3,
            string PAgeDesc4,
            string PAgeDesc5,
            string PArSortBy,
            Guid? ProcessID,
            int? IncludeEstCurrGainLossAmtsInTotals)
        {
            FlagNyType _ConsolidateCustomers = ConsolidateCustomers;
            SiteType _PSite = PSite;
            SortDirectionPlusType _PPrOpenItem = PPrOpenItem;
            DateType _PAgingDate = PAgingDate;
            ListYesNoType _PSumToCorp = PSumToCorp;
            SlsmanType _PSSlsman = PSSlsman;
            SlsmanType _PESlsman = PESlsman;
            StatementCycleType _PStateCycle = PStateCycle;
            StringType _PCreditHold = PCreditHold;
            ListYesNoType _PShowActive = PShowActive;
            ListYesNoType _PPrZeroBal = PPrZeroBal;
            ListYesNoType _PPrCreditBal = PPrCreditBal;
            ListYesNoType _PSortByCurr = PSortByCurr;
            ListYesNoType _PPrOpenPay = PPrOpenPay;
            DateType _PCutoffDate = PCutoffDate;
            ArAgeByType _PInvDue = PInvDue;
            AgeDaysType _PAgeDays1 = PAgeDays1;
            AgeDaysType _PAgeDays2 = PAgeDays2;
            AgeDaysType _PAgeDays3 = PAgeDays3;
            AgeDaysType _PAgeDays4 = PAgeDays4;
            AgeDaysType _PAgeDays5 = PAgeDays5;
            IntType _PHidePaid = PHidePaid;
            AcctType _PAgeBucket = PAgeBucket;
            FlagNyType _TGrand = TGrand;
            FlagNyType _FirstOfCustomer = FirstOfCustomer;
            FlagNyType _UseHistRate = UseHistRate;
            FlagNyType _TranslateForAging = TranslateForAging;
            LongListType _SiteLabel = SiteLabel;
            FlagNyType _TTransDom = TTransDom;
            CustNumType _CurCustNum = CurCustNum;
            FlagNyType _AnyTrans = AnyTrans;
            AgeDescType _PAgeDesc1 = PAgeDesc1;
            AgeDescType _PAgeDesc2 = PAgeDesc2;
            AgeDescType _PAgeDesc3 = PAgeDesc3;
            AgeDescType _PAgeDesc4 = PAgeDesc4;
            AgeDescType _PAgeDesc5 = PAgeDesc5;
            StringType _PArSortBy = PArSortBy;
            RowPointerType _ProcessID = ProcessID;
            ListYesNoType _IncludeEstCurrGainLossAmtsInTotals = IncludeEstCurrGainLossAmtsInTotals;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ConsolidateCustomers", _ConsolidateCustomers, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPrOpenItem", _PPrOpenItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgingDate", _PAgingDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSumToCorp", _PSumToCorp, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSSlsman", _PSSlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PESlsman", _PESlsman, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStateCycle", _PStateCycle, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCreditHold", _PCreditHold, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PShowActive", _PShowActive, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPrZeroBal", _PPrZeroBal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPrCreditBal", _PPrCreditBal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSortByCurr", _PSortByCurr, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPrOpenPay", _PPrOpenPay, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCutoffDate", _PCutoffDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvDue", _PInvDue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDays1", _PAgeDays1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDays2", _PAgeDays2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDays3", _PAgeDays3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDays4", _PAgeDays4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDays5", _PAgeDays5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PHidePaid", _PHidePaid, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeBucket", _PAgeBucket, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TGrand", _TGrand, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FirstOfCustomer", _FirstOfCustomer, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TranslateForAging", _TranslateForAging, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SiteLabel", _SiteLabel, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TTransDom", _TTransDom, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CurCustNum", _CurCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AnyTrans", _AnyTrans, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PAgeDesc1", _PAgeDesc1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDesc2", _PAgeDesc2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDesc3", _PAgeDesc3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDesc4", _PAgeDesc4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PAgeDesc5", _PAgeDesc5, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PArSortBy", _PArSortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "IncludeEstCurrGainLossAmtsInTotals", _IncludeEstCurrGainLossAmtsInTotals, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TGrand = _TGrand;
                FirstOfCustomer = _FirstOfCustomer;
                UseHistRate = _UseHistRate;
                TranslateForAging = _TranslateForAging;
                SiteLabel = _SiteLabel;
                TTransDom = _TTransDom;
                AnyTrans = _AnyTrans;

                return (Severity, TGrand, FirstOfCustomer, UseHistRate, TranslateForAging, SiteLabel, TTransDom, AnyTrans);
            }
        }
    }
}
