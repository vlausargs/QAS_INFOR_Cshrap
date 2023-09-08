//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTGenerateOutputAndTidyFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTTGenerateOutputAndTidyFactory
	{
		public IFTTTGenerateOutputAndTidy Create(IApplicationDB appDB)
		{
			var _FTTTGenerateOutputAndTidy = new Logistics.WarehouseMobility.FTTTGenerateOutputAndTidy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTTGenerateOutputAndTidyExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTTGenerateOutputAndTidy>(_FTTTGenerateOutputAndTidy);
			
			return iFTTTGenerateOutputAndTidyExt;
		}
	}
}
