//PROJECT NAME: Logistics
//CLASS NAME: Homepage_MyPurchaseOrdersFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
	public class Homepage_MyPurchaseOrdersFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_MyPurchaseOrders";

		public IHomepage_MyPurchaseOrders Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iGetLabel = cSIExtensionClassBase.MongooseDependencies.GetLabel;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHomepage_MyPurchaseOrders _Homepage_MyPurchaseOrders = new Homepage_MyPurchaseOrders(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				existsChecker,
				convertToUtil,
				dateTimeUtil,
				variableUtil,
				stringUtil,
				iGetLabel,
				sQLUtil);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_MyPurchaseOrders = IDOMethodIntercept<IHomepage_MyPurchaseOrders>.Create(_Homepage_MyPurchaseOrders, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MyPurchaseOrdersExt = timerfactory.Create<IHomepage_MyPurchaseOrders>(_Homepage_MyPurchaseOrders);

			return iHomepage_MyPurchaseOrdersExt;
		}
	}
}
