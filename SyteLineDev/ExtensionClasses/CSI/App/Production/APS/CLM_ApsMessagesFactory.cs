//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsMessagesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsMessagesFactory
	{
		public ICLM_ApsMessages Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsMessages = new Production.APS.CLM_ApsMessages(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsMessagesExt = timerfactory.Create<Production.APS.ICLM_ApsMessages>(_CLM_ApsMessages);
			
			return iCLM_ApsMessagesExt;
		}
	}
}
