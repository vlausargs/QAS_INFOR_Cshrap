//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBRequisitionLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBRequisitionLineFactory
	{
		public ICLM_ESBRequisitionLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBRequisitionLine = new BusInterface.CLM_ESBRequisitionLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBRequisitionLineExt = timerfactory.Create<BusInterface.ICLM_ESBRequisitionLine>(_CLM_ESBRequisitionLine);
			
			return iCLM_ESBRequisitionLineExt;
		}
	}
}
