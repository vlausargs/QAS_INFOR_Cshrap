//PROJECT NAME: Logistics
//CLASS NAME: VerifyAppmtChecksToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VerifyAppmtChecksToPrintPostFactory
	{
		public IVerifyAppmtChecksToPrintPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _VerifyAppmtChecksToPrintPost = new Logistics.Vendor.VerifyAppmtChecksToPrintPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVerifyAppmtChecksToPrintPostExt = timerfactory.Create<Logistics.Vendor.IVerifyAppmtChecksToPrintPost>(_VerifyAppmtChecksToPrintPost);
			
			return iVerifyAppmtChecksToPrintPostExt;
		}
	}
}
