//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjParmDevPercFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetProjParmDevPercFactory
	{
		public IGetProjParmDevPerc Create(IApplicationDB appDB)
		{
			var _GetProjParmDevPerc = new Production.Projects.GetProjParmDevPerc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjParmDevPercExt = timerfactory.Create<Production.Projects.IGetProjParmDevPerc>(_GetProjParmDevPerc);
			
			return iGetProjParmDevPercExt;
		}
	}
}
