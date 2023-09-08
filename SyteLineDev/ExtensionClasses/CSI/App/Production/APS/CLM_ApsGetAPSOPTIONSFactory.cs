//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetAPSOPTIONSFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
    public class CLM_ApsGetAPSOPTIONSFactory
    {
        public const string IDO = "SLAPSOPTIONSnnns";
        public const string Method = "CLM_ApsGetAPSOPTIONS";

        public ICLM_ApsGetAPSOPTIONS Create(
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
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_ApsGetAPSOPTIONS _CLM_ApsGetAPSOPTIONS = new CLM_ApsGetAPSOPTIONS(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                sQLCollectionLoad,
                scalarFunction,
                existsChecker,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ApsGetAPSOPTIONS = IDOMethodIntercept<ICLM_ApsGetAPSOPTIONS>.Create(_CLM_ApsGetAPSOPTIONS, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetAPSOPTIONSExt = timerfactory.Create<ICLM_ApsGetAPSOPTIONS>(_CLM_ApsGetAPSOPTIONS);

            return iCLM_ApsGetAPSOPTIONSExt;
        }
    }
}
