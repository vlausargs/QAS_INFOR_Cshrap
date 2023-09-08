//PROJECT NAME: CSIProduct
//CLASS NAME: JobValidateProdMixFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobValidateProdMixFactory
	{
		public IJobValidateProdMix Create(IApplicationDB appDB)
		{
			var _JobValidateProdMix = new Production.JobValidateProdMix(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobValidateProdMixExt = timerfactory.Create<Production.IJobValidateProdMix>(_JobValidateProdMix);
			
			return iJobValidateProdMixExt;
		}
	}
}
