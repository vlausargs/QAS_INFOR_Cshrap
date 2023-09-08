//PROJECT NAME: Logistics
//CLASS NAME: GetAPAgingInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetAPAgingInfoFactory
	{
		public IGetAPAgingInfo Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _GetAPAgingInfo = new Logistics.Vendor.GetAPAgingInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAPAgingInfoExt = timerfactory.Create<Logistics.Vendor.IGetAPAgingInfo>(_GetAPAgingInfo);
			
			return iGetAPAgingInfoExt;
		}
	}
}
