//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBRequisitionHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBRequisitionHeaderFactory
	{
		public ICLM_ESBRequisitionHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBRequisitionHeader = new BusInterface.CLM_ESBRequisitionHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBRequisitionHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBRequisitionHeader>(_CLM_ESBRequisitionHeader);
			
			return iCLM_ESBRequisitionHeaderExt;
		}
	}
}
