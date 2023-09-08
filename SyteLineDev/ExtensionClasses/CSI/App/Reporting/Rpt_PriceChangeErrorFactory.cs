//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PriceChangeErrorFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PriceChangeErrorFactory
	{
		public IRpt_PriceChangeError Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PriceChangeError = new Reporting.Rpt_PriceChangeError(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PriceChangeErrorExt = timerfactory.Create<Reporting.IRpt_PriceChangeError>(_Rpt_PriceChangeError);
			
			return iRpt_PriceChangeErrorExt;
		}
	}
}
