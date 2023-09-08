//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSalesOrderBlanketLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSalesOrderBlanketLineFactory
	{
		public ICLM_ESBSalesOrderBlanketLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSalesOrderBlanketLine = new BusInterface.CLM_ESBSalesOrderBlanketLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSalesOrderBlanketLineExt = timerfactory.Create<BusInterface.ICLM_ESBSalesOrderBlanketLine>(_CLM_ESBSalesOrderBlanketLine);
			
			return iCLM_ESBSalesOrderBlanketLineExt;
		}
	}
}
