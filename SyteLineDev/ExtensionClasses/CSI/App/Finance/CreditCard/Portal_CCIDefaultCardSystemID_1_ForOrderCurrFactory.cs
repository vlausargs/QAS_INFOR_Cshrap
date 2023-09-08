//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCIDefaultCardSystemID_1_ForOrderCurrFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCIDefaultCardSystemID_1_ForOrderCurrFactory
	{
		public IPortal_CCIDefaultCardSystemID_1_ForOrderCurr Create(IApplicationDB appDB)
		{
			var _Portal_CCIDefaultCardSystemID_1_ForOrderCurr = new Finance.CreditCard.Portal_CCIDefaultCardSystemID_1_ForOrderCurr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCIDefaultCardSystemID_1_ForOrderCurrExt = timerfactory.Create<Finance.CreditCard.IPortal_CCIDefaultCardSystemID_1_ForOrderCurr>(_Portal_CCIDefaultCardSystemID_1_ForOrderCurr);
			
			return iPortal_CCIDefaultCardSystemID_1_ForOrderCurrExt;
		}
	}
}
