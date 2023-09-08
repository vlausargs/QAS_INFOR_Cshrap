//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LotTraceabilityFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LotTraceabilityFactory
	{
		public IRpt_LotTraceability Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LotTraceability = new Reporting.Rpt_LotTraceability(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LotTraceabilityExt = timerfactory.Create<Reporting.IRpt_LotTraceability>(_Rpt_LotTraceability);
			
			return iRpt_LotTraceabilityExt;
		}
	}
}
