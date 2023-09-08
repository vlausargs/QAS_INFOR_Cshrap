//PROJECT NAME: Logistics
//CLASS NAME: Homepage_MyCustomerOrdersFactory.cs

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
	public class Homepage_MyCustomerOrdersFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_MyCustomerOrders";

		readonly IGetLabelFactory iGetLabelFactory;

		public Homepage_MyCustomerOrdersFactory(IGetLabelFactory iGetLabelFactory)
		{
			this.iGetLabelFactory = iGetLabelFactory;
		}

		public IHomepage_MyCustomerOrders Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iGetLabel = this.iGetLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHomepage_MyCustomerOrders _Homepage_MyCustomerOrders = new Homepage_MyCustomerOrders(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
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
				_Homepage_MyCustomerOrders = IDOMethodIntercept<IHomepage_MyCustomerOrders>.Create(_Homepage_MyCustomerOrders, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MyCustomerOrdersExt = timerfactory.Create<IHomepage_MyCustomerOrders>(_Homepage_MyCustomerOrders);

			return iHomepage_MyCustomerOrdersExt;
		}
	}
}
