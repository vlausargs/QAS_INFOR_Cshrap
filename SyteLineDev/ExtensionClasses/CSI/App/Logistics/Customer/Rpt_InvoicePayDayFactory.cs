//PROJECT NAME: Logistics
//CLASS NAME: Rpt_InvoicePayDayFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Rpt_InvoicePayDayFactory
	{
		public IRpt_InvoicePayDay Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoicePayDay = new Logistics.Customer.Rpt_InvoicePayDay(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoicePayDayExt = timerfactory.Create<Logistics.Customer.IRpt_InvoicePayDay>(_Rpt_InvoicePayDay);
			
			return iRpt_InvoicePayDayExt;
		}
	}
}
