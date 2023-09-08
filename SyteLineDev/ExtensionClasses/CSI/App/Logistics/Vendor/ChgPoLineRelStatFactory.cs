//PROJECT NAME: Logistics
//CLASS NAME: ChgPoLineRelStatFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Customer;

namespace CSI.Logistics.Vendor
{
	public class ChgPoLineRelStatFactory
	{
		public const string IDO = "SLPoItems";
		public const string Method = "ChgPoLineRelStat";
		
		public IChgPoLineRelStat Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iPOItemlog = new POItemlogFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var raiseError = new RaiseErrorFactory().Create(appDB);
			var iObsSlow = new ObsSlowFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iChgPoLineRelStatCRUD = new ChgPoLineRelStatCRUD(appDB, bunchedLoadCollection, collectionLoadStatementRequestFactory, collectionLoadBuilderRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionUpdateRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil, stringUtil);
			IChgPoLineRelStat _ChgPoLineRelStat = new ChgPoLineRelStat(bunchedLoadCollection,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				iExecuteDynamicSQL,
				iApplyDateOffset,
				iDefineVariable,
				scalarFunction,
				convertToUtil,
				stringUtil,
				iPOItemlog,
				raiseError,
				iObsSlow,
				sQLUtil,
				iMsgApp,
				iChgPoLineRelStatCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ChgPoLineRelStat = IDOMethodIntercept<IChgPoLineRelStat>.Create(_ChgPoLineRelStat, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgPoLineRelStatExt = timerfactory.Create<IChgPoLineRelStat>(_ChgPoLineRelStat);
			
			return iChgPoLineRelStatExt;
		}
	}
}
