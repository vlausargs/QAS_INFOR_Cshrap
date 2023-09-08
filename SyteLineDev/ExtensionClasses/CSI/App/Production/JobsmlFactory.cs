//PROJECT NAME: CSIProduct
//CLASS NAME: JobsmlFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobsmlFactory
	{
		public IJobsml Create(IApplicationDB appDB)
		{
			var _Jobsml = new Production.Jobsml(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobsmlExt = timerfactory.Create<Production.IJobsml>(_Jobsml);
			
			return iJobsmlExt;
		}
	}
}
