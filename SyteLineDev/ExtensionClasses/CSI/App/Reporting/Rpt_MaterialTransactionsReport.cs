//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialTransactionsReport.cs

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
using CSI.Material;
using CSI.Data.Cache;
using CSI.Data.Utilities;

namespace CSI.Reporting
{
    public class Rpt_MaterialTransactionsReport : IRpt_MaterialTransactionsReport
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IGetWinRegDecGroup iGetWinRegDecGroup;
        readonly IFixMaskForCrystal iFixMaskForCrystal;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IDefineVariable iDefineVariable;
        readonly IExpandKyByType iExpandKyByType;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IHighDecimal iHighDecimal;
        readonly IMidnightOf iMidnightOf;
        readonly ILowDecimal iLowDecimal;
        readonly IHighAnyInt iHighAnyInt;
        readonly IStringUtil stringUtil;
        readonly ILowAnyInt iLowAnyInt;
        readonly IDayEndOf iDayEndOf;
        readonly IHighDate iHighDate;
        readonly ILowDate iLowDate;
        readonly IHighInt iHighInt;
        readonly IHighString iHighString;
        readonly ILowString iLowString;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly ILowInt iLowInt;
        readonly int recordCap;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly IBookmarkFactory bookmarkFactory;
        readonly LoadType loadType;
        readonly ISortOrderFactory sortOrderFactory;

        public Rpt_MaterialTransactionsReport(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionLoadBuilderRequestFactory collectionLoadBuilderRequestFactory,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IGetWinRegDecGroup iGetWinRegDecGroup,
            IFixMaskForCrystal iFixMaskForCrystal,
            IIsAddonAvailable iIsAddonAvailable,
            IApplyDateOffset iApplyDateOffset,
            IDefineVariable iDefineVariable,
            IExpandKyByType iExpandKyByType,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IHighDecimal iHighDecimal,
            IMidnightOf iMidnightOf,
            ILowDecimal iLowDecimal,
            IHighAnyInt iHighAnyInt,
            IStringUtil stringUtil,
            ILowAnyInt iLowAnyInt,
            IDayEndOf iDayEndOf,
            IHighDate iHighDate,
            ILowDate iLowDate,
            IHighInt iHighInt,
            IHighString iHighString,
            ILowString iLowString,
            IMathUtil mathUtil,
            ISQLValueComparerUtil sQLUtil,
            ILowInt iLowInt,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            ICache mgSessionVariableBasedCache,
            IQueryLanguage queryLanguage,
            IBookmarkFactory bookmarkFactory,
            ISortOrderFactory sortOrderFactory)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionLoadBuilderRequestFactory = collectionLoadBuilderRequestFactory;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iGetWinRegDecGroup = iGetWinRegDecGroup;
            this.iFixMaskForCrystal = iFixMaskForCrystal;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iDefineVariable = iDefineVariable;
            this.iExpandKyByType = iExpandKyByType;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.iHighDecimal = iHighDecimal;
            this.iMidnightOf = iMidnightOf;
            this.iLowDecimal = iLowDecimal;
            this.iHighAnyInt = iHighAnyInt;
            this.stringUtil = stringUtil;
            this.iLowAnyInt = iLowAnyInt;
            this.iDayEndOf = iDayEndOf;
            this.iHighDate = iHighDate;
            this.iLowDate = iLowDate;
            this.iHighInt = iHighInt;
            this.iHighString = iHighString;
            this.iLowString = iLowString;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
            this.iLowInt = iLowInt;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.queryLanguage = queryLanguage;
            this.bookmarkFactory = bookmarkFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.loadType = bunchedLoadCollection.LoadType;
            this.recordCap = bunchedLoadCollection.RecordCap;
            if (recordCap == -1)
            {
                recordCap = 200;
            }
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_MaterialTransactionsReportSp(
            string SortBy = null,
            string OrderBy = null,
            string TransType = null,
            string RefType = null,
            int? Backflushed = null,
            int? NotBackflushed = null,
            int? DisplayHeader = null,
            int? PrintCost = null,
            string OrderType = null,
            decimal? TransNumStarting = null,
            decimal? TransNumEnding = null,
            string JobStarting = null,
            string JobEnding = null,
            int? SuffixStarting = null,
            int? SuffixEnding = null,
            DateTime? TransDateStarting = null,
            DateTime? TransDateEnding = null,
            string WhseStarting = null,
            string WhseEnding = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string LocationStarting = null,
            string LocationEnding = null,
            string ReasonCodeStarting = null,
            string ReasonCodeEnding = null,
            string CustomerOrderStarting = null,
            string CustomerOrderEnding = null,
            int? LineStarting = null,
            int? LineEnding = null,
            int? ReleaseStarting = null,
            int? ReleaseEnding = null,
            string StartingLot = null,
            string EndingLot = null,
            string StartingPO = null,
            string EndingPO = null,
            int? StartingPOLine = null,
            int? EndingPOLine = null,
            int? StartingPORelease = null,
            int? EndingPORelease = null,
            string StartingRMA = null,
            string EndingRMA = null,
            string StartingTransfer = null,
            string EndingTransfer = null,
            int? StartingTransferline = null,
            int? EndingTransferline = null,
            string WCStarting = null,
            string WCEnding = null,
            string PSNumStarting = null,
            string PSNumEnding = null,
            string PDocumentNumberStarting = null,
            string PDocumentNumberEnding = null,
            string SroStarting = null,
            string SroEnding = null,
            int? SroLineStarting = null,
            int? SroLineEnding = null,
            int? SroOperStarting = null,
            int? SroOperEnding = null,
            int? TransDateStartingOffset = null,
            int? TransDateEndingOffset = null,
            string PMessageLanguage = null,
            string pSite = null,
            string BGUser = null)
        {



            ICollectionLoadResponse Data = null;
            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                IBookmark nextBookmark = null;
                if (loadType == LoadType.Next)
                {
                    nextBookmark = mgSessionVariableBasedCache.Get<Bookmark>("Bookmark");
                }
                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                string Infobar = null;
                string TransTypeAll = null;
                string RefTypeAll = null;
                ListYesNoType _LotGenExp = DBNull.Value;
                int? LotGenExp = null;
                ListYesNoType _ParmsPostJour = DBNull.Value;
                int? ParmsPostJour = null;
                int? Severity = null;
                InputMaskType _CostPriceFormat = DBNull.Value;
                string CostPriceFormat = null;
                DecimalPlacesType _CostPricePlaces = DBNull.Value;
                int? CostPricePlaces = null;
                CurrCodeType _XDomCurrency = DBNull.Value;
                string XDomCurrency = null;
                InputMaskType _QtyUnitFormat = DBNull.Value;
                string QtyUnitFormat = null;
                DecimalPlacesType _QtyUnitPlaces = DBNull.Value;
                int? QtyUnitPlaces = null;
                int? TransNumConditionExists = null;
                int? TransDateConditionExists = null;
                int? ItemConditionExists = null;
                int? LocationConditionExists = null;
			    int? LocationEndConditionOnly = null;
                int? PsNumConditionExists = null;
			    int? PsNumEndConditionOnly = null;
                int? JobConditionExists = null;
			    int? JobEndConditionOnly = null;
			    int? SuffixEndConditionOnly = null;
                int? CustomerOrderConditionExists = null;
			    int? CustomerOrderEndConditionOnly = null;
                int? LineConditionExists = null;
			    int? LineEndConditionOnly = null;
                int? ReleaseConditionExists = null;
			    int? ReleaseEndConditionOnly = null;
                int? RMAConditionExists = null;
			    int? RMAEndConditionOnly = null;
                int? POConditionExists = null;
			    int? POEndConditionOnly = null;
                int? POLineConditionExists = null;
			    int? POLineEndConditionOnly = null;
                int? POReleaseConditionExists = null;
			    int? POReleaseEndConditionOnly = null;
                int? TransferConditionExists = null;
			    int? TransferEndConditionOnly = null;
                int? TransferLineConditionExists = null;
			    int? TransferLineEndConditionOnly = null;
                int? WCConditionExists = null;
			    int? WCEndConditionOnly = null;
                int? WhseConditionExists = null;
			    int? WhseEndConditionOnly = null;
                int? ReasoncodeConditionExists = null;
			    int? ReasoncodeEndConditionOnly = null;
                int? LotConditionExists = null;
                int? PDocumentNumberConditionExists = null;
                int? BackflushOption = null;
                int? TransTypeCondition = null;
                int? RefTypeCondition = null;
                int? SroConditionExists = null;
                int? SroLineConditionExists = null;
                int? SroOperConditionExists = null;
                int? ServiceManagementConditionExists = null;
                decimal? DPostSum = null;
                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_MaterialTransactionsReportSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL")))
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
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_MaterialTransactionsReportSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord


                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_MaterialTransactionsReportSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                        items: optional_module1LoadResponse.Items);

