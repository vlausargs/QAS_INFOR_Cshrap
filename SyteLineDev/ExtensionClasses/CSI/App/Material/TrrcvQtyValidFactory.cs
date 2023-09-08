//PROJECT NAME: Material
//CLASS NAME: TrrcvQtyValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TrrcvQtyValidFactory
	{
		public ITrrcvQtyValid Create(IApplicationDB appDB)
		{
			var _TrrcvQtyValid = new Material.TrrcvQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrrcvQtyValidExt = timerfactory.Create<Material.ITrrcvQtyValid>(_TrrcvQtyValid);
			
			return iTrrcvQtyValidExt;
		}
	}
}
