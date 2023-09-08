//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PayrollDistributionLogFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PayrollDistributionLogFactory
	{
		public IRpt_PayrollDistributionLog Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PayrollDistributionLog = new Reporting.Rpt_PayrollDistributionLog(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PayrollDistributionLogExt = timerfactory.Create<Reporting.IRpt_PayrollDistributionLog>(_Rpt_PayrollDistributionLog);
			
			return iRpt_PayrollDistributionLogExt;
		}
	}
}
