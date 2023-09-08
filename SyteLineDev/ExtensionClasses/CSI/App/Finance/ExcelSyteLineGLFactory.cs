//PROJECT NAME: Finance
//CLASS NAME: ExcelSyteLineGLFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class ExcelSyteLineGLFactory
	{
		public IExcelSyteLineGL Create(IApplicationDB appDB)
		{
			var _ExcelSyteLineGL = new Finance.ExcelSyteLineGL(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExcelSyteLineGLExt = timerfactory.Create<Finance.IExcelSyteLineGL>(_ExcelSyteLineGL);
			
			return iExcelSyteLineGLExt;
		}
	}
}
