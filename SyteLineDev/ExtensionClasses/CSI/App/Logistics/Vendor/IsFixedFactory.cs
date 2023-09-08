//PROJECT NAME: Logistics
//CLASS NAME: IsFixedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class IsFixedFactory
	{
		public IIsFixed Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _IsFixed = new Logistics.Vendor.IsFixed(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsFixedExt = timerfactory.Create<Logistics.Vendor.IIsFixed>(_IsFixed);
			
			return iIsFixedExt;
		}
	}
}
