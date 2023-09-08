//PROJECT NAME: Logistics
//CLASS NAME: Homepage_PastDueDatePOCountFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_PastDueDatePOCountFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_PastDueDatePOCount";
		
		public IHomepage_PastDueDatePOCount Create(IApplicationDB appDB,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
            var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IHomepage_PastDueDatePOCount _Homepage_PastDueDatePOCount = new Homepage_PastDueDatePOCount(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				stringUtil,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_PastDueDatePOCount = IDOMethodIntercept<IHomepage_PastDueDatePOCount>.Create(_Homepage_PastDueDatePOCount, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_PastDueDatePOCountExt = timerfactory.Create<IHomepage_PastDueDatePOCount>(_Homepage_PastDueDatePOCount);
			
			return iHomepage_PastDueDatePOCountExt;
		}
	}
}
