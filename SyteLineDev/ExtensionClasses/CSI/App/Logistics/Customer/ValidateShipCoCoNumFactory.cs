//PROJECT NAME: Logistics
//CLASS NAME: ValidateShipCoCoNumFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
    public class ValidateShipCoCoNumFactory
    {
        public const string IDO = "SLShipCos";
        public const string Method = "ValidateShipCoCoNum";

        public IValidateShipCoCoNum Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iShipLcr = new ShipLcrFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);

            IValidateShipCoCoNum _ValidateShipCoCoNum = new ValidateShipCoCoNum(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                convertToUtil,
                stringUtil,
                iShipLcr,
                sQLUtil,
                iMsgApp);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ValidateShipCoCoNum = IDOMethodIntercept<IValidateShipCoCoNum>.Create(_ValidateShipCoCoNum, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateShipCoCoNumExt = timerfactory.Create<IValidateShipCoCoNum>(_ValidateShipCoCoNum);

            return iValidateShipCoCoNumExt;
        }
    }
}
