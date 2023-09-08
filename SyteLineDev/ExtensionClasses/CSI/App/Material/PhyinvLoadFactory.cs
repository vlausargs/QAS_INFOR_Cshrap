//PROJECT NAME: CSIMaterial
//CLASS NAME: PhyinvLoadFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PhyinvLoadFactory
	{
		public IPhyinvLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _PhyinvLoad = new Material.PhyinvLoad(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPhyinvLoadExt = timerfactory.Create<Material.IPhyinvLoad>(_PhyinvLoad);
			
			return iPhyinvLoadExt;
		}
	}
}
