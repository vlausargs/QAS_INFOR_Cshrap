//PROJECT NAME: Reporting
//CLASS NAME: Rpt_SalesValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_SalesValueFactory
	{
		public IRpt_SalesValue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalesValue = new Reporting.Rpt_SalesValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalesValueExt = timerfactory.Create<Reporting.IRpt_SalesValue>(_Rpt_SalesValue);
			
			return iRpt_SalesValueExt;
		}
	}
}
