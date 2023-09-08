//PROJECT NAME: Material
//CLASS NAME: ItemPriceChangeFactory.cs

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
    public class ItemPriceChangeFactory
    {
        public const string IDO = "SLItemprices";
        public const string Method = "ItemPriceChange";

        public IItemPriceChange Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var variableUtil = new VariableUtilFactory().Create();
            var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
            var stringUtil = new StringUtil();
            var iHighDate = cSIExtensionClassBase.MongooseDependencies.HighDate;
            var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);

            IItemPriceChange _ItemPriceChange = new ItemPriceChange(appDB,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iApplyDateOffset,
                scalarFunction,
                existsChecker,
                convertToUtil,
                iGetSiteDate,
                variableUtil,
                iMidnightOf,
                stringUtil,
                iHighDate,
                iLowDate,
                sQLUtil,
                iMsgApp,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _ItemPriceChange = IDOMethodIntercept<IItemPriceChange>.Create(_ItemPriceChange, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iItemPriceChangeExt = timerfactory.Create<IItemPriceChange>(_ItemPriceChange);

            return iItemPriceChangeExt;
        }
    }
}
