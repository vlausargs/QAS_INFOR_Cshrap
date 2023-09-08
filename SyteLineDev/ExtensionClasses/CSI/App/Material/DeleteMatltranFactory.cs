//PROJECT NAME: CSIMaterial
//CLASS NAME: DeleteMatltranFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class DeleteMatltranFactory
	{
		public IDeleteMatltran Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DeleteMatltran = new Material.DeleteMatltran(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteMatltranExt = timerfactory.Create<Material.IDeleteMatltran>(_DeleteMatltran);
			
			return iDeleteMatltranExt;
		}
	}
}
