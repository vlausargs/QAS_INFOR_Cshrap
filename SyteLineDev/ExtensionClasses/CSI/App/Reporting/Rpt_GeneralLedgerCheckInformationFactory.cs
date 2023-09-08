//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GeneralLedgerCheckInformationFactory.cs

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
	public class Rpt_GeneralLedgerCheckInformationFactory
	{
		public const string IDO = "SLGeneralLedgerCheckInformationReport";
		public const string Method = "Rpt_GeneralLedgerCheckInformation";

		public IRpt_GeneralLedgerCheckInformation Create(
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
			var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iRpt_GeneralLedgerCheckInformationCRUD = new Rpt_GeneralLedgerCheckInformationCRUD(appDB, bunchedLoadCollection, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil, stringUtil);
			IRpt_GeneralLedgerCheckInformation _Rpt_GeneralLedgerCheckInformation = new Rpt_GeneralLedgerCheckInformation(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				sQLCollectionLoad,
				iApplyDateOffset,
				iExpandKyByType,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iRpt_GeneralLedgerCheckInformationCRUD,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_GeneralLedgerCheckInformation = IDOMethodIntercept<IRpt_GeneralLedgerCheckInformation>.Create(_Rpt_GeneralLedgerCheckInformation, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GeneralLedgerCheckInformationExt = timerfactory.Create<IRpt_GeneralLedgerCheckInformation>(_Rpt_GeneralLedgerCheckInformation);

			return iRpt_GeneralLedgerCheckInformationExt;
		}
	}
}
