//PROJECT NAME: Admin
//CLASS NAME: Rpt_ServiceContactPrivacyFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.MG.MGCore;

namespace CSI.Admin
{
	public class Rpt_ServiceContactPrivacyFactory
	{
		public const string IDO = "SLGDPRData";
		public const string Method = "Rpt_ServiceContactPrivacy";
		
		public IRpt_ServiceContactPrivacy Create(
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
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var iRpt_ServiceContactPrivacyCRUD = new Rpt_ServiceContactPrivacyCRUD(appDB, collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				existsChecker);
			
			IRpt_ServiceContactPrivacy _Rpt_ServiceContactPrivacy = new Rpt_ServiceContactPrivacy(collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iCloseSessionContext,
				iInitSessionContext,
				scalarFunction,
				stringUtil,
				sQLUtil,
				iRpt_ServiceContactPrivacyCRUD);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Rpt_ServiceContactPrivacy = IDOMethodIntercept<IRpt_ServiceContactPrivacy>.Create(_Rpt_ServiceContactPrivacy, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ServiceContactPrivacyExt = timerfactory.Create<IRpt_ServiceContactPrivacy>(_Rpt_ServiceContactPrivacy);
			
			return iRpt_ServiceContactPrivacyExt;
		}
	}
}
