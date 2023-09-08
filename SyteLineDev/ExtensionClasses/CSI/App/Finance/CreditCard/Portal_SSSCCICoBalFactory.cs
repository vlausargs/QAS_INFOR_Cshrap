//PROJECT NAME: Finance
//CLASS NAME: Portal_SSSCCICoBalFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_SSSCCICoBalFactory
	{
		public IPortal_SSSCCICoBal Create(IApplicationDB appDB)
		{
			var _Portal_SSSCCICoBal = new Finance.CreditCard.Portal_SSSCCICoBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_SSSCCICoBalExt = timerfactory.Create<Finance.CreditCard.IPortal_SSSCCICoBal>(_Portal_SSSCCICoBal);
			
			return iPortal_SSSCCICoBalExt;
		}
	}
}
