//PROJECT NAME: Finance
//CLASS NAME: ExcelSyteLineGLBatchSqlFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ExcelSyteLineGLBatchSqlFactory
	{
		public IExcelSyteLineGLBatchSql Create(IApplicationDB appDB)
		{
			var _ExcelSyteLineGLBatchSql = new Finance.ExcelSyteLineGLBatchSql(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExcelSyteLineGLBatchSqlExt = timerfactory.Create<Finance.IExcelSyteLineGLBatchSql>(_ExcelSyteLineGLBatchSql);
			
			return iExcelSyteLineGLBatchSqlExt;
		}
	}
}
