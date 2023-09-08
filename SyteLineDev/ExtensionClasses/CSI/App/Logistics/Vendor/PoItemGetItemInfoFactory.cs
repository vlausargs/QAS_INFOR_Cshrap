//PROJECT NAME: Logistics
//CLASS NAME: PoItemGetItemInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoItemGetItemInfoFactory
	{
		public IPoItemGetItemInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoItemGetItemInfo = new Logistics.Vendor.PoItemGetItemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoItemGetItemInfoExt = timerfactory.Create<Logistics.Vendor.IPoItemGetItemInfo>(_PoItemGetItemInfo);
			
			return iPoItemGetItemInfoExt;
		}
	}
}
