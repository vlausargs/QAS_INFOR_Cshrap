//PROJECT NAME: Production
//CLASS NAME: JustInTimeTransactionFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Finance;
using CSI.Codes;

namespace CSI.Production
{
	public class JustInTimeTransactionFactory
	{
		public const string IDO = "SLJobTrans";
		public const string Method = "JustInTimeTransaction";
		
		public IJustInTimeTransaction Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var iCheckWhseExternalControlledFlag = new CheckWhseExternalControlledFlagFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iUndefineVariableBySessionId = cSIExtensionClassBase.MongooseDependencies.UndefineVariableBySessionId;
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var iValidateRestrictedTrans = new ValidateRestrictedTransFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iDefinedValueBySessionId = cSIExtensionClassBase.MongooseDependencies.DefinedValueBySessionId;
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iJournalImmediate = new JournalImmediateFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iApsSyncImmediate = new ApsSyncImmediateFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iJobtranPostMatl = new JobtranPostMatlFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iApsSyncDefer = new ApsSyncDeferFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iJournalDefer = new JournalDeferFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			var iUserCode = new UserCodeFactory().Create(cSIExtensionClassBase);
			var iSernumJ = new SernumJFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var iJobP2 = new JobP2Factory().Create(cSIExtensionClassBase, calledFromIDO);
			var iJobtP = new JobtPFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iJustInTimeTransactionCRUD = new JustInTimeTransactionCRUD(appDB, collectionLoadBuilderRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionUpdateRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil, stringUtil);
			IJustInTimeTransaction _JustInTimeTransaction = new JustInTimeTransaction(iCheckWhseExternalControlledFlag,
				iUndefineVariableBySessionId,
				collectionLoadResponseUtil,
				iValidateRestrictedTrans,
				iDefinedValueBySessionId,
				sQLExpressionExecutor,
				transactionFactory,
				iJournalImmediate,
				iApsSyncImmediate,
				iJobtranPostMatl,
				iDefineVariable,
				scalarFunction,
				convertToUtil,
				iApsSyncDefer,
				iJournalDefer,
				stringUtil,
				iUserCode,
				iSernumJ,
				sQLUtil,
				iMsgApp,
				iJobP2,
				iJobtP,
				iJustInTimeTransactionCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_JustInTimeTransaction = IDOMethodIntercept<IJustInTimeTransaction>.Create(_JustInTimeTransaction, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJustInTimeTransactionExt = timerfactory.Create<IJustInTimeTransaction>(_JustInTimeTransaction);
			
			return iJustInTimeTransactionExt;
		}
	}
}
