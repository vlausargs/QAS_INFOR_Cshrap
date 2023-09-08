//PROJECT NAME: CSIProduct
//CLASS NAME: CreateJobFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class CreateJobFactory
	{
		public ICreateJob Create(IApplicationDB appDB)
		{
			var _CreateJob = new Production.CreateJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreateJobExt = timerfactory.Create<Production.ICreateJob>(_CreateJob);
			
			return iCreateJobExt;
		}
	}
}
