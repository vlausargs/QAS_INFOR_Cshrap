//PROJECT NAME: CSICustomer
//CLASS NAME: GetSiteGroupARAgingInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetSiteGroupARAgingInfoFactory
	{
		public IGetSiteGroupARAgingInfo Create(IApplicationDB appDB)
		{
			var _GetSiteGroupARAgingInfo = new Logistics.Customer.GetSiteGroupARAgingInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteGroupARAgingInfoExt = timerfactory.Create<Logistics.Customer.IGetSiteGroupARAgingInfo>(_GetSiteGroupARAgingInfo);
			
			return iGetSiteGroupARAgingInfoExt;
		}
	}
}
