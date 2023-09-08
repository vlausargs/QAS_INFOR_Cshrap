//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSalesContactFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSalesContactFactory
	{
		public ICLM_ESBSalesContact Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSalesContact = new BusInterface.CLM_ESBSalesContact(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSalesContactExt = timerfactory.Create<BusInterface.ICLM_ESBSalesContact>(_CLM_ESBSalesContact);
			
			return iCLM_ESBSalesContactExt;
		}
	}
}
