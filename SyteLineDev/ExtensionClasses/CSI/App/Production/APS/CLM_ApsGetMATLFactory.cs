//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetMATLFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetMATLFactory
	{
		public ICLM_ApsGetMATL Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetMATL = new Production.APS.CLM_ApsGetMATL(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetMATLExt = timerfactory.Create<Production.APS.ICLM_ApsGetMATL>(_CLM_ApsGetMATL);
			
			return iCLM_ApsGetMATLExt;
		}
	}
}
