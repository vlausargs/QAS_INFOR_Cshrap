//PROJECT NAME: Material
//CLASS NAME: UpdateOverrideForAttributesFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class UpdateOverrideForAttributesFactory
	{
		public IUpdateOverrideForAttributes Create(IApplicationDB appDB)
		{
			var _UpdateOverrideForAttributes = new Material.UpdateOverrideForAttributes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateOverrideForAttributesExt = timerfactory.Create<Material.IUpdateOverrideForAttributes>(_UpdateOverrideForAttributes);
			
			return iUpdateOverrideForAttributesExt;
		}
	}
}
