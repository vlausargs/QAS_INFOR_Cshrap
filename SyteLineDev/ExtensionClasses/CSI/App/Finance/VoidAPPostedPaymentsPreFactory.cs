//PROJECT NAME: Finance
//CLASS NAME: VoidAPPostedPaymentsPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class VoidAPPostedPaymentsPreFactory
	{
		public IVoidAPPostedPaymentsPre Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VoidAPPostedPaymentsPre = new Finance.VoidAPPostedPaymentsPre(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidAPPostedPaymentsPreExt = timerfactory.Create<Finance.IVoidAPPostedPaymentsPre>(_VoidAPPostedPaymentsPre);
			
			return iVoidAPPostedPaymentsPreExt;
		}
	}
}
