//PROJECT NAME: Finance
//CLASS NAME: ReplaceUnitCodesFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using System.Linq;

namespace CSI.Finance
{
	public class ReplaceUnitCodesFactory
	{
		public const string IDO = "SLCharts";
		public const string Method = "ReplaceUnitCodes";
		
		public IReplaceUnitCodes Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var sQLCollectionLoad = new SQLExpressionExecutorFactory().Create(appDB);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iReplaceUnitCodesCRUD = new ReplaceUnitCodesCRUD(appDB, collectionLoadStatementRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil);
			IReplaceUnitCodes _ReplaceUnitCodes = new ReplaceUnitCodes(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				sQLCollectionLoad,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iMsgApp,
				iReplaceUnitCodesCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_ReplaceUnitCodes = IDOMethodIntercept<IReplaceUnitCodes>.Create(_ReplaceUnitCodes, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReplaceUnitCodesExt = timerfactory.Create<IReplaceUnitCodes>(_ReplaceUnitCodes);
			
			return iReplaceUnitCodesExt;
		}
	}
}
