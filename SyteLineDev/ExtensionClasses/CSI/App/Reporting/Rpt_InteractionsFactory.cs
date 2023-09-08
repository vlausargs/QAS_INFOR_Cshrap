//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InteractionsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Customer;
using CSI.Logistics.Vendor;
using CSI.Material;
using CSI.POS;

namespace CSI.Reporting
{
	public class Rpt_InteractionsFactory
	{
		public const string IDO = "SLInteractionsReport";
		public const string Method = "Rpt_Interactions";

		public IRpt_Interactions Create(
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
			var iFormatProspectAddress = new FormatProspectAddressFactory().Create(appDB);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iFormatContactAddress = new FormatContactAddressFactory().Create(appDB);
			var iFormatVendorAddress = new FormatVendorAddressFactory().Create(cSIExtensionClassBase);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetIsolationLevel = cSIExtensionClassBase.MongooseDependencies.GetIsolationLevel;
			var iReportNotesExist = new ReportNotesExistFactory().Create(cSIExtensionClassBase,true);
			var iApplyDateOffset = cSIExtensionClassBase.MongooseDependencies.ApplyDateOffset;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(cSIExtensionClassBase,true);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iFormatAddress = new FormatAddressFactory().Create(cSIExtensionClassBase);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iHighDecimal = new HighDecimalFactory().Create(cSIExtensionClassBase);
			var variableUtil = new VariableUtilFactory().Create();
			var iGetFullName = new GetFullNameFactory().Create(cSIExtensionClassBase);
			var iLowDecimal = new LowDecimalFactory().Create(cSIExtensionClassBase);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IRpt_Interactions _Rpt_Interactions = new Rpt_Interactions(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				iFormatProspectAddress,
				sQLExpressionExecutor,
				iFormatContactAddress,
				iFormatVendorAddress,
				iCloseSessionContext,
				iInitSessionContext,
				transactionFactory,
				iGetIsolationLevel,
				iReportNotesExist,
				iApplyDateOffset,
				iExpandKyByType,
				scalarFunction,
				iFormatAddress,
				existsChecker,
				convertToUtil,
				iHighDecimal,
				variableUtil,
				iGetFullName,
				iLowDecimal,
				stringUtil,
				sQLUtil,
                cSIExtensionClassBase.MongooseDependencies.LowCharacter,
                cSIExtensionClassBase.MongooseDependencies.HighCharacter);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_Interactions = IDOMethodIntercept<IRpt_Interactions>.Create(_Rpt_Interactions, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InteractionsExt = timerfactory.Create<IRpt_Interactions>(_Rpt_Interactions);

			return iRpt_InteractionsExt;
		}
	}
}
