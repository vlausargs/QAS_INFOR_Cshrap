//PROJECT NAME: Production
//CLASS NAME: PmfFmValidateJobSyncFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmValidateJobSyncFactory
	{
		public IPmfFmValidateJobSync Create(IApplicationDB appDB)
		{
			var _PmfFmValidateJobSync = new Production.ProcessManufacturing.PmfFmValidateJobSync(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmValidateJobSyncExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmValidateJobSync>(_PmfFmValidateJobSync);
			
			return iPmfFmValidateJobSyncExt;
		}
	}
}
