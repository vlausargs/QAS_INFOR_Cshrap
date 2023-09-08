//PROJECT NAME: Logistics
//CLASS NAME: SSSFSInspectionsPreviewCleanupFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Logistics.FieldService
{
	public class SSSFSInspectionsPreviewCleanupFactory
	{
		public const string IDO = "FSTmpInspects";
		public const string Method = "SSSFSInspectionsPreviewCleanup";
		
		public ISSSFSInspectionsPreviewCleanup Create(
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
			var stringUtil = new StringUtil();
			var iSessionID = cSIExtensionClassBase.MongooseDependencies.SessionID;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			ISSSFSInspectionsPreviewCleanup _SSSFSInspectionsPreviewCleanup = new SSSFSInspectionsPreviewCleanup(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				existsChecker,
				stringUtil,
				iSessionID,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_SSSFSInspectionsPreviewCleanup = IDOMethodIntercept<ISSSFSInspectionsPreviewCleanup>.Create(_SSSFSInspectionsPreviewCleanup, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSInspectionsPreviewCleanupExt = timerfactory.Create<ISSSFSInspectionsPreviewCleanup>(_SSSFSInspectionsPreviewCleanup);
			
			return iSSSFSInspectionsPreviewCleanupExt;
		}
	}
}
