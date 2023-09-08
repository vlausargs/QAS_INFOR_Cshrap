//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetOPRULEFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetOPRULEFactory
	{
		public ICLM_ApsGetOPRULE Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetOPRULE = new Production.APS.CLM_ApsGetOPRULE(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetOPRULEExt = timerfactory.Create<Production.APS.ICLM_ApsGetOPRULE>(_CLM_ApsGetOPRULE);
			
			return iCLM_ApsGetOPRULEExt;
		}
	}
}
