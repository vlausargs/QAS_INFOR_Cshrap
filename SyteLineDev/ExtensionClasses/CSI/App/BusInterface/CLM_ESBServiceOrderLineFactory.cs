//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBServiceOrderLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBServiceOrderLineFactory
	{
		public ICLM_ESBServiceOrderLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBServiceOrderLine = new BusInterface.CLM_ESBServiceOrderLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBServiceOrderLineExt = timerfactory.Create<BusInterface.ICLM_ESBServiceOrderLine>(_CLM_ESBServiceOrderLine);
			
			return iCLM_ESBServiceOrderLineExt;
		}
	}
}
