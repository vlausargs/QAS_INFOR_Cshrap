//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_GetPROCPLNnnnsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_GetPROCPLNnnnsFactory
	{
		public ICLM_GetPROCPLNnnns Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetPROCPLNnnns = new Production.APS.CLM_GetPROCPLNnnns(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetPROCPLNnnnsExt = timerfactory.Create<Production.APS.ICLM_GetPROCPLNnnns>(_CLM_GetPROCPLNnnns);
			
			return iCLM_GetPROCPLNnnnsExt;
		}
	}
}
