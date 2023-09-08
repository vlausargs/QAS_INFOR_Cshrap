//PROJECT NAME: Production
//CLASS NAME: GetJobMatlItemFactory.cs

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

namespace CSI.Production
{
    public class GetJobMatlItemFactory
    {
        public const string IDO = "SLJobmatls";
        public const string Method = "GetJobMatlItem";

        public IGetJobMatlItem Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
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
            var iShipLocDefault = new ShipLocDefaultFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iItemUMValid = new ItemUMValidFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iGetCostCode = new GetCostCodeFactory().Create(cSIExtensionClassBase);
            var iGetVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var iUomConvAmt = new UomConvAmtFactory().Create(cSIExtensionClassBase);
            var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var stringUtil = new StringUtil();
            var mathUtil = new MathUtilFactory().Create();
            var iObsSlow = new ObsSlowFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            var iReqQty = new ReqQtyFactory().Create(cSIExtensionClassBase);
            var iFmtJob = new FmtJobFactory().Create(cSIExtensionClassBase);

            IGetJobMatlItem _GetJobMatlItem = new GetJobMatlItem(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iShipLocDefault,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iItemUMValid,
                iGetCostCode,
                iGetVariable,
                iUomConvAmt,
                iUomConvQty,
                stringUtil,
                mathUtil,
                iObsSlow,
                sQLUtil,
                iMsgApp,
                iReqQty,
                iFmtJob);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _GetJobMatlItem = IDOMethodIntercept<IGetJobMatlItem>.Create(_GetJobMatlItem, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetJobMatlItemExt = timerfactory.Create<IGetJobMatlItem>(_GetJobMatlItem);

            return iGetJobMatlItemExt;
        }
    }
}
