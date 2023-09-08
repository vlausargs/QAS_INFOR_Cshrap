//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSPortalValidateSROMiscFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalValidateSROMiscFactory
	{
		public ISSSFSPortalValidateSROMisc Create(IApplicationDB appDB)
		{
			var _SSSFSPortalValidateSROMisc = new Logistics.FieldService.Requests.SSSFSPortalValidateSROMisc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalValidateSROMiscExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalValidateSROMisc>(_SSSFSPortalValidateSROMisc);
			
			return iSSSFSPortalValidateSROMiscExt;
		}
	}
}
