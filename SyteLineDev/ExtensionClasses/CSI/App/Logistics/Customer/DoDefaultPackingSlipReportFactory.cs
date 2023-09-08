//PROJECT NAME: Logistics
//CLASS NAME: DoDefaultPackingSlipReportFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class DoDefaultPackingSlipReportFactory
	{
		public IDoDefaultPackingSlipReport Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DoDefaultPackingSlipReport = new Logistics.Customer.DoDefaultPackingSlipReport(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDoDefaultPackingSlipReportExt = timerfactory.Create<Logistics.Customer.IDoDefaultPackingSlipReport>(_DoDefaultPackingSlipReport);
			
			return iDoDefaultPackingSlipReportExt;
		}
	}
}
