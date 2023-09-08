//PROJECT NAME: Production
//CLASS NAME: RgrpMbrsUpdFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class RgrpMbrsUpdFactory
	{
		public IRgrpMbrsUpd Create(IApplicationDB appDB)
		{
			var _RgrpMbrsUpd = new Production.RgrpMbrsUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRgrpMbrsUpdExt = timerfactory.Create<Production.IRgrpMbrsUpd>(_RgrpMbrsUpd);
			
			return iRgrpMbrsUpdExt;
		}
	}
}
