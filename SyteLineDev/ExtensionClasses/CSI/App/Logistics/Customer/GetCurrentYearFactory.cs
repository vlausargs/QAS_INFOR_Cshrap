//PROJECT NAME: Logistics
//CLASS NAME: GetCurrentYearFactory.cs

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
    public class GetCurrentYearFactory
    {
        public const string IDO = "SLReports";
        public const string Method = "GetCurrentYear";

        private IGetSiteDateFactory getSiteDateFactory;

        public GetCurrentYearFactory(IGetSiteDateFactory getSiteDateFactory)
        {
            this.getSiteDateFactory = getSiteDateFactory;
        }

        public IGetCurrentYear Create(IApplicationDB appDB,
            IMGInvoker mgInvoker,
            IParameterProvider parameterProvider,
            bool calledFromIDO)
        {
            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var iGetSiteDate = this.getSiteDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IGetCurrentYear _GetCurrentYear = new GetCurrentYear(appDB,
                collectionLoadStatementRequestFactory,
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
                iGetSiteDate,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _GetCurrentYear = IDOMethodIntercept<IGetCurrentYear>.Create(_GetCurrentYear, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetCurrentYearExt = timerfactory.Create<IGetCurrentYear>(_GetCurrentYear);

            return iGetCurrentYearExt;
        }
    }
}
