//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCITotalAmtChangedFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCITotalAmtChangedFactory
	{
		public IPortal_CCITotalAmtChanged Create(IApplicationDB appDB)
		{
			var _Portal_CCITotalAmtChanged = new Finance.CreditCard.Portal_CCITotalAmtChanged(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCITotalAmtChangedExt = timerfactory.Create<Finance.CreditCard.IPortal_CCITotalAmtChanged>(_Portal_CCITotalAmtChanged);
			
			return iPortal_CCITotalAmtChangedExt;
		}
	}
}
