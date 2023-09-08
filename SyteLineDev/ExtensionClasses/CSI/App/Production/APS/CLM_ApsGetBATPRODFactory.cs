//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetBATPRODFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetBATPRODFactory
	{
		public ICLM_ApsGetBATPROD Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetBATPROD = new Production.APS.CLM_ApsGetBATPROD(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetBATPRODExt = timerfactory.Create<Production.APS.ICLM_ApsGetBATPROD>(_CLM_ApsGetBATPROD);
			
			return iCLM_ApsGetBATPRODExt;
		}
	}
}
