//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetRuleValues2Factory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetRuleValues2Factory
	{
		public ICLM_ApsGetRuleValues2 Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetRuleValues2 = new Production.APS.CLM_ApsGetRuleValues2(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetRuleValues2Ext = timerfactory.Create<Production.APS.ICLM_ApsGetRuleValues2>(_CLM_ApsGetRuleValues2);
			
			return iCLM_ApsGetRuleValues2Ext;
		}
	}
}
