//PROJECT NAME: Reporting
//CLASS NAME: Rpt_YearToDateDeductionsandEarningsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_YearToDateDeductionsandEarningsFactory
	{
		public IRpt_YearToDateDeductionsandEarnings Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_YearToDateDeductionsandEarnings = new Reporting.Rpt_YearToDateDeductionsandEarnings(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_YearToDateDeductionsandEarningsExt = timerfactory.Create<Reporting.IRpt_YearToDateDeductionsandEarnings>(_Rpt_YearToDateDeductionsandEarnings);
			
			return iRpt_YearToDateDeductionsandEarningsExt;
		}
	}
}
