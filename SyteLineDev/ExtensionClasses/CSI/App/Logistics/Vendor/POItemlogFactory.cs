//PROJECT NAME: Logistics
//CLASS NAME: POItemlogFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class POItemlogFactory
	{
		public IPOItemlog Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _POItemlog = new Logistics.Vendor.POItemlog(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOItemlogExt = timerfactory.Create<Logistics.Vendor.IPOItemlog>(_POItemlog);
			
			return iPOItemlogExt;
		}
	}
}
