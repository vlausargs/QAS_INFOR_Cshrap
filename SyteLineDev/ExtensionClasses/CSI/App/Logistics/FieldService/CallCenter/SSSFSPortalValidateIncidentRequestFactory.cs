//PROJECT NAME: CSIFSPlusCallCenter
//CLASS NAME: SSSFSPortalValidateIncidentRequestFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.CallCenter
{
	public class SSSFSPortalValidateIncidentRequestFactory
	{
		public ISSSFSPortalValidateIncidentRequest Create(IApplicationDB appDB)
		{
			var _SSSFSPortalValidateIncidentRequest = new Logistics.FieldService.CallCenter.SSSFSPortalValidateIncidentRequest(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalValidateIncidentRequestExt = timerfactory.Create<Logistics.FieldService.CallCenter.ISSSFSPortalValidateIncidentRequest>(_SSSFSPortalValidateIncidentRequest);
			
			return iSSSFSPortalValidateIncidentRequestExt;
		}
	}
}
