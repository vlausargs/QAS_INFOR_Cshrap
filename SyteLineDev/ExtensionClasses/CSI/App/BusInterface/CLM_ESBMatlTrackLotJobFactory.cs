//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBMatlTrackLotJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBMatlTrackLotJobFactory
	{
		public ICLM_ESBMatlTrackLotJob Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBMatlTrackLotJob = new BusInterface.CLM_ESBMatlTrackLotJob(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBMatlTrackLotJobExt = timerfactory.Create<BusInterface.ICLM_ESBMatlTrackLotJob>(_CLM_ESBMatlTrackLotJob);
			
			return iCLM_ESBMatlTrackLotJobExt;
		}
	}
}
