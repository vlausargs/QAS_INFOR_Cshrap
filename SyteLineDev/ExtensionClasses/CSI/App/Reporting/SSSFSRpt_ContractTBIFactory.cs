//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_ContractTBIFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_ContractTBIFactory
	{
		public ISSSFSRpt_ContractTBI Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_ContractTBI = new Reporting.SSSFSRpt_ContractTBI(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_ContractTBIExt = timerfactory.Create<Reporting.ISSSFSRpt_ContractTBI>(_SSSFSRpt_ContractTBI);
			
			return iSSSFSRpt_ContractTBIExt;
		}
	}
}
