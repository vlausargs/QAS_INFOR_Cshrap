//PROJECT NAME: Codes
//CLASS NAME: Home_MetricProdcodeValueFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Codes
{
	public class Home_MetricProdcodeValueFactory
	{
		public const string IDO = "SLDistAccts";
		public const string Method = "Home_MetricProdcodeValue";

		public IHome_MetricProdcodeValue Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCLM_PerTotByProdcode = new CLM_PerTotByProdcodeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iHome_MetricProdcodeValueCRUD = new Home_MetricProdcodeValueCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				existsChecker);

			IHome_MetricProdcodeValue _Home_MetricProdcodeValue = new Home_MetricProdcodeValue(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCLM_PerTotByProdcode,
				transactionFactory,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iHome_MetricProdcodeValueCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_MetricProdcodeValue = IDOMethodIntercept<IHome_MetricProdcodeValue>.Create(_Home_MetricProdcodeValue, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricProdcodeValueExt = timerfactory.Create<IHome_MetricProdcodeValue>(_Home_MetricProdcodeValue);

			return iHome_MetricProdcodeValueExt;
		}
	}
}
