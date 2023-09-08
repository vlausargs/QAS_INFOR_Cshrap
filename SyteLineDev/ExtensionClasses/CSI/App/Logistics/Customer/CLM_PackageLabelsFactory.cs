//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_PackageLabelsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_PackageLabelsFactory
	{
		public ICLM_PackageLabels Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PackageLabels = new Logistics.Customer.CLM_PackageLabels(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PackageLabelsExt = timerfactory.Create<Logistics.Customer.ICLM_PackageLabels>(_CLM_PackageLabels);
			
			return iCLM_PackageLabelsExt;
		}
	}
}
