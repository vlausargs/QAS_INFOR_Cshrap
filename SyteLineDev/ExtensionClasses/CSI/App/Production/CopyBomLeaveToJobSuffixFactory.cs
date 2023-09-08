//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToJobSuffixFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveToJobSuffixFactory
	{
		public ICopyBomLeaveToJobSuffix Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveToJobSuffix = new Production.CopyBomLeaveToJobSuffix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveToJobSuffixExt = timerfactory.Create<Production.ICopyBomLeaveToJobSuffix>(_CopyBomLeaveToJobSuffix);
			
			return iCopyBomLeaveToJobSuffixExt;
		}
	}
}
