//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetORDERFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetORDERFactory
	{
		public ICLM_ApsGetORDER Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetORDER = new Production.APS.CLM_ApsGetORDER(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetORDERExt = timerfactory.Create<Production.APS.ICLM_ApsGetORDER>(_CLM_ApsGetORDER);
			
			return iCLM_ApsGetORDERExt;
		}
	}
}
