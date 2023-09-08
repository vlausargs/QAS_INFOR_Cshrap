//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetSHIFTFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSHIFTFactory
	{
		public ICLM_ApsGetSHIFT Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSHIFT = new Production.APS.CLM_ApsGetSHIFT(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSHIFTExt = timerfactory.Create<Production.APS.ICLM_ApsGetSHIFT>(_CLM_ApsGetSHIFT);
			
			return iCLM_ApsGetSHIFTExt;
		}
	}
}
