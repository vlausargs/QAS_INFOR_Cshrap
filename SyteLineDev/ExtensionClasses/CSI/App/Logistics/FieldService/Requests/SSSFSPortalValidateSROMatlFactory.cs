//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSPortalValidateSROMatlFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalValidateSROMatlFactory
	{
		public ISSSFSPortalValidateSROMatl Create(IApplicationDB appDB)
		{
			var _SSSFSPortalValidateSROMatl = new Logistics.FieldService.Requests.SSSFSPortalValidateSROMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalValidateSROMatlExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalValidateSROMatl>(_SSSFSPortalValidateSROMatl);
			
			return iSSSFSPortalValidateSROMatlExt;
		}
	}
}
