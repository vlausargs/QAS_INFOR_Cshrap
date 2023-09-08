//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBUMAlternateFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.BusInterface
{
	public class CLM_ESBUMAlternateFactory
	{
		public const string IDO = "ESBUMAltViews";
		public const string Method = "CLM_ESBUMAlternate";

		public ICLM_ESBUMAlternate Create(
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
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var iCLM_ESBUMAlternateCRUD = new CLM_ESBUMAlternateCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);

			ICLM_ESBUMAlternate _CLM_ESBUMAlternate = new CLM_ESBUMAlternate(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil,
				iCLM_ESBUMAlternateCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ESBUMAlternate = IDOMethodIntercept<ICLM_ESBUMAlternate>.Create(_CLM_ESBUMAlternate, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBUMAlternateExt = timerfactory.Create<ICLM_ESBUMAlternate>(_CLM_ESBUMAlternate);

			return iCLM_ESBUMAlternateExt;
		}
	}
}
