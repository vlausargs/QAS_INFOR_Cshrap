//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialTransactionsReportFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_MaterialTransactionsReportFactory
    {
        public const string IDO = "SLMaterialTransactionsReport";
        public const string Method = "Rpt_MaterialTransactionsReport";

        public IRpt_MaterialTransactionsReport Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iHighDecimal = new HighDecimalFactory().Create(cSIExtensionClassBase);
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var iLowDecimal = new LowDecimalFactory().Create(cSIExtensionClassBase);
            var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var iHighDate = cSIExtensionClassBase.MongooseDependencies.HighDate;
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var iHighInt = cSIExtensionClassBase.MongooseDependencies.HighInt;
            var iHighString = cSIExtensionClassBase.MongooseDependencies.HighString;
            var iLowString = cSIExtensionClassBase.MongooseDependencies.LowString;
            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iLowInt = cSIExtensionClassBase.MongooseDependencies.LowInt;
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkFactory = new BookmarkFactory();
            var sortOrderFactory = new SortOrderFactory();

            IRpt_MaterialTransactionsReport _Rpt_MaterialTransactionsReport = new Rpt_MaterialTransactionsReport(appDB,
                bunchedLoadCollection,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                iGetIsolationLevel,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iIsAddonAvailable,
                iApplyDateOffset,
                iDefineVariable,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                iHighDecimal,
                iMidnightOf,
                iLowDecimal,
                iHighAnyInt,
                stringUtil,
                iLowAnyInt,
                iDayEndOf,
                iHighDate,
                iLowDate,
                iHighInt,
                iHighString,
                iLowString,
                mathUtil,
                sQLUtil,
                iLowInt,
                defineProcessVariable,
                getVariable,
                mgSessionVariableBasedCache,
                queryLanguage,
                bookmarkFactory,
                sortOrderFactory);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_MaterialTransactionsReport = IDOMethodIntercept<IRpt_MaterialTransactionsReport>.Create(_Rpt_MaterialTransactionsReport, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_MaterialTransactionsReportExt = timerfactory.Create<IRpt_MaterialTransactionsReport>(_Rpt_MaterialTransactionsReport);

            return iRpt_MaterialTransactionsReportExt;
        }
    }
}
