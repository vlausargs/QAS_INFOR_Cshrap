//PROJECT NAME: Production
//CLASS NAME: PsitemItemValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PsitemItemValidFactory
	{
		public IPsitemItemValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PsitemItemValid = new Production.PsitemItemValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPsitemItemValidExt = timerfactory.Create<Production.IPsitemItemValid>(_PsitemItemValid);
			
			return iPsitemItemValidExt;
		}
	}
}
