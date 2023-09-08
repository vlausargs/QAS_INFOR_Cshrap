//PROJECT NAME: CSIMaterial
//CLASS NAME: CyclePostFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CyclePostFactory
	{
		public ICyclePost Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CyclePost = new Material.CyclePost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCyclePostExt = timerfactory.Create<Material.ICyclePost>(_CyclePost);
			
			return iCyclePostExt;
		}
	}
}
