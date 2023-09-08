//PROJECT NAME: Employee
//CLASS NAME: Rpt_SalariesByEEOClassFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_SalariesByEEOClassFactory
	{
		public IRpt_SalariesByEEOClass Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalariesByEEOClass = new Employee.Rpt_SalariesByEEOClass(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalariesByEEOClassExt = timerfactory.Create<Employee.IRpt_SalariesByEEOClass>(_Rpt_SalariesByEEOClass);
			
			return iRpt_SalariesByEEOClassExt;
		}
	}
}
