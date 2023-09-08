//PROJECT NAME: Production
//CLASS NAME: Home_GetTodaysKeyProjectValuesFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Production.Projects
{
	public class Home_GetTodaysKeyProjectValuesFactory
	{
		public const string IDO = "SLInvMs";
		public const string Method = "Home_GetTodaysKeyProjectValues";
		
		public IHome_GetTodaysKeyProjectValues Create(
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
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var iHome_GetTodaysKeyProjectValuesCRUD = new Home_GetTodaysKeyProjectValuesCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				stringUtil,
                sQLExpressionExecutor,
                collectionLoadResponseUtil);
			
			IHome_GetTodaysKeyProjectValues _Home_GetTodaysKeyProjectValues = new Home_GetTodaysKeyProjectValues(
				transactionFactory,
				scalarFunction,
				convertToUtil,
				iGetSiteDate,
				iMidnightOf,
				sQLUtil,
				iHome_GetTodaysKeyProjectValuesCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_GetTodaysKeyProjectValues = IDOMethodIntercept<IHome_GetTodaysKeyProjectValues>.Create(_Home_GetTodaysKeyProjectValues, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_GetTodaysKeyProjectValuesExt = timerfactory.Create<IHome_GetTodaysKeyProjectValues>(_Home_GetTodaysKeyProjectValues);
			
			return iHome_GetTodaysKeyProjectValuesExt;
		}
	}
}
