//PROJECT NAME: Production
//CLASS NAME: RecalculateObligationsFactory.cs

using CSI.MG;

namespace CSI.Production.Projects
{
	public class RecalculateObligationsFactory
	{
		public IRecalculateObligations Create(IApplicationDB appDB)
		{
			var _RecalculateObligations = new Production.Projects.RecalculateObligations(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRecalculateObligationsExt = timerfactory.Create<Production.Projects.IRecalculateObligations>(_RecalculateObligations);
			
			return iRecalculateObligationsExt;
		}
	}
}
