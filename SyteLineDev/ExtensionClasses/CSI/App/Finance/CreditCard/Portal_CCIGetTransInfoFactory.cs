//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCIGetTransInfoFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCIGetTransInfoFactory
	{
		public IPortal_CCIGetTransInfo Create(IApplicationDB appDB)
		{
			var _Portal_CCIGetTransInfo = new Finance.CreditCard.Portal_CCIGetTransInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCIGetTransInfoExt = timerfactory.Create<Finance.CreditCard.IPortal_CCIGetTransInfo>(_Portal_CCIGetTransInfo);
			
			return iPortal_CCIGetTransInfoExt;
		}
	}
}
