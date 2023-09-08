//PROJECT NAME: CSIProjects
//CLASS NAME: GetProjInitDataFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetProjInitDataFactory
	{
		public IGetProjInitData Create(IApplicationDB appDB)
		{
			var _GetProjInitData = new Production.Projects.GetProjInitData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetProjInitDataExt = timerfactory.Create<Production.Projects.IGetProjInitData>(_GetProjInitData);
			
			return iGetProjInitDataExt;
		}
	}
}
