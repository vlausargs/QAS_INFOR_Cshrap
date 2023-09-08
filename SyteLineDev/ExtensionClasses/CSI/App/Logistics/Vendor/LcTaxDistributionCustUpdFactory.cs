//PROJECT NAME: Logistics
//CLASS NAME: LcTaxDistributionCustUpdFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class LcTaxDistributionCustUpdFactory
	{
		public ILcTaxDistributionCustUpd Create(IApplicationDB appDB)
		{
			var _LcTaxDistributionCustUpd = new Logistics.Vendor.LcTaxDistributionCustUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLcTaxDistributionCustUpdExt = timerfactory.Create<Logistics.Vendor.ILcTaxDistributionCustUpd>(_LcTaxDistributionCustUpd);
			
			return iLcTaxDistributionCustUpdExt;
		}
	}
}
