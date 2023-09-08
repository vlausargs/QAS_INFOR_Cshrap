//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetRESRCFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetRESRCFactory
	{
		public ICLM_ApsGetRESRC Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetRESRC = new Production.APS.CLM_ApsGetRESRC(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetRESRCExt = timerfactory.Create<Production.APS.ICLM_ApsGetRESRC>(_CLM_ApsGetRESRC);
			
			return iCLM_ApsGetRESRCExt;
		}
	}
}
