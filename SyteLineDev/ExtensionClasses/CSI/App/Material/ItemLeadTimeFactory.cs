//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemLeadTimeFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class ItemLeadTimeFactory
	{
		public IItemLeadTime Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ItemLeadTime = new Material.ItemLeadTime(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemLeadTimeExt = timerfactory.Create<Material.IItemLeadTime>(_ItemLeadTime);
			
			return iItemLeadTimeExt;
		}
	}
}
