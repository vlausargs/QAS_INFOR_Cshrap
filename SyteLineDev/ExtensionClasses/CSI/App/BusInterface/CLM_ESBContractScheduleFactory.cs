//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBContractScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBContractScheduleFactory
	{
		public ICLM_ESBContractSchedule Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBContractSchedule = new BusInterface.CLM_ESBContractSchedule(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBContractScheduleExt = timerfactory.Create<BusInterface.ICLM_ESBContractSchedule>(_CLM_ESBContractSchedule);
			
			return iCLM_ESBContractScheduleExt;
		}
	}
}
