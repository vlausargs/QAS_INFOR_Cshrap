//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtLeaveCustAmtFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtLeaveCustAmtFactory
	{
		public IArpmtLeaveCustAmt Create(IApplicationDB appDB)
		{
			var _ArpmtLeaveCustAmt = new Logistics.Customer.ArpmtLeaveCustAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtLeaveCustAmtExt = timerfactory.Create<Logistics.Customer.IArpmtLeaveCustAmt>(_ArpmtLeaveCustAmt);
			
			return iArpmtLeaveCustAmtExt;
		}
	}
}
