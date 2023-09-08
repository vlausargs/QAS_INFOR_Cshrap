//PROJECT NAME: Logistics
//CLASS NAME: Home_CustomerAnalysisFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Finance.AR;
using CSI.CRUD.Logistics.Customer;
using CSI.Material;

namespace CSI.Logistics.Customer
{
	public class Home_CustomerAnalysisFactory
	{
		public const string IDO = "SLControllerAlls";
		public const string Method = "Home_CustomerAnalysis";

		readonly IUndefineProcessVariableFactory iUndefineProcessVariableFactory;
		readonly IDefineProcessVariableFactory iDefineProcessVariableFactory;
		readonly IBuildXMLFilterStringFactory iBuildXMLFilterStringFactory;
		readonly IDefaultToLocalSiteFactory iDefaultToLocalSiteFactory;
		readonly IGetProcessVariableFactory iGetProcessVariableFactory;
		readonly IExecuteDynamicSQLFactory iExecuteDynamicSQLFactory;
		readonly IARAgingBucketsFactory iARAgingBucketsFactory;
		readonly IGetStringValueFactory iGetStringValueFactory;

		public Home_CustomerAnalysisFactory(IUndefineProcessVariableFactory iUndefineProcessVariableFactory,
			IDefineProcessVariableFactory iDefineProcessVariableFactory,
			IBuildXMLFilterStringFactory iBuildXMLFilterStringFactory,
			IDefaultToLocalSiteFactory iDefaultToLocalSiteFactory,
			IGetProcessVariableFactory iGetProcessVariableFactory,
			IExecuteDynamicSQLFactory iExecuteDynamicSQLFactory,
			IARAgingBucketsFactory iARAgingBucketsFactory,
			IGetStringValueFactory iGetStringValueFactory)
		{
			this.iUndefineProcessVariableFactory = iUndefineProcessVariableFactory;
			this.iDefineProcessVariableFactory = iDefineProcessVariableFactory;
			this.iBuildXMLFilterStringFactory = iBuildXMLFilterStringFactory;
			this.iDefaultToLocalSiteFactory = iDefaultToLocalSiteFactory;
			this.iGetProcessVariableFactory = iGetProcessVariableFactory;
			this.iExecuteDynamicSQLFactory = iExecuteDynamicSQLFactory;
			this.iARAgingBucketsFactory = iARAgingBucketsFactory;
			this.iGetStringValueFactory = iGetStringValueFactory;
		}

		public IHome_CustomerAnalysis Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var iUndefineProcessVariable = this.iUndefineProcessVariableFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iDefineProcessVariable = this.iDefineProcessVariableFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iBuildXMLFilterString = this.iBuildXMLFilterStringFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iDefaultToLocalSite = this.iDefaultToLocalSiteFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iGetProcessVariable = this.iGetProcessVariableFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iExecuteDynamicSQL = this.iExecuteDynamicSQLFactory.Create(appDB, bunchedLoadCollection, mgInvoker, parameterProvider, calledFromIDO);
			var iARAgingBuckets = this.iARAgingBucketsFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var iGetStringValue = this.iGetStringValueFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iQuotedLiteral = new QuotedLiteralFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var mathUtil = new MathUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMaxQty = new MaxQtyFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);

			var collectionNonTriggerInsertRequestFactory = new CollectionNonTriggerInsertRequestFactory(queryLanguage);
			var collectionNonTriggerUpdateRequestFactory = new CollectionNonTriggerUpdateRequestFactory(queryLanguage);
			var collectionNonTriggerDeleteRequestFactory = new CollectionNonTriggerDeleteRequestFactory(queryLanguage);

			var InsertSiteGroupLoader = new InsertSiteGroupLoader();
			var expandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var buildCustomerFilter = new BuildCustomerFilter();

			var iHome_CustomerAnalysisCRUD = new Home_CustomerAnalysisCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				iDefaultToLocalSite,
				iQuotedLiteral,
				existsChecker,
				variableUtil,
				stringUtil,
				collectionNonTriggerInsertRequestFactory,
				collectionNonTriggerUpdateRequestFactory,
				collectionNonTriggerDeleteRequestFactory);

			IHome_CustomerAnalysis _Home_CustomerAnalysis = new Home_CustomerAnalysis(collectionLoadResponseUtil,
				iUndefineProcessVariable,
				iDefineProcessVariable,
				sQLExpressionExecutor,
				iBuildXMLFilterString,
				iDefaultToLocalSite,
				iGetProcessVariable,
				iExecuteDynamicSQL,
				iARAgingBuckets,
				iGetStringValue,
				scalarFunction,
				convertToUtil,
				stringUtil,
				mathUtil,
				sQLUtil,
				iMaxQty,
				iHome_CustomerAnalysisCRUD,
				InsertSiteGroupLoader,
				expandKyByType,
				buildCustomerFilter);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Home_CustomerAnalysis = IDOMethodIntercept<IHome_CustomerAnalysis>.Create(_Home_CustomerAnalysis, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_CustomerAnalysisExt = timerfactory.Create<IHome_CustomerAnalysis>(_Home_CustomerAnalysis);

			return iHome_CustomerAnalysisExt;
		}
	}
}