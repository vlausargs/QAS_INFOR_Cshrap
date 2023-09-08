//PROJECT NAME: Logistics
//CLASS NAME: PoReceivePopulateTtRcvFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoReceivePopulateTtRcvFactory
	{
		public IPoReceivePopulateTtRcv Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoReceivePopulateTtRcv = new Logistics.Vendor.PoReceivePopulateTtRcv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoReceivePopulateTtRcvExt = timerfactory.Create<Logistics.Vendor.IPoReceivePopulateTtRcv>(_PoReceivePopulateTtRcv);
			
			return iPoReceivePopulateTtRcvExt;
		}
	}
}
