//PROJECT NAME: Material
//CLASS NAME: AU_GetAvaiableParentContainersFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Material
{
	public class AU_GetAvaiableParentContainersFactory
	{
		public const string IDO = "SLContainers";
		public const string Method = "AU_GetAvaiableParentContainers";
		
		public IAU_GetAvaiableParentContainers Create(
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
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var iAU_GetAvaiableParentContainersCRUD = new AU_GetAvaiableParentContainersCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);
			
			IAU_GetAvaiableParentContainers _AU_GetAvaiableParentContainers = new AU_GetAvaiableParentContainers(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iIsAddonAvailable,
				scalarFunction,
				sQLUtil,
				iAU_GetAvaiableParentContainersCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_AU_GetAvaiableParentContainers = IDOMethodIntercept<IAU_GetAvaiableParentContainers>.Create(_AU_GetAvaiableParentContainers, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_GetAvaiableParentContainersExt = timerfactory.Create<IAU_GetAvaiableParentContainers>(_AU_GetAvaiableParentContainers);
			
			return iAU_GetAvaiableParentContainersExt;
		}
	}
}
