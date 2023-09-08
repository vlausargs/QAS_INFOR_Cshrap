//PROJECT NAME: Production
//CLASS NAME: JobtClsLogErrorFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class JobtClsLogErrorFactory
	{
		public IJobtClsLogError Create(IApplicationDB appDB)
		{
			var _JobtClsLogError = new Production.JobtClsLogError(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtClsLogErrorExt = timerfactory.Create<Production.IJobtClsLogError>(_JobtClsLogError);
			
			return iJobtClsLogErrorExt;
		}
	}
}
