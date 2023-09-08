//PROJECT NAME: Logistics
//CLASS NAME: Homepage_InventoryFollowUpFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Logistics.Customer
{
	public class Homepage_InventoryFollowUpFactory
	{
		public const string IDO = "SLHomepages";
		public const string Method = "Homepage_InventoryFollowUp";

		readonly IGetLabelFactory iGetLabelFactory;
		public Homepage_InventoryFollowUpFactory(IGetLabelFactory iGetLabelFactory)
		{
			this.iGetLabelFactory = iGetLabelFactory;
		}

		public IHomepage_InventoryFollowUp Create(IApplicationDB appDB,
			IBunchedLoadCollection bunchedLoadCollection,
			IMGInvoker mgInvoker,
			IParameterProvider parameterProvider,
			bool calledFromIDO)
		{
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var transactionFactory = new TransactionFactory(sQLExpressionExecutor);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsChecker(appDB, collectionLoadRequestFactory, collectionLoadStatementRequestFactory);
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var iGetLabel = this.iGetLabelFactory.Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();

			IHomepage_InventoryFollowUp _Homepage_InventoryFollowUp = new Homepage_InventoryFollowUp(appDB,
				bunchedLoadCollection,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				transactionFactory,
				scalarFunction,
				existsChecker,
				variableUtil,
				stringUtil,
				iGetLabel,
				sQLUtil);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Homepage_InventoryFollowUp = IDOMethodIntercept<IHomepage_InventoryFollowUp>.Create(_Homepage_InventoryFollowUp, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_InventoryFollowUpExt = timerfactory.Create<IHomepage_InventoryFollowUp>(_Homepage_InventoryFollowUp);

			return iHomepage_InventoryFollowUpExt;
		}
	}
}
