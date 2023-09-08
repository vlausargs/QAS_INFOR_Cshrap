//PROJECT NAME: Logistics
//CLASS NAME: UpdateCoitemFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class UpdateCoitemFactory
	{
		public IUpdateCoitem Create(IApplicationDB appDB)
		{
			var _UpdateCoitem = new Logistics.Customer.UpdateCoitem(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateCoitemExt = timerfactory.Create<Logistics.Customer.IUpdateCoitem>(_UpdateCoitem);
			
			return iUpdateCoitemExt;
		}
	}
}
