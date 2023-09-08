//PROJECT NAME: CSIVendor
//CLASS NAME: CheckPOBuilderViewsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckPOBuilderViewsFactory
	{
		public ICheckPOBuilderViews Create(IApplicationDB appDB)
		{
			var _CheckPOBuilderViews = new Logistics.Vendor.CheckPOBuilderViews(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckPOBuilderViewsExt = timerfactory.Create<Logistics.Vendor.ICheckPOBuilderViews>(_CheckPOBuilderViews);
			
			return iCheckPOBuilderViewsExt;
		}
	}
}
