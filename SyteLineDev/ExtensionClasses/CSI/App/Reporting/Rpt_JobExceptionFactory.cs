//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobExceptionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobExceptionFactory
	{
		public IRpt_JobException Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobException = new Reporting.Rpt_JobException(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobExceptionExt = timerfactory.Create<Reporting.IRpt_JobException>(_Rpt_JobException);
			
			return iRpt_JobExceptionExt;
		}
	}
}
