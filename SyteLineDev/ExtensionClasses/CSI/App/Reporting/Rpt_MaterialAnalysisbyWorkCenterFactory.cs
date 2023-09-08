//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MaterialAnalysisbyWorkCenterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_MaterialAnalysisbyWorkCenterFactory
	{
		public IRpt_MaterialAnalysisbyWorkCenter Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_MaterialAnalysisbyWorkCenter = new Reporting.Rpt_MaterialAnalysisbyWorkCenter(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_MaterialAnalysisbyWorkCenterExt = timerfactory.Create<Reporting.IRpt_MaterialAnalysisbyWorkCenter>(_Rpt_MaterialAnalysisbyWorkCenter);
			
			return iRpt_MaterialAnalysisbyWorkCenterExt;
		}
	}
}
