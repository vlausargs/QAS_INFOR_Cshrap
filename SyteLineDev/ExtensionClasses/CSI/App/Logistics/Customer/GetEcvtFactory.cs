//PROJECT NAME: Logistics
//CLASS NAME: GetEcvtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetEcvtFactory
	{
		public IGetEcvt Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetEcvt = new Logistics.Customer.GetEcvt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEcvtExt = timerfactory.Create<Logistics.Customer.IGetEcvt>(_GetEcvt);
			
			return iGetEcvtExt;
		}
	}
}
