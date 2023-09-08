//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobCostDetailFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Production;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_EstimateJobCostDetailFactory
    {
        public const string IDO = "SLEstimateJobCostDetailReport";
        public const string Method = "Rpt_EstimateJobCostDetail";

        public IRpt_EstimateJobCostDetail Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iCostOperJobCost = new CostOperJobCostFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var highCharacter = cSIExtensionClassBase.MongooseDependencies.HighCharacter;
            var lowCharacter = cSIExtensionClassBase.MongooseDependencies.LowCharacter;
            var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var unionUtil = new UnionUtil(UnionType.UnionAll);
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);

            var recordStreamFactory = new RecordStreamFactory();
            var bookmarkFactory = new BookmarkFactory();
            var sortOrderFactory = new SortOrderFactory();

            var iRpt_EstimateJobCostDetailCRUD = new Rpt_EstimateJobCostDetailCRUD(appDB,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                transactionFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iGetIsolationLevel,
                existsChecker,
                stringUtil,
                sQLUtil,
                recordStreamFactory,
                sortOrderFactory,
                bookmarkFactory,
                queryLanguage,
                mgSessionVariableBasedCache);

            IRpt_EstimateJobCostDetail _Rpt_EstimateJobCostDetail = new Rpt_EstimateJobCostDetail(
                appDB,
                bunchedLoadCollection,
                collectionLoadRequestFactory,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iIsAddonAvailable,
                iApplyDateOffset,
                iCostOperJobCost,
                iExpandKyByType,
                scalarFunction,
                convertToUtil,
                highCharacter,
                lowCharacter,
                iHighAnyInt,
                stringUtil,
                unionUtil,
                iLowAnyInt,
                sQLUtil,
                defineProcessVariable,
                getVariable,
                recordStreamFactory,
                sortOrderFactory,
                queryLanguage,
                mgSessionVariableBasedCache,
                CachePageSize.XLarge,
                iRpt_EstimateJobCostDetailCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_EstimateJobCostDetail = IDOMethodIntercept<IRpt_EstimateJobCostDetail>.Create(_Rpt_EstimateJobCostDetail, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_EstimateJobCostDetailExt = timerfactory.Create<IRpt_EstimateJobCostDetail>(_Rpt_EstimateJobCostDetail);

            return iRpt_EstimateJobCostDetailExt;
        }
    }
}
