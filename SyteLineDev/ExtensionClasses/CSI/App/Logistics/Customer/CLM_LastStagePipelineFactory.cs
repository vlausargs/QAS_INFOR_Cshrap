//PROJECT NAME: Logistics
//CLASS NAME: CLM_LastStagePipelineFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public class CLM_LastStagePipelineFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "CLM_LastStagePipeline";

        public ICLM_LastStagePipeline Create(
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
            var convertToUtil = new ConvertToUtilFactory().Create();
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var iCLM_LastStagePipelineCRUD = new CLM_LastStagePipelineCRUD(appDB, collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                variableUtil,
                stringUtil);

            ICLM_LastStagePipeline _CLM_LastStagePipeline = new CLM_LastStagePipeline(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                convertToUtil,
                stringUtil,
                sQLUtil,
                iCLM_LastStagePipelineCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_LastStagePipeline = IDOMethodIntercept<ICLM_LastStagePipeline>.Create(_CLM_LastStagePipeline, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_LastStagePipelineExt = timerfactory.Create<ICLM_LastStagePipeline>(_CLM_LastStagePipeline);

            return iCLM_LastStagePipelineExt;
        }
    }
}
