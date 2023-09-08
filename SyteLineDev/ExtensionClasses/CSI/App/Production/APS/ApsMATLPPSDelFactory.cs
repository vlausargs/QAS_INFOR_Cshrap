//PROJECT NAME: Production
//CLASS NAME: ApsMATLPPSDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLPPSDelFactory
	{
		public IApsMATLPPSDel Create(IApplicationDB appDB)
		{
			var _ApsMATLPPSDel = new Production.APS.ApsMATLPPSDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLPPSDelExt = timerfactory.Create<Production.APS.IApsMATLPPSDel>(_ApsMATLPPSDel);
			
			return iApsMATLPPSDelExt;
		}
	}
}
