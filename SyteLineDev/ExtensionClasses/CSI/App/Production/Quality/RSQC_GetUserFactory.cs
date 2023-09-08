//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUserFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.Quality
{
    public class RSQC_GetUserFactory
    {
        public const string IDO = "RS_QCCRcvrs";
        public const string Method = "RSQC_GetUser";

        public IRSQC_GetUser Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var iRSQC_GetUserCRUD = new RSQC_GetUserCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                iIsAddonAvailable,
                existsChecker);

            IRSQC_GetUser _RSQC_GetUser = new RSQC_GetUser(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iIsAddonAvailable,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iRSQC_GetUserCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _RSQC_GetUser = IDOMethodIntercept<IRSQC_GetUser>.Create(_RSQC_GetUser, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRSQC_GetUserExt = timerfactory.Create<IRSQC_GetUser>(_RSQC_GetUser);

            return iRSQC_GetUserExt;
        }
    }
}