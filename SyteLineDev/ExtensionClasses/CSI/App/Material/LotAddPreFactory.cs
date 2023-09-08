//PROJECT NAME: CSIMaterial
//CLASS NAME: LotAddPreFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class LotAddPreFactory
	{
		public ILotAddPre Create(IApplicationDB appDB)
		{
			var _LotAddPre = new Material.LotAddPre(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLotAddPreExt = timerfactory.Create<Material.ILotAddPre>(_LotAddPre);
			
			return iLotAddPreExt;
		}
	}
}
