//PROJECT NAME: Employee
//CLASS NAME: CLM_ESSGetEmpInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_ESSGetEmpInfoFactory
	{
		public ICLM_ESSGetEmpInfo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESSGetEmpInfo = new Employee.CLM_ESSGetEmpInfo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESSGetEmpInfoExt = timerfactory.Create<Employee.ICLM_ESSGetEmpInfo>(_CLM_ESSGetEmpInfo);
			
			return iCLM_ESSGetEmpInfoExt;
		}
	}
}
