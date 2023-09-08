//PROJECT NAME: Material
//CLASS NAME: TrcombCheckItemwhseFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class TrcombCheckItemwhseFactory
	{
		public ITrcombCheckItemwhse Create(IApplicationDB appDB)
		{
			var _TrcombCheckItemwhse = new Material.TrcombCheckItemwhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrcombCheckItemwhseExt = timerfactory.Create<Material.ITrcombCheckItemwhse>(_TrcombCheckItemwhse);
			
			return iTrcombCheckItemwhseExt;
		}
	}
}
