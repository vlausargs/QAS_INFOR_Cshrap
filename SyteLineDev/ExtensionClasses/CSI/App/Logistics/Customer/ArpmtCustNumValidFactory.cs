//PROJECT NAME: CSICustomer
//CLASS NAME: ArpmtCustNumValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ArpmtCustNumValidFactory
	{
		public IArpmtCustNumValid Create(IApplicationDB appDB)
		{
			var _ArpmtCustNumValid = new Logistics.Customer.ArpmtCustNumValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArpmtCustNumValidExt = timerfactory.Create<Logistics.Customer.IArpmtCustNumValid>(_ArpmtCustNumValid);
			
			return iArpmtCustNumValidExt;
		}
	}
}
