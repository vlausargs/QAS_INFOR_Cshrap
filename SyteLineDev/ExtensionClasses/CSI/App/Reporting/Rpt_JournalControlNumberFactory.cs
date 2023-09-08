//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JournalControlNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JournalControlNumberFactory
	{
		public IRpt_JournalControlNumber Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JournalControlNumber = new Reporting.Rpt_JournalControlNumber(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JournalControlNumberExt = timerfactory.Create<Reporting.IRpt_JournalControlNumber>(_Rpt_JournalControlNumber);
			
			return iRpt_JournalControlNumberExt;
		}
	}
}
