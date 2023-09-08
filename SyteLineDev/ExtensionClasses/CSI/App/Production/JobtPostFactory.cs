//PROJECT NAME: Production
//CLASS NAME: JobtPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtPostFactory
	{
		public IJobtPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtPost = new Production.JobtPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtPostExt = timerfactory.Create<Production.IJobtPost>(_JobtPost);
			
			return iJobtPostExt;
		}
	}
}
