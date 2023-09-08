//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateOperationDropDownFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateOperationDropDownFactory
	{
		public IFTSLValidateOperationDropDown Create(IApplicationDB appDB)
		{
			var _FTSLValidateOperationDropDown = new Logistics.WarehouseMobility.FTSLValidateOperationDropDown(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateOperationDropDownExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateOperationDropDown>(_FTSLValidateOperationDropDown);
			
			return iFTSLValidateOperationDropDownExt;
		}
	}
}
