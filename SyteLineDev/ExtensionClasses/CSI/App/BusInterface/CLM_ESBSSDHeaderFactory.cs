//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSSDHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSSDHeaderFactory
	{
		public ICLM_ESBSSDHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSSDHeader = new BusInterface.CLM_ESBSSDHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSSDHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBSSDHeader>(_CLM_ESBSSDHeader);
			
			return iCLM_ESBSSDHeaderExt;
		}
	}
}
