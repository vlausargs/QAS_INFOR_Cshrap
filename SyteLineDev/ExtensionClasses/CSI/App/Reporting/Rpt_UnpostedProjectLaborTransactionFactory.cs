//PROJECT NAME: Reporting
//CLASS NAME: Rpt_UnpostedProjectLaborTransactionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_UnpostedProjectLaborTransactionFactory
	{
		public IRpt_UnpostedProjectLaborTransaction Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_UnpostedProjectLaborTransaction = new Reporting.Rpt_UnpostedProjectLaborTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_UnpostedProjectLaborTransactionExt = timerfactory.Create<Reporting.IRpt_UnpostedProjectLaborTransaction>(_Rpt_UnpostedProjectLaborTransaction);
			
			return iRpt_UnpostedProjectLaborTransactionExt;
		}
	}
}
