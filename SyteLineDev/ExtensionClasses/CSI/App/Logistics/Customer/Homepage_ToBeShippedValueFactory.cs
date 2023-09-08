//PROJECT NAME: Logistics
//CLASS NAME: Homepage_ToBeShippedValueFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;

namespace CSI.Logistics.Customer
{
	public class Homepage_ToBeShippedValueFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_ToBeShippedValue";

		public IHomepage_ToBeShippedValue Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iDefaultToLocalSite = cSIExtensionClassBase.MongooseDependencies.DefaultToLocalSite;
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var iPeriodsGetDates = new PeriodsGetDatesFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var stringUtil = new StringUtil();
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iPerGet = new PerGetFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iCurrCnvtSingleAmt2 = new CurrCnvtSingleAmt2Factory().Create(cSIExtensionClassBase, calledFromIDO);
			var iHomepage_ToBeShippedValueCRUD = new Homepage_ToBeShippedValueCRUD(appDB, bunchedLoadCollection, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil);
			IHomepage_ToBeShippedValue _Homepage_ToBeShippedValue = new Homepage_ToBeShippedValue(
				appDB,
				collectionLoadBuilderRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iDefaultToLocalSite,
				transactionFactory,
				iPeriodsGetDates,
				scalarFunction,
				convertToUtil,
				stringUtil,
				mathUtil,
				sQLUtil,
				iPerGet,
				iCurrCnvtSingleAmt2,
				iHomepage_ToBeShippedValueCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_ToBeShippedValue = IDOMethodIntercept<IHomepage_ToBeShippedValue>.Create(_Homepage_ToBeShippedValue, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_ToBeShippedValueExt = timerfactory.Create<IHomepage_ToBeShippedValue>(_Homepage_ToBeShippedValue);

			return iHomepage_ToBeShippedValueExt;
		}
	}
}
