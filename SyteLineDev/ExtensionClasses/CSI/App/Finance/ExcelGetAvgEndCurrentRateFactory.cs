//PROJECT NAME: Finance
//CLASS NAME: ExcelGetAvgEndCurrentRateFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ExcelGetAvgEndCurrentRateFactory
	{
		public IExcelGetAvgEndCurrentRate Create(IApplicationDB appDB)
		{
			var _ExcelGetAvgEndCurrentRate = new Finance.ExcelGetAvgEndCurrentRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExcelGetAvgEndCurrentRateExt = timerfactory.Create<Finance.IExcelGetAvgEndCurrentRate>(_ExcelGetAvgEndCurrentRate);
			
			return iExcelGetAvgEndCurrentRateExt;
		}
	}
}
