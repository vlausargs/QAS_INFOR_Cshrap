//PROJECT NAME: Logistics
//CLASS NAME: VendorInsUpdRemCallFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VendorInsUpdRemCallFactory
	{
		public IVendorInsUpdRemCall Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VendorInsUpdRemCall = new Logistics.Vendor.VendorInsUpdRemCall(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorInsUpdRemCallExt = timerfactory.Create<Logistics.Vendor.IVendorInsUpdRemCall>(_VendorInsUpdRemCall);
			
			return iVendorInsUpdRemCallExt;
		}
	}
}
