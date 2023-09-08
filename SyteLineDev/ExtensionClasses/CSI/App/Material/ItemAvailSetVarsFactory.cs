//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemAvailSetVarsFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemAvailSetVarsFactory
	{
		public IItemAvailSetVars Create(IApplicationDB appDB)
		{
			var _ItemAvailSetVars = new Material.ItemAvailSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemAvailSetVarsExt = timerfactory.Create<Material.IItemAvailSetVars>(_ItemAvailSetVars);
			
			return iItemAvailSetVarsExt;
		}
	}
}
