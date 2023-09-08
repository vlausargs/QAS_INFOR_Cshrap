//PROJECT NAME: Logistics
//CLASS NAME: Ap01FRIFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Ap01FRIFactory
	{
		public IAp01FRI Create(IApplicationDB appDB)
		{
			var _Ap01FRI = new Logistics.Vendor.Ap01FRI(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAp01FRIExt = timerfactory.Create<Logistics.Vendor.IAp01FRI>(_Ap01FRI);
			
			return iAp01FRIExt;
		}
	}
}
