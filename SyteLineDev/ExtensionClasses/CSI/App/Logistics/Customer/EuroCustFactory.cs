//PROJECT NAME: Logistics
//CLASS NAME: EuroCustFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class EuroCustFactory
	{
		public IEuroCust Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EuroCust = new Logistics.Customer.EuroCust(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEuroCustExt = timerfactory.Create<Logistics.Customer.IEuroCust>(_EuroCust);
			
			return iEuroCustExt;
		}
	}
}
