//PROJECT NAME: Logistics
//CLASS NAME: Homepage_PORequisitionLineByStatusFactory.cs

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
    public class Homepage_PORequisitionLineByStatusFactory
    {
        public const string IDO = "SLHomepages";
        public const string Method = "Homepage_PORequisitionLineByStatus";

        private IGetLabelFactory getLabelFactory;

        public Homepage_PORequisitionLineByStatusFactory(IGetLabelFactory getLabelFactory)
        {
            this.getLabelFactory = getLabelFactory;
        }

        public IHomepage_PORequisitionLineByStatus Create(IApplicationDB appDB,
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
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iGetLabel = this.getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IHomepage_PORequisitionLineByStatus _Homepage_PORequisitionLineByStatus = new Homepage_PORequisitionLineByStatus(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
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
                stringUtil,
                iGetLabel,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Homepage_PORequisitionLineByStatus = IDOMethodIntercept<IHomepage_PORequisitionLineByStatus>.Create(_Homepage_PORequisitionLineByStatus, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iHomepage_PORequisitionLineByStatusExt = timerfactory.Create<IHomepage_PORequisitionLineByStatus>(_Homepage_PORequisitionLineByStatus);

            return iHomepage_PORequisitionLineByStatusExt;
        }
    }
}
