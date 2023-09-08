//PROJECT NAME: CSIVendor
//CLASS NAME: CheckPOLineStatusFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckPOLineStatusFactory
	{
		public ICheckPOLineStatus Create(IApplicationDB appDB)
		{
			var _CheckPOLineStatus = new Logistics.Vendor.CheckPOLineStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPOLineStatusExt = timerfactory.Create<Logistics.Vendor.ICheckPOLineStatus>(_CheckPOLineStatus);
			
			return iCheckPOLineStatusExt;
		}
	}
}
