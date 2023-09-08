//PROJECT NAME: Logistics
//CLASS NAME: CLM_ListLeadsmobiFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
	public class CLM_ListLeadsmobiFactory
	{
		public const string IDO = "SLLeads";
		public const string Method = "CLM_ListLeadsmobi";
		
		public ICLM_ListLeadsmobi Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var iCLM_ListLeadsmobiCRUD = new CLM_ListLeadsmobiCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);
			
			ICLM_ListLeadsmobi _CLM_ListLeadsmobi = new CLM_ListLeadsmobi(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil,
				iCLM_ListLeadsmobiCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ListLeadsmobi = IDOMethodIntercept<ICLM_ListLeadsmobi>.Create(_CLM_ListLeadsmobi, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ListLeadsmobiExt = timerfactory.Create<ICLM_ListLeadsmobi>(_CLM_ListLeadsmobi);
			
			return iCLM_ListLeadsmobiExt;
		}
	}
}
