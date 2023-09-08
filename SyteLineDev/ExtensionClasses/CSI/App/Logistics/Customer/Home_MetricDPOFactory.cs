//PROJECT NAME: Logistics
//CLASS NAME: Home_MetricDPOFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Linq;
using CSI.Finance;
using CSI.Logistics.Vendor;

namespace CSI.Logistics.Customer
{
	public class Home_MetricDPOFactory
	{
		public const string IDO = "SLControllerAlls";
		public const string Method = "Home_MetricDPO";
		
		public IHome_MetricDPO Create(
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
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var stringUtil = new StringUtil();
			var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
			var iCurrCnvt = new CurrCnvtCacheFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
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
			var mathUtil = new MathUtilFactory().Create();
			var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
			var collectionNonTriggerUpdatetRequestFactory = new CollectionNonTriggerUpdateRequestFactory(queryLanguage);
			var CollectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);

            var iHome_MetricDPOCRUD = new Home_MetricDPOCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				convertToUtil,
				variableUtil,
				stringUtil,
				mathUtil,
				sQLUtil,
                collectionLoadResponseUtil,
                sQLExpressionExecutor,
                collectionNonTriggerInsertRequestFactory,
                collectionNonTriggerUpdatetRequestFactory,
                CollectionNonTriggerDeleteRequestFactory);
			
			IHome_MetricDPO _Home_MetricDPO = new Home_MetricDPO(sQLExpressionExecutor,
				transactionFactory,
				iPeriodsGetDates,
				scalarFunction,
				convertToUtil,
				iGetSiteDate,
				dateTimeUtil,
				iMidnightOf,
				stringUtil,
				iDayEndOf,
				iCurrCnvt,
				iLowDate,
				sQLUtil,
				iPerGet,
				iHome_MetricDPOCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_MetricDPO = IDOMethodIntercept<IHome_MetricDPO>.Create(_Home_MetricDPO, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_MetricDPOExt = timerfactory.Create<IHome_MetricDPO>(_Home_MetricDPO);
			
			return iHome_MetricDPOExt;
		}
	}
}
