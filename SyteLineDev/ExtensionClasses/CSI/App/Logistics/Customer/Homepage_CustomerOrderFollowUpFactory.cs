//PROJECT NAME: Logistics
//CLASS NAME: Homepage_CustomerOrderFollowUpFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Logistics.Customer
{
	public class Homepage_CustomerOrderFollowUpFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_CustomerOrderFollowUp";

		public IHomepage_CustomerOrderFollowUp Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var stringUtil = new StringUtil();
			var iDayEndOf = cSIExtensionClassBase.MongooseDependencies.DayEndOf;
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHomepage_CustomerOrderFollowUp _Homepage_CustomerOrderFollowUp = new Homepage_CustomerOrderFollowUp(appDB,
				bunchedLoadCollection,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				existsChecker,
				convertToUtil,
				iGetSiteDate,
				dateTimeUtil,
				variableUtil,
				iMidnightOf,
				stringUtil,
				iDayEndOf,
				sQLUtil);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_CustomerOrderFollowUp = IDOMethodIntercept<IHomepage_CustomerOrderFollowUp>.Create(_Homepage_CustomerOrderFollowUp, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_CustomerOrderFollowUpExt = timerfactory.Create<IHomepage_CustomerOrderFollowUp>(_Homepage_CustomerOrderFollowUp);

			return iHomepage_CustomerOrderFollowUpExt;
		}
	}
}
