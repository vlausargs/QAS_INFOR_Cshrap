//PROJECT NAME: Material
//CLASS NAME: CheckLotManufacturerFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Material
{
	public class CheckLotManufacturerFactory
	{
		public const string IDO = "SLLots";
		public const string Method = "CheckLotManufacturer";
		
		public ICheckLotManufacturer Create(
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
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgAsk = cSIExtensionClassBase.MongooseDependencies.MsgAsk;
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iCheckLotManufacturerCRUD = new CheckLotManufacturerCRUD(appDB, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker);
			ICheckLotManufacturer _CheckLotManufacturer = new CheckLotManufacturer(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iMsgAsk,
				iCheckLotManufacturerCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CheckLotManufacturer = IDOMethodIntercept<ICheckLotManufacturer>.Create(_CheckLotManufacturer, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckLotManufacturerExt = timerfactory.Create<ICheckLotManufacturer>(_CheckLotManufacturer);
			
			return iCheckLotManufacturerExt;
		}
	}
}
