//PROJECT NAME: Finance
//CLASS NAME: SSSVTXCalcCoTaxFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Customer;

namespace CSI.Finance.TaxInterface
{
	public class SSSVTXCalcCoTaxFactory
	{
		public const string IDO = "TaxInterfaceParms";
		public const string Method = "SSSVTXCalcCoTax";
		
		public ISSSVTXCalcCoTax Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
            

			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iUndefineVariable = cSIExtensionClassBase.MongooseDependencies.UndefineVariable;
			var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iSumCo = new SumCoFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iSSSVTXCalcCoTaxCRUD = new SSSVTXCalcCoTaxCRUD(appDB, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker);
			ISSSVTXCalcCoTax _SSSVTXCalcCoTax = new SSSVTXCalcCoTax(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iUndefineVariable,
				iDefineVariable,
				scalarFunction,
				convertToUtil,
				stringUtil,
				sQLUtil,
				iSumCo,
				iSSSVTXCalcCoTaxCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_SSSVTXCalcCoTax = IDOMethodIntercept<ISSSVTXCalcCoTax>.Create(_SSSVTXCalcCoTax, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSVTXCalcCoTaxExt = timerfactory.Create<ISSSVTXCalcCoTax>(_SSSVTXCalcCoTax);
			
			return iSSSVTXCalcCoTaxExt;
		}
	}
}
