//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPlanActualFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPlanActualFactory
	{
		public ISSSFSRpt_SROPlanActual Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROPlanActual = new Reporting.SSSFSRpt_SROPlanActual(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROPlanActualExt = timerfactory.Create<Reporting.ISSSFSRpt_SROPlanActual>(_SSSFSRpt_SROPlanActual);
			
			return iSSSFSRpt_SROPlanActualExt;
		}
	}
}
