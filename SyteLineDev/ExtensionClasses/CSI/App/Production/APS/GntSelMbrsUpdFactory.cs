//PROJECT NAME: Production
//CLASS NAME: GntSelMbrsUpdFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class GntSelMbrsUpdFactory
	{
		public IGntSelMbrsUpd Create(IApplicationDB appDB)
		{
			var _GntSelMbrsUpd = new Production.APS.GntSelMbrsUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGntSelMbrsUpdExt = timerfactory.Create<Production.APS.IGntSelMbrsUpd>(_GntSelMbrsUpd);
			
			return iGntSelMbrsUpdExt;
		}
	}
}
