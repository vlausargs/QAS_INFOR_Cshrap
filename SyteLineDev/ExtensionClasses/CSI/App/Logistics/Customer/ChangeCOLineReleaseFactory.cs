//PROJECT NAME: CSICustomer
//CLASS NAME: ChangeCOLineReleaseFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ChangeCOLineReleaseFactory
	{
		public IChangeCOLineRelease Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ChangeCOLineRelease = new Logistics.Customer.ChangeCOLineRelease(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChangeCOLineReleaseExt = timerfactory.Create<Logistics.Customer.IChangeCOLineRelease>(_ChangeCOLineRelease);
			
			return iChangeCOLineReleaseExt;
		}
	}
}
