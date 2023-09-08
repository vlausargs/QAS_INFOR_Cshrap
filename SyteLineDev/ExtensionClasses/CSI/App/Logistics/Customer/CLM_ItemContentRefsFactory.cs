//PROJECT NAME: Logistics
//CLASS NAME: CLM_ItemContentRefsFactory.cs

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
    public class CLM_ItemContentRefsFactory
    {
        public const string IDO = "SLItemContentRefs";
        public const string Method = "CLM_ItemContentRefs";

        private IBuildXMLFilterStringFactory iBuildXMLFilterStringFactory;
        private IExecuteDynamicSQLFactory iExecuteDynamicSQLFactory;
        private IGetSiteDateFactory iGetSiteDateFactory;

        public CLM_ItemContentRefsFactory(IBuildXMLFilterStringFactory iBuildXMLFilterStringFactory, IExecuteDynamicSQLFactory iExecuteDynamicSQLFactory,
           IGetSiteDateFactory iGetSiteDateFactory)
        {
            this.iBuildXMLFilterStringFactory = iBuildXMLFilterStringFactory;
            this.iExecuteDynamicSQLFactory = iExecuteDynamicSQLFactory;
            this.iGetSiteDateFactory = iGetSiteDateFactory;
        }

        public ICLM_ItemContentRefs Create(IApplicationDB appDB,
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
            var iBuildXMLFilterString = this.iBuildXMLFilterStringFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var iExecuteDynamicSQL = this.iExecuteDynamicSQLFactory.Create(appDB, bunchedLoadCollection, mgInvoker, parameterProvider, calledFromIDO);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iGetSiteDate = this.iGetSiteDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var variableUtil = new VariableUtilFactory().Create();
            var stringUtil = new StringUtil();
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            ICLM_ItemContentRefs _CLM_ItemContentRefs = new CLM_ItemContentRefs(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iBuildXMLFilterString,
                iExecuteDynamicSQL,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                iGetSiteDate,
                variableUtil,
                stringUtil,
                raiseError,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ItemContentRefs = IDOMethodIntercept<ICLM_ItemContentRefs>.Create(_CLM_ItemContentRefs, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ItemContentRefsExt = timerfactory.Create<ICLM_ItemContentRefs>(_CLM_ItemContentRefs);

            return iCLM_ItemContentRefsExt;
        }
    }
}
