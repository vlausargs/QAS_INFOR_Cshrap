//PROJECT NAME: CSIVendor
//CLASS NAME: CheckLcrAmtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckLcrAmtFactory
	{
		public ICheckLcrAmt Create(IApplicationDB appDB)
		{
			var _CheckLcrAmt = new Logistics.Vendor.CheckLcrAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckLcrAmtExt = timerfactory.Create<Logistics.Vendor.ICheckLcrAmt>(_CheckLcrAmt);
			
			return iCheckLcrAmtExt;
		}
	}
}
