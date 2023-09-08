//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AvailableToShipFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_AvailableToShipFactory
	{
		public IRpt_AvailableToShip Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_AvailableToShip = new Reporting.Rpt_AvailableToShip(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AvailableToShipExt = timerfactory.Create<Reporting.IRpt_AvailableToShip>(_Rpt_AvailableToShip);
			
			return iRpt_AvailableToShipExt;
		}
	}
}
