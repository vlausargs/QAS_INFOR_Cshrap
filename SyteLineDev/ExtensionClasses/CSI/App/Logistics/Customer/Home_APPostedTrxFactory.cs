//PROJECT NAME: Logistics
//CLASS NAME: Home_APPostedTrxFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Home_APPostedTrxFactory
	{
		public IHome_APPostedTrx Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_APPostedTrx = new Logistics.Customer.Home_APPostedTrx(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_APPostedTrxExt = timerfactory.Create<Logistics.Customer.IHome_APPostedTrx>(_Home_APPostedTrx);
			
			return iHome_APPostedTrxExt;
		}
	}
}
