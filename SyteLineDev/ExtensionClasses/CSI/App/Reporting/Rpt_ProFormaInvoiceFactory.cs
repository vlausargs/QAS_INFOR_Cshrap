//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProFormaInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProFormaInvoiceFactory
	{
		public IRpt_ProFormaInvoice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProFormaInvoice = new Reporting.Rpt_ProFormaInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProFormaInvoiceExt = timerfactory.Create<Reporting.IRpt_ProFormaInvoice>(_Rpt_ProFormaInvoice);
			
			return iRpt_ProFormaInvoiceExt;
		}
	}
}
