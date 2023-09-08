//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderStatusFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.DataCollection;

namespace CSI.Reporting
{
    public class Rpt_TransferOrderStatusFactory
    {
        public const string IDO = "SLTransferOrderStatusReport";
        public const string Method = "Rpt_TransferOrderStatus";

        public IRpt_TransferOrderStatus Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var iProcessShipmentProcess = new ProcessShipmentProcessFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
            var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
            var iAddProcessErrorLog = cSIExtensionClassBase.MongooseDependencies.AddProcessErrorLog;
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var stringUtil = new StringUtil();
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IRpt_TransferOrderStatus _Rpt_TransferOrderStatus = new Rpt_TransferOrderStatus(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                iProcessShipmentProcess,
                sQLExpressionExecutor,
                iCloseSessionContext,
                iInitSessionContext,
                iAddProcessErrorLog,
                transactionFactory,
                iGetIsolationLevel,
                iApplyDateOffset,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iUomConvQty,
                stringUtil,
                raiseError,
                iLowDate,
                iGetumcf,
                sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_TransferOrderStatus = IDOMethodIntercept<IRpt_TransferOrderStatus>.Create(_Rpt_TransferOrderStatus, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_TransferOrderStatusExt = timerfactory.Create<IRpt_TransferOrderStatus>(_Rpt_TransferOrderStatus);

            return iRpt_TransferOrderStatusExt;
        }
    }
}
