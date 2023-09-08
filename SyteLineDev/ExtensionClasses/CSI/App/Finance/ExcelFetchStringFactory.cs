//PROJECT NAME: Finance
//CLASS NAME: ExcelFetchStringFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ExcelFetchStringFactory
	{
		public IExcelFetchString Create(IApplicationDB appDB)
		{
			var _ExcelFetchString = new Finance.ExcelFetchString(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExcelFetchStringExt = timerfactory.Create<Finance.IExcelFetchString>(_ExcelFetchString);
			
			return iExcelFetchStringExt;
		}
	}
}
