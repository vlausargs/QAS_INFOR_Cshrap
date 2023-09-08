//PROJECT NAME: Production
//CLASS NAME: PmfFmGetRevisionFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmGetRevisionFactory
	{
		public const string IDO = "PmfFormulasBase";
		public const string Method = "PmfFmGetRevision";
		
		public IPmfFmGetRevision Create(
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
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iPmfFmGetRevisionCRUD = new PmfFmGetRevisionCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker);
			
			IPmfFmGetRevision _PmfFmGetRevision = new PmfFmGetRevision(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iPmfFmGetRevisionCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_PmfFmGetRevision = IDOMethodIntercept<IPmfFmGetRevision>.Create(_PmfFmGetRevision, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmGetRevisionExt = timerfactory.Create<IPmfFmGetRevision>(_PmfFmGetRevision);
			
			return iPmfFmGetRevisionExt;
		}
	}
}
