//PROJECT NAME: Logistics
//CLASS NAME: CLM_GetARBalanceFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Finance.AR;

namespace CSI.Logistics.Customer
{
    public class CLM_GetARBalanceFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "CLM_GetARBalance";

        public ICLM_GetARBalance Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iARAgingBuckets = new ARAgingBucketsFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_GetARBalance _CLM_GetARBalance = new CLM_GetARBalance(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iARAgingBuckets,
                scalarFunction,
                existsChecker,
                variableUtil,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_GetARBalance = IDOMethodIntercept<ICLM_GetARBalance>.Create(_CLM_GetARBalance, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_GetARBalanceExt = timerfactory.Create<ICLM_GetARBalance>(_CLM_GetARBalance);

            return iCLM_GetARBalanceExt;
        }
    }
}