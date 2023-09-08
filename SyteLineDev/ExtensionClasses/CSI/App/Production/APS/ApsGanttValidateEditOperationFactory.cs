//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGanttValidateEditOperationFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsGanttValidateEditOperationFactory
	{
		public IApsGanttValidateEditOperation Create(IApplicationDB appDB)
		{
			var _ApsGanttValidateEditOperation = new Production.APS.ApsGanttValidateEditOperation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsGanttValidateEditOperationExt = timerfactory.Create<Production.APS.IApsGanttValidateEditOperation>(_ApsGanttValidateEditOperation);
			
			return iApsGanttValidateEditOperationExt;
		}
	}
}