                    this.appDB.Insert(optional_module1InsertRequest);
                    #endregion InsertByRecords

                    while (existsChecker.Exists(tableName: "#tv_ALTGEN",
                        fromClause: collectionLoadRequestFactory.Clause(""),
                        whereClause: collectionLoadRequestFactory.Clause("")))
                    {
                        //BEGIN

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

                        var ALTGEN = AltExtGen_Rpt_MaterialTransactionsReportSp(ALTGEN_SpName,
                            SortBy,
                            OrderBy,
                            TransType,
                            RefType,
                            Backflushed,
                            NotBackflushed,
                            DisplayHeader,
                            PrintCost,
                            OrderType,
                            TransNumStarting,
                            TransNumEnding,
                            JobStarting,
                            JobEnding,
                            SuffixStarting,
                            SuffixEnding,
                            TransDateStarting,
                            TransDateEnding,
                            WhseStarting,
                            WhseEnding,
                            ItemStarting,
                            ItemEnding,
                            LocationStarting,
                            LocationEnding,
                            ReasonCodeStarting,
                            ReasonCodeEnding,
                            CustomerOrderStarting,
                            CustomerOrderEnding,
                            LineStarting,
                            LineEnding,
                            ReleaseStarting,
                            ReleaseEnding,
                            StartingLot,
                            EndingLot,
                            StartingPO,
                            EndingPO,
                            StartingPOLine,
                            EndingPOLine,
                            StartingPORelease,
                            EndingPORelease,
                            StartingRMA,
                            EndingRMA,
                            StartingTransfer,
                            EndingTransfer,
                            StartingTransferline,
                            EndingTransferline,
                            WCStarting,
                            WCEnding,
                            PSNumStarting,
                            PSNumEnding,
                            PDocumentNumberStarting,
                            PDocumentNumberEnding,
                            SroStarting,
                            SroEnding,
                            SroLineStarting,
                            SroLineEnding,
                            SroOperStarting,
                            SroOperEnding,
                            TransDateStartingOffset,
                            TransDateEndingOffset,
                            PMessageLanguage,
                            pSite,
                            BGUser);
                        ALTGEN_Severity = ALTGEN.ReturnCode;


                        if (sQLUtil.SQLNotEqual(ALTGEN_Severity, 1) == true)
                        {
                            return (ALTGEN.Data, ALTGEN_Severity);

                        }
                        this.sQLExpressionExecutor.Execute("ALTER TABLE #tv_ALTGEN ADD tempTableId INT IDENTITY");
                        /*Needs to load at least one column from the table: #tv_ALTGEN for delete, Loads the record based on its where and from clause, then deletes it by record.*/
                        #region CRUD LoadToRecord
                        var tv_ALTGEN2LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: new Dictionary<string, string>()
                        {
                            {"[SpName]","[SpName]"},
                        },
                        loadForChange: true,
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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_MaterialTransactionsReportSp") != null)
                {
                    var EXTGEN = AltExtGen_Rpt_MaterialTransactionsReportSp("dbo.EXTGEN_Rpt_MaterialTransactionsReportSp",
                        SortBy,
                        OrderBy,
                        TransType,
                        RefType,
                        Backflushed,
                        NotBackflushed,
                        DisplayHeader,
                        PrintCost,
                        OrderType,
                        TransNumStarting,
                        TransNumEnding,
                        JobStarting,
                        JobEnding,
                        SuffixStarting,
                        SuffixEnding,
                        TransDateStarting,
                        TransDateEnding,
                        WhseStarting,
                        WhseEnding,
                        ItemStarting,
                        ItemEnding,
                        LocationStarting,
                        LocationEnding,
                        ReasonCodeStarting,
                        ReasonCodeEnding,
                        CustomerOrderStarting,
                        CustomerOrderEnding,
                        LineStarting,
                        LineEnding,
                        ReleaseStarting,
                        ReleaseEnding,
                        StartingLot,
                        EndingLot,
                        StartingPO,
                        EndingPO,
                        StartingPOLine,
                        EndingPOLine,
                        StartingPORelease,
                        EndingPORelease,
                        StartingRMA,
                        EndingRMA,
                        StartingTransfer,
                        EndingTransfer,
                        StartingTransferline,
                        EndingTransferline,
                        WCStarting,
                        WCEnding,
                        PSNumStarting,
                        PSNumEnding,
                        PDocumentNumberStarting,
                        PDocumentNumberEnding,
                        SroStarting,
                        SroEnding,
                        SroLineStarting,
                        SroLineEnding,
                        SroOperStarting,
                        SroOperEnding,
                        TransDateStartingOffset,
                        TransDateEndingOffset,
                        PMessageLanguage,
                        pSite,
                        BGUser);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");
                if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("MaterialTransactionReport"), "COMMITTED") == true)
                {
                    this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");

                }
                else
                {
                    this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");

                }


                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: DefineVariableSp
                var DefineVariable = this.iDefineVariable.DefineVariableSp(
                    VariableName: "MessageLanguage",
                    VariableValue: PMessageLanguage,
                    Infobar: Infobar);
                Infobar = DefineVariable.Infobar;

                #endregion ExecuteMethodCall

                TransTypeAll = "ABCDFGHILMNOPRSTW";
                RefTypeAll = "CIORPJTSKW";
                TransType = stringUtil.IsNull(
                    TransType,
                    TransTypeAll);
                RefType = stringUtil.IsNull(
                    RefType,
                    RefTypeAll);
                Backflushed = (int?)(stringUtil.IsNull(
                    Backflushed,
                    1));
                NotBackflushed = (int?)(stringUtil.IsNull(
                    NotBackflushed,
                    1));
                DisplayHeader = (int?)(stringUtil.IsNull(
                    DisplayHeader,
                    1));
                PrintCost = (int?)(stringUtil.IsNull(
                    PrintCost,
                    0));
                OrderType = stringUtil.IsNull(
                    OrderType,
                    "RB");
                if (PSNumStarting != null)
                {
                    PSNumStarting = this.iExpandKyByType.ExpandKyByTypeFn(
                        "PsNumType",
                        PSNumStarting);

                }
                if (PSNumEnding != null)
                {
                    PSNumEnding = this.iExpandKyByType.ExpandKyByTypeFn(
                        "PsNumType",
                        PSNumEnding);

                }
                if (TransDateStarting != null)
                {
                    //BEGIN

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: TransDateStarting,
                        Offset: TransDateStartingOffset,
                        IsEndDate: 0);
                    TransDateStarting = ApplyDateOffset.Date;

                    #endregion ExecuteMethodCall

