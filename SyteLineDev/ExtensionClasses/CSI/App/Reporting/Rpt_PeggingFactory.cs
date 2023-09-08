//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PeggingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PeggingFactory
	{
		public IRpt_Pegging Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_Pegging = new Reporting.Rpt_Pegging(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PeggingExt = timerfactory.Create<Reporting.IRpt_Pegging>(_Rpt_Pegging);
			
			return iRpt_PeggingExt;
		}
	}
}
