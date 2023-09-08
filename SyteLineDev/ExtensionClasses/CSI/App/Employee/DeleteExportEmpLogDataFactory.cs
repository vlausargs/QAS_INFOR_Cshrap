//PROJECT NAME: Employee
//CLASS NAME: DeleteExportEmpLogDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class DeleteExportEmpLogDataFactory
	{
		public IDeleteExportEmpLogData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DeleteExportEmpLogData = new Employee.DeleteExportEmpLogData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeleteExportEmpLogDataExt = timerfactory.Create<Employee.IDeleteExportEmpLogData>(_DeleteExportEmpLogData);
			
			return iDeleteExportEmpLogDataExt;
		}
	}
}
