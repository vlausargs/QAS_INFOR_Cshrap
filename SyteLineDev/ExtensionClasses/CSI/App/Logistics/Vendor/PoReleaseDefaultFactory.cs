//PROJECT NAME: Logistics
//CLASS NAME: PoReleaseDefaultFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoReleaseDefaultFactory
	{
		public IPoReleaseDefault Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoReleaseDefault = new Logistics.Vendor.PoReleaseDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoReleaseDefaultExt = timerfactory.Create<Logistics.Vendor.IPoReleaseDefault>(_PoReleaseDefault);
			
			return iPoReleaseDefaultExt;
		}
	}
}
