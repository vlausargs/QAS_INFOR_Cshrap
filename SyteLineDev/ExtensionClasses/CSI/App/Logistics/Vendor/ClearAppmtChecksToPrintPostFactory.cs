//PROJECT NAME: Logistics
//CLASS NAME: ClearAppmtChecksToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ClearAppmtChecksToPrintPostFactory
	{
		public IClearAppmtChecksToPrintPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ClearAppmtChecksToPrintPost = new Logistics.Vendor.ClearAppmtChecksToPrintPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iClearAppmtChecksToPrintPostExt = timerfactory.Create<Logistics.Vendor.IClearAppmtChecksToPrintPost>(_ClearAppmtChecksToPrintPost);
			
			return iClearAppmtChecksToPrintPostExt;
		}
	}
}
