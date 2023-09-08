//PROJECT NAME: CSICustomer
//CLASS NAME: GetSalesmanAddressFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetSalesmanAddressFactory
	{
		public IGetSalesmanAddress Create(IApplicationDB appDB)
		{
			var _GetSalesmanAddress = new Logistics.Customer.GetSalesmanAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSalesmanAddressExt = timerfactory.Create<Logistics.Customer.IGetSalesmanAddress>(_GetSalesmanAddress);
			
			return iGetSalesmanAddressExt;
		}
	}
}
