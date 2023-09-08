//PROJECT NAME: Production
//CLASS NAME: RgrpMbrsDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class RgrpMbrsDelFactory
	{
		public IRgrpMbrsDel Create(IApplicationDB appDB)
		{
			var _RgrpMbrsDel = new Production.APS.RgrpMbrsDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRgrpMbrsDelExt = timerfactory.Create<Production.APS.IRgrpMbrsDel>(_RgrpMbrsDel);
			
			return iRgrpMbrsDelExt;
		}
	}
}
