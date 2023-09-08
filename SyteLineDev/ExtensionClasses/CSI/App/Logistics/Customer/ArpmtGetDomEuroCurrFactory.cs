//PROJECT NAME: Logistics
//CLASS NAME: ArpmtGetDomEuroCurrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ArpmtGetDomEuroCurrFactory
	{
		public IArpmtGetDomEuroCurr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ArpmtGetDomEuroCurr = new Logistics.Customer.ArpmtGetDomEuroCurr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtGetDomEuroCurrExt = timerfactory.Create<Logistics.Customer.IArpmtGetDomEuroCurr>(_ArpmtGetDomEuroCurr);
			
			return iArpmtGetDomEuroCurrExt;
		}
	}
}
