//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateJobMaterialExistFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateJobMaterialExistFactory
	{
		public IFTSLValidateJobMaterialExist Create(IApplicationDB appDB)
		{
			var _FTSLValidateJobMaterialExist = new Logistics.WarehouseMobility.FTSLValidateJobMaterialExist(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateJobMaterialExistExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateJobMaterialExist>(_FTSLValidateJobMaterialExist);
			
			return iFTSLValidateJobMaterialExistExt;
		}
	}
}
