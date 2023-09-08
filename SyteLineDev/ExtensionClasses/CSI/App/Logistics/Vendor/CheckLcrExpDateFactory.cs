//PROJECT NAME: CSIVendor
//CLASS NAME: CheckLcrExpDateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckLcrExpDateFactory
	{
		public ICheckLcrExpDate Create(IApplicationDB appDB)
		{
			var _CheckLcrExpDate = new Logistics.Vendor.CheckLcrExpDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckLcrExpDateExt = timerfactory.Create<Logistics.Vendor.ICheckLcrExpDate>(_CheckLcrExpDate);
			
			return iCheckLcrExpDateExt;
		}
	}
}
