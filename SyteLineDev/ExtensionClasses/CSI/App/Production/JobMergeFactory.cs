//PROJECT NAME: CSIProduct
//CLASS NAME: JobMergeFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobMergeFactory
	{
		public IJobMerge Create(IApplicationDB appDB)
		{
			var _JobMerge = new Production.JobMerge(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobMergeExt = timerfactory.Create<Production.IJobMerge>(_JobMerge);
			
			return iJobMergeExt;
		}
	}
}
