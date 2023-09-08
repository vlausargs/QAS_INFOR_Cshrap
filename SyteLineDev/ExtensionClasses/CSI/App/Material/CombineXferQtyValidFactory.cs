//PROJECT NAME: CSIMaterial
//CLASS NAME: CombineXferQtyValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CombineXferQtyValidFactory
	{
		public ICombineXferQtyValid Create(IApplicationDB appDB)
		{
			var _CombineXferQtyValid = new Material.CombineXferQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferQtyValidExt = timerfactory.Create<Material.ICombineXferQtyValid>(_CombineXferQtyValid);
			
			return iCombineXferQtyValidExt;
		}
	}
}
