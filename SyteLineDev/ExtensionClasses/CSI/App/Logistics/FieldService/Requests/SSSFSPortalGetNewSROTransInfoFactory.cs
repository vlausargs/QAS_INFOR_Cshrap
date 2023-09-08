//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSPortalGetNewSROTransInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalGetNewSROTransInfoFactory
	{
		public ISSSFSPortalGetNewSROTransInfo Create(IApplicationDB appDB)
		{
			var _SSSFSPortalGetNewSROTransInfo = new Logistics.FieldService.Requests.SSSFSPortalGetNewSROTransInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalGetNewSROTransInfoExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalGetNewSROTransInfo>(_SSSFSPortalGetNewSROTransInfo);
			
			return iSSSFSPortalGetNewSROTransInfoExt;
		}
	}
}
