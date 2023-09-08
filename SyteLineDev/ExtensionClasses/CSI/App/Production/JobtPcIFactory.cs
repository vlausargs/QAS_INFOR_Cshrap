//PROJECT NAME: Production
//CLASS NAME: JobtPcIFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtPcIFactory
	{
		public IJobtPcI Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtPcI = new Production.JobtPcI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtPcIExt = timerfactory.Create<Production.IJobtPcI>(_JobtPcI);
			
			return iJobtPcIExt;
		}
	}
}
