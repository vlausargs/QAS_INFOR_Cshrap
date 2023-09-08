//PROJECT NAME: Production
//CLASS NAME: ApsGntDeleteSelectionFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGntDeleteSelectionFactory
	{
		public IApsGntDeleteSelection Create(IApplicationDB appDB)
		{
			var _ApsGntDeleteSelection = new Production.APS.ApsGntDeleteSelection(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsGntDeleteSelectionExt = timerfactory.Create<Production.APS.IApsGntDeleteSelection>(_ApsGntDeleteSelection);
			
			return iApsGntDeleteSelectionExt;
		}
	}
}
