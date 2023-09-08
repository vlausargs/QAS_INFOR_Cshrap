//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateIncidentFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSPortalCreateIncidentFactory
	{
		public ISSSFSPortalCreateIncident Create(IApplicationDB appDB)
		{
			var _SSSFSPortalCreateIncident = new Logistics.FieldService.CallCenter.SSSFSPortalCreateIncident(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalCreateIncidentExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSPortalCreateIncident>(_SSSFSPortalCreateIncident);
			
			return iSSSFSPortalCreateIncidentExt;
		}
	}
}
