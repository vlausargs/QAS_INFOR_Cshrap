//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROStatusFactory
	{
		public ISSSFSRpt_SROStatus Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROStatus = new Reporting.SSSFSRpt_SROStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROStatusExt = timerfactory.Create<Reporting.ISSSFSRpt_SROStatus>(_SSSFSRpt_SROStatus);
			
			return iSSSFSRpt_SROStatusExt;
		}
	}
}
