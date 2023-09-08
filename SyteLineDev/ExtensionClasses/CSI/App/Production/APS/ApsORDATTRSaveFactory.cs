//PROJECT NAME: Production
//CLASS NAME: ApsORDATTRSaveFactory.cs

using CSI.MG;

namespace CSI.Production.APS
{
	public class ApsORDATTRSaveFactory
	{
		public IApsORDATTRSave Create(IApplicationDB appDB)
		{
			var _ApsORDATTRSave = new Production.APS.ApsORDATTRSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsORDATTRSaveExt = timerfactory.Create<Production.APS.IApsORDATTRSave>(_ApsORDATTRSave);
			
			return iApsORDATTRSaveExt;
		}
	}
}
