//PROJECT NAME: Employee
//CLASS NAME: SalUpdFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class SalUpdFactory
	{
		public ISalUpd Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SalUpd = new Employee.SalUpd(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSalUpdExt = timerfactory.Create<Employee.ISalUpd>(_SalUpd);
			
			return iSalUpdExt;
		}
	}
}
