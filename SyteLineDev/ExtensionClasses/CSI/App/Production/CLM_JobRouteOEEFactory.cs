//PROJECT NAME: Production
//CLASS NAME: CLM_JobRouteOEEFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production
{
	public class CLM_JobRouteOEEFactory
	{
		public const string IDO = "SLJrtResourceGroups";
		public const string Method = "CLM_JobRouteOEE";
		
		public ICLM_JobRouteOEE Create(
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
			var unionUtil = new UnionUtil(UnionType.Union, "col0");
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iCLM_JobRouteOEECRUD = new CLM_JobRouteOEECRUD(appDB, collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);
			
			ICLM_JobRouteOEE _CLM_JobRouteOEE = new CLM_JobRouteOEE(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				stringUtil,
				unionUtil,
				sQLUtil,
				iMsgApp,
				iCLM_JobRouteOEECRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_JobRouteOEE = IDOMethodIntercept<ICLM_JobRouteOEE>.Create(_CLM_JobRouteOEE, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_JobRouteOEEExt = timerfactory.Create<ICLM_JobRouteOEE>(_CLM_JobRouteOEE);
			
			return iCLM_JobRouteOEEExt;
		}
	}
}
