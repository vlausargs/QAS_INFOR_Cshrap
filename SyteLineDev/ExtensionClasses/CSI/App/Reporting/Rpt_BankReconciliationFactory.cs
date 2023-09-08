//PROJECT NAME: Reporting
//CLASS NAME: Rpt_BankReconciliationFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Adapters;

namespace CSI.Reporting
{
	public class Rpt_BankReconciliationFactory
	{
		public const string IDO = "SLBankReconciliationReport";
		public const string Method = "Rpt_BankReconciliation";
		private IInitSessionContextWithUserFactory initSessionContextWithUserFactory;
		private ICopySessionVariablesFactory copySessionVariablesFactory;
		private ICloseSessionContextFactory closeSessionContextFactory;
		private IGetIsolationLevelFactory getIsolationLevelFactory;
		private IApplyDateOffsetFactory applyDateOffsetFactory;
		private IGetLabelFactory getLabelFactory;
		private IHighIntFactory highIntFactory;
		private ILowIntFactory lowIntFactory;

		public Rpt_BankReconciliationFactory(IInitSessionContextWithUserFactory initSessionContextWithUserFactory, ICopySessionVariablesFactory copySessionVariablesFactory,
			ICloseSessionContextFactory closeSessionContextFactory, IGetIsolationLevelFactory getIsolationLevelFactory, IApplyDateOffsetFactory applyDateOffsetFactory,
			IGetLabelFactory getLabelFactory, IHighIntFactory highIntFactory, ILowIntFactory lowIntFactory)
		{
			this.initSessionContextWithUserFactory = initSessionContextWithUserFactory;
			this.copySessionVariablesFactory = copySessionVariablesFactory;
			this.closeSessionContextFactory = closeSessionContextFactory;
			this.getIsolationLevelFactory = getIsolationLevelFactory;
			this.applyDateOffsetFactory = applyDateOffsetFactory;
			this.getLabelFactory = getLabelFactory;
			this.highIntFactory = highIntFactory;
			this.lowIntFactory = lowIntFactory;
		}

		public IRpt_BankReconciliation Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO, ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var iInitSessionContextWithUser = initSessionContextWithUserFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCopySessionVariables = copySessionVariablesFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iCloseSessionContext = closeSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = getIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iApplyDateOffset = applyDateOffsetFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iGetLabel = getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iHighInt = highIntFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iGetCode = new GetCodeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iLowInt = lowIntFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iMsgApp = new MsgApp(appDB);

			IRpt_BankReconciliation _Rpt_BankReconciliation = new Rpt_BankReconciliation(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				iInitSessionContextWithUser,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCopySessionVariables,
				iCloseSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iApplyDateOffset,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				stringUtil,
				iGetLabel,
				iHighInt,
				iGetCode,
				sQLUtil,
				iLowInt,
				iMsgApp,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_BankReconciliation = IDOMethodIntercept<IRpt_BankReconciliation>.Create(_Rpt_BankReconciliation, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_BankReconciliationExt = timerfactory.Create<IRpt_BankReconciliation>(_Rpt_BankReconciliation);

			return iRpt_BankReconciliationExt;
		}
	}
}
