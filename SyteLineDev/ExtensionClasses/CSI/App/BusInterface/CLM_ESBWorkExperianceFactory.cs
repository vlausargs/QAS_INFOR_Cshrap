//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBWorkExperianceFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.BusInterface
{
	public class CLM_ESBWorkExperianceFactory
	{
		public const string IDO = "ESBWorkExperianceViews";
		public const string Method = "CLM_ESBWorkExperiance";

		public ICLM_ESBWorkExperiance Create(
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
			var iCLM_ESBWorkExperianceCRUD = new CLM_ESBWorkExperianceCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);

			ICLM_ESBWorkExperiance _CLM_ESBWorkExperiance = new CLM_ESBWorkExperiance(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil,
				iCLM_ESBWorkExperianceCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ESBWorkExperiance = IDOMethodIntercept<ICLM_ESBWorkExperiance>.Create(_CLM_ESBWorkExperiance, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBWorkExperianceExt = timerfactory.Create<ICLM_ESBWorkExperiance>(_CLM_ESBWorkExperiance);

			return iCLM_ESBWorkExperianceExt;
		}
	}
}
