//PROJECT NAME: Logistics
//CLASS NAME: APVchPostingAptrxdSnapShotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class APVchPostingAptrxdSnapShotFactory
	{
		public IAPVchPostingAptrxdSnapShot Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _APVchPostingAptrxdSnapShot = new Logistics.Vendor.APVchPostingAptrxdSnapShot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPVchPostingAptrxdSnapShotExt = timerfactory.Create<Logistics.Vendor.IAPVchPostingAptrxdSnapShot>(_APVchPostingAptrxdSnapShot);
			
			return iAPVchPostingAptrxdSnapShotExt;
		}
	}
}
