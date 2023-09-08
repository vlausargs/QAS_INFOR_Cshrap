//PROJECT NAME: CSIVendor
//CLASS NAME: EurVendFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class EurVendFactory
	{
		public IEurVend Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _EurVend = new Logistics.Vendor.EurVend(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEurVendExt = timerfactory.Create<Logistics.Vendor.IEurVend>(_EurVend);
			
			return iEurVendExt;
		}
	}
}
