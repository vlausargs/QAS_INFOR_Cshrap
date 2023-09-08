//PROJECT NAME: Material
//CLASS NAME: CopyCostingAnalysisAlternativeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Production;

namespace CSI.Material
{
	public class CopyCostingAnalysisAlternativeFactory
	{
		public const string IDO = "SLCostingAlts";
		public const string Method = "CopyCostingAnalysisAlternative";
		
		public ICopyCostingAnalysisAlternative Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iUndefineVariable = cSIExtensionClassBase.MongooseDependencies.UndefineVariable;
			var iApsSyncImmediate = new ApsSyncImmediateFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var iDefineVariable = cSIExtensionClassBase.MongooseDependencies.DefineVariable;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var iApsSyncDefer = new ApsSyncDeferFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var stringUtil = new StringUtil();
			var highString = cSIExtensionClassBase.MongooseDependencies.HighString;
			var lowString = cSIExtensionClassBase.MongooseDependencies.LowString;
			var iNextSjb = new NextSjbFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iCopyCostingAnalysisAlternativeCRUD = new CopyCostingAnalysisAlternativeCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionLoadBuilderRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionUpdateRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				variableUtil,
				stringUtil);
			
			ICopyCostingAnalysisAlternative _CopyCostingAnalysisAlternative = new CopyCostingAnalysisAlternative(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iUndefineVariable,
				iApsSyncImmediate,
				iDefineVariable,
				scalarFunction,
				iApsSyncDefer,
				convertToUtil,
				stringUtil,
				highString,
				lowString,
				iNextSjb,
				sQLUtil,
				iMsgApp,
				iCopyCostingAnalysisAlternativeCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CopyCostingAnalysisAlternative = IDOMethodIntercept<ICopyCostingAnalysisAlternative>.Create(_CopyCostingAnalysisAlternative, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyCostingAnalysisAlternativeExt = timerfactory.Create<ICopyCostingAnalysisAlternative>(_CopyCostingAnalysisAlternative);
			
			return iCopyCostingAnalysisAlternativeExt;
		}
	}
}
