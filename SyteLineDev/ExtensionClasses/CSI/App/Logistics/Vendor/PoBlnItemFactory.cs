//PROJECT NAME: Logistics
//CLASS NAME: PoBlnItemFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoBlnItemFactory
	{
		public IPoBlnItem Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoBlnItem = new Logistics.Vendor.PoBlnItem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoBlnItemExt = timerfactory.Create<Logistics.Vendor.IPoBlnItem>(_PoBlnItem);
			
			return iPoBlnItemExt;
		}
	}
}
