//PROJECT NAME: Finance
//CLASS NAME: Portal_SSSCCIProcessCardWrapFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_SSSCCIProcessCardWrapFactory
	{
		public IPortal_SSSCCIProcessCardWrap Create(IApplicationDB appDB)
		{
			var _Portal_SSSCCIProcessCardWrap = new Finance.CreditCard.Portal_SSSCCIProcessCardWrap(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_SSSCCIProcessCardWrapExt = timerfactory.Create<Finance.CreditCard.IPortal_SSSCCIProcessCardWrap>(_Portal_SSSCCIProcessCardWrap);
			
			return iPortal_SSSCCIProcessCardWrapExt;
		}
	}
}
