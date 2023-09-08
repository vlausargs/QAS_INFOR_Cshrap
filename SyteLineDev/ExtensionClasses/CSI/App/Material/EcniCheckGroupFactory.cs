//PROJECT NAME: Material
//CLASS NAME: ecniCheckGroupFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class ecniCheckGroupFactory
	{
		public IecniCheckGroup Create(IApplicationDB appDB)
		{
			var _ecniCheckGroup = new Material.ecniCheckGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iecniCheckGroupExt = timerfactory.Create<Material.IecniCheckGroup>(_ecniCheckGroup);
			
			return iecniCheckGroupExt;
		}
	}
}
