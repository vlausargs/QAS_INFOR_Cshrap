//PROJECT NAME: Finance
//CLASS NAME: CLM_FixedAssetDetailTranFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Finance
{
    public class CLM_FixedAssetDetailTranFactory
    {
        public const string IDO = "SLFamasters";
        public const string Method = "CLM_FixedAssetDetailTran";

        public ICLM_FixedAssetDetailTran Create(
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
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var iCLM_FixedAssetDetailTranCRUD = new CLM_FixedAssetDetailTranCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker);

            ICLM_FixedAssetDetailTran _CLM_FixedAssetDetailTran = new CLM_FixedAssetDetailTran(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iCLM_FixedAssetDetailTranCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_FixedAssetDetailTran = IDOMethodIntercept<ICLM_FixedAssetDetailTran>.Create(_CLM_FixedAssetDetailTran, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_FixedAssetDetailTranExt = timerfactory.Create<ICLM_FixedAssetDetailTran>(_CLM_FixedAssetDetailTran);

            return iCLM_FixedAssetDetailTranExt;
        }
    }
}
