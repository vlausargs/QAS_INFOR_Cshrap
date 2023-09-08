//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentProFormaInvoiceSerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ShipmentProFormaInvoiceSerFactory
	{
		public IRpt_ShipmentProFormaInvoiceSer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ShipmentProFormaInvoiceSer = new Reporting.Rpt_ShipmentProFormaInvoiceSer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ShipmentProFormaInvoiceSerExt = timerfactory.Create<Reporting.IRpt_ShipmentProFormaInvoiceSer>(_Rpt_ShipmentProFormaInvoiceSer);
			
			return iRpt_ShipmentProFormaInvoiceSerExt;
		}
	}
}
