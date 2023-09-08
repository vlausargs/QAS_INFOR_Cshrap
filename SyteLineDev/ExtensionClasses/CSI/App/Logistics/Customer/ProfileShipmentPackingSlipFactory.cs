//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileShipmentPackingSlipFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileShipmentPackingSlipFactory
	{
		public IProfileShipmentPackingSlip Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileShipmentPackingSlip = new Logistics.Customer.ProfileShipmentPackingSlip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileShipmentPackingSlipExt = timerfactory.Create<Logistics.Customer.IProfileShipmentPackingSlip>(_ProfileShipmentPackingSlip);
			
			return iProfileShipmentPackingSlipExt;
		}
	}
}
