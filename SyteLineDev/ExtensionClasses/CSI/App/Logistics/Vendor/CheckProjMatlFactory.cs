//PROJECT NAME: CSIVendor
//CLASS NAME: CheckProjMatlFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckProjMatlFactory
	{
		public ICheckProjMatl Create(IApplicationDB appDB)
		{
			var _CheckProjMatl = new Logistics.Vendor.CheckProjMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckProjMatlExt = timerfactory.Create<Logistics.Vendor.ICheckProjMatl>(_CheckProjMatl);
			
			return iCheckProjMatlExt;
		}
	}
}
