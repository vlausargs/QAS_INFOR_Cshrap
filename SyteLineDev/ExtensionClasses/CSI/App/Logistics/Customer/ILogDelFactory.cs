//PROJECT NAME: CSICustomer
//CLASS NAME: ILogDelFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ILogDelFactory
	{
		public IILogDel Create(IApplicationDB appDB)
		{
			var _ILogDel = new Logistics.Customer.ILogDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iILogDelExt = timerfactory.Create<Logistics.Customer.IILogDel>(_ILogDel);
			
			return iILogDelExt;
		}
	}
}
