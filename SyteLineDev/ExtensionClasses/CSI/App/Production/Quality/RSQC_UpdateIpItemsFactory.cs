//PROJECT NAME: Production
//CLASS NAME: RSQC_UpdateIpItemsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.Quality
{
    public class RSQC_UpdateIpItemsFactory
    {
        public const string IDO = "RS_QCItemhs";
        public const string Method = "RSQC_UpdateIpItems";

        public IRSQC_UpdateIpItems Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var iRSQC_UpdateIpItemsCRUD = new RSQC_UpdateIpItemsCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            IRSQC_UpdateIpItems _RSQC_UpdateIpItems = new RSQC_UpdateIpItems(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iIsAddonAvailable,
                scalarFunction,
                sQLUtil,
                iRSQC_UpdateIpItemsCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _RSQC_UpdateIpItems = IDOMethodIntercept<IRSQC_UpdateIpItems>.Create(_RSQC_UpdateIpItems, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_UpdateIpItemsExt = timerfactory.Create<IRSQC_UpdateIpItems>(_RSQC_UpdateIpItems);

            return iRSQC_UpdateIpItemsExt;
        }
    }
}
