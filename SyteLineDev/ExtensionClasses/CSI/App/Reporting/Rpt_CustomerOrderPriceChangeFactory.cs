//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerOrderPriceChangeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerOrderPriceChangeFactory
	{
		public IRpt_CustomerOrderPriceChange Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerOrderPriceChange = new Reporting.Rpt_CustomerOrderPriceChange(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerOrderPriceChangeExt = timerfactory.Create<Reporting.IRpt_CustomerOrderPriceChange>(_Rpt_CustomerOrderPriceChange);
			
			return iRpt_CustomerOrderPriceChangeExt;
		}
	}
}
