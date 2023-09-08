//PROJECT NAME: Logistics
//CLASS NAME: CLM_CashImpactGridFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
    public class CLM_CashImpactGridFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "CLM_CashImpactGrid";

        public ICLM_CashImpactGrid Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iRpt_CashImpactSub = new Rpt_CashImpactSubFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iSqlFilter = cSIExtensionClassBase.MongooseDependencies.SqlFilter;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_CashImpactGrid _CLM_CashImpactGrid = new CLM_CashImpactGrid(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                iRpt_CashImpactSub,
                iExecuteDynamicSQL,
                scalarFunction,
                existsChecker,
                variableUtil,
                stringUtil,
                iSqlFilter,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_CashImpactGrid = IDOMethodIntercept<ICLM_CashImpactGrid>.Create(_CLM_CashImpactGrid, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_CashImpactGridExt = timerfactory.Create<ICLM_CashImpactGrid>(_CLM_CashImpactGrid);

            return iCLM_CashImpactGridExt;
        }
    }
}
