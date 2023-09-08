//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCustomerReturnLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCustomerReturnLineFactory
	{
		public ICLM_ESBCustomerReturnLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCustomerReturnLine = new BusInterface.CLM_ESBCustomerReturnLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCustomerReturnLineExt = timerfactory.Create<BusInterface.ICLM_ESBCustomerReturnLine>(_CLM_ESBCustomerReturnLine);
			
			return iCLM_ESBCustomerReturnLineExt;
		}
	}
}
