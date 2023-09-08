//PROJECT NAME: Employee
//CLASS NAME: CLM_ESSPopulateTimeOffCalendarFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_ESSPopulateTimeOffCalendarFactory
	{
		public ICLM_ESSPopulateTimeOffCalendar Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESSPopulateTimeOffCalendar = new Employee.CLM_ESSPopulateTimeOffCalendar(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESSPopulateTimeOffCalendarExt = timerfactory.Create<Employee.ICLM_ESSPopulateTimeOffCalendar>(_CLM_ESSPopulateTimeOffCalendar);
			
			return iCLM_ESSPopulateTimeOffCalendarExt;
		}
	}
}
