//PROJECT NAME: Finance
//CLASS NAME: CLM_JourTransMaintFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Finance
{
    public class CLM_JourTransMaintFactory
    {
        public const string IDO = "SLJournals";
        public const string Method = "CLM_JourTransMaint";

        public ICLM_JourTransMaint Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iBuildXMLFilterString = cSIExtensionClassBase.MongooseDependencies.BuildXMLFilterString;
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_JourTransMaint _CLM_JourTransMaint = new CLM_JourTransMaint(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iBuildXMLFilterString,
                transactionFactory,
                iExecuteDynamicSQL,
                scalarFunction,
                existsChecker,
                variableUtil,
                stringUtil,
                raiseError,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_JourTransMaint = IDOMethodIntercept<ICLM_JourTransMaint>.Create(_CLM_JourTransMaint, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_JourTransMaintExt = timerfactory.Create<ICLM_JourTransMaint>(_CLM_JourTransMaint);

            return iCLM_JourTransMaintExt;
        }
    }
}
