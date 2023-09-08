//PROJECT NAME: CSIFinance
//CLASS NAME: GlCmprPLastTranFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class GlCmprPLastTranFactory
	{
		public IGlCmprPLastTran Create(IApplicationDB appDB)
		{
			var _GlCmprPLastTran = new Finance.GlCmprPLastTran(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGlCmprPLastTranExt = timerfactory.Create<Finance.IGlCmprPLastTran>(_GlCmprPLastTran);
			
			return iGlCmprPLastTranExt;
		}
	}
}
