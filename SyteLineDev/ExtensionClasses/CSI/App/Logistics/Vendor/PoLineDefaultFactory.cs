//PROJECT NAME: Logistics
//CLASS NAME: PoLineDefaultFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoLineDefaultFactory
	{
		public IPoLineDefault Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoLineDefault = new Logistics.Vendor.PoLineDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoLineDefaultExt = timerfactory.Create<Logistics.Vendor.IPoLineDefault>(_PoLineDefault);
			
			return iPoLineDefaultExt;
		}
	}
}
