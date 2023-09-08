//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectPurchaseOrderCommitmentsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectPurchaseOrderCommitmentsFactory
	{
		public IRpt_ProjectPurchaseOrderCommitments Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectPurchaseOrderCommitments = new Reporting.Rpt_ProjectPurchaseOrderCommitments(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectPurchaseOrderCommitmentsExt = timerfactory.Create<Reporting.IRpt_ProjectPurchaseOrderCommitments>(_Rpt_ProjectPurchaseOrderCommitments);
			
			return iRpt_ProjectPurchaseOrderCommitmentsExt;
		}
	}
}
