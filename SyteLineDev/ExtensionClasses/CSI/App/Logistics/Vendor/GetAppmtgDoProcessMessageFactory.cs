//PROJECT NAME: CSIVendor
//CLASS NAME: GetAppmtgDoProcessMessageFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAppmtgDoProcessMessageFactory
	{
		public IGetAppmtgDoProcessMessage Create(IApplicationDB appDB)
		{
			var _GetAppmtgDoProcessMessage = new Logistics.Vendor.GetAppmtgDoProcessMessage(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAppmtgDoProcessMessageExt = timerfactory.Create<Logistics.Vendor.IGetAppmtgDoProcessMessage>(_GetAppmtgDoProcessMessage);
			
			return iGetAppmtgDoProcessMessageExt;
		}
	}
}
