//PROJECT NAME: Production
//CLASS NAME: CLM_ProjectMetricTopPlanCostFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.Projects
{
	public class CLM_ProjectMetricTopPlanCostFactory
	{
		public const string IDO = "SLProjs";
		public const string Method = "CLM_ProjectMetricTopPlanCost";
		
		public ICLM_ProjectMetricTopPlanCost Create(
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
			var iCLM_ProjectMetricTopPlanCostCRUD = new CLM_ProjectMetricTopPlanCostCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker);
			
			ICLM_ProjectMetricTopPlanCost _CLM_ProjectMetricTopPlanCost = new CLM_ProjectMetricTopPlanCost(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iCLM_ProjectMetricTopPlanCostCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ProjectMetricTopPlanCost = IDOMethodIntercept<ICLM_ProjectMetricTopPlanCost>.Create(_CLM_ProjectMetricTopPlanCost, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProjectMetricTopPlanCostExt = timerfactory.Create<ICLM_ProjectMetricTopPlanCost>(_CLM_ProjectMetricTopPlanCost);
			
			return iCLM_ProjectMetricTopPlanCostExt;
		}
	}
}
