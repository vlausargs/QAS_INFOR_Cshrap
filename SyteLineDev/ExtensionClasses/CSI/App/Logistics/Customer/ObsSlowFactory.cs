//PROJECT NAME: Logistics
//CLASS NAME: ObsSlowFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ObsSlowFactory
	{
		public IObsSlow Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ObsSlow = new Logistics.Customer.ObsSlow(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iObsSlowExt = timerfactory.Create<Logistics.Customer.IObsSlow>(_ObsSlow);
			
			return iObsSlowExt;
		}
	}
}
