//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobPickListFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Production;

namespace CSI.Reporting
{
	public class Rpt_JobPickListFactory
	{
		public const string IDO = "SLJobPickListReport";
		public const string Method = "Rpt_JobPickList";

		public IRpt_JobPickList Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var iInitSessionContextWithUser = cSIExtensionClassBase.MongooseDependencies.InitSessionContextWithUser;
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCopySessionVariables = cSIExtensionClassBase.MongooseDependencies.CopySessionVariables;
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iAddProcessErrorLog = cSIExtensionClassBase.MongooseDependencies.AddProcessErrorLog;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iGetCodeDesc = new GetCodeDescFactory().Create(cSIExtensionClassBase);
			var stringUtil = new StringUtil();
			var iUserName = cSIExtensionClassBase.MongooseDependencies.UserName;
			var iJobPick = new JobPickFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var iFmtJob = new FmtJobFactory().Create(cSIExtensionClassBase);

			IRpt_JobPickList _Rpt_JobPickList = new Rpt_JobPickList(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				iInitSessionContextWithUser,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCopySessionVariables,
				iCloseSessionContext,
				iAddProcessErrorLog,
				transactionFactory,
				iGetIsolationLevel,
				iGetWinRegDecGroup,
				iFixMaskForCrystal,
				iDefineVariable,
				iExpandKyByType,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				iGetCodeDesc,
				stringUtil,
				iUserName,
				iJobPick,
				sQLUtil,
				iMsgApp,
				iFmtJob);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_JobPickList = IDOMethodIntercept<IRpt_JobPickList>.Create(_Rpt_JobPickList, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobPickListExt = timerfactory.Create<IRpt_JobPickList>(_Rpt_JobPickList);

			return iRpt_JobPickListExt;
		}
	}
}
