//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetCONSPLANFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetCONSPLANFactory
	{
		public ICLM_ApsGetCONSPLAN Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetCONSPLAN = new Production.APS.CLM_ApsGetCONSPLAN(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetCONSPLANExt = timerfactory.Create<Production.APS.ICLM_ApsGetCONSPLAN>(_CLM_ApsGetCONSPLAN);
			
			return iCLM_ApsGetCONSPLANExt;
		}
	}
}
