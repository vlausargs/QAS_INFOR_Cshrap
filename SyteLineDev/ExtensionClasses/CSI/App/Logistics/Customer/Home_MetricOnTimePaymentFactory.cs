//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricOnTimePaymentFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;

namespace CSI.Logistics.Customer
{
    public class Home_MetricOnTimePaymentFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "Home_MetricOnTimePayment";

        public IHome_MetricOnTimePayment Create(
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
            var iPeriodsGetDates = new PeriodsGetDatesFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iPerGet = new PerGetFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var iHome_MetricOnTimePaymentCRUD = new Home_MetricOnTimePaymentCRUD(appDB, collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                variableUtil,
                sQLUtil,
                dateTimeUtil,
                stringUtil,
                collectionLoadResponseUtil);

            IHome_MetricOnTimePayment _Home_MetricOnTimePayment = new Home_MetricOnTimePayment(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                iPeriodsGetDates,
                scalarFunction,
                convertToUtil,
                iGetSiteDate,
                dateTimeUtil,
                iMidnightOf,
                stringUtil,
                iDayEndOf,
                sQLUtil,
                iPerGet,
                iHome_MetricOnTimePaymentCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Home_MetricOnTimePayment = IDOMethodIntercept<IHome_MetricOnTimePayment>.Create(_Home_MetricOnTimePayment, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_MetricOnTimePaymentExt = timerfactory.Create<IHome_MetricOnTimePayment>(_Home_MetricOnTimePayment);

            return iHome_MetricOnTimePaymentExt;
        }
    }
}