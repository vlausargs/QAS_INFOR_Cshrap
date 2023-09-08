//PROJECT NAME: Logistics
//CLASS NAME: Home_GetProductionPlannerParmsFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Production;
using CSI.Production.Projects;
using CSI.Finance;
using CSI.Codes;
using CSI.Material;

namespace CSI.Logistics.Customer
{
	public class Home_GetProductionPlannerParmsFactory
	{
		public const string IDO = "SLControllers";
		public const string Method = "Home_GetProductionPlannerParms";
		
		public IHome_GetProductionPlannerParms Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var iHome_GetTodaysKeyProductionValues = new Home_GetTodaysKeyProductionValuesFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var iGetSysParPermPlanMode = new GetSysParPermPlanModeFactory().Create(cSIExtensionClassBase);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iGetUnPostedProdTrans = new GetUnPostedProdTransFactory().Create(appDB);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iGetFiscalPeriods = new GetFiscalPeriodsFactory().Create(cSIExtensionClassBase);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iGetFiscalYear = new GetFiscalYearFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iGetInvSiteGrp = new GetInvSiteGrpFactory().Create(cSIExtensionClassBase);
			var iGetCurPeriod = new GetCurPeriodFactory().Create(cSIExtensionClassBase);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iHome_GetProductionPlannerParmsCRUD = new Home_GetProductionPlannerParmsCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker, 
                stringUtil,
                collectionLoadResponseUtil);
			
			IHome_GetProductionPlannerParms _Home_GetProductionPlannerParms = new Home_GetProductionPlannerParms(iHome_GetTodaysKeyProductionValues,
				collectionLoadResponseUtil,
				iGetSysParPermPlanMode,
				sQLExpressionExecutor,
				iGetUnPostedProdTrans,
				transactionFactory,
				iGetFiscalPeriods,
				scalarFunction,
				iGetFiscalYear,
				iGetInvSiteGrp,
				iGetCurPeriod,
				stringUtil,
				sQLUtil,
				iHome_GetProductionPlannerParmsCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_GetProductionPlannerParms = IDOMethodIntercept<IHome_GetProductionPlannerParms>.Create(_Home_GetProductionPlannerParms, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_GetProductionPlannerParmsExt = timerfactory.Create<IHome_GetProductionPlannerParms>(_Home_GetProductionPlannerParms);
			
			return iHome_GetProductionPlannerParmsExt;
		}
	}
}
