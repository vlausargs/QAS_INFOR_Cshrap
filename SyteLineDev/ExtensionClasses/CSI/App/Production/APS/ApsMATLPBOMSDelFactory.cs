//PROJECT NAME: Production
//CLASS NAME: ApsMATLPBOMSDelFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLPBOMSDelFactory
	{
		public IApsMATLPBOMSDel Create(IApplicationDB appDB)
		{
			var _ApsMATLPBOMSDel = new Production.APS.ApsMATLPBOMSDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLPBOMSDelExt = timerfactory.Create<Production.APS.IApsMATLPBOMSDel>(_ApsMATLPBOMSDel);
			
			return iApsMATLPBOMSDelExt;
		}
	}
}
