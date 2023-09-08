//PROJECT NAME: Logistics
//CLASS NAME: PoAckPostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoAckPostFactory
	{
		public IPoAckPost Create(IApplicationDB appDB)
		{
			var _PoAckPost = new Logistics.Vendor.PoAckPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoAckPostExt = timerfactory.Create<Logistics.Vendor.IPoAckPost>(_PoAckPost);
			
			return iPoAckPostExt;
		}
	}
}
