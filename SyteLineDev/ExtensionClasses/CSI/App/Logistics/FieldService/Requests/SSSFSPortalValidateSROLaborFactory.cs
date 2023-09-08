//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSPortalValidateSROLaborFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public class SSSFSPortalValidateSROLaborFactory
	{
		public ISSSFSPortalValidateSROLabor Create(IApplicationDB appDB)
		{
			var _SSSFSPortalValidateSROLabor = new Logistics.FieldService.Requests.SSSFSPortalValidateSROLabor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSPortalValidateSROLaborExt = timerfactory.Create<Logistics.FieldService.Requests.ISSSFSPortalValidateSROLabor>(_SSSFSPortalValidateSROLabor);
			
			return iSSSFSPortalValidateSROLaborExt;
		}
	}
}
