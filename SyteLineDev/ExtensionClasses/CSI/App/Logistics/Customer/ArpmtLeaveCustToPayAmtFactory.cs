//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveCustToPayAmtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtLeaveCustToPayAmtFactory
	{
		public IArpmtLeaveCustToPayAmt Create(IApplicationDB appDB)
		{
			var _ArpmtLeaveCustToPayAmt = new Logistics.Customer.ArpmtLeaveCustToPayAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtLeaveCustToPayAmtExt = timerfactory.Create<Logistics.Customer.IArpmtLeaveCustToPayAmt>(_ArpmtLeaveCustToPayAmt);
			
			return iArpmtLeaveCustToPayAmtExt;
		}
	}
}
