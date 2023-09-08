//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetWhseFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetWhseFactory
	{
		public ICLM_ApsGetWhse Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetWhse = new Production.APS.CLM_ApsGetWhse(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetWhseExt = timerfactory.Create<Production.APS.ICLM_ApsGetWhse>(_CLM_ApsGetWhse);
			
			return iCLM_ApsGetWhseExt;
		}
	}
}
