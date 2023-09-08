//PROJECT NAME: Logistics
//CLASS NAME: PoitemInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoitemInfoFactory
	{
		public IPoitemInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoitemInfo = new Logistics.Vendor.PoitemInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoitemInfoExt = timerfactory.Create<Logistics.Vendor.IPoitemInfo>(_PoitemInfo);
			
			return iPoitemInfoExt;
		}
	}
}
