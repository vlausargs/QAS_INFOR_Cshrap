//PROJECT NAME: Logistics
//CLASS NAME: CheckforFRCPFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CheckforFRCPFactory
	{
		public ICheckforFRCP Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CheckforFRCP = new Logistics.Customer.CheckforFRCP(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckforFRCPExt = timerfactory.Create<Logistics.Customer.ICheckforFRCP>(_CheckforFRCP);
			
			return iCheckforFRCPExt;
		}
	}
}
