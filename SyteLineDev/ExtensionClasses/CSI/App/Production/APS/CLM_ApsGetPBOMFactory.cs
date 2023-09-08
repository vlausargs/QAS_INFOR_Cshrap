//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetPBOMFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Production.APS
{
	public class CLM_ApsGetPBOMFactory
	{
		public const string IDO = "SLPBOMnnns";
		public const string Method = "CLM_ApsGetPBOM";
		
		public ICLM_ApsGetPBOM Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			var bunchedLoadCollection = cSIExtensionClassBase.BunchedLoadCollection;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iExecuteDynamicSQL = cSIExtensionClassBase.MongooseDependencies.ExecuteDynamicSQL;
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionLoadStatementRequestFactory = new CollectionLoadStatementRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iCLM_ApsGetPBOMCRUD = new CLM_ApsGetPBOMCRUD(appDB, collectionLoadStatementRequestFactory,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker,
				variableUtil,
				stringUtil);
			
			ICLM_ApsGetPBOM _CLM_ApsGetPBOM = new CLM_ApsGetPBOM(bunchedLoadCollection,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iExecuteDynamicSQL,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iCLM_ApsGetPBOMCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_CLM_ApsGetPBOM = IDOMethodIntercept<ICLM_ApsGetPBOM>.Create(_CLM_ApsGetPBOM, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetPBOMExt = timerfactory.Create<ICLM_ApsGetPBOM>(_CLM_ApsGetPBOM);
			
			return iCLM_ApsGetPBOMExt;
		}
	}
}
