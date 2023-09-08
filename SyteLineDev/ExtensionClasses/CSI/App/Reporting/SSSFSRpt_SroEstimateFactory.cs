//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SroEstimateFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SroEstimateFactory
	{
		public ISSSFSRpt_SroEstimate Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SroEstimate = new Reporting.SSSFSRpt_SroEstimate(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SroEstimateExt = timerfactory.Create<Reporting.ISSSFSRpt_SroEstimate>(_SSSFSRpt_SroEstimate);
			
			return iSSSFSRpt_SroEstimateExt;
		}
	}
}
