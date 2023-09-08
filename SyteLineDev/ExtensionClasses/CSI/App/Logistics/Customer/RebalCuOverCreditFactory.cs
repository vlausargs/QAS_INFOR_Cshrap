//PROJECT NAME: Logistics
//CLASS NAME: RebalCuOverCreditFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class RebalCuOverCreditFactory
	{
		public IRebalCuOverCredit Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RebalCuOverCredit = new Logistics.Customer.RebalCuOverCredit(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRebalCuOverCreditExt = timerfactory.Create<Logistics.Customer.IRebalCuOverCredit>(_RebalCuOverCredit);
			
			return iRebalCuOverCreditExt;
		}
	}
}
