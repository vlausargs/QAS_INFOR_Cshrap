//PROJECT NAME: Finance
//CLASS NAME: CLM_SitesWithSameBaseCurrFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Finance
{
	public class CLM_SitesWithSameBaseCurrFactory
	{
		public const string IDO = "SLJournals";
		public const string Method = "CLM_SitesWithSameBaseCurr";
		
		public ICLM_SitesWithSameBaseCurr Create(
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
			var iCLM_SitesWithSameBaseCurrCRUD = new CLM_SitesWithSameBaseCurrCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);
			
			ICLM_SitesWithSameBaseCurr _CLM_SitesWithSameBaseCurr = new CLM_SitesWithSameBaseCurr(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil,
				iCLM_SitesWithSameBaseCurrCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_SitesWithSameBaseCurr = IDOMethodIntercept<ICLM_SitesWithSameBaseCurr>.Create(_CLM_SitesWithSameBaseCurr, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SitesWithSameBaseCurrExt = timerfactory.Create<ICLM_SitesWithSameBaseCurr>(_CLM_SitesWithSameBaseCurr);
			
			return iCLM_SitesWithSameBaseCurrExt;
		}
	}
}
