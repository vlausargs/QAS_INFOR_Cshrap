//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBContractFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBContractFactory
	{
		public ICLM_ESBContract Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBContract = new BusInterface.CLM_ESBContract(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBContractExt = timerfactory.Create<BusInterface.ICLM_ESBContract>(_CLM_ESBContract);
			
			return iCLM_ESBContractExt;
		}
	}
}
