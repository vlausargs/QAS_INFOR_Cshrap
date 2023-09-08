//PROJECT NAME: CSIMaterial
//CLASS NAME: ProdConfExcludeOptCodeFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ProdConfExcludeOptCodeFactory
	{
		public IProdConfExcludeOptCode Create(IApplicationDB appDB)
		{
			var _ProdConfExcludeOptCode = new Material.ProdConfExcludeOptCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProdConfExcludeOptCodeExt = timerfactory.Create<Material.IProdConfExcludeOptCode>(_ProdConfExcludeOptCode);
			
			return iProdConfExcludeOptCodeExt;
		}
	}
}
