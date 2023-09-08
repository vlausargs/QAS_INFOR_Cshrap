//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ComputePayrollFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ComputePayrollFactory
	{
		public IRpt_ComputePayroll Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ComputePayroll = new Reporting.Rpt_ComputePayroll(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ComputePayrollExt = timerfactory.Create<Reporting.IRpt_ComputePayroll>(_Rpt_ComputePayroll);
			
			return iRpt_ComputePayrollExt;
		}
	}
}
