//PROJECT NAME: Admin
//CLASS NAME: CLM_ProductCodeMarginFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using System.Linq;

namespace CSI.Admin
{
	public class CLM_ProductCodeMarginFactory
	{
		public const string IDO = "MobileHomepages";
		public const string Method = "CLM_ProductCodeMargin";

		public ICLM_ProductCodeMargin Create(
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
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var stringUtil = new StringUtil();
			var iLowDate = cSIExtensionClassBase.MongooseDependencies.LowDate;
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iCLM_ProductCodeMarginCRUD = new CLM_ProductCodeMarginCRUD(appDB, bunchedLoadCollection, collectionLoadStatementRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionUpdateRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil);
			ICLM_ProductCodeMargin _CLM_ProductCodeMargin = new CLM_ProductCodeMargin(
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iDefaultToLocalSite,
				scalarFunction,
				convertToUtil,
				dateTimeUtil,
				iMidnightOf,
				stringUtil,
				iLowDate,
				mathUtil,
				sQLUtil,
			iCLM_ProductCodeMarginCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ProductCodeMargin = IDOMethodIntercept<ICLM_ProductCodeMargin>.Create(_CLM_ProductCodeMargin, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProductCodeMarginExt = timerfactory.Create<ICLM_ProductCodeMargin>(_CLM_ProductCodeMargin);

			return iCLM_ProductCodeMarginExt;
		}
	}
}
