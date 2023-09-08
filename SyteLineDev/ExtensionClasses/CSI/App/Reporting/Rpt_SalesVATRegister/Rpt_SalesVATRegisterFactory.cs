//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesVATRegisterFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Codes;
using CSI.Admin;
using CSI.Material;
using CSI.Logistics.Vendor;

namespace CSI.Reporting
{
	public class Rpt_SalesVATRegisterFactory
	{
		public const string IDO = "SLSalesVATRegisterReport";
		public const string Method = "Rpt_SalesVATRegister";

		public IRpt_SalesVATRegister Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iDisplayOurAddress = new DisplayOurAddressFactory().Create(cSIExtensionClassBase);
			var iGetWinRegDecGroup = new GetWinRegDecGroupFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iFixMaskForCrystal = new FixMaskForCrystalFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iIsAddonAvailable = new IsAddonAvailableFactory().Create(cSIExtensionClassBase);
			var iMultiLineAddress = new MultiLineAddressFactory().Create(cSIExtensionClassBase);
			var iIsFeatureActive = new IsFeatureActiveFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var Rpt_SalesVATRegisterGetInvHdrDate = new Rpt_SalesVATRegisterGetInvHdrTaxDate(sQLUtil, convertToUtil);

			IRpt_SalesVATRegister _Rpt_SalesVATRegister = new Rpt_SalesVATRegister(appDB,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iDisplayOurAddress,
				iGetWinRegDecGroup,
				iFixMaskForCrystal,
				iIsAddonAvailable,
				iMultiLineAddress,
				iIsFeatureActive,
				iApplyDateOffset,
				iExpandKyByType,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				stringUtil,
				iCurrCnvt,
				mathUtil,
				sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowString,
                cSIExtensionClassBase.MongooseDependencies.HighString,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter,
				Rpt_SalesVATRegisterGetInvHdrDate
				);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_SalesVATRegister = IDOMethodIntercept<IRpt_SalesVATRegister>.Create(_Rpt_SalesVATRegister, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalesVATRegisterExt = timerfactory.Create<IRpt_SalesVATRegister>(_Rpt_SalesVATRegister);

			return iRpt_SalesVATRegisterExt;
		}
	}
}
