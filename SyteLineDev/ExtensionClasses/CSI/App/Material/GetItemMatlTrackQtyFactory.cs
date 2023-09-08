//PROJECT NAME: Material
//CLASS NAME: GetItemMatlTrackQtyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetItemMatlTrackQtyFactory
	{
		public IGetItemMatlTrackQty Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemMatlTrackQty = new Material.GetItemMatlTrackQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemMatlTrackQtyExt = timerfactory.Create<Material.IGetItemMatlTrackQty>(_GetItemMatlTrackQty);
			
			return iGetItemMatlTrackQtyExt;
		}
	}
}
