//PROJECT NAME: Finance
//CLASS NAME: ExtFinGetSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.ExtFin
{
	public class ExtFinGetSiteFactory
	{
		public IExtFinGetSite Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ExtFinGetSite = new Finance.ExtFin.ExtFinGetSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExtFinGetSiteExt = timerfactory.Create<Finance.ExtFin.IExtFinGetSite>(_ExtFinGetSite);
			
			return iExtFinGetSiteExt;
		}
	}
}
