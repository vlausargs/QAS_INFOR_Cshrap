//PROJECT NAME: CSIMaterial
//CLASS NAME: GetPhyinvStatFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class GetPhyinvStatFactory
	{
		public IGetPhyinvStat Create(IApplicationDB appDB)
		{
			var _GetPhyinvStat = new Material.GetPhyinvStat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPhyinvStatExt = timerfactory.Create<Material.IGetPhyinvStat>(_GetPhyinvStat);
			
			return iGetPhyinvStatExt;
		}
	}
}
