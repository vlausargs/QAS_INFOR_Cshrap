//PROJECT NAME: CSICodes
//CLASS NAME: GetInvAdjAcctUnitAccessFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetInvAdjAcctUnitAccessFactory
	{
		public IGetInvAdjAcctUnitAccess Create(IApplicationDB appDB)
		{
			var _GetInvAdjAcctUnitAccess = new Codes.GetInvAdjAcctUnitAccess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetInvAdjAcctUnitAccessExt = timerfactory.Create<Codes.IGetInvAdjAcctUnitAccess>(_GetInvAdjAcctUnitAccess);
			
			return iGetInvAdjAcctUnitAccessExt;
		}
	}
}
