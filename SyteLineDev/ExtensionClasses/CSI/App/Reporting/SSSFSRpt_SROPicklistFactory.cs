//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROPicklistFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROPicklistFactory
	{
		public ISSSFSRpt_SROPicklist Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROPicklist = new Reporting.SSSFSRpt_SROPicklist(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROPicklistExt = timerfactory.Create<Reporting.ISSSFSRpt_SROPicklist>(_SSSFSRpt_SROPicklist);
			
			return iSSSFSRpt_SROPicklistExt;
		}
	}
}
