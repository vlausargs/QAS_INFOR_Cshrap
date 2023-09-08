//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: CLM_FTSLItemAndVendorItemCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLItemAndVendorItemCheckFactory
	{
		public ICLM_FTSLItemAndVendorItemCheck Create(IApplicationDB appDB)
		{
			var _CLM_FTSLItemAndVendorItemCheck = new Logistics.WarehouseMobility.CLM_FTSLItemAndVendorItemCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLItemAndVendorItemCheckExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLItemAndVendorItemCheck>(_CLM_FTSLItemAndVendorItemCheck);
			
			return iCLM_FTSLItemAndVendorItemCheckExt;
		}
	}
}
