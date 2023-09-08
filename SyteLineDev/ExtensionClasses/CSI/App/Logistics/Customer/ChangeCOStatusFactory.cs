//PROJECT NAME: CSICustomer
//CLASS NAME: ChangeCOStatusFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ChangeCOStatusFactory
	{
		public IChangeCOStatus Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChangeCOStatus = new Logistics.Customer.ChangeCOStatus(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChangeCOStatusExt = timerfactory.Create<Logistics.Customer.IChangeCOStatus>(_ChangeCOStatus);
			
			return iChangeCOStatusExt;
		}
	}
}
