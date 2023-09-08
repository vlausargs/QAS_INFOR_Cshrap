//PROJECT NAME: Production
//CLASS NAME: GntHlCritUpdFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GntHlCritUpdFactory
	{
		public IGntHlCritUpd Create(IApplicationDB appDB)
		{
			var _GntHlCritUpd = new Production.APS.GntHlCritUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGntHlCritUpdExt = timerfactory.Create<Production.APS.IGntHlCritUpd>(_GntHlCritUpd);
			
			return iGntHlCritUpdExt;
		}
	}
}
