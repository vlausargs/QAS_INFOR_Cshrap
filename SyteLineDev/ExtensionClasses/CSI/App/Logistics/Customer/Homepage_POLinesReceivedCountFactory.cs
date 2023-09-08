//PROJECT NAME: Logistics
//CLASS NAME: Homepage_POLinesReceivedCountFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Logistics.Customer
{
    public class Homepage_POLinesReceivedCountFactory
    {
        public const string IDO = "SLHomepages";
        public const string Method = "Homepage_POLinesReceivedCount";

        private IExpandKyByTypeFactory expandKyByTypeFactory;
        private IInterpretTextFactory interpretTextFactory;
        private IMidnightOfFactory midnightOfFactory;
        private IGetLabelFactory getLabelFactory;

        public Homepage_POLinesReceivedCountFactory(
            IExpandKyByTypeFactory expandKyByTypeFactory,
            IInterpretTextFactory interpretTextFactory,
            IMidnightOfFactory midnightOfFactory,
            IGetLabelFactory getLabelFactory )
        {
            this.expandKyByTypeFactory = expandKyByTypeFactory;
            this.interpretTextFactory = interpretTextFactory;
            this.midnightOfFactory = midnightOfFactory;
            this.getLabelFactory = getLabelFactory;
        }

        public IHomepage_POLinesReceivedCount Create(IApplicationDB appDB,
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
            var iExpandKyByType = this.expandKyByTypeFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var iInterpretText = this.interpretTextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = this.midnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var stringUtil = new StringUtil();
            var iGetLabel = this.getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IHomepage_POLinesReceivedCount _Homepage_POLinesReceivedCount = new Homepage_POLinesReceivedCount(appDB,
                bunchedLoadCollection,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExpandKyByType,
                scalarFunction,
                iInterpretText,
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
                _Homepage_POLinesReceivedCount = IDOMethodIntercept<IHomepage_POLinesReceivedCount>.Create(_Homepage_POLinesReceivedCount, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_POLinesReceivedCountExt = timerfactory.Create<IHomepage_POLinesReceivedCount>(_Homepage_POLinesReceivedCount);

            return iHomepage_POLinesReceivedCountExt;
        }
    }
}
