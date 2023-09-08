//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBMatltrackSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBMatltrackSerialFactory
	{
		public ICLM_ESBMatltrackSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBMatltrackSerial = new BusInterface.CLM_ESBMatltrackSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBMatltrackSerialExt = timerfactory.Create<BusInterface.ICLM_ESBMatltrackSerial>(_CLM_ESBMatltrackSerial);
			
			return iCLM_ESBMatltrackSerialExt;
		}
	}
}
