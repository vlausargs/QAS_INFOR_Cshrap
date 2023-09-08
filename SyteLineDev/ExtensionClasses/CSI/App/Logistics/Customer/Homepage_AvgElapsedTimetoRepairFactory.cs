//PROJECT NAME: Logistics
//CLASS NAME: Homepage_AvgElapsedTimetoRepairFactory.cs

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
	public class Homepage_AvgElapsedTimetoRepairFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_AvgElapsedTimetoRepair";

		private IMidnightOfFactory midnightOfFactory;
		private IGetLabelFactory getLabelFactory;

		public Homepage_AvgElapsedTimetoRepairFactory(IMidnightOfFactory midnightOfFactory, IGetLabelFactory getLabelFactory)
		{
			this.midnightOfFactory = midnightOfFactory;
			this.getLabelFactory = getLabelFactory;
		}

		public IHomepage_AvgElapsedTimetoRepair Create(IApplicationDB appDB,
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
			var iMidnightOf = midnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iGetLabel = getLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHomepage_AvgElapsedTimetoRepair _Homepage_AvgElapsedTimetoRepair = new Homepage_AvgElapsedTimetoRepair(appDB,
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
				_Homepage_AvgElapsedTimetoRepair = IDOMethodIntercept<IHomepage_AvgElapsedTimetoRepair>.Create(_Homepage_AvgElapsedTimetoRepair, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_AvgElapsedTimetoRepairExt = timerfactory.Create<IHomepage_AvgElapsedTimetoRepair>(_Homepage_AvgElapsedTimetoRepair);

			return iHomepage_AvgElapsedTimetoRepairExt;
		}
	}
}
