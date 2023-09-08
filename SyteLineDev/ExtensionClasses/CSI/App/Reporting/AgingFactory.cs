//PROJECT NAME: Reporting
//CLASS NAME: AgingFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Admin;
using CSI.Finance.AR;
using CSI.Logistics.Customer;
using CSI.Adapters;
using CSI.Logistics.Vendor;
using CSI.Data.Cache;
using CSI.Logger;
using System;

namespace CSI.Reporting
{
    public class AgingFactory
    {
        public const string IDO = "EmptyIDO";
        public const string Method = "Aging";

        public IAging Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, true);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, true);            
            var isAddonAvailableCache = new IsAddonAvailableCacheFactory().Create(cSIExtensionClassBase);            
            var isFeatureActiveCache = new IsFeatureActiveCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
            var variableUtil = new VariableUtilFactory().Create();
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var iGainLossAr = new GainLossArFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var stringUtil = new StringUtil();
            var iArTermDue = new ArTermDueFactory().Create(cSIExtensionClassBase);
            var i2CurrCnvt = new TwoCurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iIsInteger = cSIExtensionClassBase.MongooseDependencies.IsInteger;            
            var getLabelCache = cSIExtensionClassBase.MongooseDependencies.GetLabelCache;            
            var currCnvtCache = new CurrCnvtCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);            
            var stringOfCache = cSIExtensionClassBase.MongooseDependencies.StringOfCache;            
            var lowDateCache = cSIExtensionClassBase.MongooseDependencies.LowDateCache;            
            var chkcredCache = new ChkcredCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);            
            var getCodeCache = new GetCodeCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMsgApp = new MsgApp(appDB);
            var recordStreamFactory = new RecordStreamFactory();
            var bookmarkSerializer = new BookmarkSerializer();
            var cacheEntrySerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(cacheEntrySerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var sortOrderFactory = new SortOrderFactory();

            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);
            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerUpdateRequestFactory = new CollectionNonTriggerUpdateRequestFactory(queryLanguage);
            var logger = new Logger.LoggerFactory().Create(LoggerType.Mongoose);

            IAging _Aging = new Aging(appDB,
                bunchedLoadCollection,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                dataTableToCollectionLoadResponse,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                isAddonAvailableCache,
                isFeatureActiveCache,
                scalarFunction,
                existsChecker,
                convertToUtil,
                dataTableUtil,
                variableUtil,
                dateTimeUtil,
                iGainLossAr,
                stringUtil,
                iArTermDue,
                i2CurrCnvt,
                iIsInteger,
                getLabelCache,
                currCnvtCache,
                stringOfCache,
                lowDateCache,
                chkcredCache,
                getCodeCache,
                sQLUtil,
                iMsgApp,
                queryLanguage,
                recordStreamFactory,
                mgSessionVariableBasedCache,
                sortOrderFactory,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                collectionNonTriggerDeleteRequestFactory,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerUpdateRequestFactory,
                logger);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Aging = IDOMethodIntercept<IAging>.Create(_Aging, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAgingExt = timerfactory.Create<IAging>(_Aging);

            return iAgingExt;
        }
    }
}
