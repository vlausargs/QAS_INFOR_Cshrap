//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetRGBottlenecksFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetRGBottlenecksFactory
	{
		public ICLM_ApsGetRGBottlenecks Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetRGBottlenecks = new Production.APS.CLM_ApsGetRGBottlenecks(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetRGBottlenecksExt = timerfactory.Create<Production.APS.ICLM_ApsGetRGBottlenecks>(_CLM_ApsGetRGBottlenecks);
			
			return iCLM_ApsGetRGBottlenecksExt;
		}
	}
}
