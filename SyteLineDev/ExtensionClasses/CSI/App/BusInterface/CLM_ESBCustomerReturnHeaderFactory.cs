//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCustomerReturnHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCustomerReturnHeaderFactory
	{
		public ICLM_ESBCustomerReturnHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCustomerReturnHeader = new BusInterface.CLM_ESBCustomerReturnHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCustomerReturnHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBCustomerReturnHeader>(_CLM_ESBCustomerReturnHeader);
			
			return iCLM_ESBCustomerReturnHeaderExt;
		}
	}
}
