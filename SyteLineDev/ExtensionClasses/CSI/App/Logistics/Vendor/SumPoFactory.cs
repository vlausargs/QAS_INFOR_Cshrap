//PROJECT NAME: Logistics
//CLASS NAME: SumPoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class SumPoFactory
	{
		public ISumPo Create(IApplicationDB appDB)
		{
			var _SumPo = new Logistics.Vendor.SumPo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSumPoExt = timerfactory.Create<Logistics.Vendor.ISumPo>(_SumPo);
			
			return iSumPoExt;
		}
	}
}
