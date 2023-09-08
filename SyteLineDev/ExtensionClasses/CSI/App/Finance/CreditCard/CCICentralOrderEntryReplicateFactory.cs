//PROJECT NAME: CSICCI
//CLASS NAME: CCICentralOrderEntryReplicateFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class CCICentralOrderEntryReplicateFactory
	{
		public ICCICentralOrderEntryReplicate Create(IApplicationDB appDB)
		{
			var _CCICentralOrderEntryReplicate = new Finance.CreditCard.CCICentralOrderEntryReplicate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCCICentralOrderEntryReplicateExt = timerfactory.Create<Finance.CreditCard.ICCICentralOrderEntryReplicate>(_CCICentralOrderEntryReplicate);
			
			return iCCICentralOrderEntryReplicateExt;
		}
	}
}
