//PROJECT NAME: Material
//CLASS NAME: DeleteItemsOfSpecifiedCategoriesFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Material
{
    public class DeleteItemsOfSpecifiedCategoriesFactory
    {
        public const string IDO = "SLItemCategories";
        public const string Method = "DeleteItemsOfSpecifiedCategories";

        public IDeleteItemsOfSpecifiedCategories Create(
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
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();

            IDeleteItemsOfSpecifiedCategories _DeleteItemsOfSpecifiedCategories = new DeleteItemsOfSpecifiedCategories(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                scalarFunction,
                existsChecker,
                stringUtil,
                sQLUtil);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _DeleteItemsOfSpecifiedCategories = IDOMethodIntercept<IDeleteItemsOfSpecifiedCategories>.Create(_DeleteItemsOfSpecifiedCategories, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDeleteItemsOfSpecifiedCategoriesExt = timerfactory.Create<IDeleteItemsOfSpecifiedCategories>(_DeleteItemsOfSpecifiedCategories);

            return iDeleteItemsOfSpecifiedCategoriesExt;
        }
    }
}
