//PROJECT NAME: CSICCI
//CLASS NAME: Portal_CCIDefaultCardSystemIDFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class Portal_CCIDefaultCardSystemIDFactory
	{
		public IPortal_CCIDefaultCardSystemID Create(IApplicationDB appDB)
		{
			var _Portal_CCIDefaultCardSystemID = new Finance.CreditCard.Portal_CCIDefaultCardSystemID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortal_CCIDefaultCardSystemIDExt = timerfactory.Create<Finance.CreditCard.IPortal_CCIDefaultCardSystemID>(_Portal_CCIDefaultCardSystemID);
			
			return iPortal_CCIDefaultCardSystemIDExt;
		}
	}
}
