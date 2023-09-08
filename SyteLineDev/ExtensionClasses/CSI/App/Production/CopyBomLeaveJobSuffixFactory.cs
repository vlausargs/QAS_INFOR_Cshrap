//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveJobSuffixFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveJobSuffixFactory
	{
		public ICopyBomLeaveJobSuffix Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveJobSuffix = new Production.CopyBomLeaveJobSuffix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveJobSuffixExt = timerfactory.Create<Production.ICopyBomLeaveJobSuffix>(_CopyBomLeaveJobSuffix);
			
			return iCopyBomLeaveJobSuffixExt;
		}
	}
}
