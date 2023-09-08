//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQGetVendorPriceFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQGetVendorPriceFactory
	{
		public ISSSRFQGetVendorPrice Create(IApplicationDB appDB)
		{
			var _SSSRFQGetVendorPrice = new RFQ.SSSRFQGetVendorPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQGetVendorPriceExt = timerfactory.Create<RFQ.ISSSRFQGetVendorPrice>(_SSSRFQGetVendorPrice);
			
			return iSSSRFQGetVendorPriceExt;
		}
	}
}
