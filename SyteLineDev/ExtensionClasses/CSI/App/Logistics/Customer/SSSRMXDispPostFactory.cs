//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDispPostFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDispPostFactory
	{
		public ISSSRMXDispPost Create(IApplicationDB appDB)
		{
			var _SSSRMXDispPost = new Logistics.Customer.SSSRMXDispPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXDispPostExt = timerfactory.Create<Logistics.Customer.ISSSRMXDispPost>(_SSSRMXDispPost);
			
			return iSSSRMXDispPostExt;
		}
	}
}
