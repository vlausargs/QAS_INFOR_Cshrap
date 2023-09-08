//PROJECT NAME: Logistics
//CLASS NAME: GetParmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetParmsFactory
	{
		public IGetParms Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetParms = new Logistics.Vendor.GetParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetParmsExt = timerfactory.Create<Logistics.Vendor.IGetParms>(_GetParms);
			
			return iGetParmsExt;
		}
	}
}
