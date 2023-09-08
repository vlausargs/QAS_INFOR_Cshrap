//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetBATCHFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetBATCHFactory
	{
		public ICLM_ApsGetBATCH Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetBATCH = new Production.APS.CLM_ApsGetBATCH(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetBATCHExt = timerfactory.Create<Production.APS.ICLM_ApsGetBATCH>(_CLM_ApsGetBATCH);
			
			return iCLM_ApsGetBATCHExt;
		}
	}
}
