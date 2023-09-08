//PROJECT NAME: Logistics
//CLASS NAME: VoucherBuilderProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherBuilderProcessFactory
	{
		public IVoucherBuilderProcess Create(IApplicationDB appDB)
		{
			var _VoucherBuilderProcess = new Logistics.Vendor.VoucherBuilderProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoucherBuilderProcessExt = timerfactory.Create<Logistics.Vendor.IVoucherBuilderProcess>(_VoucherBuilderProcess);
			
			return iVoucherBuilderProcessExt;
		}
	}
}
