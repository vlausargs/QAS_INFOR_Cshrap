//PROJECT NAME: CSIMaterial
//CLASS NAME: CountQtyValidateFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class CountQtyValidateFactory
	{
		public ICountQtyValidate Create(IApplicationDB appDB)
		{
			var _CountQtyValidate = new Material.CountQtyValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCountQtyValidateExt = timerfactory.Create<Material.ICountQtyValidate>(_CountQtyValidate);
			
			return iCountQtyValidateExt;
		}
	}
}
