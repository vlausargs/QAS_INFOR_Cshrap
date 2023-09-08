//PROJECT NAME: Production
//CLASS NAME: ProcplnUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ProcplnUpdFactory
	{
		public IProcplnUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProcplnUpd = new Production.APS.ProcplnUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcplnUpdExt = timerfactory.Create<Production.APS.IProcplnUpd>(_ProcplnUpd);
			
			return iProcplnUpdExt;
		}
	}
}
