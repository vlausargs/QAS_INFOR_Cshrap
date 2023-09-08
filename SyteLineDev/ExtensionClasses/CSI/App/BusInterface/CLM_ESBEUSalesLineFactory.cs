//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBEUSalesLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBEUSalesLineFactory
	{
		public ICLM_ESBEUSalesLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBEUSalesLine = new BusInterface.CLM_ESBEUSalesLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBEUSalesLineExt = timerfactory.Create<BusInterface.ICLM_ESBEUSalesLine>(_CLM_ESBEUSalesLine);
			
			return iCLM_ESBEUSalesLineExt;
		}
	}
}
