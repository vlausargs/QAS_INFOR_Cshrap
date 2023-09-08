//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBCompressLedgerFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBCompressLedgerFactory
	{
		public IRpt_MultiFSBCompressLedger Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MultiFSBCompressLedger = new Reporting.Rpt_MultiFSBCompressLedger(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MultiFSBCompressLedgerExt = timerfactory.Create<Reporting.IRpt_MultiFSBCompressLedger>(_Rpt_MultiFSBCompressLedger);
			
			return iRpt_MultiFSBCompressLedgerExt;
		}
	}
}
