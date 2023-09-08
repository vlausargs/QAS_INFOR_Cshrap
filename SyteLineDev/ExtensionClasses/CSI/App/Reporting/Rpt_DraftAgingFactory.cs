//PROJECT NAME: Reporting
//CLASS NAME: Rpt_DraftAgingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_DraftAgingFactory
	{
		public IRpt_DraftAging Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_DraftAging = new Reporting.Rpt_DraftAging(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_DraftAgingExt = timerfactory.Create<Reporting.IRpt_DraftAging>(_Rpt_DraftAging);
			
			return iRpt_DraftAgingExt;
		}
	}
}
