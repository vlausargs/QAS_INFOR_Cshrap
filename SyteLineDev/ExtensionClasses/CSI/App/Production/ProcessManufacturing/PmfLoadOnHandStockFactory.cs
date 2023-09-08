//PROJECT NAME: Production
//CLASS NAME: PmfLoadOnHandStockFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfLoadOnHandStockFactory
	{
		public IPmfLoadOnHandStock Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfLoadOnHandStock = new Production.ProcessManufacturing.PmfLoadOnHandStock(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfLoadOnHandStockExt = timerfactory.Create<Production.ProcessManufacturing.IPmfLoadOnHandStock>(_PmfLoadOnHandStock);
			
			return iPmfLoadOnHandStockExt;
		}
	}
}
