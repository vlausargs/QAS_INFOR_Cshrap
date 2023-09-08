//PROJECT NAME: Finance
//CLASS NAME: VoidPRPostedPaymentsPreFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class VoidPRPostedPaymentsPreFactory
	{
		public IVoidPRPostedPaymentsPre Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VoidPRPostedPaymentsPre = new Finance.VoidPRPostedPaymentsPre(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidPRPostedPaymentsPreExt = timerfactory.Create<Finance.IVoidPRPostedPaymentsPre>(_VoidPRPostedPaymentsPre);
			
			return iVoidPRPostedPaymentsPreExt;
		}
	}
}
