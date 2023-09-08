//PROJECT NAME: CSIVendor
//CLASS NAME: CheckPoBlnStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckPoBlnStatusFactory
	{
		public ICheckPoBlnStatus Create(IApplicationDB appDB)
		{
			var _CheckPoBlnStatus = new Logistics.Vendor.CheckPoBlnStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPoBlnStatusExt = timerfactory.Create<Logistics.Vendor.ICheckPoBlnStatus>(_CheckPoBlnStatus);
			
			return iCheckPoBlnStatusExt;
		}
	}
}
