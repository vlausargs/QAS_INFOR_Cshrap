//PROJECT NAME: Employee
//CLASS NAME: CLM_ESSTeamTimeOffFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_ESSTeamTimeOffFactory
	{
		public ICLM_ESSTeamTimeOff Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESSTeamTimeOff = new Employee.CLM_ESSTeamTimeOff(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESSTeamTimeOffExt = timerfactory.Create<Employee.ICLM_ESSTeamTimeOff>(_CLM_ESSTeamTimeOff);
			
			return iCLM_ESSTeamTimeOffExt;
		}
	}
}
