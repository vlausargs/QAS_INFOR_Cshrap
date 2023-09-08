//PROJECT NAME: Logistics
//CLASS NAME: SkipOrderLinesWithAvailableIs0Factory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class SkipOrderLinesWithAvailableIs0Factory
	{
		public ISkipOrderLinesWithAvailableIs0 Create(IApplicationDB appDB)
		{
			var _SkipOrderLinesWithAvailableIs0 = new Logistics.Customer.SkipOrderLinesWithAvailableIs0(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSkipOrderLinesWithAvailableIs0Ext = timerfactory.Create<Logistics.Customer.ISkipOrderLinesWithAvailableIs0>(_SkipOrderLinesWithAvailableIs0);
			
			return iSkipOrderLinesWithAvailableIs0Ext;
		}
	}
}
