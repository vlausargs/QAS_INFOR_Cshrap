//PROJECT NAME: Logistics
//CLASS NAME: MessageToAppmtToPrintPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class MessageToAppmtToPrintPostFactory
	{
		public IMessageToAppmtToPrintPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MessageToAppmtToPrintPost = new Logistics.Vendor.MessageToAppmtToPrintPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMessageToAppmtToPrintPostExt = timerfactory.Create<Logistics.Vendor.IMessageToAppmtToPrintPost>(_MessageToAppmtToPrintPost);
			
			return iMessageToAppmtToPrintPostExt;
		}
	}
}
