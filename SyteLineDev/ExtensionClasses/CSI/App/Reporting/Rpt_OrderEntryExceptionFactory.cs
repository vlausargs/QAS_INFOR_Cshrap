//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderEntryExceptionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderEntryExceptionFactory
	{
		public IRpt_OrderEntryException Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderEntryException = new Reporting.Rpt_OrderEntryException(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderEntryExceptionExt = timerfactory.Create<Reporting.IRpt_OrderEntryException>(_Rpt_OrderEntryException);
			
			return iRpt_OrderEntryExceptionExt;
		}
	}
}
