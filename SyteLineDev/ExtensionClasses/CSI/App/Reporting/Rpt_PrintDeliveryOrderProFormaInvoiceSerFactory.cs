//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintDeliveryOrderProFormaInvoiceSerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintDeliveryOrderProFormaInvoiceSerFactory
	{
		public IRpt_PrintDeliveryOrderProFormaInvoiceSer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintDeliveryOrderProFormaInvoiceSer = new Reporting.Rpt_PrintDeliveryOrderProFormaInvoiceSer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintDeliveryOrderProFormaInvoiceSerExt = timerfactory.Create<Reporting.IRpt_PrintDeliveryOrderProFormaInvoiceSer>(_Rpt_PrintDeliveryOrderProFormaInvoiceSer);
			
			return iRpt_PrintDeliveryOrderProFormaInvoiceSerExt;
		}
	}
}
