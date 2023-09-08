//PROJECT NAME: Material
//CLASS NAME: ItemwhseGetDetailsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Material
{
    public class ItemwhseGetDetailsFactory
    {
        public const string IDO = "SLItemwhses";
        public const string Method = "ItemwhseGetDetails";

        public IItemwhseGetDetails Create(
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
            var iMsgApp = new MsgApp(appDB);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var iItemwhseGetDetailsCRUD = new ItemwhseGetDetailsCRUD(appDB, collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                existsChecker);

            IItemwhseGetDetails _ItemwhseGetDetails = new ItemwhseGetDetails(collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                stringUtil,
                sQLUtil,
                iMsgApp,
                iItemwhseGetDetailsCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ItemwhseGetDetails = IDOMethodIntercept<IItemwhseGetDetails>.Create(_ItemwhseGetDetails, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemwhseGetDetailsExt = timerfactory.Create<IItemwhseGetDetails>(_ItemwhseGetDetails);

            return iItemwhseGetDetailsExt;
        }
    }
}
