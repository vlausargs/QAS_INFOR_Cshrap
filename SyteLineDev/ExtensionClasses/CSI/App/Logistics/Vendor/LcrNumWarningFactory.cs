//PROJECT NAME: CSIVendor
//CLASS NAME: LcrNumWarningFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class LcrNumWarningFactory
	{
		public ILcrNumWarning Create(IApplicationDB appDB)
		{
			var _LcrNumWarning = new Logistics.Vendor.LcrNumWarning(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLcrNumWarningExt = timerfactory.Create<Logistics.Vendor.ILcrNumWarning>(_LcrNumWarning);
			
			return iLcrNumWarningExt;
		}
	}
}
