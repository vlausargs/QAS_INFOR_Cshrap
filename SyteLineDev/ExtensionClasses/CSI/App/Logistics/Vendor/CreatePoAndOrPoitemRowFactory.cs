//PROJECT NAME: CSIVendor
//CLASS NAME: CreatePoAndOrPoitemRowFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreatePoAndOrPoitemRowFactory
	{
		public ICreatePoAndOrPoitemRow Create(IApplicationDB appDB)
		{
			var _CreatePoAndOrPoitemRow = new Logistics.Vendor.CreatePoAndOrPoitemRow(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePoAndOrPoitemRowExt = timerfactory.Create<Logistics.Vendor.ICreatePoAndOrPoitemRow>(_CreatePoAndOrPoitemRow);
			
			return iCreatePoAndOrPoitemRowExt;
		}
	}
}
