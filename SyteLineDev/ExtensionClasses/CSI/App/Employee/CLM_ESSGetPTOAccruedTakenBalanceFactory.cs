//PROJECT NAME: Employee
//CLASS NAME: CLM_ESSGetPTOAccruedTakenBalanceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_ESSGetPTOAccruedTakenBalanceFactory
	{
		public ICLM_ESSGetPTOAccruedTakenBalance Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESSGetPTOAccruedTakenBalance = new Employee.CLM_ESSGetPTOAccruedTakenBalance(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESSGetPTOAccruedTakenBalanceExt = timerfactory.Create<Employee.ICLM_ESSGetPTOAccruedTakenBalance>(_CLM_ESSGetPTOAccruedTakenBalance);
			
			return iCLM_ESSGetPTOAccruedTakenBalanceExt;
		}
	}
}
