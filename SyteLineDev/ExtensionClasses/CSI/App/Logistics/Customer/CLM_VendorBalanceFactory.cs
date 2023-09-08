//PROJECT NAME: Logistics
//CLASS NAME: CLM_VendorBalanceFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
	public class CLM_VendorBalanceFactory
	{
		public const string IDO = "SLControllerAlls";
		public const string Method = "CLM_VendorBalance";

		public ICLM_VendorBalance Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iDefaultToLocalSite = cSIExtensionClassBase.MongooseDependencies.DefaultToLocalSite;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iInterpretText = cSIExtensionClassBase.MongooseDependencies.InterpretText;
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iDoubleQuote = cSIExtensionClassBase.MongooseDependencies.DoubleQuote;
			var stringUtil = new StringUtil();
			var iDoAPAging = new DoAPAgingFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			ICLM_VendorBalance _CLM_VendorBalance = new CLM_VendorBalance(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iDefaultToLocalSite,
				transactionFactory,
				iExecuteDynamicSQL,
				scalarFunction,
				iInterpretText,
				existsChecker,
				convertToUtil,
				variableUtil,
				iDoubleQuote,
				stringUtil,
				iDoAPAging,
				sQLUtil);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_VendorBalance = IDOMethodIntercept<ICLM_VendorBalance>.Create(_CLM_VendorBalance, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_VendorBalanceExt = timerfactory.Create<ICLM_VendorBalance>(_CLM_VendorBalance);

			return iCLM_VendorBalanceExt;
		}
	}
}
