//PROJECT NAME: Production
//CLASS NAME: RgrpMbrsInsFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class RgrpMbrsInsFactory
	{
		public IRgrpMbrsIns Create(IApplicationDB appDB)
		{
			var _RgrpMbrsIns = new Production.APS.RgrpMbrsIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRgrpMbrsInsExt = timerfactory.Create<Production.APS.IRgrpMbrsIns>(_RgrpMbrsIns);
			
			return iRgrpMbrsInsExt;
		}
	}
}
