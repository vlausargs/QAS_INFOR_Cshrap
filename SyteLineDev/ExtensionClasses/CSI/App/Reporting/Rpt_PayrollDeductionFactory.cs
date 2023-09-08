//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PayrollDeductionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PayrollDeductionFactory
	{
		public IRpt_PayrollDeduction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PayrollDeduction = new Reporting.Rpt_PayrollDeduction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PayrollDeductionExt = timerfactory.Create<Reporting.IRpt_PayrollDeduction>(_Rpt_PayrollDeduction);
			
			return iRpt_PayrollDeductionExt;
		}
	}
}
