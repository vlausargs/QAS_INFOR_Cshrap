//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROOnHoldFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROOnHoldFactory
	{
		public ISSSFSRpt_SROOnHold Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROOnHold = new Reporting.SSSFSRpt_SROOnHold(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROOnHoldExt = timerfactory.Create<Reporting.ISSSFSRpt_SROOnHold>(_SSSFSRpt_SROOnHold);
			
			return iSSSFSRpt_SROOnHoldExt;
		}
	}
}
