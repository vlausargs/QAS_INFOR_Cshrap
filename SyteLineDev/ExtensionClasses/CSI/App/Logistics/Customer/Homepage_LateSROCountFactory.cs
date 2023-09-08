//PROJECT NAME: Logistics
//CLASS NAME: Homepage_LateSROCountFactory.cs

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
    public class Homepage_LateSROCountFactory
    {
        public const string IDO = "SLHomepages";
        public const string Method = "Homepage_LateSROCount";

        private IMidnightOfFactory MidnightOfFactory;
        private IGetLabelFactory GetLabelFactory;

        public Homepage_LateSROCountFactory(IMidnightOfFactory MidnightOfFactory, IGetLabelFactory GetLabelFactory)
        {
            this.MidnightOfFactory = MidnightOfFactory;
            this.GetLabelFactory = GetLabelFactory;
        }
        public IHomepage_LateSROCount Create(IApplicationDB appDB,
            IBunchedLoadCollection bunchedLoadCollection,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = MidnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var stringUtil = new StringUtil();
            var iGetLabel = GetLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IHomepage_LateSROCount _Homepage_LateSROCount = new Homepage_LateSROCount(appDB,
                bunchedLoadCollection,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                convertToUtil,
                dateTimeUtil,
                variableUtil,
                iMidnightOf,
                stringUtil,
                iGetLabel,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Homepage_LateSROCount = IDOMethodIntercept<IHomepage_LateSROCount>.Create(_Homepage_LateSROCount, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_LateSROCountExt = timerfactory.Create<IHomepage_LateSROCount>(_Homepage_LateSROCount);

            return iHomepage_LateSROCountExt;
        }
    }
}