                    TransDateStarting = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(TransDateStarting));
                    //END

                }
                if (TransDateEnding != null)
                {
                    //BEGIN

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: TransDateEnding,
                        Offset: TransDateEndingOffset,
                        IsEndDate: 1);
                    TransDateEnding = ApplyDateOffset1.Date;

                    #endregion ExecuteMethodCall

                    TransDateEnding = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(TransDateEnding));
                    //END

                }
                if (JobStarting != null)
                {
                    JobStarting = stringUtil.LTrim(stringUtil.RTrim(JobStarting));

                }
                if (JobEnding != null)
                {
                    JobEnding = stringUtil.LTrim(stringUtil.RTrim(JobEnding));

                }
                if (CustomerOrderStarting != null)
                {
                    CustomerOrderStarting = this.iExpandKyByType.ExpandKyByTypeFn(
                        "CoNumType",
                        CustomerOrderStarting);

                }
                if (CustomerOrderEnding != null)
                {
                    CustomerOrderEnding = this.iExpandKyByType.ExpandKyByTypeFn(
                        "CoNumType",
                        CustomerOrderEnding);

                }
                if (StartingRMA != null)
                {
                    StartingRMA = this.iExpandKyByType.ExpandKyByTypeFn(
                        "RmaNumType",
                        StartingRMA);

                }
                if (EndingRMA != null)
                {
                    EndingRMA = this.iExpandKyByType.ExpandKyByTypeFn(
                        "RmaNumType",
                        EndingRMA);

                }
                if (StartingPO != null)
                {
                    StartingPO = this.iExpandKyByType.ExpandKyByTypeFn(
                        "PoNumType",
                        StartingPO);

                }
                if (EndingPO != null)
                {
                    EndingPO = this.iExpandKyByType.ExpandKyByTypeFn(
                        "PoNumType",
                        EndingPO);

                }
                if (StartingTransfer != null)
                {
                    StartingTransfer = this.iExpandKyByType.ExpandKyByTypeFn(
                        "TrnNumType",
                        StartingTransfer);

                }
                if (EndingTransfer != null)
                {
                    EndingTransfer = this.iExpandKyByType.ExpandKyByTypeFn(
                        "TrnNumType",
                        EndingTransfer);

                }

                #region CRUD LoadToVariable
                var invparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_LotGenExp,"invparms.lot_gen_exp"},
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
                    LotGenExp = _LotGenExp;
                }
                #endregion  LoadToVariable

                if (StartingLot != null)
                {
                    StartingLot = (sQLUtil.SQLEqual(LotGenExp, 0) == true ? stringUtil.IsNull(
                        StartingLot,
                        this.iLowString.LowStringFn("LotType")) : stringUtil.IsNull(
                        this.iExpandKyByType.ExpandKyByTypeFn(
                            "LotType",
                            StartingLot),
                        this.iLowString.LowStringFn("LotType")));

                }
                if (EndingLot != null)
                {
                    EndingLot = (sQLUtil.SQLEqual(LotGenExp, 0) == true ? stringUtil.IsNull(
                        EndingLot,
                        this.iHighString.HighStringFn("LotType")) : stringUtil.IsNull(
                        this.iExpandKyByType.ExpandKyByTypeFn(
                            "LotType",
                            EndingLot),
                        this.iHighString.HighStringFn("LotType")));

                }
                Severity = 0;

                #region CRUD LoadToVariable
                var currparmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_XDomCurrency,"curr_code"},
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
                    XDomCurrency = _XDomCurrency;
                }
                #endregion  LoadToVariable


                #region CRUD LoadToVariable
                var parmsLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_ParmsPostJour,"parms.post_jour"},
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
                    ParmsPostJour = _ParmsPostJour;
                }
                #endregion  LoadToVariable


                #region CRUD LoadToVariable
                var currencyLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_CostPricePlaces,"places_cp"},
                    {_CostPriceFormat,"cst_prc_format"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "currency",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause("currency.curr_code = {0}", XDomCurrency),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var currencyLoadResponse = this.appDB.Load(currencyLoadRequest);
                if (currencyLoadResponse.Items.Count > 0)
                {
                    CostPricePlaces = _CostPricePlaces;
                    CostPriceFormat = _CostPriceFormat;
                }
                #endregion  LoadToVariable


                #region CRUD LoadToVariable
                var invparms1LoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                {
                    {_QtyUnitPlaces,"places_qty_unit"},
                    {_QtyUnitFormat,"qty_unit_format"},
                },
                loadForChange: false, 
                lockingType: LockingType.None,
                maximumRows: 1,
                tableName: "invparms",
                fromClause: collectionLoadRequestFactory.Clause(""),
                whereClause: collectionLoadRequestFactory.Clause(""),
                orderByClause: collectionLoadRequestFactory.Clause(""));
                var invparms1LoadResponse = this.appDB.Load(invparms1LoadRequest);
                if (invparms1LoadResponse.Items.Count > 0)
                {
                    QtyUnitPlaces = _QtyUnitPlaces;
                    QtyUnitFormat = _QtyUnitFormat;
                }
                #endregion  LoadToVariable

                CostPriceFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    CostPriceFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                QtyUnitFormat = this.iFixMaskForCrystal.FixMaskForCrystalFn(
                    QtyUnitFormat,
                    this.iGetWinRegDecGroup.GetWinRegDecGroupFn());
                TransNumConditionExists = 0;
                if (TransNumStarting != null || TransNumEnding != null)
                {
                    TransNumConditionExists = 1;

                }
                TransNumStarting = convertToUtil.ToDecimal(stringUtil.IsNull(
                    TransNumStarting,
                    this.iLowDecimal.LowDecimalFn("MatlTransNumType")));
                TransNumEnding = convertToUtil.ToDecimal(stringUtil.IsNull(
                    TransNumEnding,
                    this.iHighDecimal.HighDecimalFn("MatlTransNumType")));
                TransDateConditionExists = 0;
                if (TransDateStarting != null || TransDateEnding != null)
                {
                    TransDateConditionExists = 1;
                }
                TransDateStarting = convertToUtil.ToDateTime(stringUtil.IsNull(
                    TransDateStarting,
                    this.iLowDate.LowDateFn()));
                TransDateEnding = convertToUtil.ToDateTime(stringUtil.IsNull(
                    TransDateEnding,
                    this.iHighDate.HighDateFn()));
                ItemConditionExists = 0;
                if (ItemStarting != null || ItemEnding != null)
                {
                    ItemConditionExists = 1;

                }
                ItemStarting = stringUtil.IsNull(
                    ItemStarting,
                    this.iLowString.LowStringFn("ItemType"));
                ItemEnding = stringUtil.IsNull(
                    ItemEnding,
                    this.iHighString.HighStringFn("ItemType"));

                LocationConditionExists = (LocationStarting != null || LocationEnding != null) ? 1 : 0;
			    LocationEndConditionOnly = (LocationStarting == null && LocationEnding != null) ? 1 : 0;
                LocationStarting = stringUtil.IsNull(
                    LocationStarting,
                    this.iLowString.LowStringFn("LocType"));
                LocationEnding = stringUtil.IsNull(
                    LocationEnding,
                    this.iHighString.HighStringFn("LocType"));

                PsNumConditionExists = (PSNumStarting != null || PSNumEnding != null) ? 1 : 0;
			    PsNumEndConditionOnly = (PSNumStarting == null && PSNumEnding != null) ? 1 : 0;
                PSNumStarting = stringUtil.IsNull(
                    PSNumStarting,
                    this.iLowString.LowStringFn("PsNumType"));
                PSNumEnding = stringUtil.IsNull(
                    PSNumEnding,
                    this.iHighString.HighStringFn("PsNumType"));

                JobConditionExists = (JobStarting != null || JobEnding != null) ? 1 : 0;
			    JobEndConditionOnly = (JobStarting == null && JobEnding != null) ? 1 : 0;			
                JobStarting = stringUtil.IsNull(
                    JobStarting,
                    this.iLowString.LowStringFn("JobType"));
                JobEnding = stringUtil.IsNull(
                    JobEnding,
                    this.iHighString.HighStringFn("JobType"));

				SuffixEndConditionOnly = (SuffixStarting == null && SuffixEnding != null) ? 1 : 0;				
                SuffixStarting = convertToUtil.ToInt32(stringUtil.IsNull(
                    SuffixStarting,
                    this.iLowAnyInt.LowAnyIntFn("SuffixType")));
                SuffixEnding = convertToUtil.ToInt32(stringUtil.IsNull(
                    SuffixEnding,
                    this.iHighAnyInt.HighAnyIntFn("SuffixType")));

                CustomerOrderConditionExists = (CustomerOrderStarting != null || CustomerOrderEnding != null) ? 1 : 0;
			    CustomerOrderEndConditionOnly = (CustomerOrderStarting == null && CustomerOrderEnding != null) ? 1 : 0;
                CustomerOrderStarting = stringUtil.IsNull(
                    CustomerOrderStarting,
                    this.iLowString.LowStringFn("CoNumType"));
                CustomerOrderEnding = stringUtil.IsNull(
                    CustomerOrderEnding,
                    this.iHighString.HighStringFn("CoNumType"));

                LineConditionExists = (LineStarting != null || LineEnding != null) ? 1 : 0;
			    LineEndConditionOnly = (LineStarting == null && LineEnding != null) ? 1 : 0;
                LineStarting = convertToUtil.ToInt32(stringUtil.IsNull(
                    LineStarting,
                    this.iLowAnyInt.LowAnyIntFn("CoLineSuffixPoLineProjTaskRmaTrnLineType")));
                LineEnding = convertToUtil.ToInt32(stringUtil.IsNull(
                    LineEnding,
                    this.iHighAnyInt.HighAnyIntFn("CoLineSuffixPoLineProjTaskRmaTrnLineType")));

                ReleaseConditionExists = (ReleaseStarting != null || ReleaseEnding != null) ? 1 : 0;
			    ReleaseEndConditionOnly = (ReleaseStarting == null && ReleaseEnding != null) ? 1 : 0;
                ReleaseStarting = convertToUtil.ToInt32(stringUtil.IsNull(
                    ReleaseStarting,
                    this.iLowAnyInt.LowAnyIntFn("CoReleaseOperNumPoReleaseType")));
                ReleaseEnding = convertToUtil.ToInt32(stringUtil.IsNull(
                    ReleaseEnding,
                    this.iHighAnyInt.HighAnyIntFn("CoReleaseOperNumPoReleaseType")));

                RMAConditionExists = (StartingRMA != null || EndingRMA != null) ? 1 : 0;
			    RMAEndConditionOnly = (StartingRMA == null && EndingRMA != null) ? 1 : 0;
                StartingRMA = stringUtil.IsNull(
                    StartingRMA,
                    this.iLowString.LowStringFn("RmaNumType"));
                EndingRMA = stringUtil.IsNull(
                    EndingRMA,
                    this.iHighString.HighStringFn("RmaNumType"));

                POConditionExists = (StartingPO != null || EndingPO != null) ? 1 : 0;
			    POEndConditionOnly = (StartingPO == null && EndingPO != null) ? 1 : 0;
                StartingPO = stringUtil.IsNull(
                    StartingPO,
                    this.iLowString.LowStringFn("PoNumType"));
                EndingPO = stringUtil.IsNull(
                    EndingPO,
                    this.iHighString.HighStringFn("PoNumType"));

                POLineConditionExists = (StartingPOLine != null || EndingPOLine != null) ? 1 : 0;
			    POLineEndConditionOnly = (StartingPOLine == null && EndingPOLine != null) ? 1 : 0;
                StartingPOLine = convertToUtil.ToInt32(stringUtil.IsNull(
                    StartingPOLine,
                    this.iLowAnyInt.LowAnyIntFn("CoLineSuffixPoLineProjTaskRmaTrnLineType")));
                EndingPOLine = convertToUtil.ToInt32(stringUtil.IsNull(
                    EndingPOLine,
                    this.iHighAnyInt.HighAnyIntFn("CoLineSuffixPoLineProjTaskRmaTrnLineType")));

                POReleaseConditionExists = (StartingPORelease != null || EndingPORelease != null) ? 1 : 0;
			    POReleaseEndConditionOnly = (StartingPORelease == null && EndingPORelease != null) ? 1 : 0;
                StartingPORelease = convertToUtil.ToInt32(stringUtil.IsNull(
                    StartingPORelease,
                    this.iLowAnyInt.LowAnyIntFn("CoReleaseOperNumPoReleaseType")));
                EndingPORelease = convertToUtil.ToInt32(stringUtil.IsNull(
                    EndingPORelease,
                    this.iHighAnyInt.HighAnyIntFn("CoReleaseOperNumPoReleaseType")));

                TransferConditionExists = (StartingTransfer != null || EndingTransfer != null) ? 1 : 0;
			    TransferEndConditionOnly = (StartingTransfer == null && EndingTransfer != null) ? 1 : 0;
                StartingTransfer = stringUtil.IsNull(
                    StartingTransfer,
                    this.iLowString.LowStringFn("TrnNumType"));
                EndingTransfer = stringUtil.IsNull(
                    EndingTransfer,
                    this.iHighString.HighStringFn("TrnNumType"));

                TransferLineConditionExists = (StartingTransferline != null || EndingTransferline != null) ? 1 : 0;
			    TransferLineEndConditionOnly = (StartingTransferline == null && EndingTransferline != null) ? 1 : 0;              
                StartingTransferline = convertToUtil.ToInt32(stringUtil.IsNull(
                    StartingTransferline,
                    this.iLowAnyInt.LowAnyIntFn("CoLineSuffixPoLineProjTaskRmaTrnLineType")));
                EndingTransferline = convertToUtil.ToInt32(stringUtil.IsNull(
                    EndingTransferline,
                    this.iHighAnyInt.HighAnyIntFn("CoLineSuffixPoLineProjTaskRmaTrnLineType")));

                WCConditionExists = (WCStarting != null || WCEnding != null) ? 1 : 0;
			    WCEndConditionOnly = (WCStarting == null && WCEnding != null) ? 1 : 0;            
                WCStarting = stringUtil.IsNull(
                    WCStarting,
                    this.iLowString.LowStringFn("WcType"));
                WCEnding = stringUtil.IsNull(
                    WCEnding,
                    this.iHighString.HighStringFn("WcType"));

                WhseConditionExists = (WhseStarting != null || WhseEnding != null) ? 1 : 0;
			    WhseEndConditionOnly = (WhseStarting == null && WhseEnding != null) ? 1 : 0;
                WhseStarting = stringUtil.IsNull(
                    WhseStarting,
                    this.iLowString.LowStringFn("WhseType"));
                WhseEnding = stringUtil.IsNull(
                    WhseEnding,
                    this.iHighString.HighStringFn("WhseType"));

                ReasoncodeConditionExists = (ReasonCodeStarting != null || ReasonCodeEnding != null) ? 1 : 0;
			    ReasoncodeEndConditionOnly = (ReasonCodeStarting == null && ReasonCodeEnding != null) ? 1 : 0;                
                ReasonCodeStarting = stringUtil.IsNull(
                    ReasonCodeStarting,
                    this.iLowString.LowStringFn("ReasonCodeType"));
                ReasonCodeEnding = stringUtil.IsNull(
                    ReasonCodeEnding,
                    this.iHighString.HighStringFn("ReasonCodeType"));

                LotConditionExists = (StartingLot != null || EndingLot != null) ? 1 : 0;
                StartingLot = stringUtil.IsNull(
                    StartingLot,
                    this.iLowString.LowStringFn("LotType"));
                EndingLot = stringUtil.IsNull(
                    EndingLot,
                    this.iHighString.HighStringFn("LotType"));

                PDocumentNumberConditionExists = (PDocumentNumberStarting != null || PDocumentNumberEnding != null) ? 1 : 0;
                PDocumentNumberStarting = stringUtil.IsNull(
                    PDocumentNumberStarting,
                    this.iLowString.LowStringFn("DocumentNumType"));
                PDocumentNumberEnding = stringUtil.IsNull(
                    PDocumentNumberEnding,
                    this.iHighString.HighStringFn("DocumentNumType"));

                if (sQLUtil.SQLEqual(Backflushed, 0) == true && sQLUtil.SQLEqual(NotBackflushed, 0) == true)
                {
                    BackflushOption = -1;

                }
                else
                {
                    if (sQLUtil.SQLEqual(Backflushed, 0) == true && sQLUtil.SQLEqual(NotBackflushed, 1) == true)
                    {
                        BackflushOption = 0;

                    }
                    else
                    {
                        if (sQLUtil.SQLEqual(Backflushed, 1) == true && sQLUtil.SQLEqual(NotBackflushed, 0) == true)
                        {
                            BackflushOption = 1;

                        }
                        else
                        {
                            BackflushOption = -2;

                        }

                    }

                }
                if (TransType == null || sQLUtil.SQLEqual(TransType, TransTypeAll) == true)
                {
                    TransTypeCondition = 1;

                }
                else
                {
                    if (sQLUtil.SQLEqual(stringUtil.Len(TransType), 1) == true)
                    {
                        TransTypeCondition = 2;

                    }
                    else
                    {
                        TransTypeCondition = 3;

                    }

                }
                if (RefType == null || sQLUtil.SQLEqual(RefType, RefTypeAll) == true)
                {
                    RefTypeCondition = 1;

                }
                else
                {
                    if (sQLUtil.SQLEqual(stringUtil.Len(RefType), 1) == true)
                    {
                        RefTypeCondition = 2;

                    }
                    else
                    {
                        RefTypeCondition = 3;

                    }

                }
                SroConditionExists = 0;
                SroLineConditionExists = 0;
                SroOperConditionExists = 0;
                ServiceManagementConditionExists = 0;
                if ((sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagement"), 1) == true || sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagementM"), 1) == true || sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagement_MS"), 1) == true || sQLUtil.SQLEqual(this.iIsAddonAvailable.IsAddonAvailableFn("ServiceManagementM_MS"), 1) == true))
                {
                    //BEGIN
                    ServiceManagementConditionExists = 1;
                    if (SroStarting != null)
                    {
                        SroStarting = this.iExpandKyByType.ExpandKyByTypeFn(
                            "FSSRONumType",
                            SroStarting);

                    }
                    if (SroEnding != null)
                    {
                        SroEnding = this.iExpandKyByType.ExpandKyByTypeFn(
                            "FSSRONumType",
                            SroEnding);

                    }
                    if (SroStarting != null || SroEnding != null)
                    {
                        SroConditionExists = 1;

                    }
                    SroStarting = stringUtil.IsNull(
                        SroStarting,
                        this.iLowString.LowStringFn("CONumType"));
                    SroEnding = stringUtil.IsNull(
                        SroEnding,
                        this.iHighString.HighStringFn("CONumType"));
                    if (SroLineStarting != null || SroLineEnding != null)
                    {
                        SroLineConditionExists = 1;

                    }
                    SroLineStarting = (int?)(stringUtil.IsNull(
                        SroLineStarting,
                        this.iLowInt.LowIntFn()));
                    SroLineEnding = (int?)(stringUtil.IsNull(
                        SroLineEnding,
                        this.iHighInt.HighIntFn()));
                    if (SroOperStarting != null || SroOperEnding != null)
                    {
                        SroOperConditionExists = 1;

                    }
                    SroOperStarting = (int?)(stringUtil.IsNull(
                        SroOperStarting,
                        this.iLowInt.LowIntFn()));
                    SroOperEnding = (int?)(stringUtil.IsNull(
                        SroOperEnding,
                        this.iHighInt.HighIntFn()));
                    //END

                }
                DPostSum = 0;

                #region CRUD LoadToRecord
                Dictionary<String, String> columnExpressionByColumnName = new Dictionary<string, string>(){
                    {"dFrom","MatlView.[From]"},
                    {"dTo","MatlView.[To]"},
                    {"dType","MatlView.Type"},
                    {"Whse","MatlView.whse"},
                    {"Item","MatlView.Item"},
                    {"Descr","MatlView.ItemDesc"},
                    {"UM","MatlView.ItemUM"},
                    {"Reason","MatlView.ReasonCode"},
                    {"Reasond","MatlView.ReasonDesc"},
                    {"dref","MatlView.Ref"},
                    {"WC","MatlView.WC"},
                    {"duser","MatlView.UserCode"},
                    {"dflush","MatlView.Backflush"},
                    {"ddate","MatlView.TransDate"},
                    {"dtran","MatlView.Trans_Num"},
                    {"qty","MatlView.Qty"},
                    {"dcost","CAST (NULL AS DECIMAL)"},
                    {"dPost","CAST (NULL AS DECIMAL)"},
                    {"dtotl","CAST (NULL AS INT)"},
                    {"docnum","MatlView.DocumentNum"},
                    {"CostPriceFormat","CAST (NULL AS NVARCHAR)"},
                    {"CostPricePlaces","CAST (NULL AS INT)"},
                    {"QtyUnitFormat","CAST (NULL AS NVARCHAR)"},
                    {"QtyUnitPlaces","CAST (NULL AS INT)"},
                    {"DerSumDPost","CAST (NULL AS DECIMAL)"},
                    {"u0","MatlView.Cost"},
                    {"u1","MatlView.TotalCost"},
                    {"u2","MatlView.TotalPost"},
                };

                string sortByColumns = null;
                Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>(); 

                switch (SortBy)
                {
                    case "Job":
                        columnExpressionByColumnName.Add("m.ref_type", "m.ref_type");
                        columnExpressionByColumnName.Add("m.ref_num", "m.ref_num");
                        columnExpressionByColumnName.Add("isnull(m.ref_line_suf, 0)", "isnull(m.ref_line_suf, 0)");
                        columnExpressionByColumnName.Add("isnull(m.ref_release, 0)", "isnull(m.ref_release, 0)");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");
                        columnExpressionByColumnName.Add("m.trans_date", "m.trans_date");

                        sortByColumns = " m.ref_type, m.ref_num, isnull(m.ref_line_suf, 0), isnull(m.ref_release, 0), m.trans_num, m.trans_date";

                        dicSortOrder.Add("m.ref_type", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.ref_num", SortOrderDirection.Ascending);
                        dicSortOrder.Add("isnull(m.ref_line_suf, 0)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("isnull(m.ref_release, 0)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_date", SortOrderDirection.Ascending);
                        break;
                    case "Date":
                        columnExpressionByColumnName.Add("CAST(FLOOR( CAST( m.trans_date AS FLOAT ) ) AS DATETIME)", "CAST(FLOOR( CAST( m.trans_date AS FLOAT ) ) AS DATETIME)");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " CAST(FLOOR( CAST( m.trans_date AS FLOAT ) ) AS DATETIME), m.trans_num";

                        dicSortOrder.Add("CAST(FLOOR( CAST( m.trans_date AS FLOAT ) ) AS DATETIME)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "COrder":
                        columnExpressionByColumnName.Add("m.ref_type", "m.ref_type");
                        columnExpressionByColumnName.Add("m.ref_num", "m.ref_num");
                        columnExpressionByColumnName.Add("isnull(m.ref_line_suf, 0)", "isnull(m.ref_line_suf, 0)");
                        columnExpressionByColumnName.Add("isnull(m.ref_release, 0)", "isnull(m.ref_release, 0)");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.ref_type, m.ref_num, isnull(m.ref_line_suf, 0), isnull(m.ref_release, 0), m.trans_num";

                        dicSortOrder.Add("m.ref_type", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.ref_num", SortOrderDirection.Ascending);
                        dicSortOrder.Add("isnull(m.ref_line_suf, 0)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("isnull(m.ref_release, 0)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "Item":
                        columnExpressionByColumnName.Add("m.item", "m.item");
                        columnExpressionByColumnName.Add("m.trans_date", "m.trans_date");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.item, m.trans_date, m.trans_num";

                        dicSortOrder.Add("m.item", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_date", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "Location":
                        columnExpressionByColumnName.Add("m.whse", "m.whse");
                        columnExpressionByColumnName.Add("m.loc", "m.loc");
                        columnExpressionByColumnName.Add("m.item", "m.item");
                        columnExpressionByColumnName.Add("m.trans_date", "m.trans_date");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.whse, m.loc, m.item, m.trans_date, m.trans_num";

                        dicSortOrder.Add("m.whse", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.loc", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.item", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_date", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "Lot":
                        columnExpressionByColumnName.Add("isnull(m.lot,'')", "isnull(m.lot,'')");
                        columnExpressionByColumnName.Add("m.item", "m.item");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " isnull(m.lot,''), m.item, m.trans_num";

                        dicSortOrder.Add("isnull(m.lot,'')", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.item", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "POrder":
                        columnExpressionByColumnName.Add("m.ref_type", "m.ref_type");
                        columnExpressionByColumnName.Add("m.ref_num", "m.ref_num");
                        columnExpressionByColumnName.Add("isnull(m.ref_line_suf, 0)", "isnull(m.ref_line_suf, 0)");
                        columnExpressionByColumnName.Add("isnull(m.ref_release, 0)", "isnull(m.ref_release, 0)");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.ref_type, m.ref_num, isnull(m.ref_line_suf, 0), isnull(m.ref_release, 0), m.trans_num";

                        dicSortOrder.Add("m.ref_type", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.ref_num", SortOrderDirection.Ascending);
                        dicSortOrder.Add("isnull(m.ref_line_suf, 0)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("isnull(m.ref_release, 0)", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "TOrder":
                        columnExpressionByColumnName.Add("m.ref_type", "m.ref_type");
                        columnExpressionByColumnName.Add("m.ref_num", "m.ref_num");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.ref_type, m.ref_num, m.trans_num";

                        dicSortOrder.Add("m.ref_type", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.ref_num", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "JIT":
                        columnExpressionByColumnName.Add("m.item", "m.item");
                        columnExpressionByColumnName.Add("m.trans_date", "m.trans_date");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.item, m.trans_date, m.trans_num";

                        dicSortOrder.Add("m.item", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_date", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "WC":
                        columnExpressionByColumnName.Add("m.wc", "m.wc");
                        columnExpressionByColumnName.Add("m.item", "m.item");
                        columnExpressionByColumnName.Add("m.trans_date", "m.trans_date");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.wc, m.item, m.trans_date, m.trans_num";

                        dicSortOrder.Add("m.wc", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.item", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_date", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "DocNum":
                        columnExpressionByColumnName.Add("m.document_num", "m.document_num");
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.document_num, m.trans_num";

                        dicSortOrder.Add("m.document_num", SortOrderDirection.Ascending);
                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                    case "Transaction":
                        columnExpressionByColumnName.Add("m.trans_num", "m.trans_num");

                        sortByColumns = " m.trans_num";

                        dicSortOrder.Add("m.trans_num", SortOrderDirection.Ascending);
                        break;
                }

                var mtSortOrder = sortOrderFactory.Create(dicSortOrder);
                var whereClause = collectionLoadRequestFactory.Clause("1 = 1 AND ((m.trans_num BETWEEN {50} AND {61}) OR {13} = 0) AND ((m.trans_date BETWEEN {46} AND {55}) OR {9} = 0) AND ((m.item BETWEEN {70} AND {80}) OR {31} = 0) AND ({14} = 0 OR ({10} = 1 AND m.loc IS NULL) OR (m.loc BETWEEN {51} AND {62})) AND ({27} = 0 OR ({23} = 1 AND (LTRIM(RTRIM(m.ref_num)) IS NULL AND m.ref_type = 'S')) OR (LTRIM(RTRIM(m.ref_num)) BETWEEN {66} AND {75} AND m.ref_type = 'S')) AND ({37} = 0 OR ({32} = 1 AND (LTRIM(RTRIM(m.ref_num)) IS NULL AND m.ref_type = 'J')) OR (LTRIM(RTRIM(m.ref_num)) BETWEEN {76} AND {85} AND m.ref_type = 'J')) AND ({37} = 0 OR ({37} = 1 AND (({18} = 1 AND m.ref_line_suf IS NULL AND m.ref_type = 'J') OR (m.ref_line_suf BETWEEN {63} AND {71} AND m.ref_type = 'J')))) AND ({3} = 0 OR ({2} = 1 AND m.ref_num IS NULL AND m.ref_type = 'O') OR (m.ref_num BETWEEN {24} AND {33} AND m.ref_type = 'O')) AND ({34} = 0 OR ({28} = 1 AND m.ref_line_suf IS NULL AND m.ref_type = 'O') OR (m.ref_line_suf BETWEEN {72} AND {81} AND m.ref_type = 'O')) AND ({19} = 0 OR ({15} = 1 AND m.ref_release IS NULL AND m.ref_type = 'O') OR (m.ref_release BETWEEN {56} AND {67} AND m.ref_type = 'O')) AND ({38} = 0 OR ({35} = 1 AND m.ref_num IS NULL AND m.ref_type = 'R') OR (m.ref_num BETWEEN {77} AND {86} AND m.ref_type = 'R')) AND ({47} = 0 OR ({39} = 1 AND dbo.ExpandKyByType('PoNumType', m.ref_num) IS NULL AND m.ref_type = 'P') OR (dbo.ExpandKyByType('PoNumType', m.ref_num) BETWEEN {82} AND {91} AND m.ref_type = 'P')) AND ({25} = 0 OR ({20} = 1 AND m.ref_line_suf IS NULL AND m.ref_type = 'P') OR (m.ref_line_suf BETWEEN {64} AND {73} AND m.ref_type = 'P')) AND ({11} = 0 OR ({7} = 1 AND m.ref_release IS NULL AND m.ref_type = 'P') OR (m.ref_release BETWEEN {48} AND {57} AND m.ref_type = 'P')) AND ({16} = 0 OR ({12} = 1 AND m.ref_num IS NULL AND m.ref_type = 'T') OR (m.ref_num BETWEEN {52} AND {65} AND m.ref_type = 'T')) AND ({5} = 0 OR ({4} = 1 AND m.ref_line_suf IS NULL AND m.ref_type = 'T') OR (m.ref_line_suf BETWEEN {29} AND {40} AND m.ref_type = 'T')) AND ({49} = 0 OR ({41} = 1 AND m.wc IS NULL) OR (m.wc BETWEEN {83} AND {92})) AND ({36} = 0 OR ({30} = 1 AND m.whse IS NULL) OR (m.whse BETWEEN {74} AND {84})) AND ({8} = 0 OR ({6} = 1 AND m.reason_code IS NULL) OR (m.reason_code BETWEEN {42} AND {53})) AND ({43} = 0 OR (m.lot BETWEEN {78} AND {87})) AND ({1} = 0 OR (m.document_num BETWEEN {17} AND {26})) AND (({58} >= 0 AND m.backflush = {58}) OR {58} = -2) AND ({44} = 1 OR ({44} = 2 AND m.trans_type = {88}) OR ({44} = 3 AND CHARINDEX(m.trans_type, {88}) > 0)) AND ({54} = 1 OR ({54} = 2 AND m.ref_type = {93}) OR ({54} = 3 AND CHARINDEX(m.ref_type, {93}) > 0)) AND ({0} = 0 OR ((dbo.IsAddonAvailable('ServiceManagement') = 1 OR dbo.IsAddonAvailable('ServiceManagementM') = 1 OR dbo.IsAddonAvailable('ServiceManagement_MS') = 1 OR dbo.IsAddonAvailable('ServiceManagementM_MS') = 1) AND ((m.ref_num BETWEEN {79} AND {89} AND m.ref_type = 'F') OR {45} = 0) AND ((m.ref_line_suf BETWEEN {59} AND {68} AND m.ref_type = 'F') OR {21} = 0) AND ((m.ref_release BETWEEN {60} AND {69} AND m.ref_type = 'F') OR {22} = 0))) AND (CASE WHEN (m.ref_type = 'O' AND {90} <> 'RB' AND co.type <> {90}) THEN 0 WHEN (m.ref_type = 'P' AND {90} <> 'RB' AND po.type <> {90}) THEN 0 ELSE 1 END) = 1", ServiceManagementConditionExists, PDocumentNumberConditionExists, CustomerOrderEndConditionOnly, CustomerOrderConditionExists, TransferLineEndConditionOnly, TransferLineConditionExists, ReasoncodeEndConditionOnly, POReleaseEndConditionOnly, ReasoncodeConditionExists, TransDateConditionExists, LocationEndConditionOnly, POReleaseConditionExists, TransferEndConditionOnly, TransNumConditionExists, LocationConditionExists, ReleaseEndConditionOnly, TransferConditionExists, PDocumentNumberStarting, SuffixEndConditionOnly, ReleaseConditionExists, POLineEndConditionOnly, SroLineConditionExists, SroOperConditionExists, PsNumEndConditionOnly, CustomerOrderStarting, POLineConditionExists, PDocumentNumberEnding, PsNumConditionExists, LineEndConditionOnly, StartingTransferline, WhseEndConditionOnly, ItemConditionExists, JobEndConditionOnly, CustomerOrderEnding, LineConditionExists, RMAEndConditionOnly, WhseConditionExists, JobConditionExists, RMAConditionExists, POEndConditionOnly, EndingTransferline, WCEndConditionOnly, ReasonCodeStarting, LotConditionExists, TransTypeCondition, SroConditionExists, TransDateStarting, POConditionExists, StartingPORelease, WCConditionExists, TransNumStarting, LocationStarting, StartingTransfer, ReasonCodeEnding, RefTypeCondition, TransDateEnding, ReleaseStarting, EndingPORelease, BackflushOption, SroLineStarting, SroOperStarting, TransNumEnding, LocationEnding, SuffixStarting, StartingPOLine, EndingTransfer, PSNumStarting, ReleaseEnding, SroLineEnding, SroOperEnding, ItemStarting, SuffixEnding, LineStarting, EndingPOLine, WhseStarting, PSNumEnding, JobStarting, StartingRMA, StartingLot, SroStarting, ItemEnding, LineEnding, StartingPO, WCStarting, WhseEnding, JobEnding, EndingRMA, EndingLot, TransType, SroEnding, OrderType, EndingPO, WCEnding, RefType);
                if (nextBookmark != null)
                {
                    whereClause = queryLanguage.AppendBookmark(whereClause, nextBookmark);
                }
                var matltranLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: columnExpressionByColumnName,
                tableName: "matltran",
                fromClause: collectionLoadRequestFactory.Clause(@" AS m LEFT OUTER JOIN matltran_amt AS ma ON ma.trans_num = m.trans_num
			    AND ma.trans_seq = 1 LEFT OUTER JOIN co ON m.ref_num = co.co_num LEFT OUTER JOIN po ON m.ref_num = po.po_num INNER JOIN MaterialTransactionsView AS MatlView ON m.trans_num = MatlView.trans_Num"),
                whereClause: whereClause,
                orderByClause: collectionLoadRequestFactory.Clause(sortByColumns),
                maximumRows: recordCap == 0 ? recordCap : recordCap + 1,
                loadForChange: false,
                lockingType: LockingType.None);
                var matltranLoadResponse = this.appDB.Load(matltranLoadRequest);
                #endregion  LoadToRecord

                foreach (var matltranItem in matltranLoadResponse.Items)
                {
                    matltranItem.SetValue<string>("dFrom", matltranItem.GetValue<string>("dFrom"));
                    matltranItem.SetValue<string>("dTo", matltranItem.GetValue<string>("dTo"));
                    matltranItem.SetValue<string>("dType", matltranItem.GetValue<string>("dType"));
                    matltranItem.SetValue<string>("Whse", matltranItem.GetValue<string>("Whse"));
                    matltranItem.SetValue<string>("Item", matltranItem.GetValue<string>("Item"));
                    matltranItem.SetValue<string>("Descr", matltranItem.GetValue<string>("Descr"));
                    matltranItem.SetValue<string>("UM", matltranItem.GetValue<string>("UM"));
                    matltranItem.SetValue<string>("Reason", matltranItem.GetValue<string>("Reason"));
                    matltranItem.SetValue<string>("Reasond", matltranItem.GetValue<string>("Reasond"));
                    matltranItem.SetValue<string>("dref", matltranItem.GetValue<string>("dref"));
                    matltranItem.SetValue<string>("WC", matltranItem.GetValue<string>("WC"));
                    matltranItem.SetValue<string>("duser", matltranItem.GetValue<string>("duser"));
                    matltranItem.SetValue<int?>("dflush", matltranItem.GetValue<int?>("dflush"));
                    matltranItem.SetValue<DateTime?>("ddate", matltranItem.GetValue<DateTime?>("ddate"));
                    matltranItem.SetValue<decimal?>("dtran", matltranItem.GetValue<decimal?>("dtran"));
                    matltranItem.SetValue<decimal?>("qty", matltranItem.GetValue<decimal?>("qty"));
                    matltranItem.SetValue<decimal?>("dcost", (sQLUtil.SQLEqual(PrintCost, 1) == true ? mathUtil.Abs<decimal?>(mathUtil.Round<decimal?>(matltranItem.GetValue<decimal?>("u0"), CostPricePlaces)) : 0));
                    matltranItem.SetValue<decimal?>("dPost", (sQLUtil.SQLEqual(PrintCost, 1) == true ? (sQLUtil.SQLEqual(ParmsPostJour, 0) == true ? stringUtil.IsNull(
                        matltranItem.GetValue<decimal?>("u1"),
                        0) : stringUtil.IsNull<decimal?>(
                        matltranItem.GetValue<decimal?>("u2"),
                        0)) : 0));
                    matltranItem.SetValue<int?>("dtotl", 0);
                    matltranItem.SetValue<string>("docnum", matltranItem.GetValue<string>("docnum"));
                    matltranItem.SetValue<string>("CostPriceFormat", CostPriceFormat);
                    matltranItem.SetValue<int?>("CostPricePlaces", CostPricePlaces);
                    matltranItem.SetValue<string>("QtyUnitFormat", QtyUnitFormat);
                    matltranItem.SetValue<int?>("QtyUnitPlaces", QtyUnitPlaces);
                    matltranItem.SetValue<decimal?>("DerSumDPost", DPostSum);
                };

                if (matltranLoadResponse.Items.Count > 1)
                {
                    mgSessionVariableBasedCache.Insert("Bookmark", (ICachable)bookmarkFactory.Create(matltranLoadResponse.Items[matltranLoadResponse.Items.Count - 2], mtSortOrder));
                }

                Data = matltranLoadResponse;

                (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("Bookmark", "", 0, "", "");
                if (!string.IsNullOrEmpty(variableValue))
                {
                    defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                }
                bunchedLoadCollection.EndBunching();
                return (Data, Severity);
            }
            finally
            {
                if (bunchedLoadCollection != null)
                    bunchedLoadCollection.EndBunching();
            }
            
        }
        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        AltExtGen_Rpt_MaterialTransactionsReportSp(
            string AltExtGenSp,
            string SortBy = null,
            string OrderBy = null,
            string TransType = null,
            string RefType = null,
            int? Backflushed = null,
            int? NotBackflushed = null,
            int? DisplayHeader = null,
            int? PrintCost = null,
            string OrderType = null,
            decimal? TransNumStarting = null,
            decimal? TransNumEnding = null,
            string JobStarting = null,
            string JobEnding = null,
            int? SuffixStarting = null,
            int? SuffixEnding = null,
            DateTime? TransDateStarting = null,
            DateTime? TransDateEnding = null,
            string WhseStarting = null,
            string WhseEnding = null,
            string ItemStarting = null,
            string ItemEnding = null,
            string LocationStarting = null,
            string LocationEnding = null,
            string ReasonCodeStarting = null,
            string ReasonCodeEnding = null,
            string CustomerOrderStarting = null,
            string CustomerOrderEnding = null,
            int? LineStarting = null,
            int? LineEnding = null,
            int? ReleaseStarting = null,
            int? ReleaseEnding = null,
            string StartingLot = null,
            string EndingLot = null,
            string StartingPO = null,
            string EndingPO = null,
            int? StartingPOLine = null,
            int? EndingPOLine = null,
            int? StartingPORelease = null,
            int? EndingPORelease = null,
            string StartingRMA = null,
            string EndingRMA = null,
            string StartingTransfer = null,
            string EndingTransfer = null,
            int? StartingTransferline = null,
            int? EndingTransferline = null,
            string WCStarting = null,
            string WCEnding = null,
            string PSNumStarting = null,
            string PSNumEnding = null,
            string PDocumentNumberStarting = null,
            string PDocumentNumberEnding = null,
            string SroStarting = null,
            string SroEnding = null,
            int? SroLineStarting = null,
            int? SroLineEnding = null,
            int? SroOperStarting = null,
            int? SroOperEnding = null,
            int? TransDateStartingOffset = null,
            int? TransDateEndingOffset = null,
            string PMessageLanguage = null,
            string pSite = null,
            string BGUser = null)
        {
            StringType _SortBy = SortBy;
            StringType _OrderBy = OrderBy;
            StringType _TransType = TransType;
            StringType _RefType = RefType;
            ListYesNoType _Backflushed = Backflushed;
            ListYesNoType _NotBackflushed = NotBackflushed;
            ListYesNoType _DisplayHeader = DisplayHeader;
            ListYesNoType _PrintCost = PrintCost;
            StringType _OrderType = OrderType;
            MatlTransNumType _TransNumStarting = TransNumStarting;
            MatlTransNumType _TransNumEnding = TransNumEnding;
            JobType _JobStarting = JobStarting;
            JobType _JobEnding = JobEnding;
            SuffixType _SuffixStarting = SuffixStarting;
            SuffixType _SuffixEnding = SuffixEnding;
            DateType _TransDateStarting = TransDateStarting;
            DateType _TransDateEnding = TransDateEnding;
            WhseType _WhseStarting = WhseStarting;
            WhseType _WhseEnding = WhseEnding;
            ItemType _ItemStarting = ItemStarting;
            ItemType _ItemEnding = ItemEnding;
            LocType _LocationStarting = LocationStarting;
            LocType _LocationEnding = LocationEnding;
            ReasonCodeType _ReasonCodeStarting = ReasonCodeStarting;
            ReasonCodeType _ReasonCodeEnding = ReasonCodeEnding;
            CoNumType _CustomerOrderStarting = CustomerOrderStarting;
            CoNumType _CustomerOrderEnding = CustomerOrderEnding;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _LineStarting = LineStarting;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _LineEnding = LineEnding;
            CoReleaseOperNumPoReleaseType _ReleaseStarting = ReleaseStarting;
            CoReleaseOperNumPoReleaseType _ReleaseEnding = ReleaseEnding;
            LotType _StartingLot = StartingLot;
            LotType _EndingLot = EndingLot;
            PoNumType _StartingPO = StartingPO;
            PoNumType _EndingPO = EndingPO;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _StartingPOLine = StartingPOLine;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _EndingPOLine = EndingPOLine;
            CoReleaseOperNumPoReleaseType _StartingPORelease = StartingPORelease;
            CoReleaseOperNumPoReleaseType _EndingPORelease = EndingPORelease;
            RmaNumType _StartingRMA = StartingRMA;
            RmaNumType _EndingRMA = EndingRMA;
            TrnNumType _StartingTransfer = StartingTransfer;
            TrnNumType _EndingTransfer = EndingTransfer;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _StartingTransferline = StartingTransferline;
            CoLineSuffixPoLineProjTaskRmaTrnLineType _EndingTransferline = EndingTransferline;
            WcType _WCStarting = WCStarting;
            WcType _WCEnding = WCEnding;
            PsNumType _PSNumStarting = PSNumStarting;
            PsNumType _PSNumEnding = PSNumEnding;
            DocumentNumType _PDocumentNumberStarting = PDocumentNumberStarting;
            DocumentNumType _PDocumentNumberEnding = PDocumentNumberEnding;
            CoNumType _SroStarting = SroStarting;
            CoNumType _SroEnding = SroEnding;
            CoPoReleaseArInvSeqType _SroLineStarting = SroLineStarting;
            CoPoReleaseArInvSeqType _SroLineEnding = SroLineEnding;
            CoPoReleaseArInvSeqType _SroOperStarting = SroOperStarting;
            CoPoReleaseArInvSeqType _SroOperEnding = SroOperEnding;
            DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
            DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
            MessageLanguageType _PMessageLanguage = PMessageLanguage;
            SiteType _pSite = pSite;
            UsernameType _BGUser = BGUser;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "SortBy", _SortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderBy", _OrderBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Backflushed", _Backflushed, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NotBackflushed", _NotBackflushed, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNumStarting", _TransNumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNumEnding", _TransNumEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SuffixStarting", _SuffixStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SuffixEnding", _SuffixEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WhseStarting", _WhseStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WhseEnding", _WhseEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LocationStarting", _LocationStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LocationEnding", _LocationEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonCodeStarting", _ReasonCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReasonCodeEnding", _ReasonCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerOrderStarting", _CustomerOrderStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustomerOrderEnding", _CustomerOrderEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LineStarting", _LineStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LineEnding", _LineEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReleaseStarting", _ReleaseStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReleaseEnding", _ReleaseEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingLot", _StartingLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingLot", _EndingLot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingPO", _StartingPO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingPO", _EndingPO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingPOLine", _StartingPOLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingPOLine", _EndingPOLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingPORelease", _StartingPORelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingPORelease", _EndingPORelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingRMA", _StartingRMA, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingRMA", _EndingRMA, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingTransfer", _StartingTransfer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingTransfer", _EndingTransfer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingTransferline", _StartingTransferline, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingTransferline", _EndingTransferline, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WCStarting", _WCStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WCEnding", _WCEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSNumStarting", _PSNumStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSNumEnding", _PSNumEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDocumentNumberStarting", _PDocumentNumberStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDocumentNumberEnding", _PDocumentNumberEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SroStarting", _SroStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SroEnding", _SroEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SroLineStarting", _SroLineStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SroLineEnding", _SroLineEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SroOperStarting", _SroOperStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SroOperEnding", _SroOperEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                var resultSet = dataTableToCollectionLoadResponse.Process(dtReturn);
                var returnCode = (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value;

                return (resultSet, returnCode);
            }
        }


    }
}
