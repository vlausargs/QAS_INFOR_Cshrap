//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateLocationAcctFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateLocationAcctFactory
	{
		public IFTSLValidateLocationAcct Create(IApplicationDB appDB)
		{
			var _FTSLValidateLocationAcct = new Logistics.WarehouseMobility.FTSLValidateLocationAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateLocationAcctExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateLocationAcct>(_FTSLValidateLocationAcct);
			
			return iFTSLValidateLocationAcctExt;
		}
	}
}
