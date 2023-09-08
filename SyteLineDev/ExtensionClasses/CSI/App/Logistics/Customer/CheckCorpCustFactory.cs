//PROJECT NAME: CSICustomer
//CLASS NAME: CheckCorpCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckCorpCustFactory
	{
		public ICheckCorpCust Create(IApplicationDB appDB)
		{
			var _CheckCorpCust = new Logistics.Customer.CheckCorpCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckCorpCustExt = timerfactory.Create<Logistics.Customer.ICheckCorpCust>(_CheckCorpCust);
			
			return iCheckCorpCustExt;
		}
	}
}
