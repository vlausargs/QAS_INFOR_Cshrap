//PROJECT NAME: Production
//CLASS NAME: ApsMATLPPSSaveFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLPPSSaveFactory
	{
		public IApsMATLPPSSave Create(IApplicationDB appDB)
		{
			var _ApsMATLPPSSave = new Production.APS.ApsMATLPPSSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLPPSSaveExt = timerfactory.Create<Production.APS.IApsMATLPPSSave>(_ApsMATLPPSSave);
			
			return iApsMATLPPSSaveExt;
		}
	}
}
