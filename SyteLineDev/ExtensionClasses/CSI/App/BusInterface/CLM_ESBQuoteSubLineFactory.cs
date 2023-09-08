//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBQuoteSubLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBQuoteSubLineFactory
	{
		public ICLM_ESBQuoteSubLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBQuoteSubLine = new BusInterface.CLM_ESBQuoteSubLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBQuoteSubLineExt = timerfactory.Create<BusInterface.ICLM_ESBQuoteSubLine>(_CLM_ESBQuoteSubLine);
			
			return iCLM_ESBQuoteSubLineExt;
		}
	}
}
