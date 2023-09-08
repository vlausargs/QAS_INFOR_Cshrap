//PROJECT NAME: Employee
//CLASS NAME: CLM_GetOrgHierarchyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_GetOrgHierarchyFactory
	{
		public ICLM_GetOrgHierarchy Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetOrgHierarchy = new Employee.CLM_GetOrgHierarchy(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetOrgHierarchyExt = timerfactory.Create<Employee.ICLM_GetOrgHierarchy>(_CLM_GetOrgHierarchy);
			
			return iCLM_GetOrgHierarchyExt;
		}
	}
}
