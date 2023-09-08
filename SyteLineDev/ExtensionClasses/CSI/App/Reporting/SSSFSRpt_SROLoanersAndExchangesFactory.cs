//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROLoanersAndExchangesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROLoanersAndExchangesFactory
	{
		public ISSSFSRpt_SROLoanersAndExchanges Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROLoanersAndExchanges = new Reporting.SSSFSRpt_SROLoanersAndExchanges(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROLoanersAndExchangesExt = timerfactory.Create<Reporting.ISSSFSRpt_SROLoanersAndExchanges>(_SSSFSRpt_SROLoanersAndExchanges);
			
			return iSSSFSRpt_SROLoanersAndExchangesExt;
		}
	}
}
