//PROJECT NAME: Reporting
//CLASS NAME: Rpt_VoidAPPostedPaymentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_VoidAPPostedPaymentFactory
	{
		public IRpt_VoidAPPostedPayment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_VoidAPPostedPayment = new Reporting.Rpt_VoidAPPostedPayment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_VoidAPPostedPaymentExt = timerfactory.Create<Reporting.IRpt_VoidAPPostedPayment>(_Rpt_VoidAPPostedPayment);
			
			return iRpt_VoidAPPostedPaymentExt;
		}
	}
}
