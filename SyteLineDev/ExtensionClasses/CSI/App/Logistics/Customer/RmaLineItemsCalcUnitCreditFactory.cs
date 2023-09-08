//PROJECT NAME: CSICustomer
//CLASS NAME: RmaLineItemsCalcUnitCreditFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaLineItemsCalcUnitCreditFactory
	{
		public IRmaLineItemsCalcUnitCredit Create(IApplicationDB appDB)
		{
			var _RmaLineItemsCalcUnitCredit = new Logistics.Customer.RmaLineItemsCalcUnitCredit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaLineItemsCalcUnitCreditExt = timerfactory.Create<Logistics.Customer.IRmaLineItemsCalcUnitCredit>(_RmaLineItemsCalcUnitCredit);
			
			return iRmaLineItemsCalcUnitCreditExt;
		}
	}
}
