//PROJECT NAME: Employee
//CLASS NAME: CLM_PR01VRPVoidChecksRangeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_PR01VRPVoidChecksRangeFactory
	{
		public ICLM_PR01VRPVoidChecksRange Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PR01VRPVoidChecksRange = new Employee.CLM_PR01VRPVoidChecksRange(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PR01VRPVoidChecksRangeExt = timerfactory.Create<Employee.ICLM_PR01VRPVoidChecksRange>(_CLM_PR01VRPVoidChecksRange);
			
			return iCLM_PR01VRPVoidChecksRangeExt;
		}
	}
}
