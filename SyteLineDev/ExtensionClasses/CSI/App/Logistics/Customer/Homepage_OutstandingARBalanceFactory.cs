//PROJECT NAME: Logistics
//CLASS NAME: Homepage_OutstandingARBalanceFactory.cs

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
	public class Homepage_OutstandingARBalanceFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_OutstandingARBalance";

		readonly IMidnightOfFactory iMidnightOfFactory;
		readonly IGetLabelFactory iGetLabelFactory;
		public Homepage_OutstandingARBalanceFactory(IMidnightOfFactory iMidnightOfFactory, IGetLabelFactory iGetLabelFactory)
		{
			this.iMidnightOfFactory = iMidnightOfFactory;
			this.iGetLabelFactory = iGetLabelFactory;
		}

		public IHomepage_OutstandingARBalance Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iMidnightOf = this.iMidnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iGetLabel = this.iGetLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IHomepage_OutstandingARBalance _Homepage_OutstandingARBalance = new Homepage_OutstandingARBalance(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				convertToUtil,
				dateTimeUtil,
				variableUtil,
				iMidnightOf,
				stringUtil,
				iGetLabel,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_OutstandingARBalance = IDOMethodIntercept<IHomepage_OutstandingARBalance>.Create(_Homepage_OutstandingARBalance, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_OutstandingARBalanceExt = timerfactory.Create<IHomepage_OutstandingARBalance>(_Homepage_OutstandingARBalance);
			
			return iHomepage_OutstandingARBalanceExt;
		}
	}
}
