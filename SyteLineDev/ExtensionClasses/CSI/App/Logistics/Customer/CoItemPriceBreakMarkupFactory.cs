//PROJECT NAME: Logistics
//CLASS NAME: CoItemPriceBreakMarkupFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
	public class CoItemPriceBreakMarkupFactory
	{
		public const string IDO = "SLCoitems";
		public const string Method = "CoItemPriceBreakMarkup";
		
		public ICoItemPriceBreakMarkup Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var iCoItemSumJobOperCosts = new CoItemSumJobOperCostsFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iMO_GenEstJob = new MO_GenEstJobFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iCoItemPriceBreakMarkupCRUD = new CoItemPriceBreakMarkupCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				variableUtil,
				stringUtil,
				sQLUtil);
			
			ICoItemPriceBreakMarkup _CoItemPriceBreakMarkup = new CoItemPriceBreakMarkup(collectionLoadResponseUtil,
				iCoItemSumJobOperCosts,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				iMO_GenEstJob,
				convertToUtil,
				iCurrCnvt,
				sQLUtil,
				iCoItemPriceBreakMarkupCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CoItemPriceBreakMarkup = IDOMethodIntercept<ICoItemPriceBreakMarkup>.Create(_CoItemPriceBreakMarkup, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoItemPriceBreakMarkupExt = timerfactory.Create<ICoItemPriceBreakMarkup>(_CoItemPriceBreakMarkup);
			
			return iCoItemPriceBreakMarkupExt;
		}
	}
}
