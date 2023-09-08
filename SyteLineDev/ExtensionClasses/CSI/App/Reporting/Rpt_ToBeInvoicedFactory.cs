//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ToBeInvoicedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ToBeInvoicedFactory
	{
		public IRpt_ToBeInvoiced Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ToBeInvoiced = new Reporting.Rpt_ToBeInvoiced(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ToBeInvoicedExt = timerfactory.Create<Reporting.IRpt_ToBeInvoiced>(_Rpt_ToBeInvoiced);
			
			return iRpt_ToBeInvoicedExt;
		}
	}
}
