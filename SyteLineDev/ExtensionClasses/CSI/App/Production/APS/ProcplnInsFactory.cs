//PROJECT NAME: Production
//CLASS NAME: ProcplnInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ProcplnInsFactory
	{
		public IProcplnIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcplnIns = new Production.APS.ProcplnIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcplnInsExt = timerfactory.Create<Production.APS.IProcplnIns>(_ProcplnIns);
			
			return iProcplnInsExt;
		}
	}
}
