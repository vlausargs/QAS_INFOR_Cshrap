//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ShipmentProFormaInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ShipmentProFormaInvoiceFactory
	{
		public IRpt_ShipmentProFormaInvoice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ShipmentProFormaInvoice = new Reporting.Rpt_ShipmentProFormaInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ShipmentProFormaInvoiceExt = timerfactory.Create<Reporting.IRpt_ShipmentProFormaInvoice>(_Rpt_ShipmentProFormaInvoice);
			
			return iRpt_ShipmentProFormaInvoiceExt;
		}
	}
}
