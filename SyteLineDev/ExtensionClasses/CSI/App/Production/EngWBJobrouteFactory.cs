//PROJECT NAME: CSIProduct
//CLASS NAME: EngWBJobrouteFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class EngWBJobrouteFactory
	{
		public IEngWBJobroute Create(IApplicationDB appDB)
		{
			var _EngWBJobroute = new Production.EngWBJobroute(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBJobrouteExt = timerfactory.Create<Production.IEngWBJobroute>(_EngWBJobroute);
			
			return iEngWBJobrouteExt;
		}
	}
}
