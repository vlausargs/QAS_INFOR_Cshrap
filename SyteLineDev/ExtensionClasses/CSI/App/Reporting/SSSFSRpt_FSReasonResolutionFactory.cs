//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_FSReasonResolutionFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_FSReasonResolutionFactory
	{
		public ISSSFSRpt_FSReasonResolution Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_FSReasonResolution = new Reporting.SSSFSRpt_FSReasonResolution(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_FSReasonResolutionExt = timerfactory.Create<Reporting.ISSSFSRpt_FSReasonResolution>(_SSSFSRpt_FSReasonResolution);
			
			return iSSSFSRpt_FSReasonResolutionExt;
		}
	}
}
