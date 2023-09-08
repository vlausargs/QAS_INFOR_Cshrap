//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSupplierInvoiceLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSupplierInvoiceLineFactory
	{
		public ICLM_ESBSupplierInvoiceLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSupplierInvoiceLine = new BusInterface.CLM_ESBSupplierInvoiceLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSupplierInvoiceLineExt = timerfactory.Create<BusInterface.ICLM_ESBSupplierInvoiceLine>(_CLM_ESBSupplierInvoiceLine);
			
			return iCLM_ESBSupplierInvoiceLineExt;
		}
	}
}
