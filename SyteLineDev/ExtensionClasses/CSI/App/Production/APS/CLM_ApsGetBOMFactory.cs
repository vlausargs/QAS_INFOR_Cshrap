//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetBOMFactory.cs

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
    public class CLM_ApsGetBOMFactory
    {
        public const string IDO = "SLBOMnnns";
        public const string Method = "CLM_ApsGetBOM";

        public ICLM_ApsGetBOM Create(
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
            var iCLM_ApsGetBOMCRUD = new CLM_ApsGetBOMCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                variableUtil,
                stringUtil);

            ICLM_ApsGetBOM _CLM_ApsGetBOM = new CLM_ApsGetBOM(bunchedLoadCollection,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExecuteDynamicSQL,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iCLM_ApsGetBOMCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ApsGetBOM = IDOMethodIntercept<ICLM_ApsGetBOM>.Create(_CLM_ApsGetBOM, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetBOMExt = timerfactory.Create<ICLM_ApsGetBOM>(_CLM_ApsGetBOM);

            return iCLM_ApsGetBOMExt;
        }
    }
}
