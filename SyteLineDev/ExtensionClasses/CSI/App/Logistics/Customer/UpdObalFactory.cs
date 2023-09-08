//PROJECT NAME: Logistics
//CLASS NAME: UpdObalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class UpdObalFactory
	{
		public IUpdObal Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _UpdObal = new Logistics.Customer.UpdObal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdObalExt = timerfactory.Create<Logistics.Customer.IUpdObal>(_UpdObal);
			
			return iUpdObalExt;
		}
	}
}
