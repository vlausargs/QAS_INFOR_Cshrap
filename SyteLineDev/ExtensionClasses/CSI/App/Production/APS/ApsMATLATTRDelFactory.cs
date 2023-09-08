//PROJECT NAME: Production
//CLASS NAME: ApsMATLATTRDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLATTRDelFactory
	{
		public IApsMATLATTRDel Create(IApplicationDB appDB)
		{
			var _ApsMATLATTRDel = new Production.APS.ApsMATLATTRDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLATTRDelExt = timerfactory.Create<Production.APS.IApsMATLATTRDel>(_ApsMATLATTRDel);
			
			return iApsMATLATTRDelExt;
		}
	}
}
