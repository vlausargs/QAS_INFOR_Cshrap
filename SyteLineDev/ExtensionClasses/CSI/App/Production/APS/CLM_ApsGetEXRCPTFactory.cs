//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetEXRCPTFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetEXRCPTFactory
	{
		public ICLM_ApsGetEXRCPT Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetEXRCPT = new Production.APS.CLM_ApsGetEXRCPT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetEXRCPTExt = timerfactory.Create<Production.APS.ICLM_ApsGetEXRCPT>(_CLM_ApsGetEXRCPT);
			
			return iCLM_ApsGetEXRCPTExt;
		}
	}
}
