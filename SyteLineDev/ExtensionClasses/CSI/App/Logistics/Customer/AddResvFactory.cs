//PROJECT NAME: Logistics
//CLASS NAME: AddResvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class AddResvFactory
	{
		public IAddResv Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _AddResv = new Logistics.Customer.AddResv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAddResvExt = timerfactory.Create<Logistics.Customer.IAddResv>(_AddResv);
			
			return iAddResvExt;
		}
	}
}
