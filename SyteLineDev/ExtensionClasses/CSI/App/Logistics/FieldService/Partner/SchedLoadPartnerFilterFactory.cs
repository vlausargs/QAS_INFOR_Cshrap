//PROJECT NAME: Logistics
//CLASS NAME: SchedLoadPartnerFilterFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedLoadPartnerFilterFactory
	{
		public ISchedLoadPartnerFilter Create(IApplicationDB appDB)
		{
			var _SchedLoadPartnerFilter = new Logistics.FieldService.Partner.SchedLoadPartnerFilter(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedLoadPartnerFilterExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedLoadPartnerFilter>(_SchedLoadPartnerFilter);
			
			return iSchedLoadPartnerFilterExt;
		}
	}
}
