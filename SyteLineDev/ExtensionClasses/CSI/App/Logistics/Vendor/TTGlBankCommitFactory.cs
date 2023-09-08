//PROJECT NAME: CSIVendor
//CLASS NAME: TTGlBankCommitFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TTGlBankCommitFactory
	{
		public ITTGlBankCommit Create(IApplicationDB appDB)
		{
			var _TTGlBankCommit = new Logistics.Vendor.TTGlBankCommit(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTGlBankCommitExt = timerfactory.Create<Logistics.Vendor.ITTGlBankCommit>(_TTGlBankCommit);
			
			return iTTGlBankCommitExt;
		}
	}
}
