//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileReprintPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileReprintPackingSlipFactory
	{
		public IProfileReprintPackingSlip Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileReprintPackingSlip = new Logistics.Customer.ProfileReprintPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileReprintPackingSlipExt = timerfactory.Create<Logistics.Customer.IProfileReprintPackingSlip>(_ProfileReprintPackingSlip);
			
			return iProfileReprintPackingSlipExt;
		}
	}
}
