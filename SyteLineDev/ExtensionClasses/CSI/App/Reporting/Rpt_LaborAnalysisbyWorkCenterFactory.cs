//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LaborAnalysisbyWorkCenterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_LaborAnalysisbyWorkCenterFactory
	{
		public IRpt_LaborAnalysisbyWorkCenter Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_LaborAnalysisbyWorkCenter = new Reporting.Rpt_LaborAnalysisbyWorkCenter(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_LaborAnalysisbyWorkCenterExt = timerfactory.Create<Reporting.IRpt_LaborAnalysisbyWorkCenter>(_Rpt_LaborAnalysisbyWorkCenter);
			
			return iRpt_LaborAnalysisbyWorkCenterExt;
		}
	}
}
