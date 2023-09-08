//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateSROMiscFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalCreateSROMiscFactory
	{
		public ISSSFSPortalCreateSROMisc Create(IApplicationDB appDB)
		{
			var _SSSFSPortalCreateSROMisc = new Logistics.FieldService.Requests.SSSFSPortalCreateSROMisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalCreateSROMiscExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalCreateSROMisc>(_SSSFSPortalCreateSROMisc);
			
			return iSSSFSPortalCreateSROMiscExt;
		}
	}
}
