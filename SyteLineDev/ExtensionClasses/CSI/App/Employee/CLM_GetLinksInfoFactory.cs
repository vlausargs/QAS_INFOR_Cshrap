//PROJECT NAME: Employee
//CLASS NAME: CLM_GetLinksInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_GetLinksInfoFactory
	{
		public ICLM_GetLinksInfo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetLinksInfo = new Employee.CLM_GetLinksInfo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetLinksInfoExt = timerfactory.Create<Employee.ICLM_GetLinksInfo>(_CLM_GetLinksInfo);
			
			return iCLM_GetLinksInfoExt;
		}
	}
}
