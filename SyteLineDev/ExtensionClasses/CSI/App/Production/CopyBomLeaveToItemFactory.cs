//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToItemFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveToItemFactory
	{
		public ICopyBomLeaveToItem Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveToItem = new Production.CopyBomLeaveToItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveToItemExt = timerfactory.Create<Production.ICopyBomLeaveToItem>(_CopyBomLeaveToItem);
			
			return iCopyBomLeaveToItemExt;
		}
	}
}
