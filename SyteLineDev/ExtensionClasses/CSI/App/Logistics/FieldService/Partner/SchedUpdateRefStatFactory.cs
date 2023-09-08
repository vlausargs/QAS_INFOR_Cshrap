//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SchedUpdateRefStatFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedUpdateRefStatFactory
	{
		public ISchedUpdateRefStat Create(IApplicationDB appDB)
		{
			var _SchedUpdateRefStat = new Logistics.FieldService.Partner.SchedUpdateRefStat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedUpdateRefStatExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedUpdateRefStat>(_SchedUpdateRefStat);
			
			return iSchedUpdateRefStatExt;
		}
	}
}
