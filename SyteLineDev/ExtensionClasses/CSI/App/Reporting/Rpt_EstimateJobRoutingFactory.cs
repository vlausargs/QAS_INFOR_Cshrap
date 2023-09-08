//PROJECT NAME: Reporting
//CLASS NAME: Rpt_EstimateJobRoutingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_EstimateJobRoutingFactory
	{
		public IRpt_EstimateJobRouting Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EstimateJobRouting = new Reporting.Rpt_EstimateJobRouting(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EstimateJobRoutingExt = timerfactory.Create<Reporting.IRpt_EstimateJobRouting>(_Rpt_EstimateJobRouting);
			
			return iRpt_EstimateJobRoutingExt;
		}
	}
}
