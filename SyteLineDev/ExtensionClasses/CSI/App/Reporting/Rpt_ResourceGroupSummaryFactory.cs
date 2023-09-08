//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupSummaryFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Reporting
{
    public class Rpt_ResourceGroupSummaryFactory
    {
        public const string IDO = "SLResourceGroupSummaryReport";
        public const string Method = "Rpt_ResourceGroupSummary";

        private readonly ICloseSessionContextFactory iCloseSessionContextFactory;
        private readonly IInitSessionContextFactory iInitSessionContextFactory;
        private readonly IGetIsolationLevelFactory iGetIsolationLevelFactory;
        public Rpt_ResourceGroupSummaryFactory(ICloseSessionContextFactory iCloseSessionContextFactory, IInitSessionContextFactory iInitSessionContextFactory,
           IGetIsolationLevelFactory iGetIsolationLevelFactory)
        {
            this.iCloseSessionContextFactory = iCloseSessionContextFactory;
            this.iInitSessionContextFactory = iInitSessionContextFactory;
            this.iGetIsolationLevelFactory = iGetIsolationLevelFactory;
        }

        public IRpt_ResourceGroupSummary Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCloseSessionContext = this.iCloseSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iInitSessionContext = this.iInitSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = this.iGetIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IRpt_ResourceGroupSummary _Rpt_ResourceGroupSummary = new Rpt_ResourceGroupSummary(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iCloseSessionContext,
                iInitSessionContext,
                transactionFactory,
                iGetIsolationLevel,
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
                _Rpt_ResourceGroupSummary = IDOMethodIntercept<IRpt_ResourceGroupSummary>.Create(_Rpt_ResourceGroupSummary, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_ResourceGroupSummaryExt = timerfactory.Create<IRpt_ResourceGroupSummary>(_Rpt_ResourceGroupSummary);

            return iRpt_ResourceGroupSummaryExt;
        }
    }
}
