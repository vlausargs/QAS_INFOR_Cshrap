//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCICalcBalFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCICalcBalFactory
	{
		public IPortal_CCICalcBal Create(IApplicationDB appDB)
		{
			var _Portal_CCICalcBal = new Finance.CreditCard.Portal_CCICalcBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCICalcBalExt = timerfactory.Create<Finance.CreditCard.IPortal_CCICalcBal>(_Portal_CCICalcBal);
			
			return iPortal_CCICalcBalExt;
		}
	}
}
