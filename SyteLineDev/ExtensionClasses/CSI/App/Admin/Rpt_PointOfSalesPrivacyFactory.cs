//PROJECT NAME: Admin
//CLASS NAME: Rpt_PointOfSalesPrivacyFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;
using CSI.Material;

namespace CSI.Admin
{
	public class Rpt_PointOfSalesPrivacyFactory
	{
		public const string IDO = "SLGDPRData";
		public const string Method = "Rpt_PointOfSalesPrivacy";
		
		public IRpt_PointOfSalesPrivacy Create(
			ICSIExtensionClassBase cSIExtensionClassBase,
			bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iCloseSessionContext = cSIExtensionClassBase.MongooseDependencies.CloseSessionContext;
			var iInitSessionContext = cSIExtensionClassBase.MongooseDependencies.InitSessionContext;
			var iExpandKyByType = new ExpandKyByTypeFactory().Create(appDB, mgInvoker, parameterProvider, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var variableUtil = new VariableUtilFactory().Create();
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iRpt_PointOfSalesPrivacyCRUD = new Rpt_PointOfSalesPrivacyCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker);
			
			IRpt_PointOfSalesPrivacy _Rpt_PointOfSalesPrivacy = new Rpt_PointOfSalesPrivacy(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				iExpandKyByType,
				scalarFunction,
				variableUtil,
				stringUtil,
				sQLUtil,
				iRpt_PointOfSalesPrivacyCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_PointOfSalesPrivacy = IDOMethodIntercept<IRpt_PointOfSalesPrivacy>.Create(_Rpt_PointOfSalesPrivacy, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PointOfSalesPrivacyExt = timerfactory.Create<IRpt_PointOfSalesPrivacy>(_Rpt_PointOfSalesPrivacy);
			
			return iRpt_PointOfSalesPrivacyExt;
		}
	}
}
