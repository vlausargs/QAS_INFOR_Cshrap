//PROJECT NAME: CSICustomer
//CLASS NAME: GetCustItemInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCustItemInfoFactory
	{
		public IGetCustItemInfo Create(IApplicationDB appDB)
		{
			var _GetCustItemInfo = new Logistics.Customer.GetCustItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustItemInfoExt = timerfactory.Create<Logistics.Customer.IGetCustItemInfo>(_GetCustItemInfo);
			
			return iGetCustItemInfoExt;
		}
	}
}
