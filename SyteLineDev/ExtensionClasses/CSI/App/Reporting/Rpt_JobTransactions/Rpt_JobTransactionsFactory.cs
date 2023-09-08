//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobTransactionsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Linq;
using CSI.Material;
using CSI.Production;
using CSI.Data.Cache;

namespace CSI.Reporting
{
	public class Rpt_JobTransactionsFactory
	{
		public const string IDO = "SLJobTransactionsReport";
		public const string Method = "Rpt_JobTransactions";

		public IRpt_JobTransactions Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			
			var iGetAllCodes = new GetAllCodesFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			var iGetLabel = cSIExtensionClassBase.MongooseDependencies.GetLabel;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var convertToUtil = new ConvertToUtilFactory().Create();
            var convertSecondsToTimeAsStr = new ConvertSecondsToTimeAsStrFactory().Create(cSIExtensionClassBase, true);

            var defineProcessVariable = cSIExtensionClassBase.MongooseDependencies.DefineProcessVariable;
            var bookmarkSerializer = new BookmarkSerializer();
            var mGSessionVariableBasedCacheSerializer = new MGSessionVariableBasedCacheSerializer(bookmarkSerializer);
            var mgSessionVariableBasedCache = new MGSessionVariableBasedCache(mGSessionVariableBasedCacheSerializer, cSIExtensionClassBase.MongooseDependencies.UndefineVariable, cSIExtensionClassBase.MongooseDependencies.DefineVariable, cSIExtensionClassBase.MongooseDependencies.GetVariable);
            var getVariable = cSIExtensionClassBase.MongooseDependencies.GetVariable;
            var sortOrderFactory = new SortOrderFactory();
            var bookmarkFactory = new BookmarkFactory();
            var rpt_JobTransactionsBuildClause = new Rpt_JobTransactionsBuildClause(collectionLoadRequestFactory);

            IRpt_JobTransactions _Rpt_JobTransactions = new Rpt_JobTransactions(appDB,
            bunchedLoadCollection,
            collectionInsertRequestFactory,
            collectionDeleteRequestFactory,
            collectionUpdateRequestFactory,
            collectionLoadRequestFactory,
            collectionLoadResponseUtil,
            sQLExpressionExecutor,
            transactionFactory,
            iGetIsolationLevel,
            iApplyDateOffset,
            iDefineVariable,
            iExpandKyByType,
            scalarFunction,
            existsChecker,
            convertToUtil,
            variableUtil,
            iGetAllCodes,
            stringUtil,
            iGetLabel,
            sQLUtil,
            convertSecondsToTimeAsStr,
            defineProcessVariable, 
            getVariable,
            mgSessionVariableBasedCache,
            queryLanguage,
            sortOrderFactory,
            bookmarkFactory,
            rpt_JobTransactionsBuildClause);

            if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_JobTransactions = IDOMethodIntercept<IRpt_JobTransactions>.Create(_Rpt_JobTransactions, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobTransactionsExt = timerfactory.Create<IRpt_JobTransactions>(_Rpt_JobTransactions);

			return iRpt_JobTransactionsExt;
		}
	}
}
