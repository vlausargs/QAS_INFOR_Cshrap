//PROJECT NAME: Logistics
//CLASS NAME: Homepage_CustomerProductCodeBacklogFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance;
using CSI.DataCollection;

namespace CSI.Logistics.Customer
{
	public class Homepage_CustomerProductCodeBacklogFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_CustomerProductCodeBacklog";

		public IHomepage_CustomerProductCodeBacklog Create(
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
			var iCurrCnvtSingleAmt2 = new CurrCnvtSingleAmt2Factory().Create(cSIExtensionClassBase, calledFromIDO);
			var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var dataTypeUtil = new DataTypeUtilFactory().Create();
			var iMidnightOf = cSIExtensionClassBase.MongooseDependencies.MidnightOf;
			var iUomConvQty = new UomConvQtyFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var stringUtil = new StringUtil();
			var iSqlFilter = cSIExtensionClassBase.MongooseDependencies.SqlFilter;
			var iGetumcf = new GetumcfFactory().Create(cSIExtensionClassBase);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iHomepage_CustomerProductCodeBacklogCRUD = new Homepage_CustomerProductCodeBacklogCRUD(appDB, collectionLoadStatementRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil);
			IHomepage_CustomerProductCodeBacklog _Homepage_CustomerProductCodeBacklog = new Homepage_CustomerProductCodeBacklog(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iDefaultToLocalSite,
				iCurrCnvtSingleAmt2,
				iExecuteDynamicSQL,
				scalarFunction,
				convertToUtil,
				dataTypeUtil,
				iMidnightOf,
				iUomConvQty,
				stringUtil,
				iSqlFilter,
				iGetumcf,
				sQLUtil,
				variableUtil,
				iHomepage_CustomerProductCodeBacklogCRUD);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_CustomerProductCodeBacklog = IDOMethodIntercept<IHomepage_CustomerProductCodeBacklog>.Create(_Homepage_CustomerProductCodeBacklog, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_CustomerProductCodeBacklogExt = timerfactory.Create<IHomepage_CustomerProductCodeBacklog>(_Homepage_CustomerProductCodeBacklog);

			return iHomepage_CustomerProductCodeBacklogExt;
		}
	}
}
