//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricJobWIPFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Production;

namespace CSI.Logistics.Customer
{
	public class Home_MetricJobWIPFactory
	{
		public const string IDO = "SLControllerAlls";
		public const string Method = "Home_MetricJobWIP";
		
		public IHome_MetricJobWIP Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var iFmtJob = new FmtJobFactory().Create(cSIExtensionClassBase);
			var iHome_MetricJobWIPCRUD = new Home_MetricJobWIPCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil,
				iFmtJob,
                sQLExpressionExecutor,
                collectionLoadResponseUtil);
			
			IHome_MetricJobWIP _Home_MetricJobWIP = new Home_MetricJobWIP(
				transactionFactory,
				scalarFunction,
				sQLUtil,
				iHome_MetricJobWIPCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_MetricJobWIP = IDOMethodIntercept<IHome_MetricJobWIP>.Create(_Home_MetricJobWIP, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricJobWIPExt = timerfactory.Create<IHome_MetricJobWIP>(_Home_MetricJobWIP);
			
			return iHome_MetricJobWIPExt;
		}
	}
}
