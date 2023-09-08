//PROJECT NAME: Material
//CLASS NAME: ValidateSerailTrackedItemForContainerFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Material
{
    public class ValidateSerailTrackedItemForContainerFactory
    {
        public const string IDO = "SLContainerItems";
        public const string Method = "ValidateSerailTrackedItemForContainer";

        public IValidateSerailTrackedItemForContainer Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
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
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);

            IValidateSerailTrackedItemForContainer _ValidateSerailTrackedItemForContainer = new ValidateSerailTrackedItemForContainer(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                stringUtil,
                sQLUtil,
                iMsgApp);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ValidateSerailTrackedItemForContainer = IDOMethodIntercept<IValidateSerailTrackedItemForContainer>.Create(_ValidateSerailTrackedItemForContainer, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iValidateSerailTrackedItemForContainerExt = timerfactory.Create<IValidateSerailTrackedItemForContainer>(_ValidateSerailTrackedItemForContainer);

            return iValidateSerailTrackedItemForContainerExt;
        }
    }
}
