//PROJECT NAME: CSICodes
//CLASS NAME: PortalEstimateToHistoryFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PortalEstimateToHistoryFactory
	{
		public IPortalEstimateToHistory Create(IApplicationDB appDB)
		{
			var _PortalEstimateToHistory = new Codes.PortalEstimateToHistory(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalEstimateToHistoryExt = timerfactory.Create<Codes.IPortalEstimateToHistory>(_PortalEstimateToHistory);
			
			return iPortalEstimateToHistoryExt;
		}
	}
}
