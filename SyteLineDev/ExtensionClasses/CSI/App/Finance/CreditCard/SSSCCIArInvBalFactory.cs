//PROJECT NAME: CSICCI
//CLASS NAME: SSSCCIArInvBalFactory.cs

using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIArInvBalFactory
	{
		public ISSSCCIArInvBal Create(IApplicationDB appDB)
		{
			var _SSSCCIArInvBal = new Finance.CreditCard.SSSCCIArInvBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIArInvBalExt = timerfactory.Create<Finance.CreditCard.ISSSCCIArInvBal>(_SSSCCIArInvBal);
			
			return iSSSCCIArInvBalExt;
		}
	}
}
