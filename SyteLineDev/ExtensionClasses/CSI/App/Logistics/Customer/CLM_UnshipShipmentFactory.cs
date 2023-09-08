//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_UnshipShipmentFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_UnshipShipmentFactory
	{
		public ICLM_UnshipShipment Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_UnshipShipment = new Logistics.Customer.CLM_UnshipShipment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_UnshipShipmentExt = timerfactory.Create<Logistics.Customer.ICLM_UnshipShipment>(_CLM_UnshipShipment);
			
			return iCLM_UnshipShipmentExt;
		}
	}
}
