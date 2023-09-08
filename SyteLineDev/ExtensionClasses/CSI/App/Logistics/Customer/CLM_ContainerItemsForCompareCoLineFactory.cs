//PROJECT NAME: Logistics
//CLASS NAME: CLM_ContainerItemsForCompareCoLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_ContainerItemsForCompareCoLineFactory
	{
		public ICLM_ContainerItemsForCompareCoLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ContainerItemsForCompareCoLine = new Logistics.Customer.CLM_ContainerItemsForCompareCoLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ContainerItemsForCompareCoLineExt = timerfactory.Create<Logistics.Customer.ICLM_ContainerItemsForCompareCoLine>(_CLM_ContainerItemsForCompareCoLine);
			
			return iCLM_ContainerItemsForCompareCoLineExt;
		}
	}
}
