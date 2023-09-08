//PROJECT NAME: CSIEmployee
//CLASS NAME: CLM_GetExportEmpFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_GetExportEmpFactory
	{
		public ICLM_GetExportEmp Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetExportEmp = new Employee.CLM_GetExportEmp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetExportEmpExt = timerfactory.Create<Employee.ICLM_GetExportEmp>(_CLM_GetExportEmp);
			
			return iCLM_GetExportEmpExt;
		}
	}
}
