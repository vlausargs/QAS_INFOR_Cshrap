//PROJECT NAME: CSIVendor
//CLASS NAME: GetCompanyInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetCompanyInfoFactory
	{
		public IGetCompanyInfo Create(IApplicationDB appDB)
		{
			var _GetCompanyInfo = new Logistics.Vendor.GetCompanyInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCompanyInfoExt = timerfactory.Create<Logistics.Vendor.IGetCompanyInfo>(_GetCompanyInfo);
			
			return iGetCompanyInfoExt;
		}
	}
}
