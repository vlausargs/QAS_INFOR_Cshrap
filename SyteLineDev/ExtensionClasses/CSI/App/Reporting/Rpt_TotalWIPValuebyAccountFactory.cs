//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TotalWIPValuebyAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TotalWIPValuebyAccountFactory
	{
		public IRpt_TotalWIPValuebyAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TotalWIPValuebyAccount = new Reporting.Rpt_TotalWIPValuebyAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TotalWIPValuebyAccountExt = timerfactory.Create<Reporting.IRpt_TotalWIPValuebyAccount>(_Rpt_TotalWIPValuebyAccount);
			
			return iRpt_TotalWIPValuebyAccountExt;
		}
	}
}
