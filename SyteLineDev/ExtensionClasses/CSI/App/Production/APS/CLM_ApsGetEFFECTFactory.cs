//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetEFFECTFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Production.APS
{
    public class CLM_ApsGetEFFECTFactory
    {
        public const string IDO = "SLEFFECTnnns";
        public const string Method = "CLM_ApsGetEFFECT";

        public ICLM_ApsGetEFFECT Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var iCLM_ApsGetEFFECTCRUD = new CLM_ApsGetEFFECTCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                variableUtil,
                stringUtil, 
                sQLExpressionExecutor,
                collectionLoadResponseUtil);

            ICLM_ApsGetEFFECT _CLM_ApsGetEFFECT = new CLM_ApsGetEFFECT(bunchedLoadCollection,
                sQLExpressionExecutor,
                iExecuteDynamicSQL,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iCLM_ApsGetEFFECTCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ApsGetEFFECT = IDOMethodIntercept<ICLM_ApsGetEFFECT>.Create(_CLM_ApsGetEFFECT, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetEFFECTExt = timerfactory.Create<ICLM_ApsGetEFFECT>(_CLM_ApsGetEFFECT);

            return iCLM_ApsGetEFFECTExt;
        }
    }
}
