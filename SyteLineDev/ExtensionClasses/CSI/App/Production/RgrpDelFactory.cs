//PROJECT NAME: Production
//CLASS NAME: RgrpDelFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class RgrpDelFactory
	{
		public IRgrpDel Create(IApplicationDB appDB)
		{
			var _RgrpDel = new Production.RgrpDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRgrpDelExt = timerfactory.Create<Production.IRgrpDel>(_RgrpDel);
			
			return iRgrpDelExt;
		}
	}
}
