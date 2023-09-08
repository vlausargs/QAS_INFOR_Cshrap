//PROJECT NAME: Logistics
//CLASS NAME: RmaReplCoLineFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplCoLineFactory
	{
		public IRmaReplCoLine Create(IApplicationDB appDB)
		{
			var _RmaReplCoLine = new Logistics.Customer.RmaReplCoLine(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReplCoLineExt = timerfactory.Create<Logistics.Customer.IRmaReplCoLine>(_RmaReplCoLine);
			
			return iRmaReplCoLineExt;
		}
	}
}
