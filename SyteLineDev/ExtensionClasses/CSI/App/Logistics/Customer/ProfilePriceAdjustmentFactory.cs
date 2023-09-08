//PROJECT NAME: Logistics
//CLASS NAME: ProfilePriceAdjustmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfilePriceAdjustmentFactory
	{
		public IProfilePriceAdjustment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfilePriceAdjustment = new Logistics.Customer.ProfilePriceAdjustment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfilePriceAdjustmentExt = timerfactory.Create<Logistics.Customer.IProfilePriceAdjustment>(_ProfilePriceAdjustment);
			
			return iProfilePriceAdjustmentExt;
		}
	}
}
