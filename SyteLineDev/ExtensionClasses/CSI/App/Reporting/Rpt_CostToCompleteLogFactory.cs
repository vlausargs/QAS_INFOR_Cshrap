//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CostToCompleteLogFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Reporting
{
	public class Rpt_CostToCompleteLogFactory
	{
		public const string IDO = "SLCostToCompleteLogReport";
		public const string Method = "Rpt_CostToCompleteLog";
		
		public IRpt_CostToCompleteLog Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase,true);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var highCharacter = cSIExtensionClassBase.MongooseDependencies.HighCharacter;
			var lowCharacter = cSIExtensionClassBase.MongooseDependencies.LowCharacter;
			var stringUtil = new StringUtil();
			var iHighInt = cSIExtensionClassBase.MongooseDependencies.HighInt;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iLowInt = cSIExtensionClassBase.MongooseDependencies.LowInt;
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iRpt_CostToCompleteLogCRUD = new Rpt_CostToCompleteLogCRUD(appDB, collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil);
			
			IRpt_CostToCompleteLog _Rpt_CostToCompleteLog = new Rpt_CostToCompleteLog(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iApplyDateOffset,
				iExpandKyByType,
				scalarFunction,
				convertToUtil,
				highCharacter,
				lowCharacter,
				stringUtil,
				iHighInt,
				sQLUtil,
				iLowInt,
				iRpt_CostToCompleteLogCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_CostToCompleteLog = IDOMethodIntercept<IRpt_CostToCompleteLog>.Create(_Rpt_CostToCompleteLog, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CostToCompleteLogExt = timerfactory.Create<IRpt_CostToCompleteLog>(_Rpt_CostToCompleteLog);
			
			return iRpt_CostToCompleteLogExt;
		}
	}
}
