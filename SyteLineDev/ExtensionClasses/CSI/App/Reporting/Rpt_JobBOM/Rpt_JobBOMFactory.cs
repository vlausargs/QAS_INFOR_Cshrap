//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobBOMFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Adapters;
using CSI.DataCollection;
using CSI.App.Reporting.Rpt_JobBOM;
using CSI.CRUD.Reporting;

namespace CSI.Reporting
{
	public class Rpt_JobBOMFactory
	{
		public const string IDO = "SLJobBOMReport";
		public const string Method = "Rpt_JobBOM";

		public IRpt_JobBOM Create(
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
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
			var iUomConvAmt = new UomConvAmtFactory().Create(cSIExtensionClassBase);
			var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
			var iGetCode = new GetCodeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
            var iRpt_JobBOMCRUD = new Rpt_JobBOMCRUD(appDB, collectionLoadRequestFactory, variableUtil);
            var rpt_JobBOMChangeValueForUbVisibleAndUbFlag = new Rpt_JobBOMChangeValueForUbVisibleAndUbFlag();

            IRpt_JobBOM _Rpt_JobBOM = new Rpt_JobBOM(appDB,
				bunchedLoadCollection,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iGetWinRegDecGroup,
				iFixMaskForCrystal,
				iIsAddonAvailable,
				iExpandKyByType,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				iHighAnyInt,
				iUomConvAmt,
				iUomConvQty,
				stringUtil,
				iLowAnyInt,
				iGetCode,
				iGetumcf,
				sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                iRpt_JobBOMCRUD,
                rpt_JobBOMChangeValueForUbVisibleAndUbFlag);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_JobBOM = IDOMethodIntercept<IRpt_JobBOM>.Create(_Rpt_JobBOM, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobBOMExt = timerfactory.Create<IRpt_JobBOM>(_Rpt_JobBOM);

			return iRpt_JobBOMExt;
		}
	}
}
