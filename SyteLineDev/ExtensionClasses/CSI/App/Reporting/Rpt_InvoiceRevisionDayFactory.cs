//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceRevisionDayFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InvoiceRevisionDayFactory
	{
		public IRpt_InvoiceRevisionDay Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoiceRevisionDay = new Reporting.Rpt_InvoiceRevisionDay(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoiceRevisionDayExt = timerfactory.Create<Reporting.IRpt_InvoiceRevisionDay>(_Rpt_InvoiceRevisionDay);
			
			return iRpt_InvoiceRevisionDayExt;
		}
	}
}
