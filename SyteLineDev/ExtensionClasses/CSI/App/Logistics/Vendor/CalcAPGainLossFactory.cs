//PROJECT NAME: CSIVendor
//CLASS NAME: CalcAPGainLossFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CalcAPGainLossFactory
	{
		public ICalcAPGainLoss Create(IApplicationDB appDB)
		{
			var _CalcAPGainLoss = new Vendor.CalcAPGainLoss(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcAPGainLossExt = timerfactory.Create<Vendor.ICalcAPGainLoss>(_CalcAPGainLoss);
			
			return iCalcAPGainLossExt;
		}
	}
}
