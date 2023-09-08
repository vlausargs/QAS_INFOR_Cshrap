//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBMatltrackSerialJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBMatltrackSerialJobFactory
	{
		public ICLM_ESBMatltrackSerialJob Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBMatltrackSerialJob = new BusInterface.CLM_ESBMatltrackSerialJob(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBMatltrackSerialJobExt = timerfactory.Create<BusInterface.ICLM_ESBMatltrackSerialJob>(_CLM_ESBMatltrackSerialJob);
			
			return iCLM_ESBMatltrackSerialJobExt;
		}
	}
}
