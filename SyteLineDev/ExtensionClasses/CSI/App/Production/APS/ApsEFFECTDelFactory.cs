//PROJECT NAME: Production
//CLASS NAME: ApsEFFECTDelFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
	public class ApsEFFECTDelFactory
	{
		public const string IDO = "SLEFFECTnnns";
		public const string Method = "ApsEFFECTDel";

		public IApsEFFECTDel Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iApsEFFECTDelCRUD = new ApsEFFECTDelCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);

			IApsEFFECTDel _ApsEFFECTDel = new ApsEFFECTDel(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				sQLCollectionLoad,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iApsEFFECTDelCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ApsEFFECTDel = IDOMethodIntercept<IApsEFFECTDel>.Create(_ApsEFFECTDel, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsEFFECTDelExt = timerfactory.Create<IApsEFFECTDel>(_ApsEFFECTDel);

			return iApsEFFECTDelExt;
		}
	}
}
