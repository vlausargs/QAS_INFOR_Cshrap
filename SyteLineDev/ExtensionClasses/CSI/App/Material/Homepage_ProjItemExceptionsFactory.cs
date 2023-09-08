//PROJECT NAME: Material
//CLASS NAME: Homepage_ProjItemExceptionsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Material
{
    public class Homepage_ProjItemExceptionsFactory
    {
        public const string IDO = "SLHomepageItemExceptionsViews";
        public const string Method = "Homepage_ProjItemExceptions";

        public IHomepage_ProjItemExceptions Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IHomepage_ProjItemExceptions _Homepage_ProjItemExceptions = new Homepage_ProjItemExceptions(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                transactionFactory,
                scalarFunction,
                existsChecker,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Homepage_ProjItemExceptions = IDOMethodIntercept<IHomepage_ProjItemExceptions>.Create(_Homepage_ProjItemExceptions, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_ProjItemExceptionsExt = timerfactory.Create<IHomepage_ProjItemExceptions>(_Homepage_ProjItemExceptions);

            return iHomepage_ProjItemExceptionsExt;
        }
    }
}
