//PROJECT NAME: Admin
//CLASS NAME: GetSiteTableToPurgeFactory.cs

using CSI.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL;
using CSI.Data.Utilities;
using CSI.MG;
using CSI.Data.Functions;

namespace CSI.Admin
{
	public class GetSiteTableToPurgeFactory
	{
		public const string IDO = "SLSiteMgmtTableData";
		public const string Method = "GetSiteTableToPurge";
		
		public IGetSiteTableToPurge Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var queryLanguage = new SQLQueryLanguageFactory().Create(parameterProvider);
			var collectionLoadRequestFactory = new CollectionLoadRequestFactory(queryLanguage);
			var variableUtil = new VariableUtilFactory().Create();
			var sQLUtil = new SQLValueComparerUtilFactory().Create();
			
			IGetSiteTableToPurge _GetSiteTableToPurge = new GetSiteTableToPurge(appDB,
			collectionLoadRequestFactory,
			variableUtil,
			sQLUtil);
			
			if (!calledFromIDO)
			{
				//if the implementation was called by the IDO, routing it through the IDO again will cause an infinite loop
				//but it wasn't, so add the intercept
				var interceptConfiguration = new InterceptConfiguration();
				_GetSiteTableToPurge = IDOMethodIntercept<IGetSiteTableToPurge>.Create(_GetSiteTableToPurge, IDO, Method, mgInvoker, interceptConfiguration);
			}
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteTableToPurgeExt = timerfactory.Create<IGetSiteTableToPurge>(_GetSiteTableToPurge);
			
			return iGetSiteTableToPurgeExt;
		}
	}
}
