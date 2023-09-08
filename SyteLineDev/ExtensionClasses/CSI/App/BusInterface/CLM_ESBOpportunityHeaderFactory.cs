//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBOpportunityHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBOpportunityHeaderFactory
	{
		public ICLM_ESBOpportunityHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBOpportunityHeader = new BusInterface.CLM_ESBOpportunityHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBOpportunityHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBOpportunityHeader>(_CLM_ESBOpportunityHeader);
			
			return iCLM_ESBOpportunityHeaderExt;
		}
	}
}
