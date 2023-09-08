//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCustomerContactFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCustomerContactFactory
	{
		public ICLM_ESBCustomerContact Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCustomerContact = new BusInterface.CLM_ESBCustomerContact(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCustomerContactExt = timerfactory.Create<BusInterface.ICLM_ESBCustomerContact>(_CLM_ESBCustomerContact);
			
			return iCLM_ESBCustomerContactExt;
		}
	}
}
