//PROJECT NAME: Material
//CLASS NAME: CyclePostListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CyclePostListFactory
	{
		public ICyclePostList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CyclePostList = new Material.CyclePostList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCyclePostListExt = timerfactory.Create<Material.ICyclePostList>(_CyclePostList);
			
			return iCyclePostListExt;
		}
	}
}
