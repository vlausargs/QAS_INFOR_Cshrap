//PROJECT NAME: Finance
//CLASS NAME: VoidPRPostedPaymentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class VoidPRPostedPaymentFactory
	{
		public IVoidPRPostedPayment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _VoidPRPostedPayment = new Finance.VoidPRPostedPayment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoidPRPostedPaymentExt = timerfactory.Create<Finance.IVoidPRPostedPayment>(_VoidPRPostedPayment);
			
			return iVoidPRPostedPaymentExt;
		}
	}
}
