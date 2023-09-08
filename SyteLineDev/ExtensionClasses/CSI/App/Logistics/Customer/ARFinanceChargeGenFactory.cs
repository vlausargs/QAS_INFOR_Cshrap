//PROJECT NAME: CSICustomer
//CLASS NAME: ARFinanceChargeGenFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARFinanceChargeGenFactory
	{
		public IARFinanceChargeGen Create(IApplicationDB appDB)
		{
			var _ARFinanceChargeGen = new Logistics.Customer.ARFinanceChargeGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinanceChargeGenExt = timerfactory.Create<Logistics.Customer.IARFinanceChargeGen>(_ARFinanceChargeGen);
			
			return iARFinanceChargeGenExt;
		}
	}
}
