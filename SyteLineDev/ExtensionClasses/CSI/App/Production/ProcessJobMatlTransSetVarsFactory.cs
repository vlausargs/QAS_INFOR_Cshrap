//PROJECT NAME: Production
//CLASS NAME: ProcessJobMatlTransSetVarsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class ProcessJobMatlTransSetVarsFactory
	{
		public IProcessJobMatlTransSetVars Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcessJobMatlTransSetVars = new Production.ProcessJobMatlTransSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessJobMatlTransSetVarsExt = timerfactory.Create<Production.IProcessJobMatlTransSetVars>(_ProcessJobMatlTransSetVars);
			
			return iProcessJobMatlTransSetVarsExt;
		}
	}
}
