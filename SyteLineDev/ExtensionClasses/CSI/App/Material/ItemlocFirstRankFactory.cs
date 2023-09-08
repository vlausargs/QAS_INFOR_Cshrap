//PROJECT NAME: Material
//CLASS NAME: ItemlocFirstRankFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItemlocFirstRankFactory
	{
		public IItemlocFirstRank Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItemlocFirstRank = new Material.ItemlocFirstRank(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItemlocFirstRankExt = timerfactory.Create<Material.IItemlocFirstRank>(_ItemlocFirstRank);
			
			return iItemlocFirstRankExt;
		}
	}
}
