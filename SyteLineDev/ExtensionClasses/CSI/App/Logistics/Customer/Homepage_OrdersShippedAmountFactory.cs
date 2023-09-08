//PROJECT NAME: Logistics
//CLASS NAME: Homepage_OrdersShippedAmountFactory.cs

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
	public class Homepage_OrdersShippedAmountFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_OrdersShippedAmount";

		readonly IMidnightOfFactory iMidnightOfFactory;
		readonly IGetLabelFactory iGetLabelFactory;
		readonly ICurrCnvtSingleAmt2Factory iCurrCnvtSingleAmt2Factory;
		public Homepage_OrdersShippedAmountFactory(IMidnightOfFactory iMidnightOfFactory, IGetLabelFactory iGetLabelFactory, ICurrCnvtSingleAmt2Factory iCurrCnvtSingleAmt2Factory)
		{
			this.iMidnightOfFactory = iMidnightOfFactory;
			this.iGetLabelFactory = iGetLabelFactory;
			this.iCurrCnvtSingleAmt2Factory = iCurrCnvtSingleAmt2Factory;
		}

		public IHomepage_OrdersShippedAmount Create(IApplicationDB appDB,
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
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iMidnightOf = this.iMidnightOfFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var stringUtil = new StringUtil();
			var iGetLabel = this.iGetLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var mathUtil = new MathUtilFactory().Create();
			var currCnvtSingleAmt2 = this.iCurrCnvtSingleAmt2Factory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);

			IHomepage_OrdersShippedAmount _Homepage_OrdersShippedAmount = new Homepage_OrdersShippedAmount(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				existsChecker,
				convertToUtil,
				variableUtil,
				iMidnightOf,
				stringUtil,
				iGetLabel,
				sQLUtil,
				mathUtil,
				currCnvtSingleAmt2);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_OrdersShippedAmount = IDOMethodIntercept<IHomepage_OrdersShippedAmount>.Create(_Homepage_OrdersShippedAmount, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_OrdersShippedAmountExt = timerfactory.Create<IHomepage_OrdersShippedAmount>(_Homepage_OrdersShippedAmount);
			
			return iHomepage_OrdersShippedAmountExt;
		}
	}
}
