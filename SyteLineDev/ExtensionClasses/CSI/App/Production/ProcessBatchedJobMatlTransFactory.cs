//PROJECT NAME: Production
//CLASS NAME: ProcessBatchedJobMatlTransFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ProcessBatchedJobMatlTransFactory
	{
		public IProcessBatchedJobMatlTrans Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcessBatchedJobMatlTrans = new Production.ProcessBatchedJobMatlTrans(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessBatchedJobMatlTransExt = timerfactory.Create<Production.IProcessBatchedJobMatlTrans>(_ProcessBatchedJobMatlTrans);
			
			return iProcessBatchedJobMatlTransExt;
		}
	}
}
