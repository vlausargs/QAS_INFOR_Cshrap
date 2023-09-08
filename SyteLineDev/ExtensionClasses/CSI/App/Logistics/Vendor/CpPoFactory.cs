//PROJECT NAME: CSIVendor
//CLASS NAME: CpPoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CpPoFactory
	{
		public ICpPo Create(IApplicationDB appDB)
		{
			var _CpPo = new Logistics.Vendor.CpPo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCpPoExt = timerfactory.Create<Logistics.Vendor.ICpPo>(_CpPo);
			
			return iCpPoExt;
		}
	}
}
