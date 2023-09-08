//PROJECT NAME: Material
//CLASS NAME: TrnLossQtyValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TrnLossQtyValidFactory
	{
		public ITrnLossQtyValid Create(IApplicationDB appDB)
		{
			var _TrnLossQtyValid = new Material.TrnLossQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnLossQtyValidExt = timerfactory.Create<Material.ITrnLossQtyValid>(_TrnLossQtyValid);
			
			return iTrnLossQtyValidExt;
		}
	}
}
