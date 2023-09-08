//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransactionsbySerialNumberFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TransactionsbySerialNumberFactory
	{
		public IRpt_TransactionsbySerialNumber Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TransactionsbySerialNumber = new Reporting.Rpt_TransactionsbySerialNumber(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TransactionsbySerialNumberExt = timerfactory.Create<Reporting.IRpt_TransactionsbySerialNumber>(_Rpt_TransactionsbySerialNumber);
			
			return iRpt_TransactionsbySerialNumberExt;
		}
	}
}
