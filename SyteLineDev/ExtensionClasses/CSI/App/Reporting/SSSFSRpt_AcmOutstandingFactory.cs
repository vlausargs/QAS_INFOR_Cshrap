//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_AcmOutstandingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_AcmOutstandingFactory
	{
		public ISSSFSRpt_AcmOutstanding Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_AcmOutstanding = new Reporting.SSSFSRpt_AcmOutstanding(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_AcmOutstandingExt = timerfactory.Create<Reporting.ISSSFSRpt_AcmOutstanding>(_SSSFSRpt_AcmOutstanding);
			
			return iSSSFSRpt_AcmOutstandingExt;
		}
	}
}
