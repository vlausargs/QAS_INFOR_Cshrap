//PROJECT NAME: CSIMaterial
//CLASS NAME: GetSiteParmsForItemAllsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetSiteParmsForItemAllsFactory
	{
		public IGetSiteParmsForItemAlls Create(IApplicationDB appDB)
		{
			var _GetSiteParmsForItemAlls = new Material.GetSiteParmsForItemAlls(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSiteParmsForItemAllsExt = timerfactory.Create<Material.IGetSiteParmsForItemAlls>(_GetSiteParmsForItemAlls);
			
			return iGetSiteParmsForItemAllsExt;
		}
	}
}
