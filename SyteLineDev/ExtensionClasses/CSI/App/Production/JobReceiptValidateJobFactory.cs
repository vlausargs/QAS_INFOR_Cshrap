//PROJECT NAME: Production
//CLASS NAME: JobReceiptValidateJobFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Customer;

namespace CSI.Production
{
	public class JobReceiptValidateJobFactory
	{
		public const string IDO = "SLJobs";
		public const string Method = "JobReceiptValidateJob";

		public IJobReceiptValidateJob Create(
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
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iObsSlow = new ObsSlowFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iFmtJob = new FmtJobFactory().Create(cSIExtensionClassBase);
			var iMsgApp = new MsgApp(appDB);
			var iMsgAsk = cSIExtensionClassBase.MongooseDependencies.MsgAsk;

			IJobReceiptValidateJob _JobReceiptValidateJob = new JobReceiptValidateJob(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				variableUtil,
				stringUtil,
				iObsSlow,
				sQLUtil,
				iFmtJob,
				iMsgApp,
				iMsgAsk);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_JobReceiptValidateJob = IDOMethodIntercept<IJobReceiptValidateJob>.Create(_JobReceiptValidateJob, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobReceiptValidateJobExt = timerfactory.Create<IJobReceiptValidateJob>(_JobReceiptValidateJob);

			return iJobReceiptValidateJobExt;
		}
	}
}
