//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBDistributedChargesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBDistributedChargesFactory
	{
		public ICLM_ESBDistributedCharges Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBDistributedCharges = new BusInterface.CLM_ESBDistributedCharges(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBDistributedChargesExt = timerfactory.Create<BusInterface.ICLM_ESBDistributedCharges>(_CLM_ESBDistributedCharges);
			
			return iCLM_ESBDistributedChargesExt;
		}
	}
}
