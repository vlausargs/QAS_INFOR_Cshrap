//PROJECT NAME: CSICustomer
//CLASS NAME: LcrValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class LcrValidFactory
	{
		public ILcrValid Create(IApplicationDB appDB)
		{
			var _LcrValid = new Logistics.Customer.LcrValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLcrValidExt = timerfactory.Create<Logistics.Customer.ILcrValid>(_LcrValid);
			
			return iLcrValidExt;
		}
	}
}
