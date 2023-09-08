//PROJECT NAME: Logistics
//CLASS NAME: ITaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ITaxFactory
	{
		public IITax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ITax = new Logistics.Customer.ITax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iITaxExt = timerfactory.Create<Logistics.Customer.IITax>(_ITax);
			
			return iITaxExt;
		}
	}
}
