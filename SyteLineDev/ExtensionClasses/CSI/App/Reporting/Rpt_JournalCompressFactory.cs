//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JournalCompressFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JournalCompressFactory
	{
		public IRpt_JournalCompress Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JournalCompress = new Reporting.Rpt_JournalCompress(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JournalCompressExt = timerfactory.Create<Reporting.IRpt_JournalCompress>(_Rpt_JournalCompress);
			
			return iRpt_JournalCompressExt;
		}
	}
}
