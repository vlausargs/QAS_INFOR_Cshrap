//PROJECT NAME: Material
//CLASS NAME: ecniMatlItemFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ecniMatlItemFactory
	{
		public IecniMatlItem Create(IApplicationDB appDB)
		{
			var _ecniMatlItem = new Material.ecniMatlItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iecniMatlItemExt = timerfactory.Create<Material.IecniMatlItem>(_ecniMatlItem);
			
			return iecniMatlItemExt;
		}
	}
}
