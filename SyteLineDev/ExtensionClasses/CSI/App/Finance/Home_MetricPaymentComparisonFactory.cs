//PROJECT NAME: Finance
//CLASS NAME: Home_MetricPaymentComparisonFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Logistics.Vendor;

namespace CSI.Finance
{
	public class Home_MetricPaymentComparisonFactory
	{
		public const string IDO = "SLExecutives";
		public const string Method = "Home_MetricPaymentComparison";
		
		public IHome_MetricPaymentComparison Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iPeriodsGetDates = new PeriodsGetDatesFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var stringUtil = new StringUtil();
			var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
			var iCurrCnvt = new CurrCnvtFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iPerGet = new PerGetFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var iHome_MetricPaymentComparisonCRUD = new Home_MetricPaymentComparisonCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				variableUtil,
				dateTimeUtil,
				stringUtil,
                collectionLoadResponseUtil,
                sQLExpressionExecutor);
			
			IHome_MetricPaymentComparison _Home_MetricPaymentComparison = new Home_MetricPaymentComparison(
				sQLExpressionExecutor,
				transactionFactory,
				iPeriodsGetDates,
				scalarFunction,
				convertToUtil,
				iGetSiteDate,
				iMidnightOf,
				stringUtil,
				iDayEndOf,
				iCurrCnvt,
				sQLUtil,
				iPerGet,
				iHome_MetricPaymentComparisonCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_MetricPaymentComparison = IDOMethodIntercept<IHome_MetricPaymentComparison>.Create(_Home_MetricPaymentComparison, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricPaymentComparisonExt = timerfactory.Create<IHome_MetricPaymentComparison>(_Home_MetricPaymentComparison);
			
			return iHome_MetricPaymentComparisonExt;
		}
	}
}
