//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerTransactionFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Admin;
using CSI.Data.Cache;
using CSI.Logger;

namespace CSI.Reporting
{
    public class Rpt_GeneralLedgerTransactionFactory
    {
        public const string IDO = "SLGeneralLedgerTransactionReport";
        public const string Method = "Rpt_GeneralLedgerTransaction";

        public IRpt_GeneralLedgerTransaction Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
            var iReportNotesExist = new ReportNotesExistFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iIsFeatureActive = new IsFeatureActiveFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iHighDecimal = new HighDecimalFactory().Create(cSIExtensionClassBase);
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var iLowDecimal = new LowDecimalFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var iHighDate = cSIExtensionClassBase.MongooseDependencies.HighDate;
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var iHighString = cSIExtensionClassBase.MongooseDependencies.HighString;
            var iLowString = cSIExtensionClassBase.MongooseDependencies.LowString;
            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkFactory = new BookmarkFactory();
            var sortOrderFactory = new SortOrderFactory();
            var logger = new Logger.LoggerFactory().Create(LoggerType.Mongoose);

            IRpt_GeneralLedgerTransaction _Rpt_GeneralLedgerTransaction = new Rpt_GeneralLedgerTransaction(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                iGetIsolationLevel,
                iIsAddonAvailable,
                iReportNotesExist,
                iApplyDateOffset,
                iIsFeatureActive,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iHighDecimal,
                iMidnightOf,
                iLowDecimal,
                stringUtil,
                iDayEndOf,
                iHighDate,
                iLowDate,
                iHighString,
                iLowString,
                mathUtil,
                sQLUtil,
                defineProcessVariable,
                getVariable,
                mgSessionVariableBasedCache,
                queryLanguage,
                bookmarkFactory,
                sortOrderFactory,
                logger);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_GeneralLedgerTransaction = IDOMethodIntercept<IRpt_GeneralLedgerTransaction>.Create(_Rpt_GeneralLedgerTransaction, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_GeneralLedgerTransactionExt = timerfactory.Create<IRpt_GeneralLedgerTransaction>(_Rpt_GeneralLedgerTransaction);

            return iRpt_GeneralLedgerTransactionExt;
        }
    }
}
