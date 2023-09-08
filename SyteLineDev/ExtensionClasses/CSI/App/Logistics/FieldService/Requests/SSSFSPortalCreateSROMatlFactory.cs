//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateSROMatlFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalCreateSROMatlFactory
	{
		public ISSSFSPortalCreateSROMatl Create(IApplicationDB appDB)
		{
			var _SSSFSPortalCreateSROMatl = new Logistics.FieldService.Requests.SSSFSPortalCreateSROMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalCreateSROMatlExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalCreateSROMatl>(_SSSFSPortalCreateSROMatl);
			
			return iSSSFSPortalCreateSROMatlExt;
		}
	}
}
