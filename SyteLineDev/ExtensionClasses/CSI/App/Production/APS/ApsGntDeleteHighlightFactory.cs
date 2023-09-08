//PROJECT NAME: Production
//CLASS NAME: ApsGntDeleteHighlightFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGntDeleteHighlightFactory
	{
		public IApsGntDeleteHighlight Create(IApplicationDB appDB)
		{
			var _ApsGntDeleteHighlight = new Production.APS.ApsGntDeleteHighlight(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsGntDeleteHighlightExt = timerfactory.Create<Production.APS.IApsGntDeleteHighlight>(_ApsGntDeleteHighlight);
			
			return iApsGntDeleteHighlightExt;
		}
	}
}
