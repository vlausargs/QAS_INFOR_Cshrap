//PROJECT NAME: Production
//CLASS NAME: ApsSetStopAfterPushFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsSetStopAfterPushFactory
	{
		public IApsSetStopAfterPush Create(IApplicationDB appDB)
		{
			var _ApsSetStopAfterPush = new Production.APS.ApsSetStopAfterPush(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsSetStopAfterPushExt = timerfactory.Create<Production.APS.IApsSetStopAfterPush>(_ApsSetStopAfterPush);
			
			return iApsSetStopAfterPushExt;
		}
	}
}
