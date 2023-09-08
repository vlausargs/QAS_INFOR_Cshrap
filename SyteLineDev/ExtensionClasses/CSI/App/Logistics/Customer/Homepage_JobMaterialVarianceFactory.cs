//PROJECT NAME: Logistics
//CLASS NAME: Homepage_JobMaterialVarianceFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public class Homepage_JobMaterialVarianceFactory
    {
        public const string IDO = "SLHomepages";
        public const string Method = "Homepage_JobMaterialVariance";

        public IHomepage_JobMaterialVariance Create(IApplicationDB appDB,
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
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IHomepage_JobMaterialVariance _Homepage_JobMaterialVariance = new Homepage_JobMaterialVariance(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                stringUtil,
                mathUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Homepage_JobMaterialVariance = IDOMethodIntercept<IHomepage_JobMaterialVariance>.Create(_Homepage_JobMaterialVariance, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_JobMaterialVarianceExt = timerfactory.Create<IHomepage_JobMaterialVariance>(_Homepage_JobMaterialVariance);

            return iHomepage_JobMaterialVarianceExt;
        }
    }
}
