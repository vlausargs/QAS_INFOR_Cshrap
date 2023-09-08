//PROJECT NAME: CSIProjects
//CLASS NAME: GetAdjMonthYearFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class GetAdjMonthYearFactory
	{
		public IGetAdjMonthYear Create(IApplicationDB appDB)
		{
			var _GetAdjMonthYear = new Production.Projects.GetAdjMonthYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAdjMonthYearExt = timerfactory.Create<Production.Projects.IGetAdjMonthYear>(_GetAdjMonthYear);
			
			return iGetAdjMonthYearExt;
		}
	}
}
