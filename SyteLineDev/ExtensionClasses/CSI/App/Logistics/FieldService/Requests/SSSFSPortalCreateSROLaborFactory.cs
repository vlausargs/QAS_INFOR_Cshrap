//PROJECT NAME: Logistics
//CLASS NAME: SSSFSPortalCreateSROLaborFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalCreateSROLaborFactory
	{
		public ISSSFSPortalCreateSROLabor Create(IApplicationDB appDB)
		{
			var _SSSFSPortalCreateSROLabor = new Logistics.FieldService.Requests.SSSFSPortalCreateSROLabor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalCreateSROLaborExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalCreateSROLabor>(_SSSFSPortalCreateSROLabor);
			
			return iSSSFSPortalCreateSROLaborExt;
		}
	}
}
