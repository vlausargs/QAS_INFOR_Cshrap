//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileEstimateResponseFormFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileEstimateResponseFormFactory
	{
		public IProfileEstimateResponseForm Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileEstimateResponseForm = new Logistics.Customer.ProfileEstimateResponseForm(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileEstimateResponseFormExt = timerfactory.Create<Logistics.Customer.IProfileEstimateResponseForm>(_ProfileEstimateResponseForm);
			
			return iProfileEstimateResponseFormExt;
		}
	}
}
