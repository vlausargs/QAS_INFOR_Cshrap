//PROJECT NAME: CSICustomer
//CLASS NAME: ChgDoBolStatFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ChgDoBolStatFactory
	{
		public IChgDoBolStat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChgDoBolStat = new Logistics.Customer.ChgDoBolStat(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChgDoBolStatExt = timerfactory.Create<Logistics.Customer.IChgDoBolStat>(_ChgDoBolStat);
			
			return iChgDoBolStatExt;
		}
	}
}
