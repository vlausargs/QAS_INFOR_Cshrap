//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARDraftPostingFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;
using CSI.Codes;
using CSI.Material;

namespace CSI.Reporting
{
	public class Rpt_ARDraftPostingFactory
	{
		public const string IDO = "SLARDraftPostingReport";
		public const string Method = "Rpt_ARDraftPosting";
		private IInitSessionContextWithUserFactory initSessionContextWithUserFactory;
		private ICloseSessionContextFactory closeSessionContextFactory;
		private IGetIsolationLevelFactory getIsolationLevelFactory;
		private IIsIntegerFactory isIntegerFactory;
		private IGetLabelFactory getLabelFactory;

		public Rpt_ARDraftPostingFactory(IInitSessionContextWithUserFactory initSessionContextWithUserFactory, ICloseSessionContextFactory closeSessionContextFactory,
			IGetIsolationLevelFactory getIsolationLevelFactory, IIsIntegerFactory isIntegerFactory, IGetLabelFactory getLabelFactory)
		{
			this.initSessionContextWithUserFactory = initSessionContextWithUserFactory;
			this.closeSessionContextFactory = closeSessionContextFactory;
			this.getIsolationLevelFactory = getIsolationLevelFactory;
			this.isIntegerFactory = isIntegerFactory;
			this.getLabelFactory = getLabelFactory;
		}

		public IRpt_ARDraftPosting Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO, ICSIExtensionClassBase cSIExtensionClassBase)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var iInitSessionContextWithUser = initSessionContextWithUserFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = closeSessionContextFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = getIsolationLevelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iDropDynamicTable = new DropDynamicTableFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iIsInteger = isIntegerFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iGetLabel = getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iEuroInfo = new EuroInfoFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iEuroPart = new EuroPartFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iEuroCnvt = new EuroCnvtFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iCurrPer = new CurrPerFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iAcctDB = new AcctDBFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iAcctD = new AcctDFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var rpt_ARDraftPostingIsNumberInvoice = new Rpt_ARDraftPostingIsNumberInvoice(sQLUtil, iIsInteger, convertToUtil);

            IRpt_ARDraftPosting _Rpt_ARDraftPosting = new Rpt_ARDraftPosting(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				iInitSessionContextWithUser,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iDropDynamicTable,
				iExpandKyByType,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				stringUtil,
				iIsInteger,
				iGetLabel,
				iEuroInfo,
				iEuroPart,
				iEuroCnvt,
				iCurrPer,
				mathUtil,
				sQLUtil,
				iAcctDB,
				iAcctD,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                rpt_ARDraftPostingIsNumberInvoice);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_ARDraftPosting = IDOMethodIntercept<IRpt_ARDraftPosting>.Create(_Rpt_ARDraftPosting, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARDraftPostingExt = timerfactory.Create<IRpt_ARDraftPosting>(_Rpt_ARDraftPosting);

			return iRpt_ARDraftPostingExt;
		}
	}
}
