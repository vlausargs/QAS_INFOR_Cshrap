//PROJECT NAME: Logistics
//CLASS NAME: RmaReplCoNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplCoNumFactory
	{
		public IRmaReplCoNum Create(IApplicationDB appDB)
		{
			var _RmaReplCoNum = new Logistics.Customer.RmaReplCoNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReplCoNumExt = timerfactory.Create<Logistics.Customer.IRmaReplCoNum>(_RmaReplCoNum);
			
			return iRmaReplCoNumExt;
		}
	}
}
