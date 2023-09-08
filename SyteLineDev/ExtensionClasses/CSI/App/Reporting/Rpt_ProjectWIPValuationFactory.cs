//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectWIPValuationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectWIPValuationFactory
	{
		public IRpt_ProjectWIPValuation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectWIPValuation = new Reporting.Rpt_ProjectWIPValuation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectWIPValuationExt = timerfactory.Create<Reporting.IRpt_ProjectWIPValuation>(_Rpt_ProjectWIPValuation);
			
			return iRpt_ProjectWIPValuationExt;
		}
	}
}
