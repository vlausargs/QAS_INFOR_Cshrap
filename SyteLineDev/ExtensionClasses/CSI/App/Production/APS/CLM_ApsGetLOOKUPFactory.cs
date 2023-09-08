//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetLOOKUPFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetLOOKUPFactory
	{
		public ICLM_ApsGetLOOKUP Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetLOOKUP = new Production.APS.CLM_ApsGetLOOKUP(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetLOOKUPExt = timerfactory.Create<Production.APS.ICLM_ApsGetLOOKUP>(_CLM_ApsGetLOOKUP);
			
			return iCLM_ApsGetLOOKUPExt;
		}
	}
}
