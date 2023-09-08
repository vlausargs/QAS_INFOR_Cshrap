//PROJECT NAME: Material
//CLASS NAME: WhseValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class WhseValidFactory
	{
		public IWhseValid Create(IApplicationDB appDB)
		{
			var _WhseValid = new Material.WhseValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWhseValidExt = timerfactory.Create<Material.IWhseValid>(_WhseValid);
			
			return iWhseValidExt;
		}
	}
}
