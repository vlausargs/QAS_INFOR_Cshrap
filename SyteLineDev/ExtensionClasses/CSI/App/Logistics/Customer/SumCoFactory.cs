//PROJECT NAME: Logistics
//CLASS NAME: SumCoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class SumCoFactory
	{
		public ISumCo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SumCo = new Logistics.Customer.SumCo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSumCoExt = timerfactory.Create<Logistics.Customer.ISumCo>(_SumCo);
			
			return iSumCoExt;
		}
	}
}
