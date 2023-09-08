//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUser3Factory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.Quality
{
	public class RSQC_GetUser3Factory
	{
		public const string IDO = "RS_QCPhaseds";
		public const string Method = "RSQC_GetUser3";
		
		public IRSQC_GetUser3 Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iRSQC_GetUser3CRUD = new RSQC_GetUser3CRUD(appDB, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker);
			IRSQC_GetUser3 _RSQC_GetUser3 = new RSQC_GetUser3(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iIsAddonAvailable,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iRSQC_GetUser3CRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_RSQC_GetUser3 = IDOMethodIntercept<IRSQC_GetUser3>.Create(_RSQC_GetUser3, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetUser3Ext = timerfactory.Create<IRSQC_GetUser3>(_RSQC_GetUser3);
			
			return iRSQC_GetUser3Ext;
		}
	}
}
