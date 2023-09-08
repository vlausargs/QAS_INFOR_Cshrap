//PROJECT NAME: Logistics
//CLASS NAME: PoPreDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PoPreDeleteFactory
	{
		public IPoPreDelete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PoPreDelete = new Logistics.Vendor.PoPreDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoPreDeleteExt = timerfactory.Create<Logistics.Vendor.IPoPreDelete>(_PoPreDelete);
			
			return iPoPreDeleteExt;
		}
	}
}
