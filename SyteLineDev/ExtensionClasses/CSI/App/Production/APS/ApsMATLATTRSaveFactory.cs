//PROJECT NAME: Production
//CLASS NAME: ApsMATLATTRSaveFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsMATLATTRSaveFactory
	{
		public IApsMATLATTRSave Create(IApplicationDB appDB)
		{
			var _ApsMATLATTRSave = new Production.APS.ApsMATLATTRSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMATLATTRSaveExt = timerfactory.Create<Production.APS.IApsMATLATTRSave>(_ApsMATLATTRSave);
			
			return iApsMATLATTRSaveExt;
		}
	}
}
