//PROJECT NAME: Production
//CLASS NAME: PsItemValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PsItemValidFactory
	{
		public IPsItemValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PsItemValid = new Production.PsItemValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPsItemValidExt = timerfactory.Create<Production.IPsItemValid>(_PsItemValid);
			
			return iPsItemValidExt;
		}
	}
}
