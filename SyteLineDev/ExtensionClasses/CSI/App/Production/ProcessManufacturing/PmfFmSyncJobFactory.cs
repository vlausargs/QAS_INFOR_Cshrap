//PROJECT NAME: Production
//CLASS NAME: PmfFmSyncJobFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmSyncJobFactory
	{
		public IPmfFmSyncJob Create(IApplicationDB appDB)
		{
			var _PmfFmSyncJob = new Production.ProcessManufacturing.PmfFmSyncJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmSyncJobExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmSyncJob>(_PmfFmSyncJob);
			
			return iPmfFmSyncJobExt;
		}
	}
}
