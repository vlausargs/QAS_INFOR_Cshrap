//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSalesOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSalesOrderFactory
	{
		public ICLM_ESBSalesOrder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSalesOrder = new BusInterface.CLM_ESBSalesOrder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSalesOrderExt = timerfactory.Create<BusInterface.ICLM_ESBSalesOrder>(_CLM_ESBSalesOrder);
			
			return iCLM_ESBSalesOrderExt;
		}
	}
}
