//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateAPTransactionsFactory.cs

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
using CSI.DataCollection;
using CSI.Logger;
using CSI.Data.Cache;

namespace CSI.Logistics.Vendor
{
    public class CLM_GenerateAPTransactionsFactory
    {
        public const string IDO = "SLTTVouchers";
        public const string Method = "CLM_GenerateAPTransactions";

        public ICLM_GenerateAPTransactions Create(
            ICSIExtensionClassBase cSIExtensionClassBase,
            bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var parameterProvider = cSIExtensionClassBase.ParameterProvider;
            var mgInvoker = cSIExtensionClassBase.MGInvoker;
            var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

            var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
            var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
            var collectionNonTriggerUpdateRequestFactory = new CollectionNonTriggerUpdateRequestFactory(queryLanguage);
            var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);
            var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
            var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
            var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
            var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
            var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
            var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
            var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
            var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
            var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, false);
            var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
            var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
            var variableUtil = new VariableUtilFactory().Create();
            var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, false);
            var iUomConvAmt = new UomConvAmtFactory().Create(cSIExtensionClassBase);
            var stringUtil = new StringUtil();
            var iSessionID = cSIExtensionClassBase.MongooseDependencies.SessionID;
            var raiseError = new RaiseErrorFactory().Create(appDB);
            var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, false);
            var mathUtil = new MathUtilFactory().Create();
            var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iMinQty = new MinQtyFactory().Create(cSIExtensionClassBase);
            var iMsgApp = new MsgApp(appDB);
            var logger = new Logger.LoggerFactory().Create(LoggerType.Mongoose);

            // Bunching
            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var sortOrderFactory = new SortOrderFactory();
  
            LoadType loadType = bunchedLoadCollection.LoadType;
            int recordCap = bunchedLoadCollection.RecordCap;

            if (recordCap == -1)
            {
                recordCap = 200;
            }
            if (recordCap == 0)
            {
                recordCap = int.MaxValue - 1;
            }

            // Streaming
            var recordStreamFactory = new RecordStreamFactory();
            string orderBy = "PoNum, PoLine, PoRelease, GrnLine";
            var unionUtil = new UnionUtil(UnionType.UnionAll, orderBy);
            var highString = cSIExtensionClassBase.MongooseDependencies.HighString;
            var highInt = cSIExtensionClassBase.MongooseDependencies.HighInt;
            var sqlFilter = cSIExtensionClassBase.MongooseDependencies.SqlFilter;

            ICLM_GenerateAPTransactions _CLM_GenerateAPTransactions = new CLM_GenerateAPTransactions(appDB,
                bunchedLoadCollection,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerUpdateRequestFactory,
                collectionNonTriggerDeleteRequestFactory,
                collectionLoadStatementRequestFactory,
                collectionLoadBuilderRequestFactory,
                collectionInsertRequestFactory,
                collectionDeleteRequestFactory,
                collectionUpdateRequestFactory,
                collectionLoadRequestFactory,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                iExpandKyByType,
                scalarFunction,
                existsChecker,
                convertToUtil,
                variableUtil,
                iUomConvQty,
                iUomConvAmt,
                stringUtil,
                iSessionID,
                raiseError,
                iGetumcf,
                mathUtil,
                sQLUtil,
                iMinQty,
                iMsgApp,
                logger,
                defineProcessVariable,
                getVariable,
                sortOrderFactory,
                queryLanguage,
                mgSessionVariableBasedCache,
                recordCap,
                loadType,
                //CachePageSize.Large,
                recordStreamFactory,
                unionUtil,
                highString,
                highInt,
                sqlFilter
                );

            if (!calledFromIDO)
            {
                //if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
                //but it wasn't, so add the intercept
                var interceptConfiguration = new InterceptConfiguration();
                _CLM_GenerateAPTransactions = IDOMethodIntercept<ICLM_GenerateAPTransactions>.Create(_CLM_GenerateAPTransactions, IDO, Method, mgInvoker, interceptConfiguration);
            }

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_GenerateAPTransactionsExt = timerfactory.Create<ICLM_GenerateAPTransactions>(_CLM_GenerateAPTransactions);

            return iCLM_GenerateAPTransactionsExt;
        }
    }
}
