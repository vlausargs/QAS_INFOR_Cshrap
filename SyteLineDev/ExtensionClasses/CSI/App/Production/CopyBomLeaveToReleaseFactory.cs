//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToReleaseFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveToReleaseFactory
	{
		public ICopyBomLeaveToRelease Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveToRelease = new Production.CopyBomLeaveToRelease(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveToReleaseExt = timerfactory.Create<Production.ICopyBomLeaveToRelease>(_CopyBomLeaveToRelease);
			
			return iCopyBomLeaveToReleaseExt;
		}
	}
}
