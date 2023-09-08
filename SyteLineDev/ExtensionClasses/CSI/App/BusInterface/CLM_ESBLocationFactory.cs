//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBLocationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBLocationFactory
	{
		public ICLM_ESBLocation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBLocation = new BusInterface.CLM_ESBLocation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBLocationExt = timerfactory.Create<BusInterface.ICLM_ESBLocation>(_CLM_ESBLocation);
			
			return iCLM_ESBLocationExt;
		}
	}
}
