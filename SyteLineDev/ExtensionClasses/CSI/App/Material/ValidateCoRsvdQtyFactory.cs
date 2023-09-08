//PROJECT NAME: Material
//CLASS NAME: ValidateCoRsvdQtyFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Material
{
    public class ValidateCoRsvdQtyFactory
    {
        public const string IDO = "SLRsvdInvs";
        public const string Method = "ValidateCoRsvdQty";

        public IValidateCoRsvdQty Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
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
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgAsk = cSIExtensionClassBase.MongooseDependencies.MsgAsk;

            IValidateCoRsvdQty _ValidateCoRsvdQty = new ValidateCoRsvdQty(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                stringUtil,
                sQLUtil,
                iMsgAsk);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ValidateCoRsvdQty = IDOMethodIntercept<IValidateCoRsvdQty>.Create(_ValidateCoRsvdQty, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateCoRsvdQtyExt = timerfactory.Create<IValidateCoRsvdQty>(_ValidateCoRsvdQty);

            return iValidateCoRsvdQtyExt;
        }
    }
}
