//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobHeaderFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Linq;
using CSI.Material;
using CSI.Adapters;
using CSI.Logistics.Customer;

namespace CSI.Reporting
{
	public class Rpt_JobHeaderFactory
	{
		public const string IDO = "SLJobHeaderReport";
		public const string Method = "Rpt_JobHeader";

		public IRpt_JobHeader Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var iEXTSSSFSRpt_JobHeader = new EXTSSSFSRpt_JobHeaderFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCopySessionVariables = cSIExtensionClassBase.MongooseDependencies.CopySessionVariables;
			var iGetOrderInfoCustNum = new GetOrderInfoCustNumFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
			var iReportNotesExist = new ReportNotesExistFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
			var stringUtil = new StringUtil();
			var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
			var iGetCode = new GetCodeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iLeftPad = new LeftPadFactory().Create(cSIExtensionClassBase);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IRpt_JobHeader _Rpt_JobHeader = new Rpt_JobHeader(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				iEXTSSSFSRpt_JobHeader,
				sQLExpressionExecutor,
				iCopySessionVariables,
				iGetOrderInfoCustNum,
				iCloseSessionContext,
				iInitSessionContext,
				iGetIsolationLevel,
				transactionFactory,
				iIsAddonAvailable,
				iReportNotesExist,
				iApplyDateOffset,
				iExpandKyByType,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				iHighAnyInt,
				stringUtil,
				iLowAnyInt,
				iGetCode,
				iLeftPad,
				sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_JobHeader = IDOMethodIntercept<IRpt_JobHeader>.Create(_Rpt_JobHeader, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobHeaderExt = timerfactory.Create<IRpt_JobHeader>(_Rpt_JobHeader);

			return iRpt_JobHeaderExt;
		}
	}
}
