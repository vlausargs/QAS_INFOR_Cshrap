//PROJECT NAME: Production
//CLASS NAME: WcMachineTimeTransPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class WcMachineTimeTransPreFactory
	{
		public IWcMachineTimeTransPre Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WcMachineTimeTransPre = new Production.WcMachineTimeTransPre(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWcMachineTimeTransPreExt = timerfactory.Create<Production.IWcMachineTimeTransPre>(_WcMachineTimeTransPre);
			
			return iWcMachineTimeTransPreExt;
		}
	}
}
