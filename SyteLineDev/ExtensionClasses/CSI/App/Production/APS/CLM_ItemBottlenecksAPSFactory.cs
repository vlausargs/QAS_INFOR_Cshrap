//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ItemBottlenecksAPSFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ItemBottlenecksAPSFactory
	{
		public ICLM_ItemBottlenecksAPS Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ItemBottlenecksAPS = new Production.APS.CLM_ItemBottlenecksAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ItemBottlenecksAPSExt = timerfactory.Create<Production.APS.ICLM_ItemBottlenecksAPS>(_CLM_ItemBottlenecksAPS);
			
			return iCLM_ItemBottlenecksAPSExt;
		}
	}
}
