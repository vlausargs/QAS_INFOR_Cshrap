//PROJECT NAME: CSICustomer
//CLASS NAME: DisplayRMAWarningMsgFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DisplayRMAWarningMsgFactory
	{
		public IDisplayRMAWarningMsg Create(IApplicationDB appDB)
		{
			var _DisplayRMAWarningMsg = new Logistics.Customer.DisplayRMAWarningMsg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDisplayRMAWarningMsgExt = timerfactory.Create<Logistics.Customer.IDisplayRMAWarningMsg>(_DisplayRMAWarningMsg);
			
			return iDisplayRMAWarningMsgExt;
		}
	}
}
