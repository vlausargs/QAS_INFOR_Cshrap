//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBQuoteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBQuoteFactory
	{
		public ICLM_ESBQuote Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBQuote = new BusInterface.CLM_ESBQuote(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBQuoteExt = timerfactory.Create<BusInterface.ICLM_ESBQuote>(_CLM_ESBQuote);
			
			return iCLM_ESBQuoteExt;
		}
	}
}
