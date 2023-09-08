//PROJECT NAME: Logistics
//CLASS NAME: PoNumValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoNumValidFactory
	{
		public IPoNumValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoNumValid = new Logistics.Vendor.PoNumValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoNumValidExt = timerfactory.Create<Logistics.Vendor.IPoNumValid>(_PoNumValid);
			
			return iPoNumValidExt;
		}
	}
}
