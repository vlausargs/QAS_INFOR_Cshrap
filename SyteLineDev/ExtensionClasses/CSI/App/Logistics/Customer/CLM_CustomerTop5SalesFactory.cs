//PROJECT NAME: Logistics
//CLASS NAME: CLM_CustomerTop5SalesFactory.cs

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
	public class CLM_CustomerTop5SalesFactory
	{
		public const string IDO = "SLCoitems";
		public const string Method = "CLM_CustomerTop5Sales";
		
		public ICLM_CustomerTop5Sales Create(
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
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
			var stringUtil = new StringUtil();
			var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iCLM_CustomerTop5SalesCRUD = new CLM_CustomerTop5SalesCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker);
			
			ICLM_CustomerTop5Sales _CLM_CustomerTop5Sales = new CLM_CustomerTop5Sales(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				convertToUtil,
				iGetSiteDate,
				stringUtil,
				iDayEndOf,
				sQLUtil,
				iCLM_CustomerTop5SalesCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_CustomerTop5Sales = IDOMethodIntercept<ICLM_CustomerTop5Sales>.Create(_CLM_CustomerTop5Sales, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CustomerTop5SalesExt = timerfactory.Create<ICLM_CustomerTop5Sales>(_CLM_CustomerTop5Sales);
			
			return iCLM_CustomerTop5SalesExt;
		}
	}
}
