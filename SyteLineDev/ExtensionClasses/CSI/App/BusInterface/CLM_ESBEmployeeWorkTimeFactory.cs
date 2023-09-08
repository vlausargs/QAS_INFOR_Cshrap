//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBEmployeeWorkTimeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBEmployeeWorkTimeFactory
	{
		public ICLM_ESBEmployeeWorkTime Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBEmployeeWorkTime = new BusInterface.CLM_ESBEmployeeWorkTime(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBEmployeeWorkTimeExt = timerfactory.Create<BusInterface.ICLM_ESBEmployeeWorkTime>(_CLM_ESBEmployeeWorkTime);
			
			return iCLM_ESBEmployeeWorkTimeExt;
		}
	}
}
