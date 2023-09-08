//PROJECT NAME: Logistics
//CLASS NAME: COReturnQtyValidateFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Admin;

namespace CSI.Logistics.Customer
{
	public class COReturnQtyValidateFactory
	{
		public const string IDO = "SLCoitemShps";
		public const string Method = "COReturnQtyValidate";

		public ICOReturnQtyValidate Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
			var iIsFeatureActive = new IsFeatureActiveFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var stringUtil = new StringUtil();
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);

			ICOReturnQtyValidate _COReturnQtyValidate = new COReturnQtyValidate(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iIsAddonAvailable,
				iIsFeatureActive,
				scalarFunction,
				existsChecker,
				convertToUtil,
				stringUtil,
				mathUtil,
				sQLUtil,
				iMsgApp);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_COReturnQtyValidate = IDOMethodIntercept<ICOReturnQtyValidate>.Create(_COReturnQtyValidate, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOReturnQtyValidateExt = timerfactory.Create<ICOReturnQtyValidate>(_COReturnQtyValidate);

			return iCOReturnQtyValidateExt;
		}
	}
}
