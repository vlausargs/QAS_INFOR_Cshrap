//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInventoryCountLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInventoryCountLineFactory
	{
		public ICLM_ESBInventoryCountLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInventoryCountLine = new BusInterface.CLM_ESBInventoryCountLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInventoryCountLineExt = timerfactory.Create<BusInterface.ICLM_ESBInventoryCountLine>(_CLM_ESBInventoryCountLine);
			
			return iCLM_ESBInventoryCountLineExt;
		}
	}
}
