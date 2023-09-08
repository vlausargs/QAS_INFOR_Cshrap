//PROJECT NAME: Finance
//CLASS NAME: PerUnitFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Finance
{
	public class PerUnitFactory
	{
		public const string IDO = "SLPerSorts";
		public const string Method = "PerUnit";

		public IPerUnit Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;

			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iTruncateTable = new TruncateTableFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var variableUtil = new VariableUtilFactory().Create();
			var iHighAnyInt = new HighAnyIntFactory().Create(cSIExtensionClassBase);
			var stringUtil = new StringUtil();
			var iLowAnyInt = new LowAnyIntFactory().Create(cSIExtensionClassBase);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);

			IPerUnit _PerUnit = new PerUnit(appDB,
				collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				scalarFunction,
				iTruncateTable,
				existsChecker,
				convertToUtil,
				variableUtil,
				iHighAnyInt,
				stringUtil,
				iLowAnyInt,
				sQLUtil,
				iMsgApp);

			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_PerUnit = IDOMethodIntercept<IPerUnit>.Create(_PerUnit, IDO, Method, mgInvoker, interceptConfiguration);
			}

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPerUnitExt = timerfactory.Create<IPerUnit>(_PerUnit);

			return iPerUnitExt;
		}
	}
}
