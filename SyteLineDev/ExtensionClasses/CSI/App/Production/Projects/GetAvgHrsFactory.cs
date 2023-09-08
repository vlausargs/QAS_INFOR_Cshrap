//PROJECT NAME: CSIProjects
//CLASS NAME: GetAvgHrsFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetAvgHrsFactory
	{
		public IGetAvgHrs Create(IApplicationDB appDB)
		{
			var _GetAvgHrs = new Production.Projects.GetAvgHrs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAvgHrsExt = timerfactory.Create<Production.Projects.IGetAvgHrs>(_GetAvgHrs);
			
			return iGetAvgHrsExt;
		}
	}
}
