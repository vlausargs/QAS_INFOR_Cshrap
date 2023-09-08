//PROJECT NAME: Codes
//CLASS NAME: CLM_GetSiteSelectionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Codes
{
	public class CLM_GetSiteSelectionFactory
	{
		public ICLM_GetSiteSelection Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetSiteSelection = new Codes.CLM_GetSiteSelection(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetSiteSelectionExt = timerfactory.Create<Codes.ICLM_GetSiteSelection>(_CLM_GetSiteSelection);
			
			return iCLM_GetSiteSelectionExt;
		}
	}
}
