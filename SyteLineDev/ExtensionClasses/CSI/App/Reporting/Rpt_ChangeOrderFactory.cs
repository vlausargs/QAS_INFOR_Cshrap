//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChangeOrderFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;
using CSI.Admin;
using CSI.Material;
using CSI.Logistics.Customer;
using CSI.Codes;
using CSI.Logistics.Vendor;
using CSI.DataCollection;

namespace CSI.Reporting
{
	public class Rpt_ChangeOrderFactory
	{
		public const string IDO = "SLChangeOrderLaserReport";
		public const string Method = "Rpt_ChangeOrder";
		
		public IRpt_ChangeOrder Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var cSIRemoteMethodForReplicationTargets = new CSIRemoteMethodForReplicationTargetsFactory().Create(appDB);
			var iDisplayVendorAddressWithPhoneLang = new DisplayVendorAddressWithPhoneLangFactory().Create(cSIExtensionClassBase);
			var iDisplayOurAddressWithPhoneLang = new DisplayOurAddressWithPhoneLangFactory().Create(cSIExtensionClassBase);
			var iGetDropShipToAddrWithPhoneLang = new GetDropShipToAddrWithPhoneLangFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iDisplayAddressForReportFooter = new DisplayAddressForReportFooterFactory().Create(cSIExtensionClassBase);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var iGetParmsSingleLineAddress = new GetParmsSingleLineAddressFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iReleaseTmpTaxTables = new ReleaseTmpTaxTablesFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var iTaxPriceSeparation = new TaxPriceSeparationFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iAddProcessErrorLog = cSIExtensionClassBase.MongooseDependencies.AddProcessErrorLog;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iReportNotesExist = new ReportNotesExistFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iIsFeatureActive = new IsFeatureActiveFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iUseTmpTaxTables = new UseTmpTaxTablesFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var highCharacter = cSIExtensionClassBase.MongooseDependencies.HighCharacter;
			var lowCharacter = cSIExtensionClassBase.MongooseDependencies.LowCharacter;
			var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
			var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
			var iEuroInfo = new EuroInfoFactory().Create(appDB,mgInvoker,parameterProvider, calledFromIDO);
			var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iEuroPart = new EuroPartFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
            var mathUtil = new MathUtilFactory().Create();
			var iTaxBase = new TaxBaseFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iTaxCalc = new TaxCalcFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iRpt_ChangeOrderCRUD = new Rpt_ChangeOrderCRUD(appDB, collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				iReportNotesExist,
				existsChecker,
				variableUtil,
				stringUtil,
				sQLUtil);
			var iBankTransitNumLoader = new BankTransitNumLoader();


			IRpt_ChangeOrder _Rpt_ChangeOrder = new Rpt_ChangeOrder(cSIRemoteMethodForReplicationTargets,
				iDisplayVendorAddressWithPhoneLang,
				iDisplayOurAddressWithPhoneLang,
				iGetDropShipToAddrWithPhoneLang,
				iDisplayAddressForReportFooter,
				collectionLoadResponseUtil,
				iGetParmsSingleLineAddress,
				sQLExpressionExecutor,
				iReleaseTmpTaxTables,
				iCloseSessionContext,
				iInitSessionContext,
				iTaxPriceSeparation,
				iAddProcessErrorLog,
				transactionFactory,
				iGetIsolationLevel,
				iReportNotesExist,
				iIsFeatureActive,
				iUseTmpTaxTables,
				iExpandKyByType,
				scalarFunction,
				convertToUtil,
				highCharacter,
				lowCharacter,
				iHighAnyInt,
				iUomConvQty,
				stringUtil,
				iLowAnyInt,
				iEuroInfo,
				iCurrCnvt,
				iEuroPart,
				mathUtil,
				iTaxBase,
				iTaxCalc,
				iGetumcf,
				sQLUtil,
				iRpt_ChangeOrderCRUD,
				iBankTransitNumLoader);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_ChangeOrder = IDOMethodIntercept<IRpt_ChangeOrder>.Create(_Rpt_ChangeOrder, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ChangeOrderExt = timerfactory.Create<IRpt_ChangeOrder>(_Rpt_ChangeOrder);
			
			return iRpt_ChangeOrderExt;
		}
	}
}
