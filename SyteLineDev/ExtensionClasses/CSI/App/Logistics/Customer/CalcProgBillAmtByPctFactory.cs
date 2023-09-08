//PROJECT NAME: Logistics
//CLASS NAME: CalcProgBillAmtByPctFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CalcProgBillAmtByPctFactory
	{
		public ICalcProgBillAmtByPct Create(IApplicationDB appDB)
		{
			var _CalcProgBillAmtByPct = new Logistics.Customer.CalcProgBillAmtByPct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcProgBillAmtByPctExt = timerfactory.Create<Logistics.Customer.ICalcProgBillAmtByPct>(_CalcProgBillAmtByPct);
			
			return iCalcProgBillAmtByPctExt;
		}
	}
}
