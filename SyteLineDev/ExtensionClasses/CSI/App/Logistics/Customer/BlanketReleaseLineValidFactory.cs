//PROJECT NAME: Logistics
//CLASS NAME: BlanketReleaseLineValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class BlanketReleaseLineValidFactory
	{
		public IBlanketReleaseLineValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BlanketReleaseLineValid = new Logistics.Customer.BlanketReleaseLineValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBlanketReleaseLineValidExt = timerfactory.Create<Logistics.Customer.IBlanketReleaseLineValid>(_BlanketReleaseLineValid);
			
			return iBlanketReleaseLineValidExt;
		}
	}
}
