//PROJECT NAME: CSIVendor
//CLASS NAME: GetMultiLingualPOTextFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetMultiLingualPOTextFactory
	{
		public IGetMultiLingualPOText Create(IApplicationDB appDB)
		{
			var _GetMultiLingualPOText = new Logistics.Vendor.GetMultiLingualPOText(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMultiLingualPOTextExt = timerfactory.Create<Logistics.Vendor.IGetMultiLingualPOText>(_GetMultiLingualPOText);
			
			return iGetMultiLingualPOTextExt;
		}
	}
}
