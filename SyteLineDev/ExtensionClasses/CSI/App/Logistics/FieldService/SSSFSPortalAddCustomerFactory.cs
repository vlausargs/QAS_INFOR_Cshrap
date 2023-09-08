//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalAddCustomerFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSPortalAddCustomerFactory
	{
		public ISSSFSPortalAddCustomer Create(IApplicationDB appDB)
		{
			var _SSSFSPortalAddCustomer = new Logistics.FieldService.SSSFSPortalAddCustomer(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalAddCustomerExt = timerfactory.Create<Logistics.FieldService.ISSSFSPortalAddCustomer>(_SSSFSPortalAddCustomer);
			
			return iSSSFSPortalAddCustomerExt;
		}
	}
}
