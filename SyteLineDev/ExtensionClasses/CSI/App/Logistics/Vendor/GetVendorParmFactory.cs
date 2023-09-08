//PROJECT NAME: Logistics
//CLASS NAME: GetVendorParmFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetVendorParmFactory
	{
		public IGetVendorParm Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetVendorParm = new Logistics.Vendor.GetVendorParm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVendorParmExt = timerfactory.Create<Logistics.Vendor.IGetVendorParm>(_GetVendorParm);
			
			return iGetVendorParmExt;
		}
	}
}
