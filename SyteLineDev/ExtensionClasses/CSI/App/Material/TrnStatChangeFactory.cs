//PROJECT NAME: Material
//CLASS NAME: TrnStatChangeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class TrnStatChangeFactory
	{
		public ITrnStatChange Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TrnStatChange = new Material.TrnStatChange(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnStatChangeExt = timerfactory.Create<Material.ITrnStatChange>(_TrnStatChange);
			
			return iTrnStatChangeExt;
		}
	}
}
