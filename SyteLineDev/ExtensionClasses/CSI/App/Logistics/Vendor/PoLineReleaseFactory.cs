//PROJECT NAME: Logistics
//CLASS NAME: PoLineReleaseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoLineReleaseFactory
	{
		public IPoLineRelease Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoLineRelease = new Logistics.Vendor.PoLineRelease(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoLineReleaseExt = timerfactory.Create<Logistics.Vendor.IPoLineRelease>(_PoLineRelease);
			
			return iPoLineReleaseExt;
		}
	}
}
