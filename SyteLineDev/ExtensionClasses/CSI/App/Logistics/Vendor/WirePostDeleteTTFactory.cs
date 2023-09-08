//PROJECT NAME: Logistics
//CLASS NAME: WirePostDeleteTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class WirePostDeleteTTFactory
	{
		public IWirePostDeleteTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _WirePostDeleteTT = new Logistics.Vendor.WirePostDeleteTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iWirePostDeleteTTExt = timerfactory.Create<Logistics.Vendor.IWirePostDeleteTT>(_WirePostDeleteTT);
			
			return iWirePostDeleteTTExt;
		}
	}
}
