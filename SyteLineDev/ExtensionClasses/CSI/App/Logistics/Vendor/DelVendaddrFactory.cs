//PROJECT NAME: Logistics
//CLASS NAME: DelVendaddrFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DelVendaddrFactory
	{
		public IDelVendaddr Create(IApplicationDB appDB)
		{
			var _DelVendaddr = new Logistics.Vendor.DelVendaddr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelVendaddrExt = timerfactory.Create<Logistics.Vendor.IDelVendaddr>(_DelVendaddr);
			
			return iDelVendaddrExt;
		}
	}
}
