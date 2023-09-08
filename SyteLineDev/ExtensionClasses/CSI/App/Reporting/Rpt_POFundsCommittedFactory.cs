//PROJECT NAME: Reporting
//CLASS NAME: Rpt_POFundsCommittedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_POFundsCommittedFactory
	{
		public IRpt_POFundsCommitted Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_POFundsCommitted = new Reporting.Rpt_POFundsCommitted(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_POFundsCommittedExt = timerfactory.Create<Reporting.IRpt_POFundsCommitted>(_Rpt_POFundsCommitted);
			
			return iRpt_POFundsCommittedExt;
		}
	}
}
