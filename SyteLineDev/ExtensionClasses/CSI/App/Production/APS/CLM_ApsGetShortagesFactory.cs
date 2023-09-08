//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetShortagesFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.CRUD.Production.APS;

namespace CSI.Production.APS
{
    public class CLM_ApsGetShortagesFactory
    {
        public const string IDO = "SLShortages";
        public const string Method = "CLM_ApsGetShortages";

        public ICLM_ApsGetShortages Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var iApsTransferOutOrderId = new ApsTransferOutOrderIdFactory().Create(cSIExtensionClassBase);
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCLM_ApsGetDemandId = new CLM_ApsGetDemandIdFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApsForecastOrderId = new ApsForecastOrderIdFactory().Create(cSIExtensionClassBase);
            var iSSSFSApsSROOrderID = new SSSFSApsSROOrderIDFactory().Create(cSIExtensionClassBase);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iApsProjectOrderId = new ApsProjectOrderIdFactory().Create(cSIExtensionClassBase);
            var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
            var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApsGetOrderID2 = new ApsGetOrderID2Factory().Create(cSIExtensionClassBase);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var iApsMpsOrderId = new ApsMpsOrderIdFactory().Create(cSIExtensionClassBase);
            var iApsJobOrderId = new ApsJobOrderIdFactory().Create(cSIExtensionClassBase);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var iApsOrderId = new ApsOrderIdFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iApsSafetyStockOrderId = new ApsSafetyStockOrderId(appDB);
            var iCLM_ApsGetShortagesCRUD = new CLM_ApsGetShortagesCRUD(sQLCollectionLoad, stringUtil);

            ICLM_ApsGetShortages _CLM_ApsGetShortages = new CLM_ApsGetShortages(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                iCLM_ApsGetShortagesCRUD,
                iApsTransferOutOrderId,
                sQLExpressionExecutor,
                iCLM_ApsGetDemandId,
                iApsForecastOrderId,
                iSSSFSApsSROOrderID,
                transactionFactory,
                iApsProjectOrderId,
                iExecuteDynamicSQL,
                sQLCollectionLoad,
                iExpandKyByType,
                iApsGetOrderID2,
                scalarFunction,
                iApsMpsOrderId,
                iApsJobOrderId,
                existsChecker,
                convertToUtil,
                variableUtil,
                dateTimeUtil,
                iApsOrderId,
                stringUtil,
                iDayEndOf,
                sQLUtil,
                iApsSafetyStockOrderId);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_ApsGetShortages = IDOMethodIntercept<ICLM_ApsGetShortages>.Create(_CLM_ApsGetShortages, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ApsGetShortagesExt = timerfactory.Create<ICLM_ApsGetShortages>(_CLM_ApsGetShortages);


            return iCLM_ApsGetShortagesExt;
        }
    }
}