//PROJECT NAME: CSICustomer
//CLASS NAME: CheckCustExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckCustExistsFactory
	{
		public ICheckCustExists Create(IApplicationDB appDB)
		{
			var _CheckCustExists = new Customer.CheckCustExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckCustExistsExt = timerfactory.Create<Customer.ICheckCustExists>(_CheckCustExists);
			
			return iCheckCustExistsExt;
		}
	}
}
