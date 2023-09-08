//PROJECT NAME: CSIVendor
//CLASS NAME: GetParmVchrAuthorizeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetParmVchrAuthorizeFactory
	{
		public IGetParmVchrAuthorize Create(IApplicationDB appDB)
		{
			var _GetParmVchrAuthorize = new Logistics.Vendor.GetParmVchrAuthorize(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetParmVchrAuthorizeExt = timerfactory.Create<Logistics.Vendor.IGetParmVchrAuthorize>(_GetParmVchrAuthorize);
			
			return iGetParmVchrAuthorizeExt;
		}
	}
}
