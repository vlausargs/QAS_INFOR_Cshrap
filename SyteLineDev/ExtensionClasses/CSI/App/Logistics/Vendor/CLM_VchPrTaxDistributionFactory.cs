//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_VchPrTaxDistributionFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CLM_VchPrTaxDistributionFactory
	{
		public ICLM_VchPrTaxDistribution Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_VchPrTaxDistribution = new Logistics.Vendor.CLM_VchPrTaxDistribution(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_VchPrTaxDistributionExt = timerfactory.Create<Logistics.Vendor.ICLM_VchPrTaxDistribution>(_CLM_VchPrTaxDistribution);
			
			return iCLM_VchPrTaxDistributionExt;
		}
	}
}
