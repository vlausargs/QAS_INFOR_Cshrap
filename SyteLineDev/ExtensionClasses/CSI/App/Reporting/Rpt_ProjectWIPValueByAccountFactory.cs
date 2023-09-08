//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectWIPValueByAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectWIPValueByAccountFactory
	{
		public IRpt_ProjectWIPValueByAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectWIPValueByAccount = new Reporting.Rpt_ProjectWIPValueByAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectWIPValueByAccountExt = timerfactory.Create<Reporting.IRpt_ProjectWIPValueByAccount>(_Rpt_ProjectWIPValueByAccount);
			
			return iRpt_ProjectWIPValueByAccountExt;
		}
	}
}
