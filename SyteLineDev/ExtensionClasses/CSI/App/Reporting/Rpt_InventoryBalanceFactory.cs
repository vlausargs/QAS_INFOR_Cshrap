//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryBalanceFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Admin;
using CSI.Material;
using CSI.Data.Cache;

namespace CSI.Reporting
{
    public class Rpt_InventoryBalanceFactory
    {
        public const string IDO = "SLInventoryBalanceReport";
        public const string Method = "Rpt_InventoryBalance";

        public IRpt_InventoryBalance Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var iAndSqlWhereWithISNULL = new AndSqlWhereWithISNULLFactory().Create(cSIExtensionClassBase);
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
            var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
            var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
            var iIsFeatureActive = new IsFeatureActiveFactory().Create(cSIExtensionClassBase, calledFromIDO);
            var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var highString = cSIExtensionClassBase.MongooseDependencies.HighString;
            var lowCharacter = cSIExtensionClassBase.MongooseDependencies.LowCharacter;
            var variableUtil = new VariableUtilFactory().Create();
            var iAndSqlWhere = cSIExtensionClassBase.MongooseDependencies.AndSqlWhere;
            var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
            var dateTimeUtil = new DateTimeUtilFactory().Create();
            var stringUtil = new StringUtil();
            var iHighDate = cSIExtensionClassBase.MongooseDependencies.HighDate;
            var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
            var iMtCodes = new MtCodesFactory().Create(cSIExtensionClassBase);
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerUpdateRequestFactory = new CollectionNonTriggerUpdateRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var bookmarkFactory = new BookmarkFactory();
            var sortOrderFactory = new SortOrderFactory();
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var iRpt_InventoryBalanceCRUD = new Rpt_InventoryBalanceCRUD(appDB,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionLoadRequestFactory,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerUpdateRequestFactory,
                collectionNonTriggerDeleteRequestFactory,
                existsChecker,
                variableUtil,
                stringUtil,
                sQLUtil,
                collectionLoadResponseUtil,
                iAndSqlWhere,
                iAndSqlWhereWithISNULL,
                transactionFactory,
                iGetIsolationLevel,
                scalarFunction,
                queryLanguage,
                sQLExpressionExecutor,
                bookmarkFactory,
                sortOrderFactory,
                defineProcessVariable,
                getVariable,
                mgSessionVariableBasedCache);

            IRpt_InventoryBalance _Rpt_InventoryBalance = new Rpt_InventoryBalance(
                bunchedLoadCollection,
                iGetWinRegDecGroup,
                iFixMaskForCrystal,
                iApplyDateOffset,
                iIsFeatureActive,
                iDefineVariable,
                scalarFunction,
                convertToUtil,
                highString,
                lowCharacter,
                iGetSiteDate,
                dateTimeUtil,
                stringUtil,
                iHighDate,
                iDayEndOf,
                iMtCodes,
                sQLUtil, 
                iRpt_InventoryBalanceCRUD);

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _Rpt_InventoryBalance = IDOMethodIntercept<IRpt_InventoryBalance>.Create(_Rpt_InventoryBalance, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRpt_InventoryBalanceExt = timerfactory.Create<IRpt_InventoryBalance>(_Rpt_InventoryBalance);

            return iRpt_InventoryBalanceExt;
        }
    }
}
