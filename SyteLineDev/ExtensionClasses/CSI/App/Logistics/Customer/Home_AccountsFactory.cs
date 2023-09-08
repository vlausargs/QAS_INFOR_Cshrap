//PROJECT NAME: Logistics
//CLASS NAME: Home_AccountsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
	public class Home_AccountsFactory
	{
		public const string IDO = "SLControllerAlls";
		public const string Method = "Home_Accounts";
		private IBuildXMLFilterStringFactory buildXMLFilterStringFactory;
		private IExecuteDynamicSQLFactory executeDynamicSQLFactory;
		private IDoubleQuoteFactory doubleQuoteFactory;
		private IMidnightOfFactory midnightOfFactory;
		private IDayEndOfFactory dayEndOfFactory;

		public Home_AccountsFactory(IBuildXMLFilterStringFactory buildXMLFilterStringFactory, IExecuteDynamicSQLFactory executeDynamicSQLFactory,
			 IDoubleQuoteFactory doubleQuoteFactory, IMidnightOfFactory midnightOfFactory, IDayEndOfFactory dayEndOfFactory)
		{
			this.buildXMLFilterStringFactory = buildXMLFilterStringFactory;
			this.executeDynamicSQLFactory = executeDynamicSQLFactory;
			this.doubleQuoteFactory = doubleQuoteFactory;
			this.midnightOfFactory = midnightOfFactory;
			this.dayEndOfFactory = dayEndOfFactory;
		}
		public IHome_Accounts Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iBuildXMLFilterString = buildXMLFilterStringFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iExecuteDynamicSQL = executeDynamicSQLFactory.Create(appDB, bunchedLoadCollection, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iDoubleQuote = doubleQuoteFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iMidnightOf = midnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iDayEndOf = dayEndOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHome_Accounts _Home_Accounts = new Home_Accounts(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iBuildXMLFilterString,
				iExecuteDynamicSQL,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				iDoubleQuote,
				iMidnightOf,
				stringUtil,
				iDayEndOf,
				sQLUtil);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_Accounts = IDOMethodIntercept<IHome_Accounts>.Create(_Home_Accounts, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_AccountsExt = timerfactory.Create<IHome_Accounts>(_Home_Accounts);

			return iHome_AccountsExt;
		}
	}
}
