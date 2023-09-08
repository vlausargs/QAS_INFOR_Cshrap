//PROJECT NAME: Logistics
//CLASS NAME: SchedUpdateApptStatFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedUpdateApptStatFactory
	{
		public ISchedUpdateApptStat Create(IApplicationDB appDB)
		{
			var _SchedUpdateApptStat = new Logistics.FieldService.Partner.SchedUpdateApptStat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedUpdateApptStatExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedUpdateApptStat>(_SchedUpdateApptStat);
			
			return iSchedUpdateApptStatExt;
		}
	}
}
