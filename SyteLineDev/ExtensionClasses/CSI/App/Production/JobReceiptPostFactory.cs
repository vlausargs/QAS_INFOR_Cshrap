//PROJECT NAME: Production
//CLASS NAME: JobReceiptPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobReceiptPostFactory
	{
		public IJobReceiptPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobReceiptPost = new Production.JobReceiptPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobReceiptPostExt = timerfactory.Create<Production.IJobReceiptPost>(_JobReceiptPost);
			
			return iJobReceiptPostExt;
		}
	}
}
