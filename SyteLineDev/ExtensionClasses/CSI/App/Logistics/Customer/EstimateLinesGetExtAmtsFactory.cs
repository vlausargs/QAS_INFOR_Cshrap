//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesGetExtAmtsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesGetExtAmtsFactory
	{
		public IEstimateLinesGetExtAmts Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstimateLinesGetExtAmts = new Logistics.Customer.EstimateLinesGetExtAmts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesGetExtAmtsExt = timerfactory.Create<Logistics.Customer.IEstimateLinesGetExtAmts>(_EstimateLinesGetExtAmts);
			
			return iEstimateLinesGetExtAmtsExt;
		}
	}
}
