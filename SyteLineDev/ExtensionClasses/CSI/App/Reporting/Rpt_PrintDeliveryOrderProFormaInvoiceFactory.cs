//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintDeliveryOrderProFormaInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PrintDeliveryOrderProFormaInvoiceFactory
	{
		public IRpt_PrintDeliveryOrderProFormaInvoice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PrintDeliveryOrderProFormaInvoice = new Reporting.Rpt_PrintDeliveryOrderProFormaInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PrintDeliveryOrderProFormaInvoiceExt = timerfactory.Create<Reporting.IRpt_PrintDeliveryOrderProFormaInvoice>(_Rpt_PrintDeliveryOrderProFormaInvoice);
			
			return iRpt_PrintDeliveryOrderProFormaInvoiceExt;
		}
	}
}
