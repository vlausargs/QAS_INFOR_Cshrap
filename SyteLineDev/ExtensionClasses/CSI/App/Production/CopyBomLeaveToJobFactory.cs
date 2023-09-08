//PROJECT NAME: CSIProduct
//CLASS NAME: CopyBomLeaveToJobFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CopyBomLeaveToJobFactory
	{
		public ICopyBomLeaveToJob Create(IApplicationDB appDB)
		{
			var _CopyBomLeaveToJob = new Production.CopyBomLeaveToJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyBomLeaveToJobExt = timerfactory.Create<Production.ICopyBomLeaveToJob>(_CopyBomLeaveToJob);
			
			return iCopyBomLeaveToJobExt;
		}
	}
}
