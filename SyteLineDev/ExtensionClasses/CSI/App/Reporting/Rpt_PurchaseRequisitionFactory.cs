//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PurchaseRequisitionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PurchaseRequisitionFactory
	{
		public IRpt_PurchaseRequisition Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PurchaseRequisition = new Reporting.Rpt_PurchaseRequisition(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PurchaseRequisitionExt = timerfactory.Create<Reporting.IRpt_PurchaseRequisition>(_Rpt_PurchaseRequisition);
			
			return iRpt_PurchaseRequisitionExt;
		}
	}
}
