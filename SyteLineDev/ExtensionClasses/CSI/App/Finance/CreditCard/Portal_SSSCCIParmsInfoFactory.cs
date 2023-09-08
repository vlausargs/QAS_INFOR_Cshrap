//PROJECT NAME: CSICCI
//CLASS NAME: Portal_SSSCCIParmsInfoFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_SSSCCIParmsInfoFactory
	{
		public IPortal_SSSCCIParmsInfo Create(IApplicationDB appDB)
		{
			var _Portal_SSSCCIParmsInfo = new Finance.CreditCard.Portal_SSSCCIParmsInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_SSSCCIParmsInfoExt = timerfactory.Create<Finance.CreditCard.IPortal_SSSCCIParmsInfo>(_Portal_SSSCCIParmsInfo);
			
			return iPortal_SSSCCIParmsInfoExt;
		}
	}
}
