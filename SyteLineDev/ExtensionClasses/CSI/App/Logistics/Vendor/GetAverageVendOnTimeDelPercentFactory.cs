//PROJECT NAME: Logistics
//CLASS NAME: GetAverageVendOnTimeDelPercentFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetAverageVendOnTimeDelPercentFactory
	{
		public IGetAverageVendOnTimeDelPercent Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetAverageVendOnTimeDelPercent = new Logistics.Vendor.GetAverageVendOnTimeDelPercent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAverageVendOnTimeDelPercentExt = timerfactory.Create<Logistics.Vendor.IGetAverageVendOnTimeDelPercent>(_GetAverageVendOnTimeDelPercent);
			
			return iGetAverageVendOnTimeDelPercentExt;
		}
	}
}
