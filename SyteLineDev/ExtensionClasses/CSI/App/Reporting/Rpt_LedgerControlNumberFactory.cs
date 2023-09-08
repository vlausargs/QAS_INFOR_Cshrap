//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LedgerControlNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LedgerControlNumberFactory
	{
		public IRpt_LedgerControlNumber Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LedgerControlNumber = new Reporting.Rpt_LedgerControlNumber(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LedgerControlNumberExt = timerfactory.Create<Reporting.IRpt_LedgerControlNumber>(_Rpt_LedgerControlNumber);
			
			return iRpt_LedgerControlNumberExt;
		}
	}
}
