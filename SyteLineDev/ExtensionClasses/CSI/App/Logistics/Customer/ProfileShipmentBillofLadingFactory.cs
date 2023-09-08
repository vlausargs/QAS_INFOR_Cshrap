//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileShipmentBillofLadingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileShipmentBillofLadingFactory
	{
		public IProfileShipmentBillofLading Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileShipmentBillofLading = new Logistics.Customer.ProfileShipmentBillofLading(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileShipmentBillofLadingExt = timerfactory.Create<Logistics.Customer.IProfileShipmentBillofLading>(_ProfileShipmentBillofLading);
			
			return iProfileShipmentBillofLadingExt;
		}
	}
}
