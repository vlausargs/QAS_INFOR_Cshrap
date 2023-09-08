//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPayableHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPayableHeaderFactory
	{
		public ICLM_ESBPayableHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPayableHeader = new BusInterface.CLM_ESBPayableHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPayableHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBPayableHeader>(_CLM_ESBPayableHeader);
			
			return iCLM_ESBPayableHeaderExt;
		}
	}
}
