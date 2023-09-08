//PROJECT NAME: CSIReport
//CLASS NAME: FloorStkReplenCel06RPFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class FloorStkReplenCel06RPFactory
	{
		public IFloorStkReplenCel06RP Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FloorStkReplenCel06RP = new Reporting.FloorStkReplenCel06RP(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFloorStkReplenCel06RPExt = timerfactory.Create<Reporting.IFloorStkReplenCel06RP>(_FloorStkReplenCel06RP);
			
			return iFloorStkReplenCel06RPExt;
		}
	}
}
