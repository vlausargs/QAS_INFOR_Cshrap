//PROJECT NAME: Reporting
//CLASS NAME: Rpt_YearEndPayrollFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_YearEndPayrollFactory
	{
		public IRpt_YearEndPayroll Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_YearEndPayroll = new Reporting.Rpt_YearEndPayroll(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_YearEndPayrollExt = timerfactory.Create<Reporting.IRpt_YearEndPayroll>(_Rpt_YearEndPayroll);
			
			return iRpt_YearEndPayrollExt;
		}
	}
}
