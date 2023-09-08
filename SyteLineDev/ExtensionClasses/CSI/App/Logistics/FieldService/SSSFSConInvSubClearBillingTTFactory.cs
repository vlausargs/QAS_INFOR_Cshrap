//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSConInvSubClearBillingTTFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSConInvSubClearBillingTTFactory
	{
		public ISSSFSConInvSubClearBillingTT Create(IApplicationDB appDB)
		{
			var _SSSFSConInvSubClearBillingTT = new Logistics.FieldService.SSSFSConInvSubClearBillingTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSConInvSubClearBillingTTExt = timerfactory.Create<Logistics.FieldService.ISSSFSConInvSubClearBillingTT>(_SSSFSConInvSubClearBillingTT);
			
			return iSSSFSConInvSubClearBillingTTExt;
		}
	}
}
