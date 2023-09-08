//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SubTaxCodePurchaseOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SubTaxCodePurchaseOrderFactory
	{
		public IRpt_SubTaxCodePurchaseOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SubTaxCodePurchaseOrder = new Reporting.Rpt_SubTaxCodePurchaseOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SubTaxCodePurchaseOrderExt = timerfactory.Create<Reporting.IRpt_SubTaxCodePurchaseOrder>(_Rpt_SubTaxCodePurchaseOrder);
			
			return iRpt_SubTaxCodePurchaseOrderExt;
		}
	}
}
