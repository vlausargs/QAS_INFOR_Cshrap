//PROJECT NAME: Logistics
//CLASS NAME: RmaItemChangeCoitemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaItemChangeCoitemFactory
	{
		public IRmaItemChangeCoitem Create(IApplicationDB appDB)
		{
			var _RmaItemChangeCoitem = new Logistics.Customer.RmaItemChangeCoitem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaItemChangeCoitemExt = timerfactory.Create<Logistics.Customer.IRmaItemChangeCoitem>(_RmaItemChangeCoitem);
			
			return iRmaItemChangeCoitemExt;
		}
	}
}
