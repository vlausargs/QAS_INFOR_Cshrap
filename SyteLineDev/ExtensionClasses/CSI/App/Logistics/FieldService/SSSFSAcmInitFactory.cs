//PROJECT NAME: Logistics
//CLASS NAME: SSSFSAcmInitFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.FieldService
{
    public class SSSFSAcmInitFactory
    {
        public const string IDO = "FSAcmHdrs";
        public const string Method = "SSSFSAcmInit";

        public ISSSFSAcmInit Create(
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
            var iSSSFSAcmInitCRUD = new SSSFSAcmInitCRUD(appDB, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker);
            ISSSFSAcmInit _SSSFSAcmInit = new SSSFSAcmInit(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iSSSFSAcmInitCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _SSSFSAcmInit = IDOMethodIntercept<ISSSFSAcmInit>.Create(_SSSFSAcmInit, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSAcmInitExt = timerfactory.Create<ISSSFSAcmInit>(_SSSFSAcmInit);

            return iSSSFSAcmInitExt;
        }
    }
}
