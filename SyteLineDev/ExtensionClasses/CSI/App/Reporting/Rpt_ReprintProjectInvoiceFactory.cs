//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ReprintProjectInvoiceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ReprintProjectInvoiceFactory
	{
		public IRpt_ReprintProjectInvoice Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ReprintProjectInvoice = new Reporting.Rpt_ReprintProjectInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ReprintProjectInvoiceExt = timerfactory.Create<Reporting.IRpt_ReprintProjectInvoice>(_Rpt_ReprintProjectInvoice);
			
			return iRpt_ReprintProjectInvoiceExt;
		}
	}
}
