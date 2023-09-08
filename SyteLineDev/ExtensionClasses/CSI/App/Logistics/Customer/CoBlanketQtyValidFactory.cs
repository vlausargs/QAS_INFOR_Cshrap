//PROJECT NAME: CSICustomer
//CLASS NAME: CoBlanketQtyValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoBlanketQtyValidFactory
	{
		public ICoBlanketQtyValid Create(IApplicationDB appDB)
		{
			var _CoBlanketQtyValid = new Logistics.Customer.CoBlanketQtyValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoBlanketQtyValidExt = timerfactory.Create<Logistics.Customer.ICoBlanketQtyValid>(_CoBlanketQtyValid);
			
			return iCoBlanketQtyValidExt;
		}
	}
}
