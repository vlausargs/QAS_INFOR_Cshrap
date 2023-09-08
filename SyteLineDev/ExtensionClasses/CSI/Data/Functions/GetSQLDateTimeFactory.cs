//PROJECT NAME: Data
//CLASS NAME: GetSQLDateTimeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class GetSQLDateTimeFactory
    {
        public const string IDO = "SLAppmts";
        public const string Method = "GetSQLDateTime";

        private IGetSiteDateFactory getSiteDateFactory;

        public GetSQLDateTimeFactory(IGetSiteDateFactory getSiteDateFactory)
        {
            this.getSiteDateFactory = getSiteDateFactory;
        }

        public IGetSQLDateTime Create(IApplicationDB appDB,
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
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var iGetSiteDate = this.getSiteDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IGetSQLDateTime _GetSQLDateTime = new GetSQLDateTime(appDB,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                dateTimeUtil,
                iGetSiteDate,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _GetSQLDateTime = IDOMethodIntercept<IGetSQLDateTime>.Create(_GetSQLDateTime, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetSQLDateTimeExt = timerfactory.Create<IGetSQLDateTime>(_GetSQLDateTime);

            return iGetSQLDateTimeExt;
        }
    }
}
