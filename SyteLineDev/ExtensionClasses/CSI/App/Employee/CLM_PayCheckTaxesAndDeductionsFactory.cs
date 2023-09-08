//PROJECT NAME: Employee
//CLASS NAME: CLM_PayCheckTaxesAndDeductionsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_PayCheckTaxesAndDeductionsFactory
	{
		public ICLM_PayCheckTaxesAndDeductions Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PayCheckTaxesAndDeductions = new Employee.CLM_PayCheckTaxesAndDeductions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PayCheckTaxesAndDeductionsExt = timerfactory.Create<Employee.ICLM_PayCheckTaxesAndDeductions>(_CLM_PayCheckTaxesAndDeductions);
			
			return iCLM_PayCheckTaxesAndDeductionsExt;
		}
	}
}
