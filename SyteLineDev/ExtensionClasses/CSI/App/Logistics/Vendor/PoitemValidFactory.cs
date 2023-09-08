//PROJECT NAME: Logistics
//CLASS NAME: PoitemValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoitemValidFactory
	{
		public IPoitemValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoitemValid = new Logistics.Vendor.PoitemValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoitemValidExt = timerfactory.Create<Logistics.Vendor.IPoitemValid>(_PoitemValid);
			
			return iPoitemValidExt;
		}
	}
}
