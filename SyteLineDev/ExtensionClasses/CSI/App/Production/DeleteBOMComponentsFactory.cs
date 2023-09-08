//PROJECT NAME: CSIProduct
//CLASS NAME: DeleteBOMComponentsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class DeleteBOMComponentsFactory
	{
		public IDeleteBOMComponents Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _DeleteBOMComponents = new Production.DeleteBOMComponents(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteBOMComponentsExt = timerfactory.Create<Production.IDeleteBOMComponents>(_DeleteBOMComponents);
			
			return iDeleteBOMComponentsExt;
		}
	}
}
