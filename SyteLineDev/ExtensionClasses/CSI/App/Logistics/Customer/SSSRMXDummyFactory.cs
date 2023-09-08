//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXDummyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SSSRMXDummyFactory
	{
		public ISSSRMXDummy Create(IApplicationDB appDB)
		{
			var _SSSRMXDummy = new Logistics.Customer.SSSRMXDummy(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXDummyExt = timerfactory.Create<Logistics.Customer.ISSSRMXDummy>(_SSSRMXDummy);
			
			return iSSSRMXDummyExt;
		}
	}
}
