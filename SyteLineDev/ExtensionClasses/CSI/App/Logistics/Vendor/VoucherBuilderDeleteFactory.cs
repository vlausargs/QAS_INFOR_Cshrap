//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderDeleteFactory
	{
		public IVoucherBuilderDelete Create(IApplicationDB appDB)
		{
			var _VoucherBuilderDelete = new Logistics.Vendor.VoucherBuilderDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoucherBuilderDeleteExt = timerfactory.Create<Logistics.Vendor.IVoucherBuilderDelete>(_VoucherBuilderDelete);
			
			return iVoucherBuilderDeleteExt;
		}
	}
}
