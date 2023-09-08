//PROJECT NAME: CSIVendor
//CLASS NAME: GetAccountsPayableParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAccountsPayableParmsFactory
	{
		public IGetAccountsPayableParms Create(IApplicationDB appDB)
		{
			var _GetAccountsPayableParms = new Logistics.Vendor.GetAccountsPayableParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAccountsPayableParmsExt = timerfactory.Create<Logistics.Vendor.IGetAccountsPayableParms>(_GetAccountsPayableParms);
			
			return iGetAccountsPayableParmsExt;
		}
	}
}
