//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROInvoicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROInvoicingFactory
	{
		public ISSSFSRpt_SROInvoicing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROInvoicing = new Reporting.SSSFSRpt_SROInvoicing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROInvoicingExt = timerfactory.Create<Reporting.ISSSFSRpt_SROInvoicing>(_SSSFSRpt_SROInvoicing);
			
			return iSSSFSRpt_SROInvoicingExt;
		}
	}
}
