//PROJECT NAME: POS
//CLASS NAME: SSSPOSSerialClearFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.CRUD.POS;

namespace CSI.POS
{
	public class SSSPOSSerialClearFactory
	{
		public const string IDO = "POSMMatls";
		public const string Method = "SSSPOSSerialClear";

		public ISSSPOSSerialClear Create(
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
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var iSSSPOSSerialClearCRUD = new SSSPOSSerialClearCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);

			ISSSPOSSerialClear _SSSPOSSerialClear = new SSSPOSSerialClear(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil,
				iSSSPOSSerialClearCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_SSSPOSSerialClear = IDOMethodIntercept<ISSSPOSSerialClear>.Create(_SSSPOSSerialClear, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSSerialClearExt = timerfactory.Create<ISSSPOSSerialClear>(_SSSPOSSerialClear);

			return iSSSPOSSerialClearExt;
		}
	}
}
