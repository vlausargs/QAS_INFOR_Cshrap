//PROJECT NAME: Codes
//CLASS NAME: ReasonGetInvAdjAcctFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class ReasonGetInvAdjAcctFactory
	{
		public IReasonGetInvAdjAcct Create(IApplicationDB appDB)
		{
			var _ReasonGetInvAdjAcct = new Codes.ReasonGetInvAdjAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReasonGetInvAdjAcctExt = timerfactory.Create<Codes.IReasonGetInvAdjAcct>(_ReasonGetInvAdjAcct);
			
			return iReasonGetInvAdjAcctExt;
		}
	}
}
