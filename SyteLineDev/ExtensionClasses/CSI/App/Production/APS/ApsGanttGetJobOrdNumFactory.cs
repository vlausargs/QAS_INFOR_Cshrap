//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGanttGetJobOrdNumFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGanttGetJobOrdNumFactory
	{
		public IApsGanttGetJobOrdNum Create(IApplicationDB appDB)
		{
			var _ApsGanttGetJobOrdNum = new Production.APS.ApsGanttGetJobOrdNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsGanttGetJobOrdNumExt = timerfactory.Create<Production.APS.IApsGanttGetJobOrdNum>(_ApsGanttGetJobOrdNum);
			
			return iApsGanttGetJobOrdNumExt;
		}
	}
}
