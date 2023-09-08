//PROJECT NAME: Production
//CLASS NAME: ProcplnDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ProcplnDelFactory
	{
		public IProcplnDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcplnDel = new Production.APS.ProcplnDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcplnDelExt = timerfactory.Create<Production.APS.IProcplnDel>(_ProcplnDel);
			
			return iProcplnDelExt;
		}
	}
}
