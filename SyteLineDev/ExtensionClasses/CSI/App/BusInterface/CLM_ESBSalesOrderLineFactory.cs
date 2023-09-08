//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSalesOrderLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSalesOrderLineFactory
	{
		public ICLM_ESBSalesOrderLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSalesOrderLine = new BusInterface.CLM_ESBSalesOrderLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSalesOrderLineExt = timerfactory.Create<BusInterface.ICLM_ESBSalesOrderLine>(_CLM_ESBSalesOrderLine);
			
			return iCLM_ESBSalesOrderLineExt;
		}
	}
}
