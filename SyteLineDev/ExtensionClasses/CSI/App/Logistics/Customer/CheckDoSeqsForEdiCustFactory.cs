//PROJECT NAME: CSICustomer
//CLASS NAME: CheckDoSeqsForEdiCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckDoSeqsForEdiCustFactory
	{
		public ICheckDoSeqsForEdiCust Create(IApplicationDB appDB)
		{
			var _CheckDoSeqsForEdiCust = new Logistics.Customer.CheckDoSeqsForEdiCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckDoSeqsForEdiCustExt = timerfactory.Create<Logistics.Customer.ICheckDoSeqsForEdiCust>(_CheckDoSeqsForEdiCust);
			
			return iCheckDoSeqsForEdiCustExt;
		}
	}
}
