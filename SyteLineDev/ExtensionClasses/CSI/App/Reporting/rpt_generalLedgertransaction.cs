//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerTransaction.cs

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
using System.Threading.Tasks;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_GeneralLedgerTransaction : IRpt_GeneralLedgerTransaction
    {
        readonly IApplicationDB appDB;

        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly ICollectionInsertRequestFactory collectionInsertRequestFactory;
        readonly ICollectionDeleteRequestFactory collectionDeleteRequestFactory;
        readonly ICollectionLoadRequestFactory collectionLoadRequestFactory;
        readonly ICollectionLoadResponseUtil collectionLoadResponseUtil;
        readonly ISQLExpressionExecutor sQLExpressionExecutor;
        readonly ITransactionFactory transactionFactory;
        readonly IGetIsolationLevel iGetIsolationLevel;
        readonly IIsAddonAvailable iIsAddonAvailable;
        readonly IReportNotesExist iReportNotesExist;
        readonly IApplyDateOffset iApplyDateOffset;
        readonly IIsFeatureActive iIsFeatureActive;
        readonly IScalarFunction scalarFunction;
        readonly IExistsChecker existsChecker;
        readonly IConvertToUtil convertToUtil;
        readonly IVariableUtil variableUtil;
        readonly IHighDecimal iHighDecimal;
        readonly IMidnightOf iMidnightOf;
        readonly ILowDecimal iLowDecimal;
        readonly IStringUtil stringUtil;
        readonly IDayEndOf iDayEndOf;
        readonly IHighDate iHighDate;
        readonly ILowDate iLowDate;
        readonly IHighString iHighString;
        readonly ILowString iLowString;
        readonly IMathUtil mathUtil;
        readonly ISQLValueComparerUtil sQLUtil;
        readonly int recordCap;
        readonly IDefineProcessVariable defineProcessVariable;
        readonly IGetVariable getVariable;
        readonly ICache mgSessionVariableBasedCache;
        readonly IQueryLanguage queryLanguage;
        readonly IBookmarkFactory bookmarkFactory;
        readonly LoadType loadType;
        readonly ISortOrderFactory sortOrderFactory;
        readonly ILogger logger;

        DateTime startTime;
        public Rpt_GeneralLedgerTransaction(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            ICollectionInsertRequestFactory collectionInsertRequestFactory,
            ICollectionDeleteRequestFactory collectionDeleteRequestFactory,
            ICollectionLoadRequestFactory collectionLoadRequestFactory,
            ICollectionLoadResponseUtil collectionLoadResponseUtil,
            ISQLExpressionExecutor sQLExpressionExecutor,
            ITransactionFactory transactionFactory,
            IGetIsolationLevel iGetIsolationLevel,
            IIsAddonAvailable iIsAddonAvailable,
            IReportNotesExist iReportNotesExist,
            IApplyDateOffset iApplyDateOffset,
            IIsFeatureActive iIsFeatureActive,
            IScalarFunction scalarFunction,
            IExistsChecker existsChecker,
            IConvertToUtil convertToUtil,
            IVariableUtil variableUtil,
            IHighDecimal iHighDecimal,
            IMidnightOf iMidnightOf,
            ILowDecimal iLowDecimal,
            IStringUtil stringUtil,
            IDayEndOf iDayEndOf,
            IHighDate iHighDate,
            ILowDate iLowDate,
            IHighString iHighString,
            ILowString iLowString,
            IMathUtil mathUtil,
            ISQLValueComparerUtil sQLUtil,
            IDefineProcessVariable defineProcessVariable,
            IGetVariable getVariable,
            ICache mgSessionVariableBasedCache,
            IQueryLanguage queryLanguage,
            IBookmarkFactory bookmarkFactory,
            ISortOrderFactory sortOrderFactory,
            ILogger logger)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.collectionInsertRequestFactory = collectionInsertRequestFactory;
            this.collectionDeleteRequestFactory = collectionDeleteRequestFactory;
            this.collectionLoadRequestFactory = collectionLoadRequestFactory;
            this.collectionLoadResponseUtil = collectionLoadResponseUtil;
            this.sQLExpressionExecutor = sQLExpressionExecutor;
            this.transactionFactory = transactionFactory;
            this.iGetIsolationLevel = iGetIsolationLevel;
            this.iIsAddonAvailable = iIsAddonAvailable;
            this.iReportNotesExist = iReportNotesExist;
            this.iApplyDateOffset = iApplyDateOffset;
            this.iIsFeatureActive = iIsFeatureActive;
            this.scalarFunction = scalarFunction;
            this.existsChecker = existsChecker;
            this.convertToUtil = convertToUtil;
            this.variableUtil = variableUtil;
            this.iHighDecimal = iHighDecimal;
            this.iMidnightOf = iMidnightOf;
            this.iLowDecimal = iLowDecimal;
            this.stringUtil = stringUtil;
            this.iDayEndOf = iDayEndOf;
            this.iHighDate = iHighDate;
            this.iLowDate = iLowDate;
            this.iHighString = iHighString;
            this.iLowString = iLowString;
            this.mathUtil = mathUtil;
            this.sQLUtil = sQLUtil;
            this.defineProcessVariable = defineProcessVariable;
            this.getVariable = getVariable;
            this.mgSessionVariableBasedCache = mgSessionVariableBasedCache;
            this.queryLanguage = queryLanguage;
            this.bookmarkFactory = bookmarkFactory;
            this.sortOrderFactory = sortOrderFactory;
            this.loadType = bunchedLoadCollection.LoadType;
            this.recordCap = bunchedLoadCollection.RecordCap;
            this.logger = logger;
            if (recordCap == -1)
            {
                recordCap = 5000;
            }
        }

        void LogTiming(string message)
        {
            var timing = DateTime.Now - startTime;
            logger.Performance(this.GetType().Name, $"{message} - {timing.ToString("c")}");
            startTime = DateTime.Now;
        }

        public (
            ICollectionLoadResponse Data,
            int? ReturnCode)
        Rpt_GeneralLedgerTransactionSp(
            decimal? ExOptStartingTrans = null,
            decimal? ExOptEndingTrans = null,
            string ExOptStartingRef = null,
            string ExOptEndingRef = null,
            int? TAnalyticalLedger = null,
            DateTime? ExOptStartingTransDate = null,
            DateTime? ExOptEndingTransDate = null,
            string ExOptStartingAcc = null,
            string ExOptEndingAcc = null,
            string ExOptacChartType = null,
            string ExOptBegAcctUnit1 = null,
            string ExOptEndAcctUnit1 = null,
            string ExOptBegAcctUnit2 = null,
            string ExOptEndAcctUnit2 = null,
            string ExOptBegAcctUnit3 = null,
            string ExOptEndAcctUnit3 = null,
            string ExOptBegAcctUnit4 = null,
            string ExOptEndAcctUnit4 = null,
            string ExOptSortBy = null,
            int? StartingTransDateOffset = null,
            int? EndingTransDateOffset = null,
            int? DisplayHeader = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            string pSite = null)
        {

            ICollectionLoadResponse Data = null;
            startTime = DateTime.Now;

            // LOG TIMING
            LogTiming($"start time: {startTime}");

            if (bunchedLoadCollection != null)
                bunchedLoadCollection.StartBunching();

            try
            {
                IBookmark nextBookmark = null;
                if (loadType == LoadType.Next)
                {
                    nextBookmark = mgSessionVariableBasedCache.Get<Bookmark>("BunchingBookmark");
                }

                // LOG TIMING
                LogTiming("MgSessionVariableBasedCache");

                StringType _ALTGEN_SpName = DBNull.Value;
                string ALTGEN_SpName = null;
                int? ALTGEN_Severity = null;
                int? Severity = null;
                SiteType _ParmsSite = DBNull.Value;
                string ParmsSite = null;
                ListSiteEntityType _SiteType = DBNull.Value;
                string SiteType = null;
                int? LedgerCancellationParm = null;
                int? ThailandCountryPack = null;
                string ProductName = null;
                string FeatureRS8071 = null;
                int? FeatureRS8071Active = null;
                string FeatureInfoBar = null;
                int? ExOptTransConditionExists = null;
                int? ExOptTransDateConditionExists = null;
                int? ExOptAccConditionExists = null;
                int? ExOptAccUnit1ConditionExists = null;
                int? ExOptAccUnit1EndConditionOnly = null;
                int? ExOptAccUnit2ConditionExists = null;
                int? ExOptAccUnit2EndConditionOnly = null;
                int? ExOptAccUnit3ConditionExists = null;
                int? ExOptAccUnit3EndConditionOnly = null;
                int? ExOptAccUnit4ConditionExists = null;
                int? ExOptAccUnit4EndConditionOnly = null;
                int? ExOptRefConditionExists = null;
                int? ExOptRefEndConditionOnly = null;
                string LowStringFnUnitCode1Type = null;
                string HighStringFnUnitCode1Type = null;
                string QuotedValueParmSite = null;

                // LOG TIMING
                LogTiming("Init Variables");

                if (existsChecker.Exists(tableName: "optional_module",
                    fromClause: collectionLoadRequestFactory.Clause("AS [om]"),
                    whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_GeneralLedgerTransactionSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"))
                )
                {
                    // LOG TIMING
                    LogTiming("Exist Checker optional_module");

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
                        whereClause: collectionLoadRequestFactory.Clause("ISNULL([om].[is_enabled], 0) = 1 AND OBJECT_ID(QUOTENAME('Rpt_GeneralLedgerTransactionSp' + CHAR(95) + [om].[ModuleName])) IS NOT NULL"),
                        orderByClause: collectionLoadRequestFactory.Clause(""));
                    var optional_module1LoadResponse = this.appDB.Load(optional_module1LoadRequest);
                    #endregion  LoadToRecord

                    #region CRUD InsertByRecords
                    foreach (var optional_module1Item in optional_module1LoadResponse.Items)
                    {
                        optional_module1Item.SetValue<string>("SpName", stringUtil.QuoteName(stringUtil.Concat("Rpt_GeneralLedgerTransactionSp", stringUtil.Char(95), optional_module1Item.GetValue<string>("u0"))));
                    };

                    var optional_module1RequiredColumns = new List<string>() { "SpName" };

                    // LOG TIMING
                    LogTiming("InsertByRecords loop optional_module1LoadResponse");

                    optional_module1LoadResponse = collectionLoadResponseUtil.ExtractRequiredColumns(optional_module1LoadResponse, optional_module1RequiredColumns);

                    // LOG TIMING
                    LogTiming("ExtractRequiredColumns optional_module1LoadResponse");

                    var optional_module1InsertRequest = collectionInsertRequestFactory.SQLInsert(tableName: "#tv_ALTGEN",
                        items: optional_module1LoadResponse.Items);

                    this.appDB.Insert(optional_module1InsertRequest);

                    // LOG TIMING
                    LogTiming("InsertByRecords appDb");
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

                        var ALTGEN = AltExtGen_Rpt_GeneralLedgerTransactionSp(ALTGEN_SpName,
                            ExOptStartingTrans,
                            ExOptEndingTrans,
                            ExOptStartingRef,
                            ExOptEndingRef,
                            TAnalyticalLedger,
                            ExOptStartingTransDate,
                            ExOptEndingTransDate,
                            ExOptStartingAcc,
                            ExOptEndingAcc,
                            ExOptacChartType,
                            ExOptBegAcctUnit1,
                            ExOptEndAcctUnit1,
                            ExOptBegAcctUnit2,
                            ExOptEndAcctUnit2,
                            ExOptBegAcctUnit3,
                            ExOptEndAcctUnit3,
                            ExOptBegAcctUnit4,
                            ExOptEndAcctUnit4,
                            ExOptSortBy,
                            StartingTransDateOffset,
                            EndingTransDateOffset,
                            DisplayHeader,
                            ShowInternal,
                            ShowExternal,
                            pSite);
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
                if (this.scalarFunction.Execute<int?>("OBJECT_ID", "dbo.EXTGEN_Rpt_GeneralLedgerTransactionSp") != null)
                {
                    var EXTGEN = AltExtGen_Rpt_GeneralLedgerTransactionSp("dbo.EXTGEN_Rpt_GeneralLedgerTransactionSp",
                        ExOptStartingTrans,
                        ExOptEndingTrans,
                        ExOptStartingRef,
                        ExOptEndingRef,
                        TAnalyticalLedger,
                        ExOptStartingTransDate,
                        ExOptEndingTransDate,
                        ExOptStartingAcc,
                        ExOptEndingAcc,
                        ExOptacChartType,
                        ExOptBegAcctUnit1,
                        ExOptEndAcctUnit1,
                        ExOptBegAcctUnit2,
                        ExOptEndAcctUnit2,
                        ExOptBegAcctUnit3,
                        ExOptEndAcctUnit3,
                        ExOptBegAcctUnit4,
                        ExOptEndAcctUnit4,
                        ExOptSortBy,
                        StartingTransDateOffset,
                        EndingTransDateOffset,
                        DisplayHeader,
                        ShowInternal,
                        ShowExternal,
                        pSite);
                    int? EXTGEN_Severity = EXTGEN.ReturnCode;

                    if (EXTGEN_Severity != 1)
                    {
                        return (EXTGEN.Data, EXTGEN_Severity);
                    }
                }

                // LOG TIMING
                LogTiming("END OF ALTGEN/EXTGEN");

                this.sQLExpressionExecutor.Execute("SET XACT_ABORT ON");

                if (sQLUtil.SQLEqual(this.iGetIsolationLevel.GetIsolationLevelFn("GeneralLedgerTransactionReport"), "COMMITTED") == true)
                {
                    this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ COMMITTED");
                }
                else
                {
                    // LOG TIMING
                    LogTiming("GetIsolationLevelFn Else");
                    this.transactionFactory.SetIsolationLevel("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED");
                }

                DisplayHeader = (int?)(stringUtil.IsNull(
                    DisplayHeader,
                    1));

                ShowInternal = (int?)(stringUtil.IsNull(
                    ShowInternal,
                    0));

                ShowExternal = (int?)(stringUtil.IsNull(
                    ShowExternal,
                    1));

                TAnalyticalLedger = (int?)(stringUtil.IsNull(
                    TAnalyticalLedger,
                    0));

                if (sQLUtil.SQLEqual(ExOptBegAcctUnit1, "NULL") == true)
                {
                    ExOptBegAcctUnit1 = null;
                }
                if (sQLUtil.SQLEqual(ExOptEndAcctUnit1, "NULL") == true)
                {
                    ExOptEndAcctUnit1 = null;
                }
                if (sQLUtil.SQLEqual(ExOptBegAcctUnit2, "NULL") == true)
                {
                    ExOptBegAcctUnit2 = null;
                }
                if (sQLUtil.SQLEqual(ExOptEndAcctUnit2, "NULL") == true)
                {
                    ExOptEndAcctUnit2 = null;
                }
                if (sQLUtil.SQLEqual(ExOptBegAcctUnit3, "NULL") == true)
                {
                    ExOptBegAcctUnit3 = null;
                }
                if (sQLUtil.SQLEqual(ExOptEndAcctUnit3, "NULL") == true)
                {
                    ExOptEndAcctUnit3 = null;
                }
                if (sQLUtil.SQLEqual(ExOptBegAcctUnit4, "NULL") == true)
                {
                    ExOptBegAcctUnit4 = null;
                }
                if (sQLUtil.SQLEqual(ExOptEndAcctUnit4, "NULL") == true)
                {
                    ExOptEndAcctUnit4 = null;
                }
                if (ExOptStartingTransDate != null)
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: ExOptStartingTransDate,
                        Offset: StartingTransDateOffset,
                        IsEndDate: 0);
                    ExOptStartingTransDate = ApplyDateOffset.Date;

                    #endregion ExecuteMethodCall

                    LogTiming("ApplyDateOffset");

                }
                if (ExOptEndingTransDate != null)
                {

                    #region CRUD ExecuteMethodCall

                    //Please Generate the bounce for this stored procedure: ApplyDateOffsetSp
                    var ApplyDateOffset1 = this.iApplyDateOffset.ApplyDateOffsetSp(
                        Date: ExOptEndingTransDate,
                        Offset: EndingTransDateOffset,
                        IsEndDate: 1);
                    ExOptEndingTransDate = ApplyDateOffset1.Date;

                    #endregion ExecuteMethodCall

                    LogTiming("ApplyDateOffset1");
                }
                ExOptSortBy = stringUtil.IsNull(
                    ExOptSortBy,
                    "T");
                Severity = 0;
                SiteType = "";
                ProductName = "CSI";
                FeatureRS8071 = "RS8071";

                #region CRUD ExecuteMethodCall

                //Please Generate the bounce for this stored procedure: IsFeatureActiveSp
                var IsFeatureActive = this.iIsFeatureActive.IsFeatureActiveSp(
                    ProductName: ProductName,
                    FeatureID: FeatureRS8071,
                    FeatureActive: FeatureRS8071Active,
                    InfoBar: FeatureInfoBar);
                Severity = IsFeatureActive.ReturnCode;
                FeatureRS8071Active = IsFeatureActive.FeatureActive;
                FeatureInfoBar = IsFeatureActive.InfoBar;

                #endregion ExecuteMethodCall

                LogTiming("IsFeatureActive");

                if (sQLUtil.SQLNotEqual(Severity, 0) == true)
                {
                    return (Data, Severity);
                }

                // Refactored - Removed ConvertToUtil
                ThailandCountryPack = sQLUtil.SQLEqual(
                       this.iIsAddonAvailable.IsAddonAvailableFn("ThailandCountryPack"), 1) == true
                       && sQLUtil.SQLEqual(FeatureRS8071Active, 1) == true ? 1 : 0;

                // LOG TIMING
                LogTiming("convertToUtil.ToInt32 ThailandCountryPack");

                // Refactored - Removed Cast to int
                ThailandCountryPack = stringUtil.IsNull(
                    ThailandCountryPack,
                    0);

                // LOG TIMING
                LogTiming("ThailandCountryPack IsNull");

                #region CRUD LoadToVariable
                var siteLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByVariableToAssign: new Dictionary<IUDDTType, string>()
                    {
                        {_SiteType,"site.type"},
                        {_ParmsSite,"parms.site"},
                    },
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: "site",
                    fromClause: collectionLoadRequestFactory.Clause(" ,parms"),
                    whereClause: collectionLoadRequestFactory.Clause("site.site = parms.Site"),
                    orderByClause: collectionLoadRequestFactory.Clause(""));
                var siteLoadResponse = this.appDB.Load(siteLoadRequest);
                if (siteLoadResponse.Items.Count > 0)
                {
                    SiteType = _SiteType;
                    ParmsSite = _ParmsSite;
                }
                #endregion  LoadToVariable

                LogTiming("siteLoadRequest");

                if (existsChecker.Exists(tableName: "parms",
                    fromClause: collectionLoadRequestFactory.Clause(""),
                    whereClause: collectionLoadRequestFactory.Clause("enable_cancellation_posting = 1 AND parm_key = 0"))
                )
                {
                    LedgerCancellationParm = 1;
                }
                else
                {
                    LedgerCancellationParm = 0;
                }

                // LOG TIMING
                LogTiming("Exist Checker parms");

                if (ExOptStartingTransDate != null)
                {
                    ExOptStartingTransDate = convertToUtil.ToDateTime(this.iMidnightOf.MidnightOfFn(ExOptStartingTransDate));
                }
                if (ExOptEndingTransDate != null)
                {
                    ExOptEndingTransDate = convertToUtil.ToDateTime(this.iDayEndOf.DayEndOfFn(ExOptEndingTransDate));
                }

                ExOptTransConditionExists = (ExOptStartingTrans != null || ExOptEndingTrans != null) ? 1 : 0;
                ExOptStartingTrans = convertToUtil.ToDecimal(stringUtil.IsNull(
                    ExOptStartingTrans,
                    this.iLowDecimal.LowDecimalFn("MatlTransNumType")));
                ExOptEndingTrans = convertToUtil.ToDecimal(stringUtil.IsNull(
                    ExOptEndingTrans,
                    this.iHighDecimal.HighDecimalFn("MatlTransNumType")));

                ExOptTransDateConditionExists = (ExOptStartingTransDate != null || ExOptEndingTransDate != null) ? 1 : 0;
                ExOptStartingTransDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                    ExOptStartingTransDate,
                    this.iLowDate.LowDateFn()));
                ExOptEndingTransDate = convertToUtil.ToDateTime(stringUtil.IsNull(
                    ExOptEndingTransDate,
                    this.iHighDate.HighDateFn()));

                ExOptAccConditionExists = (ExOptStartingAcc != null || ExOptEndingAcc != null) ? 1 : 0;
                ExOptStartingAcc = stringUtil.IsNull(
                    ExOptStartingAcc,
                    this.iLowString.LowStringFn("AcctType"));
                ExOptEndingAcc = stringUtil.IsNull(
                    ExOptEndingAcc,
                    this.iHighString.HighStringFn("AcctType"));

                // Refactored - multiple calls of LowStringFn and HighStringFn
                LowStringFnUnitCode1Type = this.iLowString.LowStringFn("UnitCode1Type");
                HighStringFnUnitCode1Type = this.iHighString.HighStringFn("UnitCode1Type");

                ExOptAccUnit1ConditionExists = (ExOptBegAcctUnit1 != null || ExOptEndAcctUnit1 != null) ? 1 : 0;
                ExOptAccUnit1EndConditionOnly = (ExOptBegAcctUnit1 == null && ExOptEndAcctUnit1 != null) ? 1 : 0;
                ExOptBegAcctUnit1 = stringUtil.IsNull(
                    ExOptBegAcctUnit1,
                    LowStringFnUnitCode1Type);
                ExOptEndAcctUnit1 = stringUtil.IsNull(
                    ExOptEndAcctUnit1,
                    HighStringFnUnitCode1Type);

                ExOptAccUnit2ConditionExists = (ExOptBegAcctUnit2 != null || ExOptEndAcctUnit2 != null) ? 1 : 0;
                ExOptAccUnit2EndConditionOnly = (ExOptBegAcctUnit2 == null && ExOptEndAcctUnit2 != null) ? 1 : 0;
                ExOptBegAcctUnit2 = stringUtil.IsNull(
                    ExOptBegAcctUnit2,
                    LowStringFnUnitCode1Type);
                ExOptEndAcctUnit2 = stringUtil.IsNull(
                    ExOptEndAcctUnit2,
                    HighStringFnUnitCode1Type);

                ExOptAccUnit3ConditionExists = (ExOptBegAcctUnit3 != null || ExOptEndAcctUnit3 != null) ? 1 : 0;
                ExOptAccUnit3EndConditionOnly = (ExOptBegAcctUnit3 == null && ExOptEndAcctUnit3 != null) ? 1 : 0;
                ExOptBegAcctUnit3 = stringUtil.IsNull(
                    ExOptBegAcctUnit3,
                    LowStringFnUnitCode1Type);
                ExOptEndAcctUnit3 = stringUtil.IsNull(
                    ExOptEndAcctUnit3,
                    HighStringFnUnitCode1Type);

                ExOptAccUnit4ConditionExists = (ExOptBegAcctUnit4 != null || ExOptEndAcctUnit4 != null) ? 1 : 0;
                ExOptAccUnit4EndConditionOnly = (ExOptBegAcctUnit4 == null && ExOptEndAcctUnit4 != null) ? 1 : 0;
                ExOptBegAcctUnit4 = stringUtil.IsNull(
                    ExOptBegAcctUnit4,
                    LowStringFnUnitCode1Type);
                ExOptEndAcctUnit4 = stringUtil.IsNull(
                    ExOptEndAcctUnit4,
                    HighStringFnUnitCode1Type);

                ExOptRefConditionExists = (ExOptStartingRef != null || ExOptEndingRef != null) ? 1 : 0;
                ExOptRefEndConditionOnly = (ExOptStartingRef == null && ExOptEndingRef != null) ? 1 : 0;
                ExOptStartingRef = stringUtil.IsNull(
                    ExOptStartingRef,
                    LowStringFnUnitCode1Type);
                ExOptEndingRef = stringUtil.IsNull(
                    ExOptEndingRef,
                    HighStringFnUnitCode1Type);

                // LOG TIMING
                LogTiming("convertToUtil.ToDateTime IsNull functions");

                #region CRUD LoadToRecord               
                var tableName = TAnalyticalLedger == 1 ? "ana_ledger" : "ledger";

                // Refactored - multiple calls of GetQuotedValue
                QuotedValueParmSite = variableUtil.GetQuotedValue<string>(ParmsSite);

                var loadDictionary = new Dictionary<string, string>()
                {
                    {"l.trans_num","l.trans_num"},
                    {"analedgerTransDate","l.trans_date"},
                    {"analedgeracct","l.acct"},
                    {"analedgeracct_unit1","l.acct_unit1"},
                    {"analedgeracct_unit2","l.acct_unit2"},
                    {"analedgeracct_unit3","l.acct_unit3"},
                    {"analedgeracct_unit4","l.acct_unit4"},
                    {"l.Ref","l.Ref"},
                    {"analedgeracctBank_Code","l.Bank_Code"},
                    {"dom_tc_amt_dr_amount",$"(CASE WHEN l.dom_amount > 0 Then ABS(l.dom_amount) * (CASE WHEN {LedgerCancellationParm} * ISNULL({(TAnalyticalLedger == 1 ? "0" : "l.cancellation")},0) > 0 THEN -1 ELSE 1 END) ELSE NULL END)"},
                    {"dom_tc_amt_cr_amount",$"(CASE WHEN l.dom_amount < 0 Then ABS(l.dom_amount) * (CASE WHEN {LedgerCancellationParm} * ISNULL({(TAnalyticalLedger == 1 ? "0" : "l.cancellation")},0) > 0 THEN -1 ELSE 1 END) ELSE NULL END)"},
                    {"l.site","l.site"},
                    {"chartdescription","c.description"},
                    {"analedgercurr_code",$"(CASE WHEN {QuotedValueParmSite} <> 'E' THEN l.curr_code ELSE NULL END )"},
                    {"analedgerexch_rate",$"(CASE WHEN {QuotedValueParmSite} <> 'E' THEN l.exch_rate END)"},
                    {"tc_amt_dr_amount",$"(CASE WHEN  {QuotedValueParmSite} <> 'E' THEN (CASE WHEN l.for_amount > 0 Then ABS(l.for_amount) * (CASE WHEN {LedgerCancellationParm} * ISNULL({(TAnalyticalLedger == 1 ? "0" : "l.cancellation")},0) > 0 THEN -1 ELSE 1 END) ELSE NULL END) ELSE NULL END)"},
                    { "tc_amt_cr_amount",$"(CASE WHEN  {QuotedValueParmSite} <> 'E' THEN (CASE WHEN l.for_amount < 0 Then ABS(l.for_amount) * (CASE WHEN {LedgerCancellationParm} * ISNULL({(TAnalyticalLedger == 1 ? "0" : "l.cancellation")},0) > 0 THEN -1 ELSE 1 END) ELSE NULL END) ELSE NULL END)"},
                    { "RowPointer","l.RowPointer"},
                    {"NotesExist",$@"case when l.NoteExistsFlag = 0 OR ({ShowInternal} = 0 AND {ShowExternal} = 0)  then 0 
                         when l.NoteExistsFlag = 1 AND ({ShowInternal} = 1 AND {ShowExternal} = 1) then 1
	                     else (select case when count(1) > 0 then 1 else 0 end FROM ObjectNotes obn
                                       INNER JOIN NoteHeaders nth ON nth.NoteHeaderToken = obn.NoteHeaderToken
                                       LEFT OUTER JOIN SpecificNotes spc ON spc.SpecificNoteToken = obn.SpecificNoteToken
                                       LEFT OUTER JOIN SystemNotes syn ON syn.SystemNoteToken = obn.SystemNoteToken
                               WHERE ISNULL(spc.NoteContent, '') NOT LIKE N'ATTACHMENT: <%'
                             AND nth.ObjectName    = {variableUtil.GetQuotedValue<string>(tableName)}
                             AND obn.RefRowPointer = l.RowPointer
                             AND (({ShowInternal} = 1 AND nth.NoteFlag = 1)
                                   OR ({ShowExternal} = 1 AND nth.NoteFlag = 0)))
                    end"},
                    {"top_group","1"},
                    {"TH_payment_number",(ThailandCountryPack == 1 && TAnalyticalLedger == 0) ? "l.TH_payment_number" : "CAST (NULL AS NVARCHAR)"},
                };

                Dictionary<string, SortOrderDirection> dicSortOrder = new Dictionary<string, SortOrderDirection>();
                if (ExOptSortBy.Equals("T"))
                {
                    dicSortOrder.Add("l.trans_num", SortOrderDirection.Ascending);
                    dicSortOrder.Add("l.site", SortOrderDirection.Ascending);
                }
                else
                {
                    dicSortOrder.Add("l.Ref", SortOrderDirection.Ascending);
                    dicSortOrder.Add("l.trans_num", SortOrderDirection.Ascending);
                    dicSortOrder.Add("l.site", SortOrderDirection.Ascending);
                }
                var ledgerSortOrder = sortOrderFactory.Create(dicSortOrder);
                var whereClause = collectionLoadRequestFactory.Clause("1 = 1 AND ({9} = 0 OR (l.trans_num BETWEEN {15} AND {24})) AND ({0} = 0 OR (l.trans_date BETWEEN {13} AND {14})) AND ({11} = 0 OR (c.acct BETWEEN {25} AND {28})) AND ({5} = 0 OR ({1} = 1 AND l.acct_unit1 IS NULL) OR (l.acct_unit1 BETWEEN {16} AND {17})) AND ({6} = 0 OR ({2} = 1 AND l.acct_unit2 IS NULL) OR (l.acct_unit2 BETWEEN {18} AND {19})) AND ({7} = 0 OR ({3} = 1 AND l.acct_unit3 IS NULL) OR (l.acct_unit3 BETWEEN {20} AND {21})) AND ({8} = 0 OR ({4} = 1 AND l.acct_unit4 IS NULL) OR (l.acct_unit4 BETWEEN {22} AND {23})) AND ({12} = 0 OR ({10} = 1 AND l.ref IS NULL) OR (l.ref BETWEEN {26} AND {29})) AND (({27} IS NOT NULL AND CHARINDEX(c.type, {27}) > 0) OR ({27} IS NULL)) AND ({31} <> 'S' OR ({31} = 'S' AND l.site = {30}))", ExOptTransDateConditionExists, ExOptAccUnit1EndConditionOnly, ExOptAccUnit2EndConditionOnly, ExOptAccUnit3EndConditionOnly, ExOptAccUnit4EndConditionOnly, ExOptAccUnit1ConditionExists, ExOptAccUnit2ConditionExists, ExOptAccUnit3ConditionExists, ExOptAccUnit4ConditionExists, ExOptTransConditionExists, ExOptRefEndConditionOnly, ExOptAccConditionExists, ExOptRefConditionExists, ExOptStartingTransDate, ExOptEndingTransDate, ExOptStartingTrans, ExOptBegAcctUnit1, ExOptEndAcctUnit1, ExOptBegAcctUnit2, ExOptEndAcctUnit2, ExOptBegAcctUnit3, ExOptEndAcctUnit3, ExOptBegAcctUnit4, ExOptEndAcctUnit4, ExOptEndingTrans, ExOptStartingAcc, ExOptStartingRef, ExOptacChartType, ExOptEndingAcc, ExOptEndingRef, ParmsSite, SiteType);
                if (nextBookmark != null)
                {
                    whereClause = queryLanguage.AppendBookmark(whereClause, nextBookmark);
                }
                var orderByColumns = ExOptSortBy.Equals("T") ? "l.trans_num, l.site" : "l.Ref, l.trans_num, l.site";
                var ledgerLoadRequest = collectionLoadRequestFactory.SQLLoad(columnExpressionByColumnName: loadDictionary,
                    loadForChange: false, 
                    lockingType: LockingType.None,
                    tableName: tableName,
                    fromClause: collectionLoadRequestFactory.Clause(" AS l INNER JOIN chart AS c ON c.acct = l.acct"),
                    whereClause: whereClause,
                    orderByClause: collectionLoadRequestFactory.Clause(orderByColumns),
                    maximumRows: recordCap == 0 ? recordCap : recordCap + 1);
                var ledgerLoadResponse = this.appDB.Load(ledgerLoadRequest);
                #endregion  LoadToRecord             

                // LOG TIMING
                LogTiming("LoadToRecord ledger");

                if (ledgerLoadResponse.Items.Count > 1)
                {
                    mgSessionVariableBasedCache.Insert("BunchingBookmark", (ICachable)bookmarkFactory.Create(ledgerLoadResponse.Items[ledgerLoadResponse.Items.Count - 2], ledgerSortOrder));
                }

                // LOG TIMING
                LogTiming("mgSessionVariableBasedCache");

                Data = ledgerLoadResponse;

                (int? returnCode, string variableValue, string infobar) = getVariable.GetVariableSp("BunchingBookmark", "", 0, "", "");
                if (!string.IsNullOrEmpty(variableValue))
                {
                    defineProcessVariable.DefineProcessVariableSp("Bookmark", variableValue, infobar);
                }

                // LOG TIMING
                LogTiming("END");

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
        AltExtGen_Rpt_GeneralLedgerTransactionSp(
            string AltExtGenSp,
            decimal? ExOptStartingTrans = null,
            decimal? ExOptEndingTrans = null,
            string ExOptStartingRef = null,
            string ExOptEndingRef = null,
            int? TAnalyticalLedger = null,
            DateTime? ExOptStartingTransDate = null,
            DateTime? ExOptEndingTransDate = null,
            string ExOptStartingAcc = null,
            string ExOptEndingAcc = null,
            string ExOptacChartType = null,
            string ExOptBegAcctUnit1 = null,
            string ExOptEndAcctUnit1 = null,
            string ExOptBegAcctUnit2 = null,
            string ExOptEndAcctUnit2 = null,
            string ExOptBegAcctUnit3 = null,
            string ExOptEndAcctUnit3 = null,
            string ExOptBegAcctUnit4 = null,
            string ExOptEndAcctUnit4 = null,
            string ExOptSortBy = null,
            int? StartingTransDateOffset = null,
            int? EndingTransDateOffset = null,
            int? DisplayHeader = null,
            int? ShowInternal = null,
            int? ShowExternal = null,
            string pSite = null)
        {
            MatlTransNumType _ExOptStartingTrans = ExOptStartingTrans;
            MatlTransNumType _ExOptEndingTrans = ExOptEndingTrans;
            ReferenceType _ExOptStartingRef = ExOptStartingRef;
            ReferenceType _ExOptEndingRef = ExOptEndingRef;
            ListYesNoType _TAnalyticalLedger = TAnalyticalLedger;
            DateType _ExOptStartingTransDate = ExOptStartingTransDate;
            DateType _ExOptEndingTransDate = ExOptEndingTransDate;
            AcctType _ExOptStartingAcc = ExOptStartingAcc;
            AcctType _ExOptEndingAcc = ExOptEndingAcc;
            InfobarType _ExOptacChartType = ExOptacChartType;
            UnitCode1Type _ExOptBegAcctUnit1 = ExOptBegAcctUnit1;
            UnitCode1Type _ExOptEndAcctUnit1 = ExOptEndAcctUnit1;
            UnitCode1Type _ExOptBegAcctUnit2 = ExOptBegAcctUnit2;
            UnitCode1Type _ExOptEndAcctUnit2 = ExOptEndAcctUnit2;
            UnitCode1Type _ExOptBegAcctUnit3 = ExOptBegAcctUnit3;
            UnitCode1Type _ExOptEndAcctUnit3 = ExOptEndAcctUnit3;
            UnitCode1Type _ExOptBegAcctUnit4 = ExOptBegAcctUnit4;
            UnitCode1Type _ExOptEndAcctUnit4 = ExOptEndAcctUnit4;
            StringType _ExOptSortBy = ExOptSortBy;
            DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
            DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
            ListYesNoType _DisplayHeader = DisplayHeader;
            FlagNyType _ShowInternal = ShowInternal;
            FlagNyType _ShowExternal = ShowExternal;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();
                IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = AltExtGenSp;

                appDB.AddCommandParameter(cmd, "ExOptStartingTrans", _ExOptStartingTrans, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingTrans", _ExOptEndingTrans, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptStartingRef", _ExOptStartingRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingRef", _ExOptEndingRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAnalyticalLedger", _TAnalyticalLedger, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptStartingTransDate", _ExOptStartingTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingTransDate", _ExOptEndingTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptStartingAcc", _ExOptStartingAcc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingAcc", _ExOptEndingAcc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptacChartType", _ExOptacChartType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit1", _ExOptBegAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit1", _ExOptEndAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit2", _ExOptBegAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit2", _ExOptEndAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit3", _ExOptBegAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit3", _ExOptEndAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit4", _ExOptBegAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit4", _ExOptEndAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptSortBy", _ExOptSortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

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
