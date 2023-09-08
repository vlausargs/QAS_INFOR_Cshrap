//PROJECT NAME: Logistics
//CLASS NAME: CLM_GenerateTaxDistributionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_GenerateTaxDistributionFactory
	{
		public ICLM_GenerateTaxDistribution Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GenerateTaxDistribution = new Logistics.Vendor.CLM_GenerateTaxDistribution(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GenerateTaxDistributionExt = timerfactory.Create<Logistics.Vendor.ICLM_GenerateTaxDistribution>(_CLM_GenerateTaxDistribution);
			
			return iCLM_GenerateTaxDistributionExt;
		}
	}
}
