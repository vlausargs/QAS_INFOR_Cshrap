//PROJECT NAME: Codes
//CLASS NAME: CLM_GetInvProceduralMarkingsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Material;

namespace CSI.Codes
{
	public class CLM_GetInvProceduralMarkingsFactory
	{
		public const string IDO = "SLInvProceduralMarkingAlls";
		public const string Method = "CLM_GetInvProceduralMarkings";

		public ICLM_GetInvProceduralMarkings Create(
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
			var expandKyByType = new ExpandKyByType(appDB);
			var iCLM_GetInvProceduralMarkingsCRUD = new CLM_GetInvProceduralMarkingsCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);

			ICLM_GetInvProceduralMarkings _CLM_GetInvProceduralMarkings = new CLM_GetInvProceduralMarkings(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				sQLUtil,
				iCLM_GetInvProceduralMarkingsCRUD,
				expandKyByType);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_GetInvProceduralMarkings = IDOMethodIntercept<ICLM_GetInvProceduralMarkings>.Create(_CLM_GetInvProceduralMarkings, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetInvProceduralMarkingsExt = timerfactory.Create<ICLM_GetInvProceduralMarkings>(_CLM_GetInvProceduralMarkings);

			return iCLM_GetInvProceduralMarkingsExt;
		}
	}
}
