//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROOperationCodeCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROOperationCodeCostFactory
	{
		public ISSSFSRpt_SROOperationCodeCost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROOperationCodeCost = new Reporting.SSSFSRpt_SROOperationCodeCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROOperationCodeCostExt = timerfactory.Create<Reporting.ISSSFSRpt_SROOperationCodeCost>(_SSSFSRpt_SROOperationCodeCost);
			
			return iSSSFSRpt_SROOperationCodeCostExt;
		}
	}
}
