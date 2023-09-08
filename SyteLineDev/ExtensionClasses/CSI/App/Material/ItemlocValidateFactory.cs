//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemlocValidateFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ItemlocValidateFactory
	{
		public IItemlocValidate Create(IApplicationDB appDB)
		{
			var _ItemlocValidate = new Material.ItemlocValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemlocValidateExt = timerfactory.Create<Material.IItemlocValidate>(_ItemlocValidate);
			
			return iItemlocValidateExt;
		}
	}
}
