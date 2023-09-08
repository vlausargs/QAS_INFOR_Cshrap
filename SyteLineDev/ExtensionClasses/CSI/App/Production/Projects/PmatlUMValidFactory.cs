//PROJECT NAME: CSIProjects
//CLASS NAME: PmatlUMValidFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class PmatlUMValidFactory
	{
		public IPmatlUMValid Create(IApplicationDB appDB)
		{
			var _PmatlUMValid = new Production.Projects.PmatlUMValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmatlUMValidExt = timerfactory.Create<Production.Projects.IPmatlUMValid>(_PmatlUMValid);
			
			return iPmatlUMValidExt;
		}
	}
}
