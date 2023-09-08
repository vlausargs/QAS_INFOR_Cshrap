//PROJECT NAME: Production
//CLASS NAME: ApsMATLPBOMSSaveFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLPBOMSSaveFactory
	{
		public IApsMATLPBOMSSave Create(IApplicationDB appDB)
		{
			var _ApsMATLPBOMSSave = new Production.APS.ApsMATLPBOMSSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLPBOMSSaveExt = timerfactory.Create<Production.APS.IApsMATLPBOMSSave>(_ApsMATLPBOMSSave);
			
			return iApsMATLPBOMSSaveExt;
		}
	}
}
