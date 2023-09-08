//PROJECT NAME: Logistics
//CLASS NAME: CheckBankAddrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckBankAddrFactory
	{
		public ICheckBankAddr Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CheckBankAddr = new Logistics.Customer.CheckBankAddr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckBankAddrExt = timerfactory.Create<Logistics.Customer.ICheckBankAddr>(_CheckBankAddr);
			
			return iCheckBankAddrExt;
		}
	}
}
