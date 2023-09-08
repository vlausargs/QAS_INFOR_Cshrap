//PROJECT NAME: Logistics
//CLASS NAME: CLM_SlsmanDirectReportsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CLM_SlsmanDirectReportsFactory
	{
		public ICLM_SlsmanDirectReports Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CLM_SlsmanDirectReports = new Logistics.Customer.CLM_SlsmanDirectReports(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SlsmanDirectReportsExt = timerfactory.Create<Logistics.Customer.ICLM_SlsmanDirectReports>(_CLM_SlsmanDirectReports);
			
			return iCLM_SlsmanDirectReportsExt;
		}
	}
}
