//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROMarginFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROMarginFactory
	{
		public ISSSFSRpt_SROMargin Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROMargin = new Reporting.SSSFSRpt_SROMargin(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROMarginExt = timerfactory.Create<Reporting.ISSSFSRpt_SROMargin>(_SSSFSRpt_SROMargin);
			
			return iSSSFSRpt_SROMarginExt;
		}
	}
}
