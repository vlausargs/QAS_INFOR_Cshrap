//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricShippingFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
    public class Home_MetricShippingFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "Home_MetricShipping";

        public IHome_MetricShipping Create(
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
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var iHome_MetricShippingCRUD = new Home_MetricShippingCRUD(appDB, collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                variableUtil,
                dateTimeUtil,
                stringUtil,
                sQLUtil,
                collectionLoadResponseUtil,
                sQLExpressionExecutor);

            IHome_MetricShipping _Home_MetricShipping = new Home_MetricShipping(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                scalarFunction,
                convertToUtil,
                iGetSiteDate,
                dateTimeUtil,
                iMidnightOf,
                stringUtil,
                iDayEndOf,
                iCurrCnvt,
                sQLUtil,
                iHome_MetricShippingCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Home_MetricShipping = IDOMethodIntercept<IHome_MetricShipping>.Create(_Home_MetricShipping, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_MetricShippingExt = timerfactory.Create<IHome_MetricShipping>(_Home_MetricShipping);

            return iHome_MetricShippingExt;
        }
    }
}