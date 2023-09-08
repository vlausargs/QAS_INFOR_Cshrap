//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetJOBSTEPFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetJOBSTEPFactory
	{
		public ICLM_ApsGetJOBSTEP Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetJOBSTEP = new Production.APS.CLM_ApsGetJOBSTEP(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetJOBSTEPExt = timerfactory.Create<Production.APS.ICLM_ApsGetJOBSTEP>(_CLM_ApsGetJOBSTEP);
			
			return iCLM_ApsGetJOBSTEPExt;
		}
	}
}
