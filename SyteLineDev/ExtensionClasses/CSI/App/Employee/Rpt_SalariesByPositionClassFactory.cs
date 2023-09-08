//PROJECT NAME: Employee
//CLASS NAME: Rpt_SalariesByPositionClassFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_SalariesByPositionClassFactory
	{
		public IRpt_SalariesByPositionClass Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalariesByPositionClass = new Employee.Rpt_SalariesByPositionClass(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalariesByPositionClassExt = timerfactory.Create<Employee.IRpt_SalariesByPositionClass>(_Rpt_SalariesByPositionClass);
			
			return iRpt_SalariesByPositionClassExt;
		}
	}
}
