//PROJECT NAME: Logistics
//CLASS NAME: VoidAppmtChecksToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VoidAppmtChecksToPrintPostFactory
	{
		public IVoidAppmtChecksToPrintPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VoidAppmtChecksToPrintPost = new Logistics.Vendor.VoidAppmtChecksToPrintPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidAppmtChecksToPrintPostExt = timerfactory.Create<Logistics.Vendor.IVoidAppmtChecksToPrintPost>(_VoidAppmtChecksToPrintPost);
			
			return iVoidAppmtChecksToPrintPostExt;
		}
	}
}
