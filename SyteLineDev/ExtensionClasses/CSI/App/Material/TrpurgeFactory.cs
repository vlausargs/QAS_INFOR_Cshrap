//PROJECT NAME: Material
//CLASS NAME: TrpurgeFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TrpurgeFactory
	{
		public ITrpurge Create(IApplicationDB appDB)
		{
			var _Trpurge = new Material.Trpurge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrpurgeExt = timerfactory.Create<Material.ITrpurge>(_Trpurge);
			
			return iTrpurgeExt;
		}
	}
}
