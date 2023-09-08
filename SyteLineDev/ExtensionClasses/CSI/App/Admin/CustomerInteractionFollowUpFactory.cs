//PROJECT NAME: Admin
//CLASS NAME: CustomerInteractionFollowUpFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Admin
{
	public class CustomerInteractionFollowUpFactory
	{
		public ICustomerInteractionFollowUp Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CustomerInteractionFollowUp = new Admin.CustomerInteractionFollowUp(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerInteractionFollowUpExt = timerfactory.Create<Admin.ICustomerInteractionFollowUp>(_CustomerInteractionFollowUp);
			
			return iCustomerInteractionFollowUpExt;
		}
	}
}
