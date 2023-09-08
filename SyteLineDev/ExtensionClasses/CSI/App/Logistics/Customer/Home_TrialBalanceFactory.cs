//PROJECT NAME: Logistics
//CLASS NAME: Home_TrialBalanceFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;

namespace CSI.Logistics.Customer
{
    public class Home_TrialBalanceFactory
    {
        public const string IDO = "SLControllerAlls";
        public const string Method = "Home_TrialBalance";

        private IBuildXMLFilterStringFactory buildXMLFilterStringFactory;
        private IExecuteDynamicSQLFactory executeDynamicSQLFactory;
        private IPeriodsGetDatesFactory periodsGetDatesFactory;
        private ICalcBalFactory calcBalFactory;
        private IPerGetFactory perGetFactory;

        public Home_TrialBalanceFactory(
            IBuildXMLFilterStringFactory buildXMLFilterStringFactory,
            IExecuteDynamicSQLFactory executeDynamicSQLFactory,
            IPeriodsGetDatesFactory periodsGetDatesFactory,
            ICalcBalFactory calcBalFactory,
            IPerGetFactory perGetFactory)
        {
            this.buildXMLFilterStringFactory = buildXMLFilterStringFactory;
            this.executeDynamicSQLFactory = executeDynamicSQLFactory;
            this.periodsGetDatesFactory = periodsGetDatesFactory;
            this.calcBalFactory = calcBalFactory;
            this.perGetFactory = perGetFactory;
        }

        public IHome_TrialBalance Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iBuildXMLFilterString = this.buildXMLFilterStringFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iExecuteDynamicSQL = this.executeDynamicSQLFactory.Create(appDB, bunchedLoadCollection, mgInvoker, parameterProvider, calledFromIDO);
            var iPeriodsGetDates = this.periodsGetDatesFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iCalcBal = this.calcBalFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iPerGet = this.perGetFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);

            IHome_TrialBalance _Home_TrialBalance = new Home_TrialBalance(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iBuildXMLFilterString,
                transactionFactory,
                iExecuteDynamicSQL,
                iPeriodsGetDates,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                dateTimeUtil,
                stringUtil,
                iCalcBal,
                sQLUtil,
                iPerGet);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Home_TrialBalance = IDOMethodIntercept<IHome_TrialBalance>.Create(_Home_TrialBalance, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHome_TrialBalanceExt = timerfactory.Create<IHome_TrialBalance>(_Home_TrialBalance);

            return iHome_TrialBalanceExt;
        }
    }
}
