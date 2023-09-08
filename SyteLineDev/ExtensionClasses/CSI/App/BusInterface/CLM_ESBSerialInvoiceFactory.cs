//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSerialInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSerialInvoiceFactory
	{
		public ICLM_ESBSerialInvoice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSerialInvoice = new BusInterface.CLM_ESBSerialInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSerialInvoiceExt = timerfactory.Create<BusInterface.ICLM_ESBSerialInvoice>(_CLM_ESBSerialInvoice);
			
			return iCLM_ESBSerialInvoiceExt;
		}
	}
}
