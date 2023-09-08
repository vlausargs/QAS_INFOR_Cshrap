//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSalesOrderSubLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSalesOrderSubLineFactory
	{
		public ICLM_ESBSalesOrderSubLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSalesOrderSubLine = new BusInterface.CLM_ESBSalesOrderSubLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSalesOrderSubLineExt = timerfactory.Create<BusInterface.ICLM_ESBSalesOrderSubLine>(_CLM_ESBSalesOrderSubLine);
			
			return iCLM_ESBSalesOrderSubLineExt;
		}
	}
}
