//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PlanningBOMFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PlanningBOMFactory
	{
		public IRpt_PlanningBOM Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PlanningBOM = new Reporting.Rpt_PlanningBOM(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PlanningBOMExt = timerfactory.Create<Reporting.IRpt_PlanningBOM>(_Rpt_PlanningBOM);
			
			return iRpt_PlanningBOMExt;
		}
	}
}
