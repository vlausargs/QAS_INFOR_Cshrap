//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerPriceChangeFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerPriceChangeFactory
	{
		public IRpt_CustomerPriceChange Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerPriceChange = new Reporting.Rpt_CustomerPriceChange(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerPriceChangeExt = timerfactory.Create<Reporting.IRpt_CustomerPriceChange>(_Rpt_CustomerPriceChange);
			
			return iRpt_CustomerPriceChangeExt;
		}
	}
}
