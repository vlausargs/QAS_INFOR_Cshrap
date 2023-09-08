//PROJECT NAME: CSICustomer
//CLASS NAME: CheckDelPickFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CheckDelPickFactory
	{
		public ICheckDelPick Create(IApplicationDB appDB)
		{
			var _CheckDelPick = new Logistics.Customer.CheckDelPick(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckDelPickExt = timerfactory.Create<Logistics.Customer.ICheckDelPick>(_CheckDelPick);
			
			return iCheckDelPickExt;
		}
	}
}
