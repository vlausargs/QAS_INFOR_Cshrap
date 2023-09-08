//PROJECT NAME: Reporting
//CLASS NAME: Rpt_WipValuationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_WipValuationFactory
	{
		public IRpt_WipValuation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_WipValuation = new Reporting.Rpt_WipValuation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_WipValuationExt = timerfactory.Create<Reporting.IRpt_WipValuation>(_Rpt_WipValuation);
			
			return iRpt_WipValuationExt;
		}
	}
}
