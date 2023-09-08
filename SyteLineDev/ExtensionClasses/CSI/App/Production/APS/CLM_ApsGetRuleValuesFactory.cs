//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetRuleValuesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetRuleValuesFactory
	{
		public ICLM_ApsGetRuleValues Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetRuleValues = new Production.APS.CLM_ApsGetRuleValues(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetRuleValuesExt = timerfactory.Create<Production.APS.ICLM_ApsGetRuleValues>(_CLM_ApsGetRuleValues);
			
			return iCLM_ApsGetRuleValuesExt;
		}
	}
}
