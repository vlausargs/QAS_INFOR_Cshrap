//PROJECT NAME: Logistics
//CLASS NAME: AppmtdValidateVoucherFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Logistics.Vendor
{
    public class AppmtdValidateVoucherFactory
    {
        public const string IDO = "SLAppmtds";
        public const string Method = "AppmtdValidateVoucher";

        public IAppmtdValidateVoucher Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
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
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            var iMsgAsk = cSIExtensionClassBase.MongooseDependencies.MsgAsk;
            var iMinAmt = new MinAmtFactory().Create(cSIExtensionClassBase);
            var iMaxAmt = new MaxAmtFactory().Create(cSIExtensionClassBase);
            var iMinQty = new MinQtyFactory().Create(cSIExtensionClassBase);

            IAppmtdValidateVoucher _AppmtdValidateVoucher = new AppmtdValidateVoucher(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iMidnightOf,
                stringUtil,
                iCurrCnvt,
                sQLUtil,
                iMsgApp,
                iMsgAsk,
                iMinAmt,
                iMaxAmt,
                iMinQty);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _AppmtdValidateVoucher = IDOMethodIntercept<IAppmtdValidateVoucher>.Create(_AppmtdValidateVoucher, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAppmtdValidateVoucherExt = timerfactory.Create<IAppmtdValidateVoucher>(_AppmtdValidateVoucher);

            return iAppmtdValidateVoucherExt;
        }
    }
}
