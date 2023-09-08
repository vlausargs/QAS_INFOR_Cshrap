//PROJECT NAME: Logistics
//CLASS NAME: GetApparmsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetApparmsFactory
	{
		public IGetApparms Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetApparms = new Logistics.Vendor.GetApparms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetApparmsExt = timerfactory.Create<Logistics.Vendor.IGetApparms>(_GetApparms);
			
			return iGetApparmsExt;
		}
	}
}
