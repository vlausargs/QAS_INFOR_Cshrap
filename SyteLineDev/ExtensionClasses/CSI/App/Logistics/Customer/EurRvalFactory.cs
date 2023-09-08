//PROJECT NAME: CSICustomer
//CLASS NAME: EurRvalFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EurRvalFactory
	{
		public IEurRval Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _EurRval = new Logistics.Customer.EurRval(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEurRvalExt = timerfactory.Create<Logistics.Customer.IEurRval>(_EurRval);
			
			return iEurRvalExt;
		}
	}
}
