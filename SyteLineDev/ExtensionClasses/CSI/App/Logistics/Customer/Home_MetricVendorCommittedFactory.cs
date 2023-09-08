//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricVendorCommittedFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public class Home_MetricVendorCommittedFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "Home_MetricVendorCommitted";

        public IHome_MetricVendorCommitted Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var iHome_MetricVendorCommittedCRUD = new Home_MetricVendorCommittedCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil,
                collectionLoadResponseUtil);

            IHome_MetricVendorCommitted _Home_MetricVendorCommitted = new Home_MetricVendorCommitted(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iHome_MetricVendorCommittedCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Home_MetricVendorCommitted = IDOMethodIntercept<IHome_MetricVendorCommitted>.Create(_Home_MetricVendorCommitted, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_MetricVendorCommittedExt = timerfactory.Create<IHome_MetricVendorCommitted>(_Home_MetricVendorCommitted);

            return iHome_MetricVendorCommittedExt;
        }
    }
}
