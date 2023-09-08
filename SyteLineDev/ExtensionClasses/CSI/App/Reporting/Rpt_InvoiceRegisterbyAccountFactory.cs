//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceRegisterbyAccountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InvoiceRegisterbyAccountFactory
	{
		public IRpt_InvoiceRegisterbyAccount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoiceRegisterbyAccount = new Reporting.Rpt_InvoiceRegisterbyAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoiceRegisterbyAccountExt = timerfactory.Create<Reporting.IRpt_InvoiceRegisterbyAccount>(_Rpt_InvoiceRegisterbyAccount);
			
			return iRpt_InvoiceRegisterbyAccountExt;
		}
	}
}
