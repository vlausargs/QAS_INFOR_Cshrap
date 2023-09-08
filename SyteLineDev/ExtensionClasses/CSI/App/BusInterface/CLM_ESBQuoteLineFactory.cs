//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBQuoteLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBQuoteLineFactory
	{
		public ICLM_ESBQuoteLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBQuoteLine = new BusInterface.CLM_ESBQuoteLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBQuoteLineExt = timerfactory.Create<BusInterface.ICLM_ESBQuoteLine>(_CLM_ESBQuoteLine);
			
			return iCLM_ESBQuoteLineExt;
		}
	}
}
