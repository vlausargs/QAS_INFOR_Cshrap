//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceSummaryFactory.cs

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
    public class Rpt_ResourceSummaryFactory
    {
        public const string IDO = "SLResourceSummaryReport";
        public const string Method = "Rpt_ResourceSummary";

        private ICloseSessionContextFactory CloseSessionContextFactory;
        private IInitSessionContextFactory InitSessionContextFactory;
        private readonly IGetIsolationLevelFactory GetIsolationLevelFactory;

        public Rpt_ResourceSummaryFactory(ICloseSessionContextFactory CloseSessionContextFactory, IInitSessionContextFactory InitSessionContextFactory, IGetIsolationLevelFactory GetIsolationLevelFactory)
        {
            this.CloseSessionContextFactory = CloseSessionContextFactory;
            this.InitSessionContextFactory = InitSessionContextFactory;
            this.GetIsolationLevelFactory = GetIsolationLevelFactory;
        }

        public IRpt_ResourceSummary Create(IApplicationDB appDB,
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
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var iCloseSessionContext = CloseSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iInitSessionContext = InitSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = this.GetIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IRpt_ResourceSummary _Rpt_ResourceSummary = new Rpt_ResourceSummary(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                sQLCollectionLoad,
                iCloseSessionContext,
                iInitSessionContext,
                transactionFactory,
                iGetIsolationLevel,
                scalarFunction,
                existsChecker,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_ResourceSummary = IDOMethodIntercept<IRpt_ResourceSummary>.Create(_Rpt_ResourceSummary, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_ResourceSummaryExt = timerfactory.Create<IRpt_ResourceSummary>(_Rpt_ResourceSummary);

            return iRpt_ResourceSummaryExt;
        }
    }
}
