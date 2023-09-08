//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoidPRPostedPaymentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoidPRPostedPaymentFactory
	{
		public IRpt_VoidPRPostedPayment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoidPRPostedPayment = new Reporting.Rpt_VoidPRPostedPayment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoidPRPostedPaymentExt = timerfactory.Create<Reporting.IRpt_VoidPRPostedPayment>(_Rpt_VoidPRPostedPayment);
			
			return iRpt_VoidPRPostedPaymentExt;
		}
	}
}
