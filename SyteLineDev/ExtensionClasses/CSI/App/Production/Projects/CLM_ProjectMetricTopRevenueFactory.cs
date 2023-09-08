//PROJECT NAME: Production
//CLASS NAME: CLM_ProjectMetricTopRevenueFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.Projects
{
	public class CLM_ProjectMetricTopRevenueFactory
	{
		public const string IDO = "SLProjs";
		public const string Method = "CLM_ProjectMetricTopRevenue";
		
		public ICLM_ProjectMetricTopRevenue Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iCLM_ProjectMetricTopRevenueCRUD = new CLM_ProjectMetricTopRevenueCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker);
			
			ICLM_ProjectMetricTopRevenue _CLM_ProjectMetricTopRevenue = new CLM_ProjectMetricTopRevenue(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iCLM_ProjectMetricTopRevenueCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ProjectMetricTopRevenue = IDOMethodIntercept<ICLM_ProjectMetricTopRevenue>.Create(_CLM_ProjectMetricTopRevenue, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProjectMetricTopRevenueExt = timerfactory.Create<ICLM_ProjectMetricTopRevenue>(_CLM_ProjectMetricTopRevenue);
			
			return iCLM_ProjectMetricTopRevenueExt;
		}
	}
}
