//PROJECT NAME: CSICustomer
//CLASS NAME: RMA10RPreCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RMA10RPreCheckFactory
	{
		public IRMA10RPreCheck Create(IApplicationDB appDB)
		{
			var _RMA10RPreCheck = new Logistics.Customer.RMA10RPreCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRMA10RPreCheckExt = timerfactory.Create<Logistics.Customer.IRMA10RPreCheck>(_RMA10RPreCheck);
			
			return iRMA10RPreCheckExt;
		}
	}
}
