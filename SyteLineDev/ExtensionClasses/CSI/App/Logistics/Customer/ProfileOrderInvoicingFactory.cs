//PROJECT NAME: Logistics
//CLASS NAME: ProfileOrderInvoicingFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileOrderInvoicingFactory
	{
		public IProfileOrderInvoicing Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileOrderInvoicing = new Logistics.Customer.ProfileOrderInvoicing(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileOrderInvoicingExt = timerfactory.Create<Logistics.Customer.IProfileOrderInvoicing>(_ProfileOrderInvoicing);
			
			return iProfileOrderInvoicingExt;
		}
	}
}
