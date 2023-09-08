//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLItemPackageValidateFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLItemPackageValidateFactory
	{
		public IFTSLItemPackageValidate Create(IApplicationDB appDB)
		{
			var _FTSLItemPackageValidate = new Logistics.WarehouseMobility.FTSLItemPackageValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLItemPackageValidateExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLItemPackageValidate>(_FTSLItemPackageValidate);
			
			return iFTSLItemPackageValidateExt;
		}
	}
}
