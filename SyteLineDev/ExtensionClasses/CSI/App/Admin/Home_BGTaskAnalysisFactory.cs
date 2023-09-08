//PROJECT NAME: Admin
//CLASS NAME: Home_BGTaskAnalysisFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Admin
{
	public class Home_BGTaskAnalysisFactory
	{
		public const string IDO = "SLBGTaskHistories";
		public const string Method = "Home_BGTaskAnalysis";

		private IExecuteDynamicSQLFactory executeDynamicSQLFactory;
		private IMidnightOfFactory midnightOfFactory;
		private IHighDateFactory highDateFactory;
		private IDayEndOfFactory dayEndOfFactory;
		private ILowDateFactory lowDateFactory;

		public Home_BGTaskAnalysisFactory(IExecuteDynamicSQLFactory executeDynamicSQLFactory, IMidnightOfFactory midnightOfFactory, IHighDateFactory highDateFactory,
			IDayEndOfFactory dayEndOfFactory, ILowDateFactory lowDateFactory)
		{
			this.executeDynamicSQLFactory = executeDynamicSQLFactory;
			this.midnightOfFactory = midnightOfFactory;
			this.highDateFactory = highDateFactory;
			this.dayEndOfFactory = dayEndOfFactory;
			this.lowDateFactory = lowDateFactory;
		}

		public IHome_BGTaskAnalysis Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iExecuteDynamicSQL = executeDynamicSQLFactory.Create(appDB, bunchedLoadCollection, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iMidnightOf = midnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iHighDate = highDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iDayEndOf = dayEndOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iLowDate = lowDateFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHome_BGTaskAnalysis _Home_BGTaskAnalysis = new Home_BGTaskAnalysis(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iExecuteDynamicSQL,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				iMidnightOf,
				stringUtil,
				iHighDate,
				iDayEndOf,
				iLowDate,
				sQLUtil);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_BGTaskAnalysis = IDOMethodIntercept<IHome_BGTaskAnalysis>.Create(_Home_BGTaskAnalysis, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_BGTaskAnalysisExt = timerfactory.Create<IHome_BGTaskAnalysis>(_Home_BGTaskAnalysis);

			return iHome_BGTaskAnalysisExt;
		}
	}
}
