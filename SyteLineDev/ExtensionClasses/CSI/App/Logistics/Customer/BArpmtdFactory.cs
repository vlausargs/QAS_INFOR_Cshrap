//PROJECT NAME: Logistics
//CLASS NAME: BArpmtdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class BArpmtdFactory
	{
		public IBArpmtd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BArpmtd = new Logistics.Customer.BArpmtd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBArpmtdExt = timerfactory.Create<Logistics.Customer.IBArpmtd>(_BArpmtd);
			
			return iBArpmtdExt;
		}
	}
}
