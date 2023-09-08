//PROJECT NAME: Material
//CLASS NAME: CLM_CostingAltGetCompareFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Material
{
    public class CLM_CostingAltGetCompareFactory
    {
        public const string IDO = "SLCostingAltItems";
        public const string Method = "CLM_CostingAltGetCompare";

        public ICLM_CostingAltGetCompare Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_CostingAltGetCompare _CLM_CostingAltGetCompare = new CLM_CostingAltGetCompare(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExecuteDynamicSQL,
                sQLCollectionLoad,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_CostingAltGetCompare = IDOMethodIntercept<ICLM_CostingAltGetCompare>.Create(_CLM_CostingAltGetCompare, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_CostingAltGetCompareExt = timerfactory.Create<ICLM_CostingAltGetCompare>(_CLM_CostingAltGetCompare);

            return iCLM_CostingAltGetCompareExt;
        }
    }
}
