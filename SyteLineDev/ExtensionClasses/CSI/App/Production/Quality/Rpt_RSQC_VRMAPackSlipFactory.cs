//PROJECT NAME: Production
//CLASS NAME: Rpt_RSQC_VRMAPackSlipFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class Rpt_RSQC_VRMAPackSlipFactory
	{
		public IRpt_RSQC_VRMAPackSlip Create(IApplicationDB appDB)
		{
			var _Rpt_RSQC_VRMAPackSlip = new Production.Quality.Rpt_RSQC_VRMAPackSlip(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RSQC_VRMAPackSlipExt = timerfactory.Create<Production.Quality.IRpt_RSQC_VRMAPackSlip>(_Rpt_RSQC_VRMAPackSlip);
			
			return iRpt_RSQC_VRMAPackSlipExt;
		}
	}
}
