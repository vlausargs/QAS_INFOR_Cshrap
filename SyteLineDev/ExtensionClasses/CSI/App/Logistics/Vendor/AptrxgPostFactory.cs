//PROJECT NAME: Logistics
//CLASS NAME: AptrxgPostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AptrxgPostFactory
	{
		public IAptrxgPost Create(IApplicationDB appDB)
		{
			var _AptrxgPost = new Logistics.Vendor.AptrxgPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAptrxgPostExt = timerfactory.Create<Logistics.Vendor.IAptrxgPost>(_AptrxgPost);
			
			return iAptrxgPostExt;
		}
	}
}
