//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetMATLDELVFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetMATLDELVFactory
	{
		public ICLM_ApsGetMATLDELV Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetMATLDELV = new Production.APS.CLM_ApsGetMATLDELV(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetMATLDELVExt = timerfactory.Create<Production.APS.ICLM_ApsGetMATLDELV>(_CLM_ApsGetMATLDELV);
			
			return iCLM_ApsGetMATLDELVExt;
		}
	}
}
