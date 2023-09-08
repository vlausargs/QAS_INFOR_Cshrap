//PROJECT NAME: Production
//CLASS NAME: CLM_ItemBottlenecksMRPAPSFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ItemBottlenecksMRPAPSFactory
	{
		public ICLM_ItemBottlenecksMRPAPS Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ItemBottlenecksMRPAPS = new Production.APS.CLM_ItemBottlenecksMRPAPS(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ItemBottlenecksMRPAPSExt = timerfactory.Create<Production.APS.ICLM_ItemBottlenecksMRPAPS>(_CLM_ItemBottlenecksMRPAPS);
			
			return iCLM_ItemBottlenecksMRPAPSExt;
		}
	}
}
