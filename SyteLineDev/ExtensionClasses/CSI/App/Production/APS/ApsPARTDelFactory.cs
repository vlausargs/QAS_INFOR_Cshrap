//PROJECT NAME: Production
//CLASS NAME: ApsPARTDelFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.APS
{
	public class ApsPARTDelFactory
	{
		public const string IDO = "SLPARTnnns";
		public const string Method = "ApsPARTDel";

		public IApsPARTDel Create(
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
			var iApsPARTDelCRUD = new ApsPARTDelCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);

			IApsPARTDel _ApsPARTDel = new ApsPARTDel(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				sQLCollectionLoad,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iApsPARTDelCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ApsPARTDel = IDOMethodIntercept<IApsPARTDel>.Create(_ApsPARTDel, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsPARTDelExt = timerfactory.Create<IApsPARTDel>(_ApsPARTDel);

			return iApsPARTDelExt;
		}
	}
}
