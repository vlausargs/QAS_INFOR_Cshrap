//PROJECT NAME: CSIMaterial
//CLASS NAME: GetMaxLotNumSiteFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetMaxLotNumSiteFactory
	{
		public IGetMaxLotNumSite Create(IApplicationDB appDB)
		{
			var _GetMaxLotNumSite = new Material.GetMaxLotNumSite(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMaxLotNumSiteExt = timerfactory.Create<Material.IGetMaxLotNumSite>(_GetMaxLotNumSite);
			
			return iGetMaxLotNumSiteExt;
		}
	}
}
