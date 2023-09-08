//PROJECT NAME: CSIProjects
//CLASS NAME: ASNProjectRecalcFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class ASNProjectRecalcFactory
	{
		public IASNProjectRecalc Create(IApplicationDB appDB)
		{
			var _ASNProjectRecalc = new Projects.ASNProjectRecalc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iASNProjectRecalcExt = timerfactory.Create<Projects.IASNProjectRecalc>(_ASNProjectRecalc);
			
			return iASNProjectRecalcExt;
		}
	}
}
