//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobTicketsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobTicketsFactory
	{
		public IRpt_JobTickets Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobTickets = new Reporting.Rpt_JobTickets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobTicketsExt = timerfactory.Create<Reporting.IRpt_JobTickets>(_Rpt_JobTickets);
			
			return iRpt_JobTicketsExt;
		}
	}
}
