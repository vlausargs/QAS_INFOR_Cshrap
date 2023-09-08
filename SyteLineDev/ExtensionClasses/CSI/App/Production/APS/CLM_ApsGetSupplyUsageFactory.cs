//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSupplyUsageFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.CRUD.Production.APS;

namespace CSI.Production.APS
{
    public class CLM_ApsGetSupplyUsageFactory
    {
        public const string IDO = "SLSupplyUsages";
        public const string Method = "CLM_ApsGetSupplyUsage";

        public ICLM_ApsGetSupplyUsage Create(
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
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iCLM_ApsGetSupplyUsageCRUD = new CLM_ApsGetSupplyUsageCRUD(sQLCollectionLoad, sQLExpressionExecutor);

            ICLM_ApsGetSupplyUsage _CLM_ApsGetSupplyUsage = new CLM_ApsGetSupplyUsage(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                iCLM_ApsGetSupplyUsageCRUD,
                sQLExpressionExecutor,
                iExecuteDynamicSQL,
                sQLCollectionLoad,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iMidnightOf,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ApsGetSupplyUsage = IDOMethodIntercept<ICLM_ApsGetSupplyUsage>.Create(_CLM_ApsGetSupplyUsage, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetSupplyUsageExt = timerfactory.Create<ICLM_ApsGetSupplyUsage>(_CLM_ApsGetSupplyUsage);

            return iCLM_ApsGetSupplyUsageExt;
        }
    }
}
