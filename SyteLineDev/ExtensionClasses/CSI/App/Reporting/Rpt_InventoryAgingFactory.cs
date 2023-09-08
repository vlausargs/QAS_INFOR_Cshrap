//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryAgingFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Reporting
{
	public class Rpt_InventoryAgingFactory
	{
		public const string IDO = "SLInventoryAgingReport";
		public const string Method = "Rpt_InventoryAging";

		public IRpt_InventoryAging Create(
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
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMaxQty = new MaxQtyFactory().Create(cSIExtensionClassBase);

			IRpt_InventoryAging _Rpt_InventoryAging = new Rpt_InventoryAging(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				sQLCollectionLoad,
				scalarFunction,
				existsChecker,
				convertToUtil,
				iGetSiteDate,
				dateTimeUtil,
				stringUtil,
				sQLUtil,
				iMaxQty,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_InventoryAging = IDOMethodIntercept<IRpt_InventoryAging>.Create(_Rpt_InventoryAging, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryAgingExt = timerfactory.Create<IRpt_InventoryAging>(_Rpt_InventoryAging);

			return iRpt_InventoryAgingExt;
		}
	}
}
