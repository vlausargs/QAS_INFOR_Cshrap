//PROJECT NAME: CSIVendor
//CLASS NAME: EftPostCreateTTFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class EftPostCreateTTFactory
	{
		public IEftPostCreateTT Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _EftPostCreateTT = new Logistics.Vendor.EftPostCreateTT(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEftPostCreateTTExt = timerfactory.Create<Logistics.Vendor.IEftPostCreateTT>(_EftPostCreateTT);
			
			return iEftPostCreateTTExt;
		}
	}
}
