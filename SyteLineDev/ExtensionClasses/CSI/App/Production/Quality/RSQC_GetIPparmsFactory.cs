//PROJECT NAME: Production
//CLASS NAME: RSQC_GetIPparmsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.Quality
{
    public class RSQC_GetIPparmsFactory
    {
        public const string IDO = "RS_QCIPRcpts";
        public const string Method = "RSQC_GetIPparms";

        public IRSQC_GetIPparms Create(
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
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var iRSQC_GetIPparmsCRUD = new RSQC_GetIPparmsCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            IRSQC_GetIPparms _RSQC_GetIPparms = new RSQC_GetIPparms(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iIsAddonAvailable,
                scalarFunction,
                sQLUtil,
                iRSQC_GetIPparmsCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _RSQC_GetIPparms = IDOMethodIntercept<IRSQC_GetIPparms>.Create(_RSQC_GetIPparms, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_GetIPparmsExt = timerfactory.Create<IRSQC_GetIPparms>(_RSQC_GetIPparms);

            return iRSQC_GetIPparmsExt;
        }
    }
}
