//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_ContactsForCommunicationWizardFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_ContactsForCommunicationWizardFactory
	{
		public ICLM_ContactsForCommunicationWizard Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ContactsForCommunicationWizard = new Logistics.Customer.CLM_ContactsForCommunicationWizard(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ContactsForCommunicationWizardExt = timerfactory.Create<Logistics.Customer.ICLM_ContactsForCommunicationWizard>(_CLM_ContactsForCommunicationWizard);
			
			return iCLM_ContactsForCommunicationWizardExt;
		}
	}
}
