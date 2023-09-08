//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ApprovedNotInvoicedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ApprovedNotInvoicedFactory
	{
		public IRpt_ApprovedNotInvoiced Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ApprovedNotInvoiced = new Reporting.Rpt_ApprovedNotInvoiced(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ApprovedNotInvoicedExt = timerfactory.Create<Reporting.IRpt_ApprovedNotInvoiced>(_Rpt_ApprovedNotInvoiced);
			
			return iRpt_ApprovedNotInvoicedExt;
		}
	}
}
