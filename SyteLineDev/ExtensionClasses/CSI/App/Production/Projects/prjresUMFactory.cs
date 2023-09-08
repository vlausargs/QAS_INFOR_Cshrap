//PROJECT NAME: CSIProjects
//CLASS NAME: prjresUMFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class prjresUMFactory
	{
		public IprjresUM Create(IApplicationDB appDB)
		{
			var _prjresUM = new Production.Projects.prjresUM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iprjresUMExt = timerfactory.Create<Production.Projects.IprjresUM>(_prjresUM);
			
			return iprjresUMExt;
		}
	}
}
