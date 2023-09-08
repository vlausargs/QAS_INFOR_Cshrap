//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXRMAReturnvFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXRMAReturnvFactory
	{
		public ISSSRMXRMAReturnv Create(IApplicationDB appDB)
		{
			var _SSSRMXRMAReturnv = new Logistics.Customer.SSSRMXRMAReturnv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXRMAReturnvExt = timerfactory.Create<Logistics.Customer.ISSSRMXRMAReturnv>(_SSSRMXRMAReturnv);
			
			return iSSSRMXRMAReturnvExt;
		}
	}
}
