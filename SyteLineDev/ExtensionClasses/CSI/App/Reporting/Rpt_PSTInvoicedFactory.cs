//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PSTInvoicedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PSTInvoicedFactory
	{
		public IRpt_PSTInvoiced Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PSTInvoiced = new Reporting.Rpt_PSTInvoiced(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PSTInvoicedExt = timerfactory.Create<Reporting.IRpt_PSTInvoiced>(_Rpt_PSTInvoiced);
			
			return iRpt_PSTInvoicedExt;
		}
	}
}
