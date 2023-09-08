//PROJECT NAME: Logistics
//CLASS NAME: Homepage_POReturnsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
	public class Homepage_POReturnsFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_POReturns";
		private IExpandKyByTypeFactory expandKyByTypeFactory;
		private IMidnightOfFactory midnightOfFactory;
		private IGetLabelFactory getLabelFactory;

		public Homepage_POReturnsFactory(IExpandKyByTypeFactory expandKyByTypeFactory, IMidnightOfFactory midnightOfFactory, IGetLabelFactory getLabelFactory)
		{
			this.expandKyByTypeFactory = expandKyByTypeFactory;
			this.midnightOfFactory = midnightOfFactory;
			this.getLabelFactory = getLabelFactory;
		}

		public IHomepage_POReturns Create(IApplicationDB appDB,
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
			var iExpandKyByType = expandKyByTypeFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iMidnightOf = midnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iGetLabel = getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHomepage_POReturns _Homepage_POReturns = new Homepage_POReturns(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iExpandKyByType,
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
				_Homepage_POReturns = IDOMethodIntercept<IHomepage_POReturns>.Create(_Homepage_POReturns, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_POReturnsExt = timerfactory.Create<IHomepage_POReturns>(_Homepage_POReturns);

			return iHomepage_POReturnsExt;
		}
	}
}
