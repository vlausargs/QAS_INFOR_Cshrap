//PROJECT NAME: Production
//CLASS NAME: BomChgFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class BomChgFactory
	{
		public IBomChg Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _BomChg = new Production.BomChg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBomChgExt = timerfactory.Create<Production.IBomChg>(_BomChg);
			
			return iBomChgExt;
		}
	}
}
