//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSSDLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSSDLineFactory
	{
		public ICLM_ESBSSDLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSSDLine = new BusInterface.CLM_ESBSSDLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSSDLineExt = timerfactory.Create<BusInterface.ICLM_ESBSSDLine>(_CLM_ESBSSDLine);
			
			return iCLM_ESBSSDLineExt;
		}
	}
}
