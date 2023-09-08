//PROJECT NAME: Finance
//CLASS NAME: Portal_SSSCCIARPayFromTransFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.RecordSets;
using CSI.Data.Functions;

namespace CSI.Finance.CreditCard
{
	public class Portal_SSSCCIARPayFromTransFactory
	{
		public const string IDO = "CCITrans";
		public const string Method = "Portal_SSSCCIARPayFromTrans";
		
		public IPortal_SSSCCIARPayFromTrans Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionInsertRequestFactory = new CollectionInsertRequestFactory();
			var collectionDeleteRequestFactory = new CollectionDeleteRequestFactory();
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var collectionLoadResponseUtil = new CollectionLoadResponseUtil(new RecordCollectionToDataTable(), new DataTableToCollectionLoadResponse());
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var iSSSCCIARPayFromTrans = new SSSCCIARPayFromTransFactory().Create(cSIExtensionClassBase, calledFromIDO);
			var scalarFunction = new ScalarFunctionFactory().Create(appDB, parameterProvider);
			var existsChecker = new ExistsCheckerFactory().Create(appDB, queryLanguage);
			var stringUtil = new StringUtil();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IPortal_SSSCCIARPayFromTrans _Portal_SSSCCIARPayFromTrans = new Portal_SSSCCIARPayFromTrans(appDB,
				collectionInsertRequestFactory,
				collectionDeleteRequestFactory,
				collectionLoadRequestFactory,
				collectionLoadResponseUtil,
				sQLExpressionExecutor,
				iSSSCCIARPayFromTrans,
				scalarFunction,
				existsChecker,
				stringUtil,
				sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_Portal_SSSCCIARPayFromTrans = IDOMethodIntercept<IPortal_SSSCCIARPayFromTrans>.Create(_Portal_SSSCCIARPayFromTrans, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_SSSCCIARPayFromTransExt = timerfactory.Create<IPortal_SSSCCIARPayFromTrans>(_Portal_SSSCCIARPayFromTrans);
			
			return iPortal_SSSCCIARPayFromTransExt;
		}
	}
}
