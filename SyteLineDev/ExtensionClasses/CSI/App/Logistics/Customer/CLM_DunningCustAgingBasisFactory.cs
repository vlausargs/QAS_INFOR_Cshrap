//PROJECT NAME: Logistics
//CLASS NAME: CLM_DunningCustAgingBasisFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public class CLM_DunningCustAgingBasisFactory
    {
        public const string IDO = "SLCustomerAlls";
        public const string Method = "CLM_DunningCustAgingBasis";

        public ICLM_DunningCustAgingBasis Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var iCLM_DunningCustAgingBasisCRUD = new CLM_DunningCustAgingBasisCRUD(appDB, collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker,
                stringUtil);

            ICLM_DunningCustAgingBasis _CLM_DunningCustAgingBasis = new CLM_DunningCustAgingBasis(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                sQLUtil,
                iCLM_DunningCustAgingBasisCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_DunningCustAgingBasis = IDOMethodIntercept<ICLM_DunningCustAgingBasis>.Create(_CLM_DunningCustAgingBasis, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_DunningCustAgingBasisExt = timerfactory.Create<ICLM_DunningCustAgingBasis>(_CLM_DunningCustAgingBasis);

            return iCLM_DunningCustAgingBasisExt;
        }
    }
}
