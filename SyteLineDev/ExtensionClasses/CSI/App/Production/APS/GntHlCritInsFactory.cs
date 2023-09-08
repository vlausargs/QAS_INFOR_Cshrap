//PROJECT NAME: Production
//CLASS NAME: GntHlCritInsFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GntHlCritInsFactory
	{
		public IGntHlCritIns Create(IApplicationDB appDB)
		{
			var _GntHlCritIns = new Production.APS.GntHlCritIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGntHlCritInsExt = timerfactory.Create<Production.APS.IGntHlCritIns>(_GntHlCritIns);
			
			return iGntHlCritInsExt;
		}
	}
}
