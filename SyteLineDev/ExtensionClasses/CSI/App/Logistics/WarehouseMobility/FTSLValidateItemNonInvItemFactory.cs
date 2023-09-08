//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLValidateItemNonInvItemFactory.cs

using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidateItemNonInvItemFactory
	{
		public IFTSLValidateItemNonInvItem Create(IApplicationDB appDB)
		{
			var _FTSLValidateItemNonInvItem = new Logistics.WarehouseMobility.FTSLValidateItemNonInvItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidateItemNonInvItemExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidateItemNonInvItem>(_FTSLValidateItemNonInvItem);
			
			return iFTSLValidateItemNonInvItemExt;
		}
	}
}
