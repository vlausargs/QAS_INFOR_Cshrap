//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveItemRevFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveItemRevFactory
	{
		public ICopyBomLeaveItemRev Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveItemRev = new Production.CopyBomLeaveItemRev(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveItemRevExt = timerfactory.Create<Production.ICopyBomLeaveItemRev>(_CopyBomLeaveItemRev);
			
			return iCopyBomLeaveItemRevExt;
		}
	}
}
