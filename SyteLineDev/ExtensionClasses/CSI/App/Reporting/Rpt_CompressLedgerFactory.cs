//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CompressLedgerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CompressLedgerFactory
	{
		public IRpt_CompressLedger Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CompressLedger = new Reporting.Rpt_CompressLedger(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CompressLedgerExt = timerfactory.Create<Reporting.IRpt_CompressLedger>(_Rpt_CompressLedger);
			
			return iRpt_CompressLedgerExt;
		}
	}
}
