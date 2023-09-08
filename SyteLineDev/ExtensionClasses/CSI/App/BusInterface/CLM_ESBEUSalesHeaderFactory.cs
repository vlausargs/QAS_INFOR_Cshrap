//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBEUSalesHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBEUSalesHeaderFactory
	{
		public ICLM_ESBEUSalesHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBEUSalesHeader = new BusInterface.CLM_ESBEUSalesHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBEUSalesHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBEUSalesHeader>(_CLM_ESBEUSalesHeader);
			
			return iCLM_ESBEUSalesHeaderExt;
		}
	}
}
