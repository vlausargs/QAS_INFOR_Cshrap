//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_TaxDistLoadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_TaxDistLoadFactory
	{
		public ICLM_TaxDistLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_TaxDistLoad = new Logistics.Customer.CLM_TaxDistLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TaxDistLoadExt = timerfactory.Create<Logistics.Customer.ICLM_TaxDistLoad>(_CLM_TaxDistLoad);
			
			return iCLM_TaxDistLoadExt;
		}
	}
}
