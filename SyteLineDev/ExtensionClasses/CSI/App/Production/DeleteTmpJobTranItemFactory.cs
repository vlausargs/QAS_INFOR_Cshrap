//PROJECT NAME: Production
//CLASS NAME: DeleteTmpJobTranItemFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Production
{
	public class DeleteTmpJobTranItemFactory
	{
		public const string IDO = "SLJobTrans";
		public const string Method = "DeleteTmpJobTranItem";
		
		public IDeleteTmpJobTranItem Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
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
			
			IDeleteTmpJobTranItem _DeleteTmpJobTranItem = new DeleteTmpJobTranItem(appDB,
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
				_DeleteTmpJobTranItem = IDOMethodIntercept<IDeleteTmpJobTranItem>.Create(_DeleteTmpJobTranItem, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteTmpJobTranItemExt = timerfactory.Create<IDeleteTmpJobTranItem>(_DeleteTmpJobTranItem);
			
			return iDeleteTmpJobTranItemExt;
		}
	}
}
