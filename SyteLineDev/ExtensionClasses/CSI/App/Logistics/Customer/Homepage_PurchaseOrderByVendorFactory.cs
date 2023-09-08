//PROJECT NAME: Logistics
//CLASS NAME: Homepage_PurchaseOrderByVendorFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
	public class Homepage_PurchaseOrderByVendorFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_PurchaseOrderByVendor";
		
		public IHomepage_PurchaseOrderByVendor Create(IApplicationDB appDB,
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
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IHomepage_PurchaseOrderByVendor _Homepage_PurchaseOrderByVendor = new Homepage_PurchaseOrderByVendor(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				stringUtil,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_PurchaseOrderByVendor = IDOMethodIntercept<IHomepage_PurchaseOrderByVendor>.Create(_Homepage_PurchaseOrderByVendor, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_PurchaseOrderByVendorExt = timerfactory.Create<IHomepage_PurchaseOrderByVendor>(_Homepage_PurchaseOrderByVendor);
			
			return iHomepage_PurchaseOrderByVendorExt;
		}
	}
}
