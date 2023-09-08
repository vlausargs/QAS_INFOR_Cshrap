//PROJECT NAME: Material
//CLASS NAME: ItempricePostQueryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class ItempricePostQueryFactory
	{
		public IItempricePostQuery Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ItempricePostQuery = new Material.ItempricePostQuery(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iItempricePostQueryExt = timerfactory.Create<Material.IItempricePostQuery>(_ItempricePostQuery);
			
			return iItempricePostQueryExt;
		}
	}
}
