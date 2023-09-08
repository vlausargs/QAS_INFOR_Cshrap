//PROJECT NAME: CSICustomer
//CLASS NAME: CoDiscAmountValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoDiscAmountValidFactory
	{
		public ICoDiscAmountValid Create(IApplicationDB appDB)
		{
			var _CoDiscAmountValid = new Logistics.Customer.CoDiscAmountValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoDiscAmountValidExt = timerfactory.Create<Logistics.Customer.ICoDiscAmountValid>(_CoDiscAmountValid);
			
			return iCoDiscAmountValidExt;
		}
	}
}
