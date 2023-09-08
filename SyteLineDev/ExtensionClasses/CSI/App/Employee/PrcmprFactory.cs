//PROJECT NAME: CSIEmployee
//CLASS NAME: PrcmprFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class PrcmprFactory
	{
		public IPrcmpr Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Prcmpr = new Employee.Prcmpr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrcmprExt = timerfactory.Create<Employee.IPrcmpr>(_Prcmpr);
			
			return iPrcmprExt;
		}
	}
}
