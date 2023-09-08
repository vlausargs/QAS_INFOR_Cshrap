//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveFromReleaseFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveFromReleaseFactory
	{
		public ICopyBomLeaveFromRelease Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveFromRelease = new Production.CopyBomLeaveFromRelease(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveFromReleaseExt = timerfactory.Create<Production.ICopyBomLeaveFromRelease>(_CopyBomLeaveFromRelease);
			
			return iCopyBomLeaveFromReleaseExt;
		}
	}
}
