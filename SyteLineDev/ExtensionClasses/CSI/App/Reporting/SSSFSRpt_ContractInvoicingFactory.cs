//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ContractInvoicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_ContractInvoicingFactory
	{
		public ISSSFSRpt_ContractInvoicing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_ContractInvoicing = new Reporting.SSSFSRpt_ContractInvoicing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_ContractInvoicingExt = timerfactory.Create<Reporting.ISSSFSRpt_ContractInvoicing>(_SSSFSRpt_ContractInvoicing);
			
			return iSSSFSRpt_ContractInvoicingExt;
		}
	}
}
