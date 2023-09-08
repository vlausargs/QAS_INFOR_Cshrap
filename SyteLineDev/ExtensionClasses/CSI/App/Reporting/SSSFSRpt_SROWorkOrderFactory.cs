//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_SROWorkOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSFSRpt_SROWorkOrderFactory
	{
		public ISSSFSRpt_SROWorkOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSFSRpt_SROWorkOrder = new Reporting.SSSFSRpt_SROWorkOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSFSRpt_SROWorkOrderExt = timerfactory.Create<Reporting.ISSSFSRpt_SROWorkOrder>(_SSSFSRpt_SROWorkOrder);
			
			return iSSSFSRpt_SROWorkOrderExt;
		}
	}
}
