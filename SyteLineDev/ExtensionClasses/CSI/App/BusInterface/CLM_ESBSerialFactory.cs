//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSerialFactory
	{
		public ICLM_ESBSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSerial = new BusInterface.CLM_ESBSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSerialExt = timerfactory.Create<BusInterface.ICLM_ESBSerial>(_CLM_ESBSerial);
			
			return iCLM_ESBSerialExt;
		}
	}
}
