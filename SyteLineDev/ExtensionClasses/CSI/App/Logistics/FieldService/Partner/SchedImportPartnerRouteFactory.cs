//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SchedImportPartnerRouteFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedImportPartnerRouteFactory
	{
		public ISchedImportPartnerRoute Create(IApplicationDB appDB)
		{
			var _SchedImportPartnerRoute = new Logistics.FieldService.Partner.SchedImportPartnerRoute(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSchedImportPartnerRouteExt = timerfactory.Create<Logistics.FieldService.Partner.ISchedImportPartnerRoute>(_SchedImportPartnerRoute);
			
			return iSchedImportPartnerRouteExt;
		}
	}
}
