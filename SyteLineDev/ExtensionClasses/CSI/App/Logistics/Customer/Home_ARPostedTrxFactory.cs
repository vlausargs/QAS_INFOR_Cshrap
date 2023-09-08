//PROJECT NAME: Logistics
//CLASS NAME: Home_ARPostedTrxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_ARPostedTrxFactory
	{
		public IHome_ARPostedTrx Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_ARPostedTrx = new Logistics.Customer.Home_ARPostedTrx(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_ARPostedTrxExt = timerfactory.Create<Logistics.Customer.IHome_ARPostedTrx>(_Home_ARPostedTrx);
			
			return iHome_ARPostedTrxExt;
		}
	}
}
