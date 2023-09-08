//PROJECT NAME: Employee
//CLASS NAME: SSalIFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Employee
{
	public class SSalIFactory
	{
		public const string IDO = "SLEmpSalaries";
		public const string Method = "SSalI";
		
		public ISSalI Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var convertToUtil = new ConvertToUtilFactory().Create();
			var iHighDecimal = new HighDecimalFactory().Create(cSIExtensionClassBase);
			var dateTimeUtil = new DateTimeUtilFactory().Create();
			var iGetSiteDate = cSIExtensionClassBase.MongooseDependencies.GetSiteDate;
			var stringUtil = new StringUtil();
			var iInsCalc = new InsCalcFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var iMsgApp = new MsgApp(appDB);
			var collectionLoadBuilderRequestFactory = new CollectionLoadBuilderRequestFactory(queryLanguage);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionUpdateRequestFactory = new CollectionUpdateRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var iSSalICRUD = new SSalICRUD(appDB, collectionLoadBuilderRequestFactory, collectionInsertRequestFactory, collectionDeleteRequestFactory, collectionUpdateRequestFactory, collectionLoadRequestFactory, existsChecker, variableUtil, stringUtil);
			ISSalI _SSalI = new SSalI(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iExpandKyByType,
				scalarFunction,
				convertToUtil,
				iHighDecimal,
				dateTimeUtil,
				iGetSiteDate,
				stringUtil,
				iInsCalc,
				sQLUtil,
				iMsgApp,
				iSSalICRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_SSalI = IDOMethodIntercept<ISSalI>.Create(_SSalI, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSalIExt = timerfactory.Create<ISSalI>(_SSalI);
			
			return iSSalIExt;
		}
	}
}
